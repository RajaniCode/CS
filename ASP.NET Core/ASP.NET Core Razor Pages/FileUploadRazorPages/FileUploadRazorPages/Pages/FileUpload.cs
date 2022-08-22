using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace FileUploadRazorPages.Pages
{
    /// <summary>
    /// Uploads file.
    /// </summary>
    public class FileUpload
    {
        /// <summary>
        /// Gets or sets the file.
        /// </summary>
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }
    }
}
