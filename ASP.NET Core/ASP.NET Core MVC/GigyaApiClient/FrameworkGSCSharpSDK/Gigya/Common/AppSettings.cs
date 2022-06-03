// Install-Package Microsoft.Extensions.Configuration -Version 5.0.0
// Install-Package Microsoft.Extensions.Configuration.Json -Version 5.0.0
// using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Gigya.Common
{
    public class AppSettings
    {
        // private const string Position = "appSettings";

        public GigyaSettings GigyaSettings { set; get; }

        public SmartyStreetsSettings SmartyStreetsSettings { set; get; }

        public JwtTokenAuthenticationSettings JwtTokenAuthenticationSettings { set; get; }

        public AppSettings()
        {
            /*
            IConfigurationBuilder builder = new ConfigurationBuilder();
            // Only for dev
            // Inject // IOptions<AppSettings> appSetting
            // Inject // IWebHostEnvironment // env.ContentRootPath; 
            // builder.AddJsonFile(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json"));
            string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            builder.AddJsonFile(System.IO.Path.Combine(directory, "appsettings.json"));
            IConfigurationRoot root = builder.Build();
            root.GetSection(AppSettings.Position).Bind(this);
            */

            /*
            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //.AddEnvironmentVariables()
            //.AddCommandLine(args)
            .Build();

            IConfigurationRoot configurationRoot = configuration as IConfigurationRoot;
            configurationRoot.GetSection(AppSettings.Position).Bind(this);
            */

            this.GigyaSettings = new GigyaSettings
            {
                GigyaApiKey = ConfigurationManager.AppSettings["GigyaApiKey"],
                GigyaProspectApiKey = ConfigurationManager.AppSettings["GigyaProspectApiKey"],
                GigyaSecretKey = ConfigurationManager.AppSettings["GigyaSecretKey"],
                GigyaUserKey = ConfigurationManager.AppSettings["GigyaUserKey"],
                GigyaDataCenterUS = ConfigurationManager.AppSettings["GigyaDataCenterUS"],
                GigyaAccountsGetJwtPublicKey = ConfigurationManager.AppSettings["GigyaAccountsGetJwtPublicKey"],
                GigyaIdsSearch = ConfigurationManager.AppSettings["GigyaIdsSearch"],
                GigyaIdsGetAccountInfo = ConfigurationManager.AppSettings["GigyaIdsGetAccountInfo"],
                GigyaIdsSetAccountInfo = ConfigurationManager.AppSettings["GigyaIdsSetAccountInfo"],
                GigyaAccountsRegister = ConfigurationManager.AppSettings["GigyaAccountsRegister"],
                GigyaAccountsGetAccountInfo = ConfigurationManager.AppSettings["GigyaAccountsGetAccountInfo"],
                GigyaAccountsLogin = ConfigurationManager.AppSettings["GigyaAccountsLogin"],
                GigyaAccountsLogout = ConfigurationManager.AppSettings["GigyaAccountsLogout"],
                GigyaAccountsResetPassword = ConfigurationManager.AppSettings["GigyaAccountsResetPassword"],
                GigyaAccountsDeleteAccount = ConfigurationManager.AppSettings["GigyaAccountsDeleteAccount"],
                GigyaDsSearch = ConfigurationManager.AppSettings["GigyaDsSearch"],
            };

            this.SmartyStreetsSettings = new SmartyStreetsSettings
            {
                SmartyStreetsAuthId = ConfigurationManager.AppSettings["SmartyStreetsAuthId"],
                SmartyStreetsAuthToken = ConfigurationManager.AppSettings["SmartyStreetsAuthToken"],
            };

            this.JwtTokenAuthenticationSettings = new JwtTokenAuthenticationSettings
            {
                JwtTokenAuthenticationSecretKey = ConfigurationManager.AppSettings["JwtTokenAuthenticationSecretKey"],
                JwtTokenAuthenticationIssuer = ConfigurationManager.AppSettings["JwtTokenAuthenticationIssuer"],
                JwtTokenAuthenticationAudience = ConfigurationManager.AppSettings["JwtTokenAuthenticationAudience"],
            };
        }
    }
}
