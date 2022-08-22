using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// Install-Package Newtonsoft.Json -Version 12.0.3  in GigyaApiClient.csproj
using Newtonsoft.Json;
using Gigya.Common;

namespace Gigya.Model.Models
{
    [Serializable]
    public class UserBase
    {
        public int Id { get; set; }

        [Display(Name = "UserFirstName")]
        public string FirstName { get; set; }

        [Display(Name = "UserLastName")]
        public string LastName { get; set; }

        [Display(Name = "UserPrefix")]
        public string Prefix { get; set; }

        [Display(Name = "UserSuffix")]
        public string Suffix { get; set; }

        [Display(Name = "UserEmail")]
        public string Email { get; set; }

        [Display(Name = "UserTelephone")]
        public string Telephone { get; set; }
    }

    public abstract class UserBaseWithRole : UserBase
    {
        public Enums.Roles RoleName { get; set; }
    }

    [Serializable]
    public class User : UserBase
    {
        public string ProspectCode { get; set; }

        public OrganisationBase Organisation { get; set; }

        [Display(Name = "Role")]
        public Role Role { get; set; }

        [JsonProperty("UID")]
        public string UID { get; set; }

        public bool Enabled { get; set; }

        public bool Deleted { get; set; }

        public DateTime? LastLoggedIn { get; set; }

        public bool PasswordReset { get; set; }

        public bool IsNew { get; set; }

        public bool HasRoleJustChanged { get; set; }

        public string FullName
        {
            get
            {
                return (FirstName + " " + LastName).Trim();
            }
        }

        public bool HasEnrolments { get; set; }
    }

    [Serializable]
    public class EnrolmentUser : UserBase
    {
        public string FullName
        {
            get
            {
                return (FirstName + " " + LastName).Trim();
            }
        }

    }

    [Serializable]
    public class UserLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int ClinicId { get; set; }
    }

    public class ApiUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class ApiUsersDataSet
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public List<ApiUser> data { get; set; }
    }

    public class UserServices : UserBase
    {
        [JsonProperty("userId")]
        public int? UserId { get; set; }

        [JsonProperty("clinicNarcId")]
        public string ClinicNarcId { get; set; }

        [JsonProperty("organisationId")]
        public int OrganisationId { get; set; }

        [JsonProperty("JsonResponse")]
        public string JsonResponse { get; set; }

        [JsonProperty("RoleName")]
        public Enums.Roles RoleName { get; set; }
    }

    public class UpdateUser : UserServices
    {
        [JsonProperty("prospectId")]
        public int? ProspectId { get; set; }
    }

    public class InsertUser : UserServices
    {
        [JsonProperty("password")]
        public string Password { get; set; }
    }

    public class UpdateUserPassword
    {
        public Guid ResetPasswordGuid { get; set; }

        public int UserId { get; set; }

        public string Password { get; set; }
    }
}
