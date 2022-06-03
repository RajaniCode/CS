namespace Gigya.Process.Model
{
    public class ProspectUserRegistration
    {
        public string Email { set; get; }

        public string Password { set; get; }

        public GigyaUserProfile Profile { set; get; }

        public GigyaData Data { set; get; }

        public bool FinalizeRegistration { get; set; }
    }
}
