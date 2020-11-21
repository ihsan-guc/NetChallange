using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetChallange.DAL;
using NetChallange.DAL.Abstract;
using NetChallange.DAL.Concrete;
using NetChallange.Data.Domain.Entities;
using NetChallange.Web.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace NetChallange.Web
{
    public class Startup
    {
        static readonly HttpClient client = new HttpClient();

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            var netChallangeDb = Configuration.GetConnectionString("NetChallangeDb");
            services.AddDbContext<NetChallangeContext>(opt => opt.UseSqlServer(netChallangeDb));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, NetChallangeContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            var isdatabase = db.Database.EnsureCreated();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        public async void PullData(NetChallangeContext db)
        {
            HttpResponseMessage response = await client.GetAsync("https://fakerapi.it/api/v1/companies?_quantity=1");
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                JObject Jsonparse = JObject.Parse(result);
                JArray jsonList = (JArray)Jsonparse["data"];
                List<Address> addressList = new List<Address>();
                List<Company> companyList = new List<Company>();
                List<Contact> contactList = new List<Contact>();
                foreach (var json in jsonList.ToList())
                {
                    var company = new Company()
                    {
                        Id = Guid.NewGuid(),
                        Name = json["name"].ToString(),
                        Email = json["email"].ToString(),
                        Vat = json["vat"].ToString(),
                        Phone = json["phone"].ToString(),
                        Country = json["country"].ToString(),
                        Website = json["website"].ToString(),
                        Image = json["image"].ToString(),
                    };
                    foreach (var address in json["addresses"].ToList())
                    {
                        var model = new Address()
                        {
                            Id = Guid.NewGuid(),
                            Street = address["street"].ToString(),
                            StreetName = address["streetName"].ToString(),
                            BuildingNumber = address["buildingNumber"].ToString(),
                            City = address["city"].ToString(),
                            Zipcode = address["zipcode"].ToString(),
                            Country = address["country"].ToString(),
                            CountyCode = address["county_code"].ToString(),
                            Latitude = address["latitude"].ToString(),
                            Longitude = address["longitude"].ToString(),
                        };
                        model.CompanyId = company.Id;
                        model.Company = company;
                        addressList.Add(model);
                        company.Addresses.Add(model);
                    }
                    var contact = new Contact()
                    {
                        Id = Guid.NewGuid(),
                        FirstName = json["contact"]["firstname"].ToString(),
                        LastName = json["contact"]["lastname"].ToString(),
                        Email = json["contact"]["email"].ToString(),
                        Phone = json["contact"]["phone"].ToString(),
                        Birthday = json["contact"]["birthday"].ToString(),
                        Gender = json["contact"]["gender"].ToString(),
                        Image = json["contact"]["image"].ToString(),
                        Website = json["contact"]["website"].ToString(),
                    };
                    var contactAddress = new Address()
                    {
                        Id = Guid.NewGuid(),
                        Street = json["contact"]["address"]["street"].ToString(),
                        StreetName = json["contact"]["address"]["streetName"].ToString(),
                        BuildingNumber = json["contact"]["address"]["buildingNumber"].ToString(),
                        City = json["contact"]["address"]["city"].ToString(),
                        Zipcode = json["contact"]["address"]["zipcode"].ToString(),
                        Country = json["contact"]["address"]["country"].ToString(),
                        CountyCode = json["contact"]["address"]["county_code"].ToString(),
                        Latitude = json["contact"]["address"]["latitude"].ToString(),
                        Longitude = json["contact"]["address"]["longitude"].ToString(),
                    };
                    contact.Address = contactAddress;
                    company.Contact = contact;
                    company.ContactId = contact.Id;
                    contact.Company = company;
                    contact.CompanyId = company.Id;
                    companyList.Add(company);
                    contactList.Add(contact);
                }
                await db.Addresses.AddRangeAsync(addressList);
                await db.Companies.AddRangeAsync(companyList);
                await db.Contacts.AddRangeAsync(contactList);
                await db.SaveChangesAsync();
            }
        }
    }
}
