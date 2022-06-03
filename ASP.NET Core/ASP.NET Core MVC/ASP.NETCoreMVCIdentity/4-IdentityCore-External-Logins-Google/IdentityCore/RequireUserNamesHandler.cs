using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace IdentityCore
{
    public class RequireUserNamesHandler : AuthorizationHandler<RequireUserNames>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RequireUserNames requirement)
        {
            var userName = context.User.Identity.Name;

            if (requirement.UserNames.ToList().Contains(userName))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
            return Task.CompletedTask;
        }
    }
}