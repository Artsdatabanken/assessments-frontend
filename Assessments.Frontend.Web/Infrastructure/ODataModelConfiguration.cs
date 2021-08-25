using Assessments.Mapping.Models.Species;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class ODataModelConfiguration
    {
        public static IEdmModel EdmModel()
        {
            var builder = new ODataConventionModelBuilder
            {
                Namespace = "Artsdatabanken",
                ContainerName = "Assessments"
            };

            builder.EntitySet<SpeciesAssessment2021>("Species2021").EntityType.HasKey(x => x.Id);

            return builder.GetEdmModel();
        }
    }
}