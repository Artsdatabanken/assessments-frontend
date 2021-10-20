using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LazyCache;

namespace Assessments.Frontend.Web.Infrastructure.Services
{
    public class ArtsdatabankenApiService
    {
        private readonly HttpClient _client;
        private readonly IAppCache _appCache;

        public ArtsdatabankenApiService(HttpClient client, IAppCache appCache)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://artsdatabanken.no/api/");
            _client.Timeout = TimeSpan.FromSeconds(15);
            
            _appCache = appCache;
            _appCache.DefaultCachePolicy.DefaultCacheDurationSeconds = 3600; // 1 time mellomlager
        }

        public async Task<T> Get<T>(string path)
        {
            try
            {
                return await _appCache.GetOrAddAsync(path, () => _client.GetFromJsonAsync<T>(path));
            }
            catch (Exception)
            {
                return default;
            }
        }
    }

    public class ArtsdatabankenApiContent
    {
        public ArtsdatabankenApiContentReference[] References { get; set; }
    }

    public class ArtsdatabankenApiContentReference
    {
        public string Heading { get; set; }
        
        public string Url { get; set; }
    }
}