using System;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace FileUploadRazorPages.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFileProvider _fileProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="IndexModel"/> class.
        /// </summary>
        /// <param name="fileProvider">The instance of IFileProvider.</param>
        public IndexModel(ILogger<IndexModel> logger, IFileProvider fileProvider)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
        }

        /// <summary>
        /// Gets the directory's content.
        /// </summary>
        public IDirectoryContents Files { get; private set; }

        /// <summary>
        /// Assigns directory contents by enumerating directory.
        /// </summary>
        public void OnGet() => Files = _fileProvider.GetDirectoryContents(string.Empty);

        /// <summary>
        /// Action method for downloading file.
        /// </summary>
        /// <param name="fileName">The name of file.</param>
        /// <returns>The file specified by the path.</returns>
        public IActionResult OnGetFileDownload(string fileName)
        {
            var downloadFile = _fileProvider.GetFileInfo(fileName);
            return PhysicalFile(downloadFile.PhysicalPath, MediaTypeNames.Application.Octet, fileName);
        }
    }
}
