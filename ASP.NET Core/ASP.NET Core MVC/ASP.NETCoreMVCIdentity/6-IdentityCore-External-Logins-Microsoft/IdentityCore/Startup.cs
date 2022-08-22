using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using IdentityCore.Data;

namespace IdentityCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string dataDirectory = Configuration.GetValue<string>(WebHostDefaults.ContentRootKey) + "\\App_Data";

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection").Replace("|DataDirectory|", dataDirectory)));

            services.AddDatabaseDeveloperPageExceptionFilter();

            /*
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            */

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireAdminRole", policy => policy.RequireRole("Admin"));

                options.AddPolicy("RequireUserName", policy => policy.RequireUserName("admin@example.com"));
                options.AddPolicy("RequireUserNames", policy => policy.Requirements.Add(new RequireUserNames("email@example.com", "e.mail@example.com", "mail@example.com", "admin@example.com", "facebook@example.com", "google@example.com", "twitter@example.com", "microsoft@example.com", "microsoftopenidconnect@example.com")));
            });

            services.AddSingleton<IAuthorizationHandler, RequireUserNamesHandler>();

            services.AddControllersWithViews();

            // https://developers.facebook.com
            // Install-Package Microsoft.AspNetCore.Authentication.Facebook -Version 5.0.4
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            });

            // https://console.developers.google.com
            // https://localhost:44309
            // https://localhost:44309/signin-google
            // Install-Package Microsoft.AspNetCore.Authentication.Google -Version 5.0.4
            services.AddAuthentication().AddGoogle(options =>
            {
                IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");
                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];
            });

            // https://developer.twitter.com
            // https://localhost:44309/signin-twitter
            // https://example.com
            // Install-Package Microsoft.AspNetCore.Authentication.Twitter -Version 5.0.4
            services.AddAuthentication().AddTwitter(twitterOptions =>
            {
                twitterOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerAPIKey"];
                twitterOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
                twitterOptions.RetrieveUserDetails = true;
            });

            /*
            # https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationsListBlade
            # https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/Overview/appId/####################################/isMSAApp/true
            # IdentityCore
            #### Register the webApp app (WebApp)
            1. Navigate to the Microsoft identity platform for developers [App registrations](https://go.microsoft.com/fwlink/?linkid=2083908) page.
            2. Select **New registration**.
            3. When the **Register an application page** appears, enter your application's registration information:
                - In the **Name** section, enter application name, for example `WebApp`. 
                # IdentityCore
                - Enter **Supported account types**
                # Personal Microsoft accounts only
                - Enter Redirect URI by choosing Web from the dropdown box
                # https://localhost:44309/signin-microsoft
            4. Click **Register** to create the application.
            # By default the following is set
            [
            **API permissions**
            API / Permissions name
            Microsoft Graph (1)
            User.Read
            ]
            5. On the app **Certificates & secrets**
            - **Client secrets**
            # Add New client secret
            */
            // https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationsListBlade
            // https://localhost:44309/signin-microsoft
            // Install-Package Microsoft.AspNetCore.Authentication.MicrosoftAccount -Version 5.0.4
            services.AddAuthentication().AddMicrosoftAccount(microsoftOptions =>
            {
                microsoftOptions.ClientId = Configuration["Authentication:Microsoft:ClientId"];
                microsoftOptions.ClientSecret = Configuration["Authentication:Microsoft:ClientSecret"];
                microsoftOptions.AuthorizationEndpoint = "https://login.microsoftonline.com/consumers/oauth2/v2.0/authorize";
                microsoftOptions.TokenEndpoint = "https://login.microsoftonline.com/consumers/oauth2/v2.0/token";
            });

            /*
            # https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationsListBlade
            # https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/Overview/appId/####################################/isMSAApp/true
            # IdentityCoreOpenIdConnect
            #### Register the webApp app (WebApp)
            1. Navigate to the Microsoft identity platform for developers [App registrations](https://go.microsoft.com/fwlink/?linkid=2083908) page.
            2. Select **New registration**.
            3. When the **Register an application page** appears, enter your application's registration information:
                - In the **Name** section, enter application name, for example `WebApp`. 
                # IdentityCoreOpenIdConnect
                - Enter **Supported account types**
                # Personal Microsoft accounts only
                - Enter Redirect URI by choosing Web from the dropdown box
                # https://localhost:44309/signin-oidc
            4. Click **Register** to create the application.
            # By default the following is set
            [
            **API permissions**
            API / Permissions name
            Microsoft Graph (1)
            User.Read
            ]
            5. On the app **Overview**, find the **Application (client) ID** value and record it for appsettings.json.
            6. On the app **Authentication**
                - See **Redirect URI**
                # https://localhost:44309/signin-oidc
                - Check **ID tokens (used for implicit and hybrid flows)**    
            7. Select **Save**.
            */
            // Install-Package Microsoft.AspNetCore.Authentication.OpenIdConnect -Version 5.0.4
            services.AddAuthentication().AddOpenIdConnect(openIdConnectOptions =>
            {
                openIdConnectOptions.ClientId = Configuration["Authentication:MicrosoftOpenIdConnect:ClientId"];
                openIdConnectOptions.Authority = "https://login.microsoftonline.com/consumers/v2.0";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
