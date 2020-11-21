using Microsoft.AspNetCore.Mvc;
using NetChallange.Data.Domain.Entities;
using NetChallange.Web.Core;
using NetChallange.Web.Models.ContactViewModel;
using System;
using System.Linq;
using X.PagedList;

namespace NetChallange.Web.Controllers
{
    [Route("Contact")]
    public class ContactController :BaseController
    {
        [Route("Index")]
        public IActionResult Index(int? page)
        {
            var pagenumber = page ?? 1;
            int pagesize = 3;
            var model = new ContactHomeViewModel()
            {
                PagedList = UnitOfWork.ContactRepository.GetQueryable().ToPagedList(pagenumber, pagesize)
            };
            return View(model);
        }
        [Route("Create")]
        public IActionResult Create()
        {
            var model = new ContactCEViewModel()
            {
                Addresses = DataManager.ToSelectList(UnitOfWork.AddressRepository.GetQueryable().Where(p => p.Contact == null)).ToList(),
            };
            return View(model);
        }
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult CreateConfirmed(ContactCEViewModel model)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact()
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Gender = model.Gender,
                    Birthday = model.Birthday,
                    Website = model.Website,
                    Image = model.Image,
                    Phone = model.Phone,
                    AddressId = model.AddressId,
                };
                UnitOfWork.ContactRepository.Add(contact);
                UnitOfWork.Commit();
                return RedirectToAction("Index", "Contact");
            }
            return View();
        }
        [Route("Edit")]
        public IActionResult Edit(Guid id)
        {
            var model = UnitOfWork.ContactRepository.GetById(id);
            var contact = new ContactCEViewModel()
            {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Gender = model.Gender,
                Birthday = model.Birthday,
                Website = model.Website,
                Image = model.Image,
                Phone = model.Phone,
                Addresses = DataManager.ToSelectList(UnitOfWork.AddressRepository.GetList()).ToList(),
            };
            return View(contact);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult EditConfirmed(ContactCEViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = UnitOfWork.ContactRepository.GetById(model.Id);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Email = model.Email;
                entity.Gender = model.Gender;
                entity.Birthday = model.Birthday;
                entity.Website = model.Website;
                entity.Image = model.Image;
                entity.Phone = model.Phone;
                entity.AddressId = model.AddressId;
                UnitOfWork.Commit();
                return RedirectToAction("Index", "Contact");
            }
            return View();
        }

        [Route("Details")]
        public IActionResult Details(Guid id)
        {
            var entity = UnitOfWork.ContactRepository.GetById(id);
            var company = UnitOfWork.CompanyRepository.GetQueryable().Where(p=>p.Id == entity.CompanyId).FirstOrDefault();
            entity.Company = company;
            return View(entity);
        }

        [Route("ContactDelete")]
        public IActionResult ContactDelete(Guid id)
        {
            var entity = UnitOfWork.ContactRepository.GetById(id);
            var company = UnitOfWork.CompanyRepository.GetQueryable().Where(p => p.Id == entity.CompanyId).FirstOrDefault();
            entity.Company = company;
            return View(entity);
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var entity = UnitOfWork.ContactRepository.GetById(id);
            var company = UnitOfWork.CompanyRepository.GetById((Guid)entity.CompanyId);
            if (company != null)
                company.ContactId = null;
            UnitOfWork.ContactRepository.Remove(entity);
            UnitOfWork.Commit();
            return RedirectToAction("Index", "Contact");
        }

    }
}
