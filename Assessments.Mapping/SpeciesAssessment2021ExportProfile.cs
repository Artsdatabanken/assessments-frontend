using Assessments.Mapping.Models.Species;
using AutoMapper;

namespace Assessments.Mapping
{
    public class SpeciesAssessment2021ExportProfile : Profile
    {
        public SpeciesAssessment2021ExportProfile()
        {
            CreateMap<SpeciesAssessment2021, SpeciesAssessment2021Export>();
        }
    }
}