using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileUploadRazorPages.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace FileUploadRazorPages.Pages
{
    public class FileUploadModel : PageModel
    {
        private readonly IOptions<AppSettings> _appSetting;
        private readonly string _appGuidFileName;
        private readonly string _appGuidFileExtension;

        // File Upload
        private readonly long _fileSizeLimit;
        // private readonly string[] _supportedExtensions = { ".XLS", ".XLSX", ".CSV", ".TXT", ".PRN", ".GIF", ".PNG", ".JPG", ".JPEG" };
        private readonly List<string> _supportedExtensions = new List<string> { ".XLS", ".XLSX", ".CSV", ".TXT", ".PRN", ".GIF", ".PNG", ".JPG", ".JPEG" };
        // private readonly string[] _permittedExtensions;
        private readonly List<string> _permittedExtensions;
        private readonly string _targetFilePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUploadModel"/> class.
        /// </summary>
        /// <param name="config">The instance of IConfiguration.</param>
        // public FileUploadModel(IConfiguration config)
        public FileUploadModel(IOptions<AppSettings> appSetting)
        {
            // _ = config ?? throw new ArgumentNullException(nameof(config));
            _appSetting = appSetting ?? throw new ArgumentNullException(nameof(appSetting));

            // File Upload
            // _permittedExtensions = config.GetSection("AppSettings:PermittedExtensions").Get<string[]>();
            // _permittedExtensions = _permittedExtensions.Select(x => x.ToUpperInvariant()).ToArray();
            // _permittedExtensions = _permittedExtensions.Where(x => _supportedExtensions.Contains(x)).Distinct().ToArray();
            // _appGuidFileName = config.GetValue<string>("AppSettings:AppGuidFileName");
            // _appGuidFileExtension = config.GetValue<string>("AppSettings:AppGuidFileExtension");
            // _fileSizeLimit = config.GetValue<long>("AppSettings:FileSizeLimit");
            // _targetFilePath = config.GetValue<string>("AppSettings:StoredFilesPath");

            // File Upload
            _permittedExtensions = _appSetting.Value.PermittedExtensions;
            _permittedExtensions = _permittedExtensions.Select(x => x.ToUpperInvariant()).ToList();
            _permittedExtensions = _permittedExtensions.Where(x => _supportedExtensions.Contains(x)).Distinct().ToList();

            _appGuidFileName = _appSetting.Value.AppGuidFileName;
            _appGuidFileExtension = _appSetting.Value.AppGuidFileExtension;

            _fileSizeLimit = _appSetting.Value.FileSizeLimit;

            // To save physical files to a path provided by configuration:
            _targetFilePath = _appSetting.Value.StoredFilesPath;
        }

        /// <summary>
        /// Gets or sets instance of FileUploadModel.
        /// </summary>
        [BindProperty]
        public FileUpload BindFileUpload { get; set; }

        /// <summary>
        /// Action method for uploading file.
        /// </summary>
        /// <returns>The specified redirect page.</returns>
        public async Task<IActionResult> OnPostUploadAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            var formFileContent = await FileHelpers.ProcessFormFile<FileUpload>(BindFileUpload.FormFile, ModelState, _permittedExtensions, _fileSizeLimit).ConfigureAwait(true);

            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            // For the file name of the uploaded file stored
            // server-side, use Path.GetRandomFileName to generate a safe
            // random file name.
            // var trustedFileNameForFileStorage = Path.GetRandomFileName();
            var formFileName = this.BindFileUpload.FormFile.FileName;
            var trustedFileNameForFileStorage = Path.GetFileNameWithoutExtension(formFileName) + _appGuidFileName + "_" + $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss-fff}" + "_" + Guid.NewGuid().ToString() + "_" + _appGuidFileExtension + Path.GetExtension(formFileName);
            var filePath = Path.Combine(_targetFilePath, trustedFileNameForFileStorage);

            // **WARNING!**
            // In the following example, the file is saved without
            // scanning the file's contents. In most production
            // scenarios, an anti-virus/anti-malware scanner API
            // is used on the file before making the file available
            // for download or for use by other systems.
            using (var fileStream = System.IO.File.Create(filePath))
            {
                await fileStream.WriteAsync(formFileContent);

                // To work directly with a FormFile, use the following
                // instead:
                // await FileUpload.FormFile.CopyToAsync(fileStream);
            }

            return this.RedirectToPage("./Index");
        }
    }
}
