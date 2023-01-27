using System.IO;
using System.Threading.Tasks;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Configuration;

namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public class AttachmentRepository
    {
        private readonly IConfiguration _configuration;
        private BlobContainerClient _containerClient;

        private BlobContainerClient ContainerClient
        {
            get
            {
                if (_containerClient != null) return _containerClient;
                
                var connectionString = _configuration["ConnectionStrings:AzureBlobStorage"];
                if (string.IsNullOrWhiteSpace(connectionString)) throw new System.Exception("Missing required config for azure blog storage: ConnectionStrings:AzureBlobStorage");
                _containerClient = new BlobContainerClient(connectionString, "assessments");
                return _containerClient;
            }
        }

        public AttachmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public async Task<Stream> GetFileStream(string path)
        {
            var blobClient = ContainerClient.GetBlobClient(path);

            try
            {
                var stream = await blobClient.OpenReadAsync();

                return stream;
            }
            catch (RequestFailedException ex) when (ex.ErrorCode == BlobErrorCode.BlobNotFound)
            {
                return null;
            }
        }
    }
}
