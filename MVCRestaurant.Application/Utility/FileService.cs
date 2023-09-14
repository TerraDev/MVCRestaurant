using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCRestaurant.Application.Utility
{
    public class FileService
    {
        private readonly IWebHostEnvironment _environment;

        public FileService(IWebHostEnvironment Environment)
        {
            _environment = Environment;
        }

        public async Task<string> StoreFileAsync(IFormFile file, string localPath, string? NamePrefix = null)
        {
            string path;
            if (file.Length > 0)
            {
                //TODO: each file directory path should be set via a global variable.
                path = Path.GetFullPath(Path.Combine(this._environment.WebRootPath, localPath));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string rand = NamePrefix ?? Guid.NewGuid().ToString();
                string fName = rand + "_" + file.FileName;
                string directory = Path.Combine(path, fName);
                using (var fileStream = new FileStream(directory, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
                return Path.Combine("\\",localPath, fName);
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<string> StoreFileAsync(byte[] byteArray, string fileName, string localPath, string? NamePrefix = null)
        {
            string path;
            if (byteArray.Length > 0)
            {
                //TODO: each file directory path should be set via a global variable.
                path = Path.GetFullPath(Path.Combine(this._environment.WebRootPath, localPath));
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string rand = NamePrefix ?? Guid.NewGuid().ToString();
                string fName = rand + "_" + fileName;
                string directory = Path.Combine(path, fName);
                using (var fileStream = new FileStream(directory, FileMode.Create))
                {
                    await fileStream.WriteAsync(byteArray, 0, byteArray.Length);
                }
                return Path.Combine("\\", localPath, fName);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
