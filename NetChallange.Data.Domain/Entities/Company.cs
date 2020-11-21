using System;
using System.Collections.Generic;

namespace NetChallange.Data.Domain.Entities
{
    public class Company : BaseGuidEntity
    {
        public Company()
        {
            Addresses = new HashSet<Address>();
        }
        public Guid? ContactId{ get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Vat{ get; set; }
        public string Phone { get; set; }
        public string Country { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual Contact Contact{ get; set; }
    }
}
