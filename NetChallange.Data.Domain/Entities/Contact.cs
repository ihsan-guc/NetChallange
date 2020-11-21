using System;

namespace NetChallange.Data.Domain.Entities
{
    public class Contact : BaseGuidEntity
    {
        public Guid? AddressId { get; set; }
        public Guid? CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Birthday { get; set; }
        public string Gender { get; set; }
        public string Website { get; set; }
        public string Image { get; set; }
        public Address Address{ get; set; }
        public Company Company{ get; set; }
    }
}
