using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NetChallange.Web.Models.AddressViewModel;
using System.Linq;
using X.PagedList;
using NetChallange.Web.Core;
using NetChallange.Data.Domain.Entities;
using System;

namespace NetChallange.Web.Controllers
{
    [Route("Address")]
    public class AddressController : BaseController
    {
        [Route("Index")]
        public IActionResult Index(int? page)
        {
            var pagenumber = page ?? 1;
            int pagesize = 3;
            var model = new AddressHomeViewModel()
            {
                PagedList = UnitOfWork.AddressRepository.GetQueryable().ToPagedList(pagenumber, pagesize)
            };
            return View(model);
        }
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed(AddressCEViewModel model)
        {
            if (ModelState.IsValid)
            {
                var address = new Address()
                {
                    Id = Guid.NewGuid(),
                    Street = model.Street,
                    StreetName = model.StreetName,
                    Country = model.Country,
                    CountyCode = model.CountyCode,
                    City = model.City,
                    BuildingNumber = model.BuildingNumber,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    Zipcode = model.Zipcode,
                };
                UnitOfWork.AddressRepository.Add(address);
                UnitOfWork.Commit();
                return RedirectToAction("Index", "Address");
            }
            return View();
        }
        [Route("Edit")]
        public IActionResult Edit(Guid id)
        {
            var model = UnitOfWork.AddressRepository.GetById(id);
            var address = new AddressCEViewModel()
            {
                Id = model.Id,
                Street = model.Street,
                StreetName = model.StreetName,
                Country = model.Country,
                CountyCode = model.CountyCode,
                City = model.City,
                BuildingNumber = model.BuildingNumber,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Zipcode = model.Zipcode,
            };
            return View(address);
        }
        [HttpPost]
        [Route("Edit")]
        public IActionResult EditConfirmed(AddressCEViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = UnitOfWork.AddressRepository.GetById(model.Id);
                entity.Street = model.Street;
                entity.StreetName = model.StreetName;
                entity.Country = model.Country;
                entity.CountyCode = model.CountyCode;
                entity.City = model.City;
                entity.BuildingNumber = model.BuildingNumber;
                entity.Latitude = model.Latitude;
                entity.Longitude = model.Longitude;
                entity.Zipcode = model.Zipcode;
                UnitOfWork.Commit();
                return RedirectToAction("Index", "Address");
            }
            return View();
        }
        [Route("Details")]
        public IActionResult Details(Guid id)
        {
            var entity = UnitOfWork.AddressRepository.GetById(id);
            return View(entity);
        }
        [Route("AddressDelete")]
        public IActionResult AddressDelete(Guid id)
        {
            var entity = UnitOfWork.AddressRepository.GetById(id);
            return View(entity);
        }
        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var entity = UnitOfWork.AddressRepository.GetById(id);
            var company = UnitOfWork.CompanyRepository.GetById(entity.Id);
            if (company != null)
                company.Addresses.Remove(entity);
            UnitOfWork.AddressRepository.Remove(entity);
            UnitOfWork.Commit();
            return RedirectToAction("Index", "Address");
        }
    }
}
