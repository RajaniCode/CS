namespace Gigya.Common
{
    public class JwtTokenAuthenticationSettings
    {
        public string JwtTokenAuthenticationSecretKey { get; set; }

        public string JwtTokenAuthenticationIssuer { get; set; }

        public string JwtTokenAuthenticationAudience { get; set; }
    }
}