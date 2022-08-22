using System;

namespace Gigya.Model.Models
{

    [Serializable]
    public class LoggedInUser
    {
        public int Id { get; set; }

        public string GigyaId { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public Role Role { get; set; }

        public LoggedInUser(LoggedInUserSerializeModel model)
        {
            Id = model.Id;

            GigyaId = model.G;

            Email = model.E;

            FullName = model.N;

            Role = new Role(model.R);
        }
    }


    [Serializable]
    public class LoggedInUserSerializeModel
    {
        //User Id
        public int Id { get; set; }

        //Gigya Id
        public string G { get; set; }

        //Email
        public string E { get; set; }

        //Full Name
        public string N { get; set; }

        //Role
        public RoleSerializeModel R { get; set; }

        //User Preference
        public int P { get; set; }
    }
}
