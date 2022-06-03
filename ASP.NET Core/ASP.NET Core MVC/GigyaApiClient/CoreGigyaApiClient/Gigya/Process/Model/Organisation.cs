namespace Gigya.Process.Model
{
    public class Organisation
    {
        public string Id { set; get; }

        public string Country { get; set; }

        public string RegionCode { get; set; }

        public string ProvinceCode { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string BusinessName { get; set; }

        public string BusinessClass { get; set; }

        public string BusinessPhoneNumber { get; set; }

        public string PostalCode { get; set; }

        public string Oid { set; get; }
    }
}
