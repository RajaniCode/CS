using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Gigya.Model.Models
{
    [Serializable]
    public class OrganisationBase
    {
        public OrganisationBase() { }

        public int Id { get; set; }

        [StringLength(400)]
        public string Name { get; set; }

        public string NarcId { get; set; }

        public string OrganisationId { get; set; }

        public string PremisesId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string RegionCode { get; set; }

        public string CountryCode { get; set; }


        public string PostalCode { get; set; }

        public string BusinessPhoneNumber { get; set; }
        public string GigyaOid { set; get; }

        public string FullAddress
        {
            get
            {

                StringBuilder address = new StringBuilder();

                if (!string.IsNullOrWhiteSpace(AddressLine1))
                {
                    address.Append(AddressLine1 + ", ");
                }

                if (!string.IsNullOrWhiteSpace(AddressLine2))
                {
                    address.Append(AddressLine2 + ", ");
                }

                if (!string.IsNullOrWhiteSpace(City))
                {
                    address.Append(City + ", ");
                }

                if (!string.IsNullOrWhiteSpace(RegionCode))
                {
                    address.Append(RegionCode.Replace("US-", "") + ", ");
                }

                if (!string.IsNullOrWhiteSpace(PostalCode))
                {
                    address.Append(PostalCode);
                }

                return address.ToString().TrimEnd(',').Trim();
            }
        }

        public OrganisationBase(OrganisationBaseSerializeModel model)
        {
            Id = model.Id;
            Name = model.N;
        }
    }

    [Serializable]
    public class OrganisationBaseSerializeModel
    {
        //cliRowId
        public int Id { get; set; }
        //cliName
        public string N { get; set; }
        //cliLocaleRef
        public int L { get; set; }
    }

    public class ClinicCoreServices : OrganisationBase
    {
        public string LocaleIsoCode { get; set; }
    }
    
    public class LegacyOrganisation
    {
        public string MdmAccountId { get; set; }

        public string GigyaOid { get; set; }

        public string Name { get; set; }

        public string OrganizationType { get; set; }

        public string BusinessPhoneNumber { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public string PostalCode { get; set; }

        public string RegionCode { get; set; }

        public string SelectedVetEmail { get; set; }

        public string SelectedVetFullName { get; set; }

        public int OrganizationId { get; set; }
    }
}
