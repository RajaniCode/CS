using System;
using System.Security.Claims;

namespace Gigya.UI.Security
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            int.TryParse(principal.FindFirst(ClaimTypes.NameIdentifier)?.Value, out int nameIdentifier);
            return nameIdentifier;
        }

        public static string GetUserGigyaId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            return principal.FindFirst(ClaimTypes.Sid)?.Value;
        }

        public static string GetUserName(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentNullException(nameof(principal));
            }

            return principal.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static DateTime GetLastLogin(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                return DateTime.Now;
            }

            return DateTime.Parse(principal.FindFirst(CustomClaimTypes.LastLogin)?.Value);
        }

        public static string GetUserRole(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                return string.Empty;
            }

            return principal.FindFirst(ClaimTypes.Role)?.Value;
        }

        public static int GetUserRoleId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                return 0;
            }

            int.TryParse(principal.FindFirst(CustomClaimTypes.RoleId)?.Value, out int nameIdentifier);

            return nameIdentifier;
        }
    }
}
