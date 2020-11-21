using Microsoft.AspNetCore.Mvc.Rendering;
using NetChallange.Data.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace NetChallange.Web.Core
{
    public static class DataManager
    {
        public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<Address> list)
        {
            return list.Select(p => new SelectListItem
            {
                Text = p.Street,
                Value = p.Id.ToString()
            });
        }
        public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<Company> list)
        {
            return list.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            });
        }

        public static IEnumerable<SelectListItem> ToSelectList(this IEnumerable<Contact> list)
        {
            return list.Select(p => new SelectListItem
            {
                Text = p.FirstName + " "+p.LastName ,
                Value = p.Id.ToString()
            });
        }

    }
}
