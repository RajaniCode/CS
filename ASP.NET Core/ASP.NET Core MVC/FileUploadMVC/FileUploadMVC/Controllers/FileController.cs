using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FileUploadMVC.Models;
using FileUploadMVC.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;

namespace FileUploadMVC.Controllers
{
    public class FileController : Controller
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

        // File Delete
        private readonly IFileProvider _fileProvider;

        // public FileController(IConfiguration config, IFileProvider fileProvider)
        public FileController(IOptions<AppSettings> appSetting, IFileProvider fileProvider)
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

            // File Delete
            _fileProvider = fileProvider;
        }

        // File Upload
        [BindProperty]
        public FileModel BindFileModel { get; set; }

        // File Upload
        public async Task<IActionResult> Upload(FileModel fileUpload)
        {
            if (BindFileModel == null)
            {
                ModelState.Clear();
                return View(fileUpload);
            }

            var formFileContent = await FileHelpers.ProcessFormFile<FileModel>(BindFileModel.FormFile, ModelState, _permittedExtensions, _fileSizeLimit).ConfigureAwait(true);

            if (!ModelState.IsValid)
            {
                return View(fileUpload);
            }

            // For the file name of the uploaded file stored
            // server-side, use Path.GetRandomFileName to generate a safe
            // random file name.
            // var trustedFileNameForFileStorage = Path.GetRandomFileName();
            var formFileName = this.BindFileModel.FormFile.FileName;
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

            return this.RedirectToAction("Index", "Home");
        }

        // File Delete
        [HttpGet]
        public IActionResult Delete(FileModel fileDelete)
        {
            if (string.IsNullOrEmpty(fileDelete.FileName))
            {
                return this.RedirectToAction("Index", "Home");
            }

            fileDelete.RemoveFile = _fileProvider.GetFileInfo(fileDelete.FileName);

            if (!fileDelete.RemoveFile.Exists)
            {
                return this.RedirectToAction("Index", "Home");
            }

            return View(fileDelete);
        }

        // File Delete
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeletePost(FileModel fileDelete)
        {
            if (string.IsNullOrEmpty(fileDelete.FileName))
            {
                return this.RedirectToAction("Index", "Home");
            }

            fileDelete.RemoveFile = _fileProvider.GetFileInfo(fileDelete.FileName);

            if (fileDelete.RemoveFile.Exists)
            {
                System.IO.File.Delete(fileDelete.RemoveFile.PhysicalPath);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
