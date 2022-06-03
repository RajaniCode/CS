using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

public class RevokeAuthenticationEvents : CookieAuthenticationEvents
{
  private readonly IMemoryCache _cache;
  private readonly ILogger _logger;

  public RevokeAuthenticationEvents(
    IMemoryCache cache,
    ILogger<RevokeAuthenticationEvents> logger)
  {
    _cache = cache;
    _logger = logger;
  }

  public override Task ValidatePrincipal(
    CookieValidatePrincipalContext context)
  {
    var userId = context.Principal.Claims
      .First(c => c.Type == ClaimTypes.Name);

    if (_cache.Get<bool>("revoke-" + userId.Value))
    {
      context.RejectPrincipal();

      _cache.Remove("revoke-" + userId.Value);
      _logger.LogDebug("Access has been revoked for: "
        + userId.Value + ".");
    }

    return Task.CompletedTask;
  }
}
