using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class AssessmentsApiClient
    {
        private readonly HttpClient _client;
        private readonly ILogger<AssessmentsApiClient> _logger;

        public AssessmentsApiClient(HttpClient client, ILogger<AssessmentsApiClient> logger)
        {
            _logger = logger;
            _client = client;
        }
        public async Task<T> Get<T>(string query)
        {
            var requestUri = $"{_client.BaseAddress}{query}";

            return await _client.GetFromJsonAsync<T>(requestUri);
        }

        public class Response<T>
        {
            public List<T> Value { get; set; }
        }

        public class Category
        {
            public string Kategori { get; set; }
        }
    }
}
