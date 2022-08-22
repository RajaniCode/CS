using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using Identity.Models;
using Microsoft.Owin.Security.MicrosoftAccount;
// Install-Package Microsoft.Owin.Security.OpenIdConnect -Version 4.1.1
using Microsoft.Owin.Security.OpenIdConnect;

namespace Identity
{
    public partial class Startup
    {
        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });            
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            /*
            # https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationsListBlade
            # https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/Overview/appId/####################################/isMSAApp/true
            # IdentityOpenIdConnect
            #### Register the webApp app (WebApp)
            1. Navigate to the Microsoft identity platform for developers [App registrations](https://go.microsoft.com/fwlink/?linkid=2083908) page.
            2. Select **New registration**.
            3. When the **Register an application page** appears, enter your application's registration information:
                - In the **Name** section, enter application name, for example `WebApp`. 
                # IdentityOpenIdConnect
                - Enter **Supported account types**
                # Personal Microsoft accounts only
                - Enter Redirect URI by choosing Web from the dropdown box
                # https://localhost:44392/ 
                # OR
                # https://localhost:44392/signin-oidc
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
                # https://localhost:44392/
                # OR
                # https://localhost:44392/signin-oidc
                - Check **ID tokens (used for implicit and hybrid flows)**    
            7. Select **Save**.
            */
            // https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationsListBlade
            // https://localhost:44392/
            // OR
            // https://localhost:44392/signin-oidc
            // Install-Package Microsoft.Owin.Security.OpenIdConnect -Version 4.1.1
            app.UseOpenIdConnectAuthentication(
                new OpenIdConnectAuthenticationOptions
                {
                    ClientId = "************************************",
                    Authority = "https://login.microsoftonline.com/consumers/v2.0"
                }
            );

            /*
            # https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationsListBlade
            # https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationMenuBlade/Overview/appId/####################################/isMSAApp/true
            # Identity
            #### Register the webApp app (WebApp)
            1. Navigate to the Microsoft identity platform for developers [App registrations](https://go.microsoft.com/fwlink/?linkid=2083908) page.
            2. Select **New registration**.
            3. When the **Register an application page** appears, enter your application's registration information:
                - In the **Name** section, enter application name, for example `WebApp`. 
                # Identity
                - Enter **Supported account types**
                # Personal Microsoft accounts only
                - Enter Redirect URI by choosing Web from the dropdown box
                # https://localhost:44392/signin-microsoft
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
            // Edit
            // https://portal.azure.com/#blade/Microsoft_AAD_RegisteredApps/ApplicationsListBlade
            // https://localhost:44392/signin-microsoft
            var options = new MicrosoftAccountAuthenticationOptions
            {
                ClientId = "************************************",
                ClientSecret = "**********************************",
                AuthorizationEndpoint = "https://login.microsoftonline.com/consumers/oauth2/v2.0/authorize",
                TokenEndpoint = "https://login.microsoftonline.com/consumers/oauth2/v2.0/token"
            };
            app.UseMicrosoftAccountAuthentication(options);

            // Edit
            // https://developer.twitter.com
            // https://localhost:44392/signin-twitter
            // https://example.com
            app.UseTwitterAuthentication(
                consumerKey: "*************************",
                consumerSecret: "**************************************************");

            // Edit
            // https://developers.facebook.com
            app.UseFacebookAuthentication(
                appId: "***************",
                appSecret: "********************************");

            // Edit
            // https://console.developers.google.com
            // https://localhost:44392/signin-google
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "************************************************************************",
                ClientSecret = "************************"
            });
        }
    }
}