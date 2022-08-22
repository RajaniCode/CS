namespace Gigya.UI.Areas.Account.ViewModels
{
    public class LoginStatus
    {
        public string GigyaId { get; set; }

        public bool IsLoggedIn { get; set; }

        public string LogoutActiveSession { get; set; }
    }
}
