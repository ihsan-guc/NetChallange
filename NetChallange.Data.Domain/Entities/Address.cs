using System;

namespace NetChallange.Data.Domain.Entities
{
    public class Address : BaseGuidEntity
    {
        public Guid? CompanyId { get; set; }
        public Guid? ContactId { get; set; }
        public string Street { get; set; }
        public string StreetName { get; set; }
        public string BuildingNumber { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }
        public string CountyCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Company Company{ get; set; }
    }
}
