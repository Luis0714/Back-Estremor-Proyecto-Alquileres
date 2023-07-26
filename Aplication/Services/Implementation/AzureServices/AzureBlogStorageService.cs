using Application.Services.Abstraction.AzureServices;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Application.Services.Implementation.AzureServices
{
    public class AzureBlogStorageService : IAzureBlogStorageService
    {
        private readonly string azureStorageConnectionString;

        public AzureBlogStorageService(IConfiguration configuration)
        {
            this.azureStorageConnectionString = configuration.GetValue<string>("AzureBlogStorageConnection");
        }

        public async Task DeleteAsync(string container, string blobFilename)
        {
            var blobContainerClient = new BlobContainerClient(this.azureStorageConnectionString, container);
            var blobClient = blobContainerClient.GetBlobClient(blobFilename);

            try
            {
                await blobClient.DeleteAsync();
            }
            catch
            {
            }
        }

        public async Task<string> UploadAsync(IFormFile file, string container, string blobName = null)
        {
            if (file.Length == 0) return null;
            var blobContainerClient = new BlobContainerClient(this.azureStorageConnectionString, container);

            // Get a reference to the blob just uploaded from the API in a container from configuration settings
            if (string.IsNullOrEmpty(blobName))
            {
                blobName = Guid.NewGuid().ToString();
            }

            var blobClient = blobContainerClient.GetBlobClient(blobName);

            var blobHttpHeader = new BlobHttpHeaders { ContentType = file.ContentType };

            // Open a stream for the file we want to upload
            await using (Stream stream = file.OpenReadStream())
            {
                // Upload the file async
                await blobClient.UploadAsync(stream, new BlobUploadOptions { HttpHeaders = blobHttpHeader });
            }

            return blobName;
        }
    }
}
