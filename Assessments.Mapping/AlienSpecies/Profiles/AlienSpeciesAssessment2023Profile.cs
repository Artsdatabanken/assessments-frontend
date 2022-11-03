using Assessments.Mapping.AlienSpecies.Source;
using AutoMapper;
using Assessments.Mapping.AlienSpecies.Helpers;
using Assessments.Mapping.AlienSpecies.Model;

namespace Assessments.Mapping.AlienSpecies.Profiles
{
    public class AlienSpeciesAssessment2023Profile : Profile
    {
        public AlienSpeciesAssessment2023Profile()
        {
            CreateMap<FA4, AlienSpeciesAssessment2023>()

                .ForMember(dest => dest.ScientificName, opt => opt.MapFrom(src => src.EvaluatedScientificName))
                .ForMember(dest => dest.ScientificNameId, opt => opt.MapFrom(src => src.EvaluatedScientificNameId))
                .ForMember(dest => dest.ScientificNameAuthor, opt => opt.MapFrom(src => src.EvaluatedScientificNameAuthor))
                .ForMember(dest => dest.VernacularName, opt => opt.MapFrom(src => src.EvaluatedVernacularName))
                .ForMember(dest => dest.AlienSpeciesCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetAlienSpeciesCategory(src.AlienSpeciesCategory, src.ExpertGroup)))
                .ForMember(dest => dest.ExpertGroup, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExpertGroup(src.ExpertGroup)))
                .ForMember(dest => dest.EstablishmentCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetEstablishmentCategory(src.SpeciesEstablishmentCategory, src.SpeciesStatus)))
                .ForMember(dest => dest.ScoreInvationPotential, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetScores(src.Category, src.Criteria, "inv")))
                .ForMember(dest => dest.ScoreEcologicalEffect, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetScores(src.Category, src.Criteria, "eco")))

                ;

            CreateMap<FA4.PreviousAssessment, AlienSpeciesAssessment2023PreviousAssessment>();

            CreateMap<FA4, AlienSpeciesAssessment2023RiskAssessment>()

                .ForMember(dest => dest.GeographicVariationInCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarInCat(src.Category, src.RiskAssessment.PossibleLowerCategory)))
                ;
        }
    }
}