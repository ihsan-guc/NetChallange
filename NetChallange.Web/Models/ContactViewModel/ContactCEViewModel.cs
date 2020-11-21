using Microsoft.AspNetCore.Mvc.Rendering;
using NetChallange.Data.Domain.Entities;
using System;
using System.Collections.Generic;

namespace NetChallange.Web.Models.ContactViewModel
{
    public class ContactCEViewModel: BaseViewModel
    {
        public Guid AddressId { get; set; }
        public Guid CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
        public List<SelectListItem> Companies { get; set; }
        public List<SelectListItem> Addresses{ get; set; }
    }
}
