using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;

namespace FileUploadRazorPages.Pages
{
    public class FileDeleteModel : PageModel
    {
        private readonly IFileProvider _fileProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileDeleteModel"/> class.
        /// </summary>
        /// <param name="fileProvider">The instance of IFileProvider.</param>
        public FileDeleteModel(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider;
        }

        /// <summary>
        /// Gets or sets the file to be removed.
        /// </summary>
        public IFileInfo RemoveFile { get; set; }

        /// <summary>
        /// Action method to initialize state needed for the page.
        /// </summary>
        /// <param name="fileName">The name of the file.</param>
        /// <returns>The page to render.</returns>
        public IActionResult OnGet(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return this.RedirectToPage("/Index");
            }

            this.RemoveFile = _fileProvider.GetFileInfo(fileName);

            if (!this.RemoveFile.Exists)
            {
                return this.RedirectToPage("/Index");
            }

            return this.Page();
        }

        /// <summary>
        /// Action method to handle form submissions.
        /// </summary>
        /// <param name="fileName">The name of file.</param>
        /// <returns>The specified redirect page.</returns>
        public IActionResult OnPost(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return this.RedirectToPage("/Index");
            }

            this.RemoveFile = _fileProvider.GetFileInfo(fileName);

            if (this.RemoveFile.Exists)
            {
                System.IO.File.Delete(this.RemoveFile.PhysicalPath);
            }

            return this.RedirectToPage("./Index");
        }
    }
}
