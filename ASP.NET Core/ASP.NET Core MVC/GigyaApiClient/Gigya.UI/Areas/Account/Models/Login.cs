namespace Gigya.UI.Areas.Account.ViewModels
{
    public class Login
    {
        public int? BarnCardId;

        public string ViewName { get; set; }

        public string ProspectCode { get; set; }

        public bool RedirectProfile { get; set; }

        public string DisplayNotification { get; set; }

        public int? EnrolmentId { get; set; }

        public int? HighlightEnrolmentId { get; set; }

        public bool DeletedEnrollment { get; set; }
    }
}
