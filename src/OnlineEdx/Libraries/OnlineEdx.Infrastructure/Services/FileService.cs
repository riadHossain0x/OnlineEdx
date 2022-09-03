using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdx.Infrastructure.Services
{
	public class FileService : IFileService
	{
        private string _webPath;
        private readonly IHostingEnvironment _environment;

        public FileService(IHostingEnvironment environment)
        {
            _environment = environment;
            _webPath = Path.Combine(_environment.WebRootPath, "/storeage/images");
        }

        private bool Exists(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path), "Provided path is null or empty");

            return File.Exists(path);
        }

        private string GetRandomName()
        {
            return Path.GetRandomFileName().Replace(".", string.Empty);
        }

        public async Task<string> StoreFileAsync(IFormFile file)
        {
            var randomName = GetRandomName();
            var newFileName = $"{randomName}{Path.GetExtension(file.FileName)}";

            if (!Directory.Exists(_webPath))
            {
                Directory.CreateDirectory(_webPath);
            }

            var fullPath = Path.Combine(_webPath, newFileName);

            if (!Exists(fullPath))
            {
                using var destinationStream = File.OpenWrite(fullPath);
                using var uploadFile = file.OpenReadStream();
                await uploadFile.CopyToAsync(destinationStream);
            }

            return newFileName;
        }
    }
}
