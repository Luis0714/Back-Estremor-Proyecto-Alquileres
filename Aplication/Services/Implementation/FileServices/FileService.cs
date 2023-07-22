using Application.Constants;
using Application.DTO_s;
using Application.Execteptions.Validation;
using Application.Messages.File;
using Application.Services.Abstraction.FileServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;

namespace Application.Services.Implementation.FileServices
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<FileDownloadDto> DownloadFile(string ruta)
        {
            if (string.IsNullOrEmpty(ruta)) throw new ApiException(MessageFileErrors.Ruta);

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(ruta, out var contentType))
                contentType = UserConst.CONTENTTYPE;

            var bytes = await File.ReadAllBytesAsync(ruta);
            return new FileDownloadDto() { Bytes = bytes, ContentType = contentType };
        }

        public string UploadFile(IFormFile file)
        {
            if (file.Length == default)
            {
                throw new ApiException(MessageFileErrors.Ruta);
            }
            var paht = Path.Combine(_webHostEnvironment.ContentRootPath, UserConst.IMAGEUSERS);

            if (!Directory.Exists(paht))
                Directory.CreateDirectory(paht);

            string fullPath = Path.Combine(paht, string.Concat(Guid.NewGuid().ToString(), UserConst.GUION,file.FileName));
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            return fullPath;

        }
    }
}
