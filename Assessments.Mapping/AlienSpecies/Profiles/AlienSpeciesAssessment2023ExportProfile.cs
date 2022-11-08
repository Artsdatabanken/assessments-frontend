using Assessments.Mapping.AlienSpecies.Helpers;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Shared.Helpers;
using AutoMapper;

namespace Assessments.Mapping.AlienSpecies.Profiles
{
    public class AlienSpeciesAssessment2023ExportProfile : Profile
    {
        public AlienSpeciesAssessment2023ExportProfile()
        {
            CreateMap<AlienSpeciesAssessment2023, AlienSpeciesAssessment2023Export>()
                .ForMember(dest => dest.AlienSpeciesCategory, opt => opt.MapFrom(src => src.AlienSpeciesCategory.DisplayName()))
                .ForPath(dest => dest.RiskAssessmentGeographicalVariation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ExportProfileHelper.GetGeographicalVariation(src.RiskAssessmentGeographicalVariation)))
                
                ;

        }
    }
}
