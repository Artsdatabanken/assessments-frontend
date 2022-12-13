﻿using System.Linq;
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
                .ForMember(dest => dest.ExpertGroup, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExpertGroup(src.ExpertGroup).Trim()))
                .ForMember(dest => dest.EstablishmentCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetEstablishmentCategory(src.SpeciesEstablishmentCategory, src.SpeciesStatus)))
                .ForMember(dest => dest.ScoreInvasionPotential, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetScores(src.Category, src.Criteria, "inv")))
                .ForMember(dest => dest.ScoreEcologicalEffect, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetScores(src.Category, src.Criteria, "eco")))
                .ForMember(dest => dest.RiskAssessmentGeographicVariationInCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarInCat(src.Category, src.RiskAssessment.PossibleLowerCategory)))
                .ForMember(dest => dest.RiskAssessmentGeographicalVariation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarCause(src.Category, src.RiskAssessment.PossibleLowerCategory, src.RiskAssessment.GeographicalVariation)))
                .ForMember(dest => dest.RiskAssessmentGeographicalVariationDocumentation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarDoc(src.Category, src.RiskAssessment.PossibleLowerCategory, src.RiskAssessment.GeographicalVariationDocumentation)))
                .ForMember(dest => dest.RiskAssessmentClimateEffectsInvasionpotential, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetClimateEffects(src.Category, src.Criteria, "inv", src.RiskAssessment)))
                .ForMember(dest => dest.RiskAssessmentClimateEffectsEcoEffect, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetClimateEffects(src.Category, src.Criteria, "eco", src.RiskAssessment)))
                .ForMember(dest => dest.RiskAssessmentClimateEffectsDocumentation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetClimateEffectsDoc(src.Category, src.Criteria, src.RiskAssessment, src.RiskAssessment.ClimateEffectsDocumentation)))
                .ForMember(dest => dest.SpeciesGroup, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetSpeciesGroup(src.TaxonHierarcy)))
                .ForMember(dest => dest.RiskAssessmentCriteriaDocumentation, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentation.StripUnwantedHtml()))
                .ForMember(dest => dest.RiskAssessmentCriteriaDocumentationSpeciesStatus, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentationSpeciesStatus.StripUnwantedHtml()))
                .ForMember(dest => dest.RiskAssessmentCriteriaDocumentationDomesticSpread, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentationDomesticSpread.StripUnwantedHtml()))
                .ForMember(dest => dest.RiskAssessmentCriteriaDocumentationEcoEffect, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentationEcoEffect.StripUnwantedHtml()))
                .ForMember(dest => dest.RiskAssessmentCriteriaDocumentationInvasionPotential, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentationInvationPotential.StripUnwantedHtml()))
                .ForMember(dest => dest.UncertaintyStatusDescription, opt => opt.MapFrom(src => src.UncertainityStatusDescription.StripUnwantedHtml()))
                .ForMember(dest => dest.HasIndoorProduction, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetHasIndoorProduction(src.IndoorProduktion)))
                .ForMember(dest => dest.SpreadIndoorFurtherInfo, opt => opt.MapFrom(src => src.SpreadIndoorFurtherInfo.StripUnwantedHtml()))
                .ForMember(dest => dest.SpreadFurtherSpreadFurtherInfo, opt => opt.MapFrom(src => src.SpreadFurtherSpreadFurtherInfo.StripUnwantedHtml()))
                .ForMember(dest => dest.ChangedFromAlienDescription, opt => opt.MapFrom(src => src.ChangedAssessment.StripUnwantedHtml()))
                .ForMember(dest => dest.ConnectedToHigherLowerTaxonDescription, opt => opt.MapFrom(src => src.ConnectedToHigherLowerTaxonDescription.StripUnwantedHtml()))
                .ForMember(dest => dest.UncertaintyEstablishmentTimeDescription, opt => opt.MapFrom(src => src.UncertainityEstablishmentTimeDescription.StripUnwantedHtml()))
                .ForMember(dest => dest.ChangedFromAlien, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetAlienSpeciesAssessment2023Changed(src.ChangedFromAlien)))
                .ForMember(dest => dest.Environment, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetEnvironmentEnum(src.Limnic, src.Marine, src.Terrestrial)))

                .ForMember(dest => dest.RiskAssessmentAOOknown, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedSelfReproducing");
                    opt.MapFrom(src => src.RiskAssessment.AOOknownInput);
                })
                .ForMember(dest => dest.RiskAssessmentAOOtotalLow, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedSelfReproducing");
                    opt.MapFrom(src => src.RiskAssessment.AOOtotalLowInput);
                })
                .ForMember(dest => dest.RiskAssessmentAOOtotalBest, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedSelfReproducing");
                    opt.MapFrom(src => src.RiskAssessment.AOOtotalBestInput);
                })
                .ForMember(dest => dest.RiskAssessmentAOOtotalHigh, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedSelfReproducing");
                    opt.MapFrom(src => src.RiskAssessment.AOOtotalHighInput);
                })
                .ForMember(dest => dest.AlienSpeciesDescription, opt => opt.MapFrom(src => src.IsAlien.StripUnwantedHtml()))
                .ForMember(dest => dest.RiskAssessmentAOOfutureLow, opt =>
                {
                    //TODO: remove precondition when all assessments are finished (before innsynet)
                    opt.PreCondition(src => src.EvaluationStatus == "finished");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetAOOfuture(src, src.RiskAssessment, "low"));
                })
                 .ForMember(dest => dest.RiskAssessmentAOOfutureBest, opt =>
                 {
                     //TODO: remove precondition when all assessments are finished (before innsynet)
                     opt.PreCondition(src => src.EvaluationStatus == "finished");
                     opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetAOOfuture(src, src.RiskAssessment, "best"));
                 })
                 .ForMember(dest => dest.RiskAssessmentAOOfutureHigh, opt =>
                 {
                     //TODO: remove precondition when all assessments are finished (before innsynet)
                     opt.PreCondition(src => src.EvaluationStatus == "finished");
                     opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetAOOfuture(src, src.RiskAssessment, "high"));
                 })
                 .ForMember(dest => dest.CurrentPresenceComment, opt => opt.MapFrom(src => src.CurrentPresenceComment.StripUnwantedHtml()))
                 .ForMember(dest => dest.RiskAssessmentOccurrences1Low, opt =>
                 {
                     opt.PreCondition(src => src.AssessmentConclusion == "AssessedDoorknocker");
                     opt.MapFrom(src => src.RiskAssessment.Occurrences1Low);
                 })
                 .ForMember(dest => dest.RiskAssessmentOccurrences1Best, opt =>
                 {
                     opt.PreCondition(src => src.AssessmentConclusion == "AssessedDoorknocker");
                     opt.MapFrom(src => src.RiskAssessment.Occurrences1Best);
                 })
                 .ForMember(dest => dest.RiskAssessmentOccurrences1High, opt =>
                 {
                     opt.PreCondition(src => src.AssessmentConclusion == "AssessedDoorknocker");
                     opt.MapFrom(src => src.RiskAssessment.Occurrences1High);
                 })
                 .ForMember(dest => dest.RiskAssessmentIntroductionsLow, opt =>
                 {
                     opt.PreCondition(src => src.AssessmentConclusion == "AssessedDoorknocker");
                     opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.IntroductionsLow(src.RiskAssessment));
                 })
                 .ForMember(dest => dest.RiskAssessmentIntroductionsBest, opt =>
                 {
                     opt.PreCondition(src => src.AssessmentConclusion == "AssessedDoorknocker");
                     opt.MapFrom(src => src.RiskAssessment.IntroductionsBest);
                 })
                  .ForMember(dest => dest.RiskAssessmentIntroductionsHigh, opt =>
                  {
                      opt.PreCondition(src => src.AssessmentConclusion == "AssessedDoorknocker");
                      opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.IntroductionsHigh(src.RiskAssessment));
                  })
                  .ForMember(dest => dest.MedianLifetimeEstimationMethod, opt => opt.MapFrom(src => src.Category == "NR" || src.RiskAssessment.ChosenSpreadMedanLifespan == "RedListCategoryLevel" ? "NotRelevant" : src.RiskAssessment.ChosenSpreadMedanLifespan))
                  .ForMember(dest => dest.IsAcceptedSimplifiedEstimate, opt => opt.MapFrom(src => src.RiskAssessment.AcceptOrAdjustCritA == "accept"))
                .ForMember(dest => dest.DecisiveCriteria, opt => opt.MapFrom(src => src.Criteria))
                .ForMember(dest => dest.Criteria, opt => opt.MapFrom(src => src.RiskAssessment.Criteria))

                .AfterMap((_, dest) => dest.PreviousAssessments = AlienSpeciesAssessment2023ProfileHelper.GetPreviousAssessments(dest.PreviousAssessments))
                ;

            CreateMap<FA4.PreviousAssessment, AlienSpeciesAssessment2023PreviousAssessment>(MemberList.None);
           
            CreateMap<RiskAssessment.Criterion, AlienSpeciesAssessment2023Criterion>(MemberList.None)
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value + 1))
                .ForMember(dest => dest.UncertaintyValues, opt => opt.MapFrom(src => src.UncertaintyValues.OrderBy(x => x).Select(x => x + 1)));
        }
    }
}