using Assessments.Api.Data.Models.Redlist;
using Default;
using Microsoft.Extensions.Options;
using Microsoft.OData.Client;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class AssessmentApiService
    {
        public readonly DataServiceQuery<Rodliste2015> Redlist2015;

        private static IOptions<ApplicationSettings> _applicationSettings;

        public AssessmentApiService(IOptions<ApplicationSettings> applicationSettings)
        {
            _applicationSettings = applicationSettings;
            
            Redlist2015 = Container().Redlist;
        }

        private static Container Container()
        {
            var container = new Container(_applicationSettings.Value.AssessmentsApi.EndpointUrl);

            return container;
        }
    }
}