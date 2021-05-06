using Artsdatabanken;
using Microsoft.Extensions.Options;
using Microsoft.OData.Client;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class AssessmentApiService
    {
        private static IOptions<ApplicationSettings> _settings;
        private static Artsdatabanken.Assessments Assessments() => new (_settings.Value.AssessmentsApi.EndpointUrl);

        public readonly DataServiceQuery<Rodliste2015> Redlist2015;

        public readonly DataServiceQuery<Redlist2006Assessment> Redlist2006;

        public AssessmentApiService(IOptions<ApplicationSettings> settings)
        {
            _settings = settings;
            Redlist2015 = Assessments().Redlist2015;
            Redlist2006 = Assessments().Redlist2006;
        }
    }
}