// Install-Package Microsoft.Extensions.Configuration -Version 5.0.0
// Install-Package Microsoft.Extensions.Configuration.Json -Version 5.0.0
using Microsoft.Extensions.Configuration;

namespace Gigya.Common
{
    public class AppSettings
    {
        private const string Position = "AppSettings";

        public GigyaSettings GigyaSettings { set; get; }

        public SmartyStreetsSettings SmartyStreetsSettings { set; get; }

        public JwtTokenAuthenticationSettings JwtTokenAuthenticationSettings { set; get; }

        public AppSettings()
        {
            /*
            IConfigurationBuilder builder = new ConfigurationBuilder();
            // Only for dev
            // builder.AddJsonFile(System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "appsettings.json"));
            string location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(location);
            builder.AddJsonFile(System.IO.Path.Combine(directory, "appsettings.json"));
            IConfigurationRoot root = builder.Build();
            root.GetSection(AppSettings.Position).Bind(this);
            */

            IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            // .AddEnvironmentVariables()
            // .AddCommandLine(args)
            .Build();

            IConfigurationRoot configurationRoot = configuration as IConfigurationRoot;
            configurationRoot.GetSection(AppSettings.Position).Bind(this);
        }
    }
}
