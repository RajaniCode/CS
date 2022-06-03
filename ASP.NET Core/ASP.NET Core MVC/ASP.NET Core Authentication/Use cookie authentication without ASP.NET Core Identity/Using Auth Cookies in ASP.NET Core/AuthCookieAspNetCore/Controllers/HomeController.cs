using System;
using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace AuthCookieAspNetCore.Controllers
{
  public class HomeController : Controller
  {
    private readonly IMemoryCache _cache;

    public HomeController(IMemoryCache cache)
    {
      _cache = cache;
    }

    public IActionResult Index()
    {
      return View();
    }

    [AllowAnonymous]
    public async Task<IActionResult> Login()
    {
      var userId = Guid.NewGuid().ToString();
      var claims = new List<Claim>
      {
        new Claim(ClaimTypes.Name, userId),
        new Claim("access_token", GetAccessToken(userId))
      };

      var claimsIdentity = new ClaimsIdentity(
        claims, CookieAuthenticationDefaults.AuthenticationScheme);
      var authProperties = new AuthenticationProperties();

      await HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        new ClaimsPrincipal(claimsIdentity),
        authProperties);

      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public async Task<IActionResult> Logout()
    {
      await HttpContext.SignOutAsync(
        CookieAuthenticationDefaults.AuthenticationScheme);

      return View();
    }

    public IActionResult Revoke()
    {
      var principal = HttpContext.User as ClaimsPrincipal;
      var userId = principal?.Claims
        .First(c => c.Type == ClaimTypes.Name);

      _cache.Set("revoke-" + userId.Value, true);

      return View();
    }

    private static string GetAccessToken(string userId)
    {
      const string issuer = "localhost";
      const string audience = "localhost";

      var identity = new ClaimsIdentity(new List<Claim>
      {
        new Claim("sub", userId)
      });

      var bytes = Encoding.UTF8.GetBytes(userId);
      var key = new SymmetricSecurityKey(bytes);
      var signingCredentials = new SigningCredentials(
        key, SecurityAlgorithms.HmacSha256);

      var now = DateTime.UtcNow;
      var handler = new JwtSecurityTokenHandler();

      var token = handler.CreateJwtSecurityToken(
        issuer, audience, identity,
        now, now.Add(TimeSpan.FromHours(1)),
        now, signingCredentials);

      return handler.WriteToken(token);
    }
  }
}
