using System.Linq;
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
                .ForMember(dest => dest.RiskAssessmentGeographicalVariation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ExportProfileHelper.GetGeographicalVariation(src.GeographicalVariation)))
                .ForMember(dest => dest.PreviousAssessmentCategory2018, opt =>
                {
                    opt.PreCondition(src => src.PreviousAssessments.Any(x => x.RevisionYear == 2018));
                    opt.MapFrom(src => src.PreviousAssessments.First(x => x.RevisionYear == 2018).Category);
                })
                .ForMember(dest => dest.MedianLifetimeEstimationMethod, opt => opt.MapFrom(src => src.MedianLifetimeEstimationMethod.DisplayName()))
                .ForMember(dest => dest.IsAcceptedSimplifiedEstimate, opt => {
                    opt.PreCondition(src => src.MedianLifetimeEstimationMethod.DisplayName() == "Forenklet anslag");
                    opt.MapFrom(src => src.IsAcceptedSimplifiedEstimate);
                })
                .ForMember(dest => dest.ExpansionSpeedEstimationMethod, opt => opt.MapFrom(src => src.ExpansionSpeedEstimationMethod.DisplayName()))
                ;
        }
    }
}
