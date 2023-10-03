using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;

namespace Assessments.Transformation.Helpers
{
    public static class Storage
    {
        private static BlobContainerClient _blobContainer;
        
        public static async Task UploadToBlob(IConfigurationRoot configuration, string key, string value)
        {
            var connectionString = configuration.GetConnectionString("AzureBlobStorage");
            
            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("ConnectionStrings:AzureBlobStorage (app secret) mangler");

            _blobContainer = new BlobContainerClient(connectionString, "assessments");

            await _blobContainer.CreateIfNotExistsAsync();

            Progress.ProgressBar.Tick(0, $"Laster opp {key}");
            Progress.ProgressBar.MaxTicks = 100;

            var progressHandler = new Progress<long>();
            progressHandler.ProgressChanged += Progress.UploadProgressChanged;

            var bytesToUpload = Encoding.UTF8.GetBytes(value);
            Progress.UploadFileSize = bytesToUpload.Length;

            await using var stream = new MemoryStream(bytesToUpload);
            await _blobContainer.GetBlobClient(key).UploadAsync(stream, progressHandler: progressHandler);
        }

        public static async Task UploadFile(IConfigurationRoot configuration, string path, byte[] value)
        {
            if (_blobContainer == null)
            {
                var connectionString = configuration.GetConnectionString("AzureBlobStorage");

                if (string.IsNullOrEmpty(connectionString))
                    throw new Exception("ConnectionStrings:AzureBlobStorage (app secret) mangler");

                _blobContainer = new BlobContainerClient(connectionString, "assessments");

                await _blobContainer.CreateIfNotExistsAsync();
            }

            var blobClient = _blobContainer.GetBlobClient(path);
            if (!await blobClient.ExistsAsync())
            {
                await using var stream = new MemoryStream(value);
                await blobClient.UploadAsync(stream, overwrite: true);
            }
            else
            {
                var prop = await blobClient.GetPropertiesAsync();
                if (prop.Value.ContentLength != value.Length)
                {
                    // endret!
                    await using var stream = new MemoryStream(value);
                    await blobClient.UploadAsync(stream, overwrite: true);
                }
            }
        }
    }
}
