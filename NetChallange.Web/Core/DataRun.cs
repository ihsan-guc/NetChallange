using NetChallange.DAL;
using NetChallange.DAL.Abstract;
using NetChallange.Data.Domain.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetChallange.Web.Core
{
    public class DataRun
    {
        public NetChallangeContext Context;
        public DataRun(NetChallangeContext _context)
        {
            Context = _context;
        }
        public async void BasicDataRun()
        {
            using (HttpClient client = new HttpClient())
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
                    Context.Addresses.AddRange(addressList);
                    Context.Companies.AddRange(companyList);
                    Context.Contacts.AddRange(contactList);
                    Context.SaveChanges();
                }
            }
        }
    }
}
