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
                .ForPath(dest => dest.RiskAssessment.GeographicVariationInCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarInCat(src.Category, src.RiskAssessment.PossibleLowerCategory)))
                .ForPath(dest => dest.RiskAssessment.GeographicalVariation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarCause(src.Category, src.RiskAssessment.PossibleLowerCategory, src.RiskAssessment.GeographicalVariation)))
                .ForPath(dest => dest.RiskAssessment.GeographicalVariationDocumentation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarDoc(src.Category, src.RiskAssessment.PossibleLowerCategory, src.RiskAssessment.GeographicalVariationDocumentation)))
                .ForPath(dest => dest.RiskAssessment.ClimateEffectsInvationpotential, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetClimateEffectsInvationpotential(src.Category, src.Criteria, src.RiskAssessment.ClimateEffectsInvationpotential)))
                .ForPath(dest => dest.RiskAssessment.ClimateEffectsEcoEffect, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetClimateEffectsEcoEffect(src.Category, src.Criteria, src.RiskAssessment.ClimateEffectsEcoEffect)))
                .ForPath(dest => dest.RiskAssessment.ClimateEffectsDocumentation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetClimateEffectsDoc(src.Category, src.Criteria, src.RiskAssessment.ClimateEffectsInvationpotential, src.RiskAssessment.ClimateEffectsEcoEffect, src.RiskAssessment.ClimateEffectsDocumentation)))
                ;

            CreateMap<FA4.PreviousAssessment, AlienSpeciesAssessment2023PreviousAssessment>();

            CreateMap<RiskAssessment, AlienSpeciesAssessment2023RiskAssessment>()
                .ForMember(dest => dest.GeographicVariationInCategory, opt => opt.MapFrom(src => src.PossibleLowerCategory))
                //.ForMember(dest => dest.GeographicalVariationDocumentation, opt =>
                //{
                //    opt.PreCondition((src, dest, context) => (dest.GeographicVariationInCategory == true));
                //    opt.MapFrom(src => src.GeographicalVariationDocumentation);
                //})
                ;
        }
    }
}