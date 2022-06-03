using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
// Install-Package NLog.Web.AspNetCore -Version 4.13.0
using NLog;

namespace FileUploadMVC.Utilities
{
    /// <summary>
    /// Utility class helper for file.
    /// </summary>
    public static class FileHelpers
    {
        
        private static readonly Logger Logger = LogManager.GetLogger(typeof(FileHelpers).FullName);

        // If a check is required on specific characters in the IsValidFileSignature
        // method, remove Array.Empty<byte>() and supply the characters in the _allowedChars field.
        private static readonly byte[] AllowedChars = Array.Empty<byte>(); // { };

        // For more file signatures, see the File Signatures Database (https://www.filesignatures.net/)
        // and the official specifications for the file types to be added.
        private static readonly Dictionary<string, List<byte[]>> FileSignature = new Dictionary<string, List<byte[]>>
        {
            { ".GIF", new List<byte[]> { new byte[] { 0x47, 0x49, 0x46, 0x38 } } },
            { ".PNG", new List<byte[]> { new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } } },
            {
                ".JPG", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 },
                }
            },
            {
                ".JPEG", new List<byte[]>
                {
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 },
                    new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 },
                }
            },
            {
                ".XLS", new List<byte[]>
                {
                    new byte[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 },
                    new byte[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 },
                    new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x10 },
                    new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x1F },
                    new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x22 },
                    new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x23 },
                    new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x28 },
                    new byte[] { 0xFD, 0xFF, 0xFF, 0xFF, 0x29 },
                }
            },
            {
                ".XLSX", new List<byte[]>
                {
                    new byte[] { 0x50, 0x4B, 0x03, 0x04 },
                    new byte[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 },
                }
            },
        };

        /// <summary>
        /// Processes the file for upload.
        /// </summary>
        /// <typeparam name="T">The byte array.</typeparam>
        /// <param name="formFile">The instance of IFormFile.</param>
        /// <param name="modelState">The instance of ModelStateDictionary.</param>
        /// <param name="permittedExtensions">The permitted extensions of file.</param>
        /// <param name="sizeLimit">The size limit of file.</param>
        /// <returns>Empty byte array.</returns>
        /// <remarks>
        /// **WARNING!**
        /// In this file processing method, the file's content isn't scanned.
        /// In most production scenarios, an anti-virus/anti-malware scanner API is
        /// used on the file before making the file available to users or other systems.
        /// </remarks>
        // public static async Task<byte[]> ProcessFormFile<T>(IFormFile formFile, ModelStateDictionary modelState, string[] permittedExtensions, long sizeLimit)
        public static async Task<byte[]> ProcessFormFile<T>(IFormFile formFile, ModelStateDictionary modelState, List<string> permittedExtensions, long sizeLimit)
        {
            var fieldDisplayName = string.Empty;

            if (formFile != null && modelState != null)
            {
                modelState.Clear();

                // Use reflection to obtain the display name for the model
                // property associated with this IFormFile. If a display
                // name isn't found, error messages simply won't show
                // a display name.
                MemberInfo property = typeof(T).GetProperty(formFile.Name.Substring(formFile.Name.IndexOf(".", StringComparison.Ordinal) + 1));

                if (property != null)
                {
                    if (property.GetCustomAttribute(typeof(DisplayAttribute)) is DisplayAttribute displayAttribute)
                    {
                        fieldDisplayName = $"{displayAttribute.Name} ";
                    }
                }

                // Don't trust the file name sent by the client. To display
                // the file name, HTML-encode the value.
                var trustedFileNameForDisplay = WebUtility.HtmlEncode(formFile.FileName);

                if (!IsValidFileExtension(formFile.FileName, permittedExtensions))
                {
                    modelState.AddModelError(formFile.Name, $"{fieldDisplayName}({trustedFileNameForDisplay}) file type isn't permitted.");

                    return Array.Empty<byte>();
                }

                // Check the file length. This check doesn't catch files that only have
                // a BOM as their content.
                if (formFile.Length == 0)
                {
                    modelState.AddModelError(formFile.Name, $"{fieldDisplayName}({trustedFileNameForDisplay}) is empty.");

                    return Array.Empty<byte>();
                }

                if (formFile.Length > sizeLimit)
                {
                    var megabyteSizeLimit = sizeLimit / 1048576;

                    modelState.AddModelError(formFile.Name, $"{fieldDisplayName}({trustedFileNameForDisplay}) exceeds {megabyteSizeLimit:N1} MB.");

                    return Array.Empty<byte>();
                }

                try
                {
                    using var memoryStream = new MemoryStream();
                    await formFile.CopyToAsync(memoryStream).ConfigureAwait(true);

                    // Check the content length in case the file's only
                    // content was a BOM and the content is actually
                    // empty after removing the BOM.
                    if (memoryStream.Length == 0)
                    {
                        modelState.AddModelError(formFile.Name, $"{fieldDisplayName}({trustedFileNameForDisplay}) is empty.");
                    }

                    if (!IsValidFileSignature(formFile.FileName, memoryStream))
                    {
                        modelState.AddModelError(formFile.Name, $"{fieldDisplayName}({trustedFileNameForDisplay}) the file's signature doesn't match the file's extension.");
                    }
                    else
                    {
                        return memoryStream.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    modelState.AddModelError(formFile.Name, $"{fieldDisplayName}({trustedFileNameForDisplay}) upload failed. Please contact the Help Desk for support. Error: {ex.HResult}");

                    // Log the exception
                    Logger.Error(ex, "An exception occured");
                    throw;
                }
            }

            return Array.Empty<byte>();
        }

        /// <summary>
        /// Validates file extension.
        /// </summary>
        /// <param name="fileName">The name of file.</param>
        /// <param name="permittedExtensions">The permitted extensions of file.</param>
        /// <returns>Success if file extension is valid else failure.</returns>
        // private static bool IsValidFileExtension(string fileName, string[] permittedExtensions)
        private static bool IsValidFileExtension(string fileName, List<string> permittedExtensions)
        {
            var ext = Path.GetExtension(fileName).ToUpperInvariant();

            if (string.IsNullOrWhiteSpace(ext) || !permittedExtensions.Contains(ext))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates file signature.
        /// </summary>
        /// <param name="fileName">The name of file.</param>
        /// <param name="data">The data stream of file.</param>
        /// <returns>Success if file signature is valid else failure.</returns>
        private static bool IsValidFileSignature(string fileName, Stream data)
        {
            if (string.IsNullOrWhiteSpace(fileName) || data == null || data.Length == 0)
            {
                return false;
            }

            var ext = Path.GetExtension(fileName).ToUpperInvariant();

            data.Position = 0;

            using var reader = new BinaryReader(data);
            if (ext.Equals(".CSV", StringComparison.Ordinal) || ext.Equals(".TXT", StringComparison.Ordinal) || ext.Equals(".PRN", StringComparison.Ordinal))
            {
                if (AllowedChars.Length == 0)
                {
                    // Limits characters to ASCII encoding.
                    for (var i = 0; i < data.Length; i++)
                    {
                        if (reader.ReadByte() > sbyte.MaxValue)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    // Limits characters to ASCII encoding and
                    // values of the _allowedChars array.
                    for (var i = 0; i < data.Length; i++)
                    {
                        var b = reader.ReadByte();
                        if (b > sbyte.MaxValue ||
                            !AllowedChars.Contains(b))
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            // Uncomment the following code block if is necessary to permit
            // files whose signature isn't provided in the _fileSignature
            // dictionary. It is recommended to add file signatures for
            // files (when possible) for all file types to be allowed on
            // the system, and also to perform the file signature check.
            /*
            if (!_fileSignature.ContainsKey(ext))
            {
                return true;
            }
            */

            // File signature check
            // --------------------
            // With the file signatures provided in the _fileSignature
            // dictionary, the following code tests the input content's
            // file signature.
            var signatures = FileSignature[ext];
            var headerBytes = reader.ReadBytes(signatures.Max(m => m.Length));

            return signatures.Any(signature => headerBytes.Take(signature.Length).SequenceEqual(signature));
        }
    }
}