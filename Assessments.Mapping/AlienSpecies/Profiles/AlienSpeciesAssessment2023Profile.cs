using Assessments.Mapping.AlienSpecies.Helpers;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Source;
using Assessments.Shared.Helpers;
using AutoMapper;

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
                .ForMember(dest => dest.ScientificNameRank, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetTaxonRank(src.EvaluatedScientificNameRank)))
                .ForMember(dest => dest.VernacularName, opt => opt.MapFrom(src => src.EvaluatedVernacularName))
                .ForMember(dest => dest.AlienSpeciesCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetAlienSpeciesCategory(src.AlienSpeciesCategory, src.ExpertGroup)))
                .ForMember(dest => dest.ExpertGroup, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExpertGroup(src.ExpertGroup)))
                .ForMember(dest => dest.EstablishmentCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetEstablishmentCategory(src.SpeciesEstablishmentCategory, src.SpeciesStatus)))
                .ForMember(dest => dest.ScoreInvationPotential, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetScores(src.Category, src.Criteria, "inv")))
                .ForMember(dest => dest.ScoreEcologicalEffect, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetScores(src.Category, src.Criteria, "eco")))
                .ForMember(dest => dest.RiskAssessmentGeographicVariationInCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarInCat(src.Category, src.RiskAssessment.PossibleLowerCategory)))
                .ForMember(dest => dest.RiskAssessmentGeographicalVariation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarCause(src.Category, src.RiskAssessment.PossibleLowerCategory, src.RiskAssessment.GeographicalVariation)))
                .ForMember(dest => dest.RiskAssessmentGeographicalVariationDocumentation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarDoc(src.Category, src.RiskAssessment.PossibleLowerCategory, src.RiskAssessment.GeographicalVariationDocumentation)))
                .ForMember(dest => dest.RiskAssessmentClimateEffectsInvationpotential, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetClimateEffects(src.Category, src.Criteria, "inv", src.RiskAssessment)))
                .ForMember(dest => dest.RiskAssessmentClimateEffectsEcoEffect, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetClimateEffects(src.Category, src.Criteria, "eco", src.RiskAssessment)))
                .ForMember(dest => dest.RiskAssessmentClimateEffectsDocumentation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetClimateEffectsDoc(src.Category, src.Criteria, src.RiskAssessment, src.RiskAssessment.ClimateEffectsDocumentation)))
                .ForMember(dest => dest.SpeciesGroup, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetSpeciesGroup(src.TaxonHierarcy)))
                .ForMember(dest => dest.RiskAssessmentCriteriaDocumentation, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentation.StripUnwantedHtml()))
                .ForMember(dest => dest.RiskAssessmentCriteriaDocumentationSpeciesStatus, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentationSpeciesStatus.StripUnwantedHtml()))
                .ForMember(dest => dest.RiskAssessmentCriteriaDocumentationDomesticSpread, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentationDomesticSpread.StripUnwantedHtml()))
                .ForMember(dest => dest.UncertaintyStatusDescription, opt => opt.MapFrom(src => src.UncertainityStatusDescription.StripUnwantedHtml()))
                .ForMember(dest => dest.HasIndoorProduction, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetHasIndoorProduction(src.IndoorProduktion)))
                .ForMember(dest => dest.SpreadIndoorFurtherInfo, opt => opt.MapFrom(src => src.SpreadIndoorFurtherInfo.StripUnwantedHtml()))
                .ForMember(dest => dest.SpreadIntroductionFurtherInfo, opt => opt.MapFrom(src => src.SpreadIntroductionFurtherInfo.StripUnwantedHtml()))
                .ForMember(dest => dest.SpreadFurtherSpreadFurtherInfo, opt => opt.MapFrom(src => src.SpreadFurtherSpreadFurtherInfo.StripUnwantedHtml()))

                .AfterMap((_, dest) => dest.PreviousAssessments = AlienSpeciesAssessment2023ProfileHelper.GetPreviousAssessments(dest.PreviousAssessments))
                ;

            CreateMap<FA4.PreviousAssessment, AlienSpeciesAssessment2023PreviousAssessment>(MemberList.None);
        }
    }
}