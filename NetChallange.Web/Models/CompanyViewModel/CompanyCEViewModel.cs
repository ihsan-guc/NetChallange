using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace NetChallange.Web.Models.CompanyViewModel
{
    public class CompanyCEViewModel : BaseViewModel
    {
        public Guid ContactId { get; set; }
        public Guid AddressId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Vat { get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
        public List<SelectListItem> ContactList{ get; set; }
        public List<SelectListItem> AddressList { get; set; }
    }
}
