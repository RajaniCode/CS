namespace Gigya.Common
{
    public static class Constants
    {
        public const int GigyaStatusCodeSuccess = 0;
        public const int GigyaStatusCodeMoreThan60SecondsOld = 403002;
        public const int GigyaStatusCodeUIDSignatureInvalid = 400006;

        public const string Phone = "phone";
        public const string Office = "office";
        public const string Fax = "fax";
        public const string QualificationTypeRan = "RAN";
        public const string BusinessTypeProducer = "PRODUCER";
        public const string MobilePhone = "+18553308653";

        public const int JWTTokenValidationMinutes = 1609363014; // 60 minutes = 60 * 60

        public const string ErrorMessage = "An error occurred. Please try again.";
    }
}