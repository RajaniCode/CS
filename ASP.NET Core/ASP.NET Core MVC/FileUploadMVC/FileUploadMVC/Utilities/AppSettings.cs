using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace FileUploadMVC.Utilities
{
    public class AppSettings
    {
        public List<string> PermittedExtensions { get; set; }

        public string AppGuidFileName { get; set; }

        public long FileSizeLimit { get; set; }

        public string AppGuidFileExtension { get; set; }

        public string StoredFilesPath { get; set; }

        private const string Position = "AppSettings";

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
