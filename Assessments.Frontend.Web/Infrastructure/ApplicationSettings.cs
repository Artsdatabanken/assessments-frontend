using System;

namespace Assessments.Frontend.Web.Infrastructure
{
    public class ApplicationSettings
    {
        public AssessmentsApi AssessmentsApi { get; set; }
    }

    public class AssessmentsApi
    {
        public Uri EndpointUrl { get; set; }
    }
}