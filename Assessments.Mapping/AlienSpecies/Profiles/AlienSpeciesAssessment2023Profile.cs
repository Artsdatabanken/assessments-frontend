﻿using Assessments.Mapping.AlienSpecies.Helpers;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Mapping.AlienSpecies.Source;
using Assessments.Shared.Helpers;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessments.Mapping.AlienSpecies.Profiles
{
    public class AlienSpeciesAssessment2023Profile : Profile
    {
        public AlienSpeciesAssessment2023Profile()
        {
            CreateMap<FA4, AlienSpeciesAssessment2023>()
                .ForMember(dest => dest.ScientificName, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetScientificName(src)))
                .ForMember(dest => dest.NameHiearchy, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetNameHiearchy(src.NameHiearchy)))
                .ForMember(dest => dest.VernacularName, opt => opt.MapFrom(src => src.EvaluatedVernacularName))
                .ForMember(dest => dest.AlienSpeciesCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetAlienSpeciesCategory(src.AlienSpeciesCategory, src.ExpertGroup)))
                .ForMember(dest => dest.ExpertGroup, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExpertGroup(src.ExpertGroup).Trim()))
                .ForMember(dest => dest.EstablishmentCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetEstablishmentCategory(src.SpeciesEstablishmentCategory, src.SpeciesStatus, src.AlienSpeciesCategory)))
                .ForMember(dest => dest.ScoreInvasionPotential, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetScoreInvasionPotential(src.Category, src.Criteria)))
                .ForMember(dest => dest.ScoreEcologicalEffect, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetScoreEcologicalEffect(src.Category, src.Criteria)))
                .ForMember(dest => dest.GeographicVariationInCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarInCat(src.Category, src.RiskAssessment.PossibleLowerCategory)))
                .ForMember(dest => dest.GeographicalVariation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarCause(src.Category, src.RiskAssessment.PossibleLowerCategory, src.RiskAssessment.GeographicalVariation, AlienSpeciesAssessment2023ProfileHelper.GetEnvironmentEnum(src.Limnic, src.Marine, src.Terrestrial))))
                .ForMember(dest => dest.GeographicalVariationDocumentation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetGeographicVarDoc(src.Category, src.RiskAssessment.PossibleLowerCategory, src.RiskAssessment.GeographicalVariationDocumentation.StripUnwantedHtml())))
                .ForMember(dest => dest.ClimateEffectsInvasionpotential, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetClimateEffects(src.Category, src.Criteria, "inv", src.RiskAssessment)))
                .ForMember(dest => dest.ClimateEffectsEcoEffect, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetClimateEffects(src.Category, src.Criteria, "eco", src.RiskAssessment)))
                .ForMember(dest => dest.ClimateEffectsDocumentation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetClimateEffectsDoc(src.Category, src.Criteria, src.RiskAssessment, src.RiskAssessment.ClimateEffectsDocumentation)))
                .ForMember(dest => dest.SpeciesGroup, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetSpeciesGroup(src.TaxonHierarcy)))
                .ForMember(dest => dest.CriteriaDocumentation, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentation.StripUnwantedHtml()))
                .ForMember(dest => dest.CriteriaDocumentationSpeciesStatus, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentationSpeciesStatus.StripUnwantedHtml()))
                .ForMember(dest => dest.CriteriaDocumentationDomesticSpread, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentationDomesticSpread.StripUnwantedHtml()))
                .ForMember(dest => dest.CriteriaDocumentationEcoEffect, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentationEcoEffect.StripUnwantedHtml()))
                .ForMember(dest => dest.CriteriaDocumentationInvasionPotential, opt => opt.MapFrom(src => src.RiskAssessment.CriteriaDocumentationInvationPotential.StripUnwantedHtml()))
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
                .ForMember(dest => dest.IntroductionAndSpreadPathways, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetIntroductionPathways(src.AssesmentVectors)))
                .ForMember(dest => dest.ImportPathways, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetIntroductionPathways(src.ImportPathways)))
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
                .ForMember(dest => dest.AOOfutureLow, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetAOOfuture(src, src.RiskAssessment, "low")))
                .ForMember(dest => dest.AOOfutureBest, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetAOOfuture(src, src.RiskAssessment, "best")))
                .ForMember(dest => dest.AOOfutureHigh, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetAOOfuture(src, src.RiskAssessment, "high")))
                .ForMember(dest => dest.AOOknownYearOne, opt => opt.MapFrom(src => src.RiskAssessment.AOOendyear1))
                .ForMember(dest => dest.AOOknownYearTwo, opt => opt.MapFrom(src => src.RiskAssessment.AOOendyear2))
                .ForMember(dest => dest.CurrentPresenceComment, opt => opt.MapFrom(src => src.CurrentPresenceComment.StripUnwantedHtml()))
                .ForMember(dest => dest.Occurrences1Low, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedDoorknocker");
                    opt.MapFrom(src => src.RiskAssessment.Occurrences1Low);
                })
                .ForMember(dest => dest.Occurrences1Best, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedDoorknocker");
                    opt.MapFrom(src => src.RiskAssessment.Occurrences1Best);
                })
                .ForMember(dest => dest.Occurrences1High, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedDoorknocker");
                    opt.MapFrom(src => src.RiskAssessment.Occurrences1High);
                })
                .ForMember(dest => dest.IntroductionsLow, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedDoorknocker");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.IntroductionsLow(src.RiskAssessment));
                })
                .ForMember(dest => dest.IntroductionsBest, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedDoorknocker");
                    opt.MapFrom(src => src.RiskAssessment.IntroductionsBest);
                })
                .ForMember(dest => dest.IntroductionsHigh, opt =>
                {
                    opt.PreCondition(src => src.AssessmentConclusion == "AssessedDoorknocker");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.IntroductionsHigh(src.RiskAssessment));
                })
                .ForMember(dest => dest.MedianLifetimeEstimationMethod, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetMedianLifetimeEstimationMethod(src.Category, src.RiskAssessment.ChosenSpreadMedanLifespan)))
                .ForMember(dest => dest.IsAcceptedSimplifiedEstimate, opt => opt.MapFrom(src => src.RiskAssessment.AcceptOrAdjustCritA == "accept"))
                .ForMember(dest => dest.DecisiveCriteria, opt => opt.MapFrom(src => src.Criteria))
                .ForMember(dest => dest.DecisiveCriteria, opt => opt.NullSubstitute(string.Empty))
                .ForMember(dest => dest.Criteria, opt => opt.MapFrom(src => src.RiskAssessment.Criteria))
                .ForMember(dest => dest.RegionOccurrences, opt =>
                {
                    opt.PreCondition(src => new[] { "AlienSpecie", "DoorKnocker", "EffectWithoutReproduction" }.Any(x => src.AlienSpeciesCategory.Contains(x)));
                    opt.MapFrom(src => src.ExpertGroup.Contains("Svalbard") ? src.Fylkesforekomster.Where(x => x.State2 == 0 && x.Fylke == "Sv") : src.Fylkesforekomster.Where(x => x.State2 == 0 & x.Fylke != "Sv"));
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
                .ForMember(dest => dest.ExpansionSpeedEstimationMethod, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExpansionEstimationMethod(src.Category, src.RiskAssessment.ChosenSpreadYearlyIncrease, src.AssessmentConclusion, src.RiskAssessment.AOOfirstOccurenceLessThan10Years)))
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
                    opt.PreCondition(src => src.Category != "NR" && src.AlienSpeciesCategory != "TaxonEvaluatedAtAnotherLevel");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExpansionSpeedEstimates(src.RiskAssessment, "low", src.AssessmentConclusion));
                })
                .ForMember(dest => dest.ExpansionSpeedBestEstimate, opt =>
                {
                    opt.PreCondition(src => src.Category != "NR" && src.AlienSpeciesCategory != "TaxonEvaluatedAtAnotherLevel");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExpansionSpeedEstimates(src.RiskAssessment, "best", src.AssessmentConclusion));
                })
                .ForMember(dest => dest.ExpansionSpeedHighEstimate, opt =>
                {
                    opt.PreCondition(src => src.Category != "NR" && src.AlienSpeciesCategory != "TaxonEvaluatedAtAnotherLevel");
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetExpansionSpeedEstimates(src.RiskAssessment, "high", src.AssessmentConclusion));
                })
                .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src => src.Attachmemnts))
                .ForMember(dest => dest.ParentAssessmentId, opt => opt.MapFrom(src => src.ParentAssessmentId))
                .ForMember(dest => dest.SpeciesSpeciesInteractions, opt => opt.MapFrom(src => src.RiskAssessment.SpeciesSpeciesInteractions.Where(x => !(new[] { "VU", "EN", "CR" }.Any(y => x.RedListCategory.Contains(y)) || x.KeyStoneSpecie))))
                .ForMember(dest => dest.SpeciesSpeciesInteractionsThreatenedSpecies, opt => opt.MapFrom(src => src.RiskAssessment.SpeciesSpeciesInteractions.Where(x => new[] { "VU", "EN", "CR" }.Any(y => x.RedListCategory.Contains(y)) || x.KeyStoneSpecie)))
                .ForMember(dest => dest.SpeciesNaturetypeInteractions, opt => opt.MapFrom(src => src.RiskAssessment.SpeciesNaturetypeInteractions))
                .ForMember(dest => dest.SpeciesNaturetypeInteractionsThreatenedSpecies, opt => opt.MapFrom(src => src.RiskAssessment.SpeciesNaturetypeInteractions.Where(x => x.KeyStoneSpecie)))
                .ForMember(dest => dest.EffectsOnSpeciesSupplementaryInformation, opt => opt.MapFrom(src => src.RiskAssessment.SpeciesSpeciesInteractionsSupplementaryInformation.StripUnwantedHtml()))
                .ForMember(dest => dest.EffectsOnThreathenedSpeciesUncertaintyDocumentation, opt => opt.MapFrom(src => src.RiskAssessment.DCritInsecurity.StripUnwantedHtml()))
                .ForMember(dest => dest.EffectsOnOtherNativeSpeciesUncertaintyDocumentation, opt => opt.MapFrom(src => src.RiskAssessment.ECritInsecurity.StripUnwantedHtml()))
                .ForMember(dest => dest.ThreatenedNatureTypesAffectedDomesticDescription, opt => opt.MapFrom(src => src.RiskAssessment.ThreatenedNatureTypesAffectedDomesticDescription.StripUnwantedHtml()))
                .ForMember(dest => dest.CommonNatureTypesAffectedDomesticDescription, opt => opt.MapFrom(src => src.RiskAssessment.CommonNatureTypesAffectedDomesticDescription.StripUnwantedHtml()))
                .ForMember(dest => dest.GeneticContamination, opt => opt.MapFrom(src => src.RiskAssessment.GeneticTransferDocumented))
                .ForMember(dest => dest.GeneticContaminationUncertaintyDocumentation, opt => opt.MapFrom(src => src.RiskAssessment.HCritInsecurity.StripUnwantedHtml()))
                .ForMember(dest => dest.ParasitePathogenTransmission, opt => opt.MapFrom(src => src.RiskAssessment.HostParasiteInformations))
                .ForMember(dest => dest.ParasitePathogenTransmissionUncertaintyDocumentation, opt => opt.MapFrom(src => src.RiskAssessment.ICritInsecurity.StripUnwantedHtml()))
                .ForMember(dest => dest.MicroHabitat, opt => opt.MapFrom(src => src.Habitats))
                .ForPath(dest => dest.YearsFirstRecord.ObservedEstablishmentInNorway, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetYearsFirstObserved(src.RiskAssessment, src.SpeciesStatus)))
                .ForPath(dest => dest.YearsFirstRecord.Description, opt => opt.MapFrom(src => src.FurtherInfo.StripUnwantedHtml()))
                .ForMember(dest => dest.NaturalOrigins, opt => opt.PreCondition(src => src.Terrestrial || src.Limnic))
                .ForMember(dest => dest.NaturalOriginUnknownDocumentation, opt => opt.MapFrom(src => src.NaturalOriginUnknownDocumentation.StripUnwantedHtml()))
                .ForMember(dest => dest.NaturalOriginMarine, opt => opt.PreCondition(src => src.Marine))
                .ForMember(dest => dest.NaturalOriginMarineDetails, opt => opt.MapFrom(src => src.NaturalOriginMarineDetails.StripUnwantedHtml()))
                .ForMember(dest => dest.CurrentInternationalExistenceAreas, opt => opt.PreCondition(src => src.Terrestrial || src.Limnic))
                .ForMember(dest => dest.CurrentInternationalExistenceAreasUnknownDocumentation, opt => opt.MapFrom(src => src.CurrentInternationalExistenceAreasUnknownDocumentation.StripUnwantedHtml()))
                .ForMember(dest => dest.CurrentInternationalExistenceMarineAreas, opt => opt.PreCondition(src => src.Marine))
                .ForMember(dest => dest.CurrentInternationalExistenceMarineAreasDetails, opt => opt.MapFrom(src => src.CurrentInternationalExistenceMarineAreasDetails.StripUnwantedHtml()))
                .ForMember(dest => dest.GenerationTime, opt => opt.MapFrom(src => src.ReproductionGenerationTime))
                .ForMember(dest => dest.ArrivedCountryFrom, opt => opt.PreCondition(src => src.ArrivedCountryFrom is not null && src.ArrivedCountryFrom.Count > 0))
                .ForMember(dest => dest.ArrivedCountryFromDetails, opt => opt.MapFrom(src => src.ArrivedCountryFromDetails.StripUnwantedHtml()))
                .ForMember(dest => dest.AreaOfOccupancyInStronglyAlteredEcosystems, opt => opt.MapFrom(src => src.RiskAssessment.SpreadHistoryDomesticAreaInStronglyChangedNatureTypes.HasValue ? "Value" + src.RiskAssessment.SpreadHistoryDomesticAreaInStronglyChangedNatureTypes.ToString() : "Value0"))
                .ForMember(dest => dest.AllSubTaxaAssessedSeparatelyDescription, opt => opt.MapFrom(src => src.AllSubTaxaAssessedSeparatelyDescription.StripUnwantedHtml()))
                .ForMember(dest => dest.HybridWithoutOwnRiskAssessmentDescription, opt => opt.MapFrom(src => src.IsHybridWithoutOwnRiskAssessmentDescription.StripUnwantedHtml()))
                .ForMember(dest => dest.SpeciesStatus, opt =>
                {
                    opt.PreCondition(src => src.AlienSpeciesCategory != AlienSpeciecAssessment2023AlienSpeciesCategory.NotAlienSpecie.ToString() && src.SpeciesStatus is not null);
                    opt.MapFrom(x => x.SpeciesStatus == "A" ? AlienSpeciesAssessment2023SpeciesStatus.Abroad.ToString() : x.SpeciesStatus);
                })
                .ForMember(dest => dest.CoastLineSections, opt => opt.PreCondition(src => src.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.AlienSpecie.ToString() && src.CoastLineSections.Any(x => x.Skagerrak || x.None || x.OpenCoastLine)))
                .ForMember(dest => dest.CurrentBioClimateZones, opt => opt.PreCondition(src => src.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.AlienSpecie.ToString() && src.CurrentBioClimateZones.Any(x => x.StrongOceanic || x.ClearOceanic || x.WeakOceanic || x.TransferSection || x.WeakContinental) && src.Terrestrial))
                .ForMember(dest => dest.ArcticBioClimateZones, opt => opt.PreCondition(src => src.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.AlienSpecie.ToString() && src.ArcticBioClimateZones.Any(x => x.WeakOceanic || x.TransferSection || x.WeakContinental || x.ClearContinental)))
                .ForMember(dest => dest.ArtskartObservationChangesDescription, opt =>
                {
                    opt.PreCondition(src => src.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.AlienSpecie.ToString() || src.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.RegionallyAlien.ToString());
                    opt.MapFrom(src => src.ArtskartManuellKommentar.StripUnwantedHtml());
                })
                .ForMember(dest => dest.ReasonForChangeOfCategory, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetReasonForChangeOfCategory(src.ReasonForChangeOfCategory)))
                .ForMember(dest => dest.RevisionDate, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetRevisionDate(src.Id)))

                // horisontskanning
                .ForMember(dest => dest.HorizonEstablismentPotential, opt =>
                {
                    opt.PreCondition(src => src.HorizonDoScanning);
                })
                .ForMember(dest => dest.HorizonEcologicalEffect, opt =>
                {
                    opt.PreCondition(src => src.HorizonDoScanning);
                })
                
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
                .ForMember(dest => dest.IsAssumedInFuture, opt => opt.MapFrom(src => src.State3 == 1))
                .ForMember(dest => dest.WaterRegionName, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetWaterRegionName(src.VannregionId)));

            CreateMap<Attachment, AlienSpeciesAssessment2023Attachment>(MemberList.None)
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description.StripUnwantedHtml()));
            CreateMap<FA4.ImpactedNatureType, AlienSpeciesAssessment2023ImpactedNatureTypes>(MemberList.None)
                .ForMember(dest => dest.StateChange, opt =>
                {
                    opt.PreCondition(src => src.StateChange.Count > 0);
                    opt.MapFrom(src => src.StateChange.Select(x => string.Concat(x.Where(char.IsLetter))));
                })
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLower()))
                .ForMember(dest => dest.IsThreatened, opt => opt.MapFrom(src => src.NiNCode.All(Char.IsDigit)))
                .ForMember(dest => dest.MajorTypeGroup, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetMajorTypeGroup(src.MajorTypeGroup)))
                .ForMember(dest => dest.Background, opt => opt.MapFrom(src => src.Background.DefaultIfEmpty()));

            CreateMap<RiskAssessment.SpeciesSpeciesInteraction, AlienSpeciesAssessment2023SpeciesSpeciesInteraction>(MemberList.None)
                .ForMember(dest => dest.Background, opt => opt.MapFrom(src => src.BasisOfAssessment.DefaultIfEmpty()))
                .ForMember(dest => dest.InteractionStrength, opt => opt.MapFrom(src => src.Effect))
                ;

            CreateMap<RiskAssessment.SpeciesNaturetypeInteraction, AlienSpeciesAssessment2023SpeciesNaturetypeInteraction>(MemberList.None)
                .ForMember(dest => dest.Background, opt => opt.MapFrom(src => src.BasisOfAssessment.DefaultIfEmpty()))
                .ForMember(dest => dest.InteractionStrength, opt => opt.MapFrom(src => src.Effect))
                ;

            CreateMap<RiskAssessment.HostParasiteInteraction, AlienSpeciesAssessment2023ParasitePathogenTransmission>(MemberList.None)
                .ForMember(dest => dest.ParasiteEcoEffect, opt => opt.MapFrom(src => int.Parse(src.ParasiteEcoEffect)))
                .ForMember(dest => dest.ParasiteStatus, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Background, opt => opt.MapFrom(src => src.BasisOfAssessment.DefaultIfEmpty()));

            CreateMap<FA4.Habitat, AlienSpeciesAssessment2023MicroHabitat>(MemberList.None)
                .ForMember(dest => dest.ScientificName, opt => opt.MapFrom(src => src.Taxon.ScientificName))
                .ForMember(dest => dest.ScientificNameAuthor, opt => opt.MapFrom(src => src.Taxon.ScientificNameAuthor))
                .ForMember(dest => dest.VernacularName, opt => opt.MapFrom(src => src.Taxon.VernacularName));

            CreateMap<FA4.NaturalOrigin, AlienSpeciesAssessment2023NaturalOrigin>(MemberList.None)
                .ForMember(dest => dest.ClimateZone, opt =>
                {
                    opt.PreCondition(src => src.Oceania || src.Africa || src.Asia || src.Europe || src.NorthAndCentralAmerica || src.SouthAmerica);
                    opt.MapFrom(src => src.ClimateZone.Replace(";", ""));
                })
                .ForMember(dest => dest.Continent, opt =>
                {
                    opt.PreCondition(src => src.Oceania || src.Africa || src.Asia || src.Europe || src.NorthAndCentralAmerica || src.SouthAmerica);
                    opt.MapFrom(src => AlienSpeciesAssessment2023ProfileHelper.GetNaturalOriginContinent(src.Oceania, src.Africa, src.Asia, src.Europe, src.NorthAndCentralAmerica, src.SouthAmerica));
                });

            CreateMap<FA4.CoastLineSection, AlienSpeciesAssessment2023CoastLineSection>(MemberList.None)
                .ForMember(dest => dest.ZoneList, opt => opt.MapFrom(src => new List<string> { src.None ? "Ingen" : null, src.OpenCoastLine ? "Åpen kystlinje" : null, src.Skagerrak ? "Skagerrak" : null }));

            CreateMap<FA4.BioClimateZones, AlienSpeciesAssessment2023CurrentBioClimateZones>(MemberList.None)
                .ForMember(dest => dest.ZoneList, opt => opt.MapFrom(src => new List<string> { src.StrongOceanic ? "Sterkt oseanisk seksjon" : null, src.ClearOceanic ? "Klart oseanisk seksjon" : null, src.WeakOceanic ? "Svakt oseanisk seksjon" : null, src.TransferSection ? "Overgangsseksjon" : null, src.WeakContinental ? "Svakt kontinental seksjon" : null }));

            CreateMap<FA4.BioClimateZonesArctic, AlienSpeciesAssessment2023ArcticBioClimateZones>(MemberList.None)
                .ForMember(dest => dest.ZoneList, opt => opt.MapFrom(src => new List<string> { src.WeakOceanic ? "Svakt oseanisk seksjon" : null, src.TransferSection ? "Overgangsseksjon" : null, src.ClearContinental ? "Klart kontinental seksjon" : null, src.WeakContinental ? "Svakt kontinental seksjon" : null }));
        }
    }
}