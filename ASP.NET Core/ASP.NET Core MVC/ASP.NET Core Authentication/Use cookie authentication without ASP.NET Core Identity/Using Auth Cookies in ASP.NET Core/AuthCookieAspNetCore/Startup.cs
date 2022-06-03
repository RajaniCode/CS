using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AuthCookieAspNetCore
{
  public class Startup
  {
    private readonly IHostingEnvironment _environment;
    private readonly ILogger _logger;

    public Startup(IHostingEnvironment environment, ILogger<Startup> logger)
    {
      _environment = environment;
      _logger = logger;
    }

    public void ConfigureServices(IServiceCollection services)
    {
      services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
          options.Cookie.HttpOnly = true;
          options.Cookie.SecurePolicy = _environment.IsDevelopment()
            ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
          options.Cookie.SameSite = SameSiteMode.Lax;
          options.Cookie.Name = "SimpleTalk.AuthCookieAspNetCore";
          options.LoginPath = "/Home/Login";
          options.LogoutPath = "/Home/Logout";
          options.EventsType = typeof(RevokeAuthenticationEvents);
        });

      services.Configure<CookiePolicyOptions>(options =>
      {
        options.MinimumSameSitePolicy = SameSiteMode.Strict;
        options.HttpOnly = HttpOnlyPolicy.None;
        options.Secure = _environment.IsDevelopment()
          ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
      });

      services.AddMemoryCache();

      services.AddScoped<RevokeAuthenticationEvents>();
      services.AddTransient<ITicketStore, InMemoryTicketStore>();

      services.AddSingleton<IPostConfigureOptions<CookieAuthenticationOptions>,
        ConfigureCookieAuthenticationOptions>();

      services.AddMvc(options => options.Filters.Add(new AuthorizeFilter()))
        .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment environment)
    {
      app.UseDeveloperExceptionPage();
      app.UseStaticFiles();
      app.UseCookiePolicy();
      app.UseAuthentication();

      app.Use(async (context, next) =>
      {
        var principal = context.User as ClaimsPrincipal;
        var accessToken = principal?.Claims
          .FirstOrDefault(c => c.Type == "access_token");

        if (accessToken != null)
        {
          _logger.LogDebug(accessToken.Value);
        }

        await next();
      });

      app.UseMvc(routes =>
      {
        routes.MapRoute(
          name: "default",
          template: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
