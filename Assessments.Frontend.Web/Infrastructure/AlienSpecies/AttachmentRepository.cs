using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public class AttachmentRepository
    {

        private readonly IConfiguration _configuration;
        private BlobContainerClient _containerClient;

        public BlobContainerClient ContainerClient
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
        
        public async Task<MemoryStream> GetFileStream(string path)
        {
            var stream = new MemoryStream();
            var response = await ContainerClient.GetBlobClient(path).DownloadToAsync(stream);
            stream.Position = 0;
            return stream;
        }
    }
}
