using Artsdatabanken;
using Microsoft.Extensions.Options;
using Microsoft.OData.Client;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class AssessmentApiService
    {
        private static IOptions<ApplicationSettings> _settings;
        public readonly DataServiceQuery<Rodliste2015> Redlist2015;

        public AssessmentApiService(IOptions<ApplicationSettings> settings)
        {
            _settings = settings;
            Redlist2015 = Assessments().Redlist2015;
        }

        private static Artsdatabanken.Assessments Assessments() => new (_settings.Value.AssessmentsApi.EndpointUrl);
    }
}