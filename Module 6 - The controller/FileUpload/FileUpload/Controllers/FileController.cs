using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    public class FileController : Controller
    {
        private readonly string _folder;

        public FileController(IHostingEnvironment hostingEnvironment)
        {
            _folder = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
            // Creamos "wwwroot/uploads" si no existe:
            Directory.CreateDirectory(_folder);
        }

        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filePath = Path.Combine(_folder, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return Content($"Uploaded {file.FileName}");
            }
            return Content("No file selected");
        }

        public async Task<IActionResult> Uploads(IFormFileCollection files)
        {
            foreach (var file in files)
            {
                var filePath = Path.Combine(_folder, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            return Content($"Uploaded {files.Count} file(s)");
        }
    }
}