using Microsoft.AspNetCore.Authorization;

namespace IdentityCore
{
    public class RequireUserNames : IAuthorizationRequirement
    {
        public RequireUserNames(params string[] userNames)
        {
            UserNames = userNames;
        }

        public string[] UserNames { get; set; }
    }
}