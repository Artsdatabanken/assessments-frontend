using System.Linq;
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
                .ForMember(dest => dest.EstablishmentCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetEstablishmentCategory(src.SpeciesEstablishmentCategory, src.SpeciesStatus, src.AlienSpeciesCategory)))
                .ForMember(dest => dest.ScoreInvasionPotential, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetScores(src.Category, src.Criteria, "inv")))
                .ForMember(dest => dest.ScoreEcologicalEffect, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetScores(src.Category, src.Criteria, "eco")))
                .ForMember(dest => dest.RiskAssessmentGeographicVariationInCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarInCat(src.Category, src.RiskAssessment.PossibleLowerCategory)))
                .ForMember(dest => dest.RiskAssessmentGeographicalVariation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarCause(src.Category, src.RiskAssessment.PossibleLowerCategory, src.RiskAssessment.GeographicalVariation)))
                .ForMember(dest => dest.RiskAssessmentGeographicalVariationDocumentation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarDoc(src.Category, src.RiskAssessment.PossibleLowerCategory, src.RiskAssessment.GeographicalVariationDocumentation.StripUnwantedHtml())))
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
                .ForMember(dest => dest.ReasonsForChangeOfCategoryDescription, opt => opt.MapFrom(src => src.DescriptionOfReasonsForChangeOfCategory.StripUnwantedHtml()))
                .ForMember(dest => dest.AOOknown, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedSelfReproducing");
                    opt.MapFrom(src => src.RiskAssessment.AOOknownInput);
                })
                .ForMember(dest => dest.AOOtotalLow, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedSelfReproducing");
                    opt.MapFrom(src => src.RiskAssessment.AOOtotalLowInput);
                })
                .ForMember(dest => dest.AOOtotalBest, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedSelfReproducing");
                    opt.MapFrom(src => src.RiskAssessment.AOOtotalBestInput);
                })
                .ForMember(dest => dest.AOOtotalHigh, opt =>
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
                .ForMember(dest => dest.AOOfutureBest, opt =>
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
                .ForMember(dest => dest.MedianLifetimeEstimationMethod, opt => opt.MapFrom(src => src.Category == "NR" || src.RiskAssessment.ChosenSpreadMedanLifespan == "RedListCategoryLevel" ? "NotRelevant" : src.RiskAssessment.ChosenSpreadMedanLifespan == "LifespanA1aSimplifiedEstimate" ? "SimplifiedEstimation" : src.RiskAssessment.ChosenSpreadMedanLifespan == "SpreadRscriptEstimatedSpeciesLongevity" ? "NumericalEstimation" : src.RiskAssessment.ChosenSpreadMedanLifespan))
                .ForMember(dest => dest.IsAcceptedSimplifiedEstimate, opt => opt.MapFrom(src => src.RiskAssessment.AcceptOrAdjustCritA == "accept"))
                .ForMember(dest => dest.DecisiveCriteria, opt => opt.MapFrom(src => src.Criteria))
                .ForMember(dest => dest.DecisiveCriteria, opt => opt.NullSubstitute(string.Empty))
                .ForMember(dest => dest.Criteria, opt => opt.MapFrom(src => src.RiskAssessment.Criteria))
                .ForMember(dest => dest.RegionOccurrences, opt =>
                {
                    opt.PreCondition(src => new[] { "AlienSpecie", "DoorKnocker", "EffectWithoutReproduction" }.Any(x => src.AlienSpeciesCategory.Contains(x)));
                    opt.MapFrom(src => src.Fylkesforekomster.Where(x => x.State2 == 0));
                })
                .ForMember(dest => dest.FreshWaterRegionModel, opt =>
                {
                    opt.PreCondition(src => src.AlienSpeciesCategory == "RegionallyAlien");
                    opt.MapFrom(src => src.ArtskartWaterModel);
                })
                .ForMember(dest => dest.MisIdentifiedDescription, opt => opt.MapFrom(src => src.MisIdentifiedDescription.StripUnwantedHtml()))
                .ForMember(dest => dest.ExtinctionProbability, opt =>
                {
                    opt.PreCondition(src => src.RiskAssessment.Criteria.Count > 0 && src.Category != "NR");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExtinctionProbability(src.RiskAssessment.Criteria));
                })
                .ForMember(dest => dest.MedianLifetimeSimplifiedEstimationDefaultScore, opt =>
                {
                    opt.PreCondition(src => src.Category != "NR");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetMedianLifetimeSimplifiedEstimationDefaultScoreBest(src.AssessmentConclusion, src.RiskAssessment));
                })
                .ForMember(dest => dest.MedianLifetimeSimplifiedEstimationDefaultScoreLow, opt =>
                {
                    opt.PreCondition(src => src.Category != "NR");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetMedianLifetimeSimplifiedEstimationDefaultScoreUncertainty(src.AssessmentConclusion, src.RiskAssessment, "Low"));
                })
                .ForMember(dest => dest.MedianLifetimeSimplifiedEstimationDefaultScoreHigh, opt =>
                {
                    opt.PreCondition(src => src.Category != "NR");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetMedianLifetimeSimplifiedEstimationDefaultScoreUncertainty(src.AssessmentConclusion, src.RiskAssessment, "High"));
                })
                .ForMember(dest => dest.MedianLifetimeSimplifiedEstimationAdjustScoreReason, opt => opt.MapFrom(src => src.RiskAssessment.ReasonForAdjustmentCritA.StripUnwantedHtml()))
                .ForMember(dest => dest.MedianLifetimeNumericalEstimationPopulationSize, opt => opt.MapFrom(src => src.RiskAssessment.PopulationSize))
                .ForMember(dest => dest.MedianLifetimeNumericalEstimationGrowthRate, opt => opt.MapFrom(src => src.RiskAssessment.GrowthRate))
                .ForMember(dest => dest.MedianLifetimeNumericalEstimationEnvironmentalVariance, opt => opt.MapFrom(src => src.RiskAssessment.EnvVariance))
                .ForMember(dest => dest.MedianLifetimeNumericalEstimationDemographicVariance, opt => opt.MapFrom(src => src.RiskAssessment.DemVariance))
                .ForMember(dest => dest.MedianLifetimeNumericalEstimationCarryingCapacity, opt => opt.MapFrom(src => src.RiskAssessment.CarryingCapacity))
                .ForMember(dest => dest.MedianLifetimeNumericalEstimationExtinctionThreshold, opt => opt.MapFrom(src => src.RiskAssessment.ExtinctionThreshold))
                .ForMember(dest => dest.MedianLifetimeBestEstimate, opt =>
                {
                    opt.PreCondition(src => new[] { "SpreadRscriptEstimatedSpeciesLongevity", "ViableAnalysis" }.Any(x => src.RiskAssessment.ChosenSpreadMedanLifespan.Contains(x)));
                    opt.MapFrom(src => src.RiskAssessment.MedianLifetimeInput);
                })
                .ForMember(dest => dest.MedianLifetimeLowEstimate, opt =>
                {
                    opt.PreCondition(src => src.RiskAssessment.ChosenSpreadMedanLifespan == "ViableAnalysis");
                    opt.MapFrom(src => src.RiskAssessment.LifetimeLowerQInput);
                })
                .ForMember(dest => dest.MedianLifetimeHighEstimate, opt =>
                {
                    opt.PreCondition(src => src.RiskAssessment.ChosenSpreadMedanLifespan == "ViableAnalysis");
                    opt.MapFrom(src => src.RiskAssessment.LifetimeUpperQInput);
                })
                .ForMember(dest => dest.MedianLifetimeViabilityAnalysisDescription, opt => opt.MapFrom(src => src.RiskAssessment.SpreadPVAAnalysis.StripUnwantedHtml()))
                .ForMember(dest => dest.ExpansionSpeedEstimationMethod, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExpansionEstimationMethod(src.Category, src.RiskAssessment.ChosenSpreadYearlyIncrease, src.AssessmentConclusion,src.RiskAssessment.AOOfirstOccurenceLessThan10Years)))
                .ForMember(dest => dest.ExpansionSpeedSpatioTemporalDatasetDarkFigureRange, opt =>
                {
                    opt.PreCondition(src => src.Category != "NR");
                    opt.MapFrom(src => src.RiskAssessment.BCritMCount);
                })
                .ForMember(dest => dest.ExpansionSpeedSpatioTemporalDatasetModel, opt =>
                {
                    opt.PreCondition(src => src.Category != "NR");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetSpatioTemporalDatasetModel(src.RiskAssessment.BCritModel));
                })
                .ForMember(dest => dest.ExpansionSpeedSpatioTemporalDatasetOccurrenceListing, opt =>
                {
                    opt.PreCondition(src => src.Category != "NR");
                    opt.MapFrom(src => src.RiskAssessment.BCritOccurrences == "a" ? "FirstYear" : src.RiskAssessment.BCritOccurrences == "b" ? "EveryYear" : "NotRelevant");
                })
                .ForMember(dest => dest.ExpansionSpeedEstimatedIncreaseInAOOFirstYear, opt => opt.MapFrom(src => src.RiskAssessment.AOOyear1))
                .ForMember(dest => dest.ExpansionSpeedEstimatedIncreaseInAOOLastYear, opt => opt.MapFrom(src => src.RiskAssessment.AOOyear2))
                .ForMember(dest => dest.ExpansionSpeedEstimatedIncreaseInAOOFirstAOO, opt => opt.MapFrom(src => src.RiskAssessment.AOOknown1))
                .ForMember(dest => dest.ExpansionSpeedEstimatedIncreaseInAOOLastAOO, opt => opt.MapFrom(src => src.RiskAssessment.AOOknown2))
                .ForMember(dest => dest.ExpansionSpeedEstimatedIncreaseInAOOFirstAOOCorr, opt => opt.MapFrom(src => src.RiskAssessment.AOO1))
                .ForMember(dest => dest.ExpansionSpeedEstimatedIncreaseInAOOLastAOOCorr, opt => opt.MapFrom(src => src.RiskAssessment.AOO2))
                .ForMember(dest => dest.ExpansionSpeedEstimatedIncreaseInAOODescription, opt => opt.MapFrom(src => src.RiskAssessment.CommentOrDescription.StripUnwantedHtml()))
                .ForMember(dest => dest.ExpansionSpeedLowEstimate, opt =>
                {
                    opt.PreCondition(src => src.Category != "NR" && src.EvaluationStatus == "finished");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExpansionSpeedEstimates(src.RiskAssessment, "low", src.AssessmentConclusion));
                })
                .ForMember(dest => dest.ExpansionSpeedBestEstimate, opt =>
                {
                    opt.PreCondition(src => src.Category != "NR" && src.EvaluationStatus == "finished");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExpansionSpeedEstimates(src.RiskAssessment, "best", src.AssessmentConclusion));
                })
                .ForMember(dest => dest.ExpansionSpeedHighEstimate, opt =>
                {
                    opt.PreCondition(src => src.Category != "NR" && src.EvaluationStatus == "finished");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExpansionSpeedEstimates(src.RiskAssessment, "high", src.AssessmentConclusion));
                })
                .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src => src.Attachmemnts))

                .AfterMap((_, dest) => dest.PreviousAssessments = AlienSpeciesAssessment2023ProfileHelper.GetPreviousAssessments(dest.PreviousAssessments));

            CreateMap<FA4.PreviousAssessment, AlienSpeciesAssessment2023PreviousAssessment>(MemberList.None);

            CreateMap<RiskAssessment.Criterion, AlienSpeciesAssessment2023Criterion>(MemberList.None)
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value + 1))
                .ForMember(dest => dest.UncertaintyValues, opt => opt.MapFrom(src => src.UncertaintyValues.OrderBy(x => x).Select(x => x + 1)));

            CreateMap<Fylkesforekomst, AlienSpeciesAssessment2023RegionOccurrence>(MemberList.None)
                .ForMember(dest => dest.Region, opt => opt.MapFrom(src => src.Fylke))
                .ForMember(dest => dest.IsKnown, opt => opt.MapFrom(src => src.State0 == 1))
                .ForMember(dest => dest.IsAssumedToday, opt => opt.MapFrom(src => src.State1 == 1))
                .ForMember(dest => dest.IsAssumedInFuture, opt => opt.MapFrom(src => src.State3 == 1));

            CreateMap<ArtskartWaterModel, AlienSpeciesAssessment2023FreshWaterRegionModel>(MemberList.None)
                .ForMember(dest => dest.FreshWaterRegions, opt => opt.MapFrom(src => src.Areas));

            CreateMap<ArtskartWaterAreaModel, AlienSpeciesAssessment2023FreshWaterRegion>(MemberList.None)
                .ForMember(dest => dest.WaterRegionId, opt => opt.MapFrom(src => src.VannregionId))
                .ForMember(dest => dest.IsIncludedInAssessmentArea, opt => opt.MapFrom(src => src.Disabled == 0 && src.Selected == 1))
                .ForMember(dest => dest.IsKnown, opt => opt.MapFrom(src => src.State0 == 1))
                .ForMember(dest => dest.IsAssumedToday, opt => opt.MapFrom(src => src.State1 == 1))
                .ForMember(dest => dest.IsAssumedInFuture, opt => opt.MapFrom(src => src.State3 == 1));

            CreateMap<Attachment, AlienSpeciesAssessment2023Attachment>(MemberList.None);
        }
    }
}