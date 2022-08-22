using System.Collections.Generic;
using Microsoft.Extensions.FileProviders;

namespace FileUploadMVC.Models
{
    public class HomeModel
    {
        public string FileName { get; set; }

        public List<string> FileDisplayNames { get; set; }

        public IDirectoryContents Files { get; set; }
    }
}
