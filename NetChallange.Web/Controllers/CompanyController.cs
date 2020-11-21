using Microsoft.AspNetCore.Mvc;
using NetChallange.Data.Domain.Entities;
using NetChallange.Web.Core;
using NetChallange.Web.Models.CompanyViewModel;
using NetChallange.Web.Models.ContactViewModel;
using System;
using System.Linq;
using X.PagedList;

namespace NetChallange.Web.Controllers
{
    [Route("Company")]
    public class CompanyController : BaseController
    {
        [Route("Index")]
        public IActionResult Index(int? page)
        {
            var pagenumber = page ?? 1;
            int pagesize = 3;
            var model = new CompanyHomeViewModel()
            {
                PagedList = UnitOfWork.CompanyRepository.GetQueryable().ToPagedList(pagenumber, pagesize)
            };
            return View(model);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            var model = new CompanyCEViewModel()
            {
                AddressList = DataManager.ToSelectList(UnitOfWork.AddressRepository.GetQueryable().Where(p => p.Company == null)).ToList(),
                ContactList = DataManager.ToSelectList(UnitOfWork.ContactRepository.GetQueryable().Where(p => p.CompanyId == null)).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed(CompanyCEViewModel model)
        {
            if (ModelState.IsValid)
            {
                var company = new Company()
                {
                    Id = Guid.NewGuid(),
                    Email = model.Email,
                    Website = model.Website,
                    Image = model.Image,
                    Phone = model.Phone,
                    Name = model.Name,
                    Vat = model.Vat,
                    Country = model.Country,
                };
                var contact = UnitOfWork.ContactRepository.GetById(model.ContactId);
                contact.Company = company;
                contact.CompanyId = company.Id;
                company.Contact = contact;
                company.ContactId = contact.Id;
                UnitOfWork.CompanyRepository.Add(company);
                UnitOfWork.Commit();
                return RedirectToAction("Index", "Company");
            }
            return View();
        }

        [Route("Edit")]
        public IActionResult Edit(Guid id)
        {
            var model = UnitOfWork.CompanyRepository.GetById(id);
            var company = new CompanyCEViewModel()
            {
                Id = Guid.NewGuid(),
                Email = model.Email,
                Website = model.Website,
                Image = model.Image,
                Phone = model.Phone,
                Name = model.Name,
                Vat = model.Vat,
                Country = model.Country,
            };
            company.AddressList = DataManager.ToSelectList(UnitOfWork.AddressRepository.GetQueryable().Where(p => p.Company == null)).ToList();
            company.ContactList = DataManager.ToSelectList(UnitOfWork.ContactRepository.GetQueryable().Where(p => p.CompanyId == null)).ToList();
            return View(company);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult EditConfirmed(CompanyCEViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = UnitOfWork.CompanyRepository.GetById(model.Id);
                entity.Email = model.Email;
                entity.Name = model.Name;
                entity.Vat = model.Vat;
                entity.Country = model.Country;
                entity.Website = model.Website;
                entity.Image = model.Image;
                entity.Phone = model.Phone;
                entity.ContactId = model.ContactId;
                var contact = UnitOfWork.ContactRepository.GetById(model.ContactId);
                contact.Company = entity;
                contact.CompanyId = entity.Id;
                entity.Contact = contact;
                entity.ContactId = contact.Id;
                UnitOfWork.Commit();
                return RedirectToAction("Index", "Company");
            }
            return View();
        }

        [Route("Details")]
        public IActionResult Details(Guid id)
        {
            var entity = UnitOfWork.CompanyRepository.GetById(id);
            return View(entity);
        }

        [Route("CompanyDelete")]
        public IActionResult CompanyDelete(Guid id)
        {
            var entity = UnitOfWork.CompanyRepository.GetById(id);
            return View(entity);
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var entity = UnitOfWork.CompanyRepository.GetById(id);
            var addressList = UnitOfWork.AddressRepository.GetQueryable().Where(p => p.CompanyId == entity.Id).ToList();
            if (addressList != null)
                UnitOfWork.AddressRepository.RemoveRange(addressList);
            UnitOfWork.CompanyRepository.Remove(entity);
            UnitOfWork.Commit();
            return RedirectToAction("Index", "Company");
        }


    }
}
