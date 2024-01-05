using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;
using Raven.Client.Document;
using Raven.Client;
using System.Net;

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

        public static async Task<string> DownloadFromBlob(IConfigurationRoot configuration, string key)
        {
            var connectionString = configuration.GetConnectionString("AzureBlobStorage");

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("ConnectionStrings:AzureBlobStorage (app secret) mangler");

            _blobContainer = new BlobContainerClient(connectionString, "assessments");

            await _blobContainer.CreateIfNotExistsAsync();

            var blob = _blobContainer.GetBlobClient(key);
            var response = await blob.DownloadContentAsync();

            var fileContent = response.Value.Content.ToString();
            return fileContent;
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

    public class DocumentStoreHolder
    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store
        {
            get { return store.Value; }
        }

        private static IDocumentStore CreateStore()
        {
            IConfigurationRoot configuration = GetConfiguration();

            var documentStore = new DocumentStore()
            {
                Url = configuration.GetConnectionString("RavenDBUrl"),
                DefaultDatabase = configuration.GetConnectionString("RavenDB"),
            };

            var user = configuration.GetConnectionString("RavenDBUser");
            if (!string.IsNullOrWhiteSpace(user))
            {
                var cred = user.Split(':');
                documentStore.Credentials = new NetworkCredential(cred[0], cred[1]);
            }

            documentStore.Initialize();

            documentStore.Conventions.MaxNumberOfRequestsPerSession = 100; //Raven default is 30

            return documentStore;
        }

        private static IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .Build();
        }

        public static IDocumentSession RavenSession
        {
            get
            {
                if (ravenSession == null)
                {
                    ravenSession = Store.OpenSession();
                }
                return ravenSession;
            }
        }

        private static IDocumentSession ravenSession;
    }
}
