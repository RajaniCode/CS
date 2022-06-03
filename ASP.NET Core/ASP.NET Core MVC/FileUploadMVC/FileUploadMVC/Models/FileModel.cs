using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace FileUploadMVC.Models
{
    public class FileModel
    {
        // File Upload
        public string FileName { get; set; }

        // File Delete
        public IFileInfo RemoveFile { get; set; }
                
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
