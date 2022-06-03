using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using EmployeeService.Providers;
using EmployeeService.Models;
using EmployeeService.Facebook;
using Microsoft.Owin.Security.Facebook;

namespace EmployeeService
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }
        public static string PublicClientId { get; private set; }

        // For more information on configuring authentication, please visit https://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context and user manager to use a single instance per request
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            app.UseCookieAuthentication(new CookieAuthenticationOptions());
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Configure the application for OAuth based flow
            PublicClientId = "self";
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(PublicClientId),
                AuthorizeEndpointPath = new PathString("/api/Account/ExternalLogin"),
                // AccessTokenExpireTimeSpan = TimeSpan.FromSeconds(10),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                // In production mode set AllowInsecureHttp = false
                AllowInsecureHttp = true
            };

            // Enable the application to use bearer tokens to authenticate users
            app.UseOAuthBearerTokens(OAuthOptions);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //    consumerKey: "",
            //    consumerSecret: "");

            // https://developers.facebook.com/
            // TestApp
            // Valid OAuth Redirect URIs // Not required
            // https://localhost:44337
            // https://localhost:44337/signin-facebook
            app.UseFacebookAuthentication(
                appId: "857136681377830",
                appSecret: "5d600434a01c3988d04e2da9992cd294");

            /*
            var facebookOptions = new FacebookAuthenticationOptions()
            {
                AppId = "857136681377830",
                AppSecret = "5d600434a01c3988d04e2da9992cd294",
                BackchannelHttpHandler = new FacebookBackChannelHandler(),
                // UserInformationEndpoint = "https://graph.facebook.com/v2.4/me?fields=id,email"
                // UserInformationEndpoint = "https://graph.facebook.com/v2.8/me?fields=id,email"
                // UserInformationEndpoint = "https://graph.facebook.com/v2.8/me?"
            };
            facebookOptions.Scope.Add("email");
            app.UseFacebookAuthentication(facebookOptions);
            */

            // Install-Package Microsoft.Owin.Security.Google -Version 4.1.0
            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "563141950036-3uqjt8vokukg1qte7cm3aa6tcjhbacqd.apps.googleusercontent.com",
                ClientSecret = "J9ZC41ZJgjnrheJOSZTUSvs6"
            });
        }
    }
}
