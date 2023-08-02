﻿using Assessments.Frontend.Web.Models;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public static class QueryHelpers
    {
        public static IQueryable<AlienSpeciesAssessment2023> ApplyParameters(AlienSpeciesListParameters parameters, IQueryable<AlienSpeciesAssessment2023> query)
        {
            if (!string.IsNullOrEmpty(parameters.Name))
                query = ApplySearch(parameters.Name, query);

            if (parameters.Area.Any())
                query = query.Where(x => parameters.Area.ToEnumerable<AlienSpeciesAssessment2023EvaluationContext>().Contains(x.EvaluationContext) && x.AlienSpeciesCategory != AlienSpeciecAssessment2023AlienSpeciesCategory.RegionallyAlien); // remove "regionallyalien" assessments when filtering by evaluation context

            if (parameters.Category.Any())
                query = query.Where(x => parameters.Category.ToEnumerable<AlienSpeciesAssessment2023Category>().Contains(x.Category));

            if (parameters.EcologicalEffect.Any())
                query = query.Where(x => parameters.EcologicalEffect.Any(y => x.ScoreEcologicalEffect != AlienSpeciesAssessment2023MatrixAxisScore.EcologicalEffect.Unknown && y.Contains(x.ScoreEcologicalEffect.Description())));

            if (parameters.Environment.Any())
                query = ApplyEnvironments(parameters.Environment, query);

            if (parameters.NatureTypes.Any())
                query = query.Where(x => parameters.NatureTypes.Any(y => y == x.AreaOfOccupancyInStronglyAlteredEcosystems.ToString() || x.ImpactedNatureTypes.Any(z => z.MajorTypeGroup.ToString() == y && z.IsThreatened)));

            if (parameters.InvasionPotential.Any())
                query = query.Where(x => parameters.InvasionPotential.Any(y => x.ScoreInvasionPotential != AlienSpeciesAssessment2023MatrixAxisScore.InvasionPotential.Unknown && y.Contains(x.ScoreInvasionPotential.Description())));

            if (parameters.CategoryChanged.Any())
                query = ApplyCategoryChange(parameters.CategoryChanged, query);

            if (parameters.DecisiveCriterias.Any())
                query = ApplyDecisiveCriteria(parameters.DecisiveCriterias, query);

            if (parameters.NotAssessed.Any())
                query = ApplyNotAssessed(parameters.NotAssessed, query);

            if (parameters.SpeciesStatus.Any())
                query = ApplySpeciesStatus(parameters.SpeciesStatus, query);

            if (parameters.ProductionSpecies.Any())
                query = query.Where(x => parameters.ProductionSpecies.Contains(x.ProductionSpecies.ToString()));

            if (parameters.RegionallyAlien.Any())
                query = ApplyRegionallyAlien(parameters.RegionallyAlien, query);

            if (parameters.Regions.Any())
                query = query.Where(x => x.RegionOccurrences.Any(y => parameters.Regions.Contains(y.Region.ToString()) && (y.IsAssumedInFuture || y.IsAssumedToday || y.IsKnown)));

            if (parameters.SpeciesGroups.Any())
                query = query.Where(x => parameters.SpeciesGroups.Any(y => AlienSpeciesHelpers.GetSpeciesGroupByShortName(y) == x.SpeciesGroup));

            if (parameters.SpreadWays.Any())
                query = ApplySpreadWays(parameters.SpreadWays, query);

            if (parameters.TaxonRank.Any())
                query = ApplyTaxonRank(parameters.TaxonRank, query);

            if (parameters.GeographicVariations.Any())
                query = ApplyGeographicVariation(parameters.GeographicVariations, query);

            if (parameters.ClimateEffects.Any())
                query = ApplyClimateEffects(parameters.ClimateEffects, query);

            if (string.IsNullOrEmpty(parameters.SortBy) || parameters.SortBy.Equals(nameof(AlienSpeciesAssessment2023.ScientificName), StringComparison.InvariantCultureIgnoreCase))
                query = query.OrderBy(x => x.ScientificName.ScientificName.Replace("×", string.Empty));
            else if (parameters.SortBy.Equals(nameof(AlienSpeciesAssessment2023.VernacularName), StringComparison.InvariantCultureIgnoreCase))
                query = query.OrderBy(x => x.VernacularName);
            else if (parameters.SortBy.Equals(nameof(AlienSpeciesAssessment2023.Category), StringComparison.InvariantCultureIgnoreCase))
                query = query.OrderBy(x => x.Category);

            return query;
        }

        public static IQueryable<AlienSpeciesAssessment2023> ApplySearch(string searchString, IQueryable<AlienSpeciesAssessment2023> query)
        {
            // Searching for a specific taxonomic rank
            var rankIndexAt = searchString.IndexOf('(');
            var rankIndexEnd = searchString.IndexOf(')');
            var rank = String.Empty;
            if (rankIndexAt > 0 && rankIndexEnd > 0)
            {
                rank = searchString.Substring(rankIndexAt + 1, rankIndexEnd - 1 - rankIndexAt);
                if (rank.Length > 2)
                {
                    rank = rank[0].ToString().ToUpperInvariant() + rank[1..].ToLowerInvariant();
                }
                searchString = searchString[..rankIndexAt].Trim().ToLowerInvariant();
            }

            // If taxonomic rank is not valid, the normal search will be used instead
            if (!string.IsNullOrEmpty(rank))
            {
                if (Constants.TaxonCategoriesNbToEn.TryGetValue(rank, out string rankValue))
                {
                    if (Enum.TryParse(typeof(AlienSpeciesAssessment2023ScientificNameRank), rankValue, true, out var newRank))
                    {
                        AlienSpeciesAssessment2023ScientificNameRank rankEnum = (AlienSpeciesAssessment2023ScientificNameRank)newRank;
                        return query.Where(x => x.NameHiearchy.Any(y => y.ScientificNameRank == rankEnum && y.ScientificName.ToLowerInvariant() == searchString));
                    }
                }
            }

            // Normal search
            searchString = searchString.Trim().ToLowerInvariant();
            var containsSubSpecies = query.Where(x =>
                !string.IsNullOrEmpty(x.VernacularName) &&
                x.VernacularName.ToLowerInvariant().Contains(searchString)).Select(x => x.ScientificName.ScientificName).ToArray();

            return query.Where(x =>
                x.ScientificName.ScientificName.ToLowerInvariant().Contains(searchString) ||
                containsSubSpecies.Any(hit => x.ScientificName.ScientificName.Contains(hit)) || // Search on species also includes sub species
                !string.IsNullOrEmpty(x.VernacularName) &&
                x.VernacularName.ToLowerInvariant().Contains(searchString) ||
                x.NameHiearchy.Any(x => x.ScientificName.ToLowerInvariant().Contains(searchString)) ||
                x.SpeciesGroup.ToLowerInvariant().Contains(searchString));
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyCategoryChange(string[] changes, IQueryable<AlienSpeciesAssessment2023> query)
        {
            IQueryable<AlienSpeciesAssessment2023> newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();
            var changedCriteria = "changedCriteria";
            var changedCriteriaInterpretation = "changedCriteriaInterpretation";
            var changedStatus = "changedStatus";
            var newInformation = "newInformation";
            var newInterpretation = "newInterpretation";
            var realChange = "realChange";

            foreach (var change in changes)
            {
                var assessments = change switch
                {
                    nameof(CategoryChangeEnum.ccvf) => query.Where(x => (x.PreviousAssessments.Count == 0 || x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category == AlienSpeciesAssessment2023Category.NR)) && x.Category != AlienSpeciesAssessment2023Category.NR),
                    nameof(CategoryChangeEnum.ccsk) => query.Where(x => x.PreviousAssessments.Count > 0 && x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category == y.Category)),
                    nameof(CategoryChangeEnum.ccnk) => query.Where(x => x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category != y.Category && (x.ReasonForChangeOfCategory.Contains(newInformation) || x.ReasonForChangeOfCategory.Contains(realChange)))),
                    nameof(CategoryChangeEnum.ccnt) => query.Where(x => x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category != y.Category && x.ReasonForChangeOfCategory.Contains(newInterpretation))),
                    nameof(CategoryChangeEnum.ccea) => query.Where(x => x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category != y.Category && x.ReasonForChangeOfCategory.Contains(changedCriteria))),
                    nameof(CategoryChangeEnum.ccet) => query.Where(x => x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category != y.Category && x.ReasonForChangeOfCategory.Contains(changedCriteriaInterpretation))),
                    nameof(CategoryChangeEnum.cces) => query.Where(x => x.PreviousAssessments.Any(y => y.RevisionYear == 2018 && y.Category != AlienSpeciesAssessment2023Category.NR && x.Category != y.Category && x.ReasonForChangeOfCategory.Contains(changedStatus))),
                    _ => null
                };
                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery.Distinct();
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyDecisiveCriteria(string[] criterias, IQueryable<AlienSpeciesAssessment2023> query)
        {
            IQueryable<AlienSpeciesAssessment2023> newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();
            foreach (var criteria in criterias)
            {
                var assessments = criteria switch
                {
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcexa) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dcexa.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcexb) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dcexb.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcipab) => query.Where(x => DeciciveCriteria.DecisiveCriteriaEnum.dcipab.DisplayName().Any(y => x.DecisiveCriteria.Contains(y))),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcipc) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dcipc.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dceed) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dceed.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcipe) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dcipe.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dceef) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dceef.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcipg) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dcipg.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dceeh) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dceeh.DisplayName())),
                    nameof(DeciciveCriteria.DecisiveCriteriaEnum.dcipi) => query.Where(x => x.DecisiveCriteria.Contains(DeciciveCriteria.DecisiveCriteriaEnum.dcipi.DisplayName())),
                    _ => null
                };
                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery.Distinct();
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyEnvironments(string[] environments, IQueryable<AlienSpeciesAssessment2023> query)
        {
            IQueryable<AlienSpeciesAssessment2023> newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();

            foreach (var environment in environments)
            {
                var assessments = environment switch
                {
                    Environments.Marine => query.Where(x => x.Environment == AlienSpeciesAssessment2023Environment.Marint || x.Environment == AlienSpeciesAssessment2023Environment.LimMar || x.Environment == AlienSpeciesAssessment2023Environment.MarTer || x.Environment == AlienSpeciesAssessment2023Environment.LimMarTer),
                    Environments.Limnic => query.Where(x => x.Environment == AlienSpeciesAssessment2023Environment.Limnisk || x.Environment == AlienSpeciesAssessment2023Environment.LimMar || x.Environment == AlienSpeciesAssessment2023Environment.LimTer || x.Environment == AlienSpeciesAssessment2023Environment.LimMarTer),
                    Environments.Terrestrial => query.Where(x => x.Environment == AlienSpeciesAssessment2023Environment.Terrestrisk || x.Environment == AlienSpeciesAssessment2023Environment.LimTer || x.Environment == AlienSpeciesAssessment2023Environment.MarTer || x.Environment == AlienSpeciesAssessment2023Environment.LimMarTer),
                    _ => null
                };
                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery.Distinct();
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyNotAssessed(string[] assessedType, IQueryable<AlienSpeciesAssessment2023> query)
        {
            IQueryable<AlienSpeciesAssessment2023> newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();
            foreach (var type in assessedType)
            {
                var assessments = type switch
                {
                    nameof(NotAssessed.NotAssessedEnum.Nan) => query.Where(x => x.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.NotAlienSpecie),
                    nameof(NotAssessed.NotAssessedEnum.Nau) => query.Where(x => x.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.UncertainBefore1800),
                    nameof(NotAssessed.NotAssessedEnum.Nam) => query.Where(x => x.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.MisIdentified),
                    _ => null
                };
                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery.Distinct();
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplySpeciesStatus(string[] speciesStatus, IQueryable<AlienSpeciesAssessment2023> query)
        {
            const string doorKnockerShort = "eda";

            return query.Where(x => speciesStatus.Contains(x.SpeciesStatus.ToString()) ||
                                    (speciesStatus.Contains(doorKnockerShort) && (x.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.DoorKnocker || x.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.EffectWithoutReproduction)));
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyTaxonRank(string[] rankFilters, IQueryable<AlienSpeciesAssessment2023> query)
        {
            var newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();
            var evaluatedAtAnotherLevel = AlienSpeciecAssessment2023AlienSpeciesCategory.TaxonEvaluatedAtAnotherLevel;

            foreach (var filter in rankFilters)
            {
                var isInt = int.TryParse(filter, out int result);
                var assessments = filter switch
                {
                    nameof(TaxonRank.TaxonRankEnum.tva) => query.Where(x => x.AlienSpeciesCategory == evaluatedAtAnotherLevel),
                    nameof(TaxonRank.TaxonRankEnum.tvi) => query.Where(x => x.AlienSpeciesCategory != evaluatedAtAnotherLevel),
                    nameof(TaxonRank.TaxonRankEnum.tth) => query.Where(x => x.ScientificName.ScientificName.Contains('×')),
                    _ => isInt ? query.Where(x => ((int)x.ScientificName.ScientificNameRank) == result) : null
                };
                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery.Distinct();
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyGeographicVariation(string[] geographicVariations, IQueryable<AlienSpeciesAssessment2023> query)
        {
            var newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();

            foreach (var variation in geographicVariations)
            {
                var assessments = variation switch
                {
                    nameof(GeographicVariation.GeographicVariationEnum.Gvv) => query.Where(x => x.GeographicVariationInCategory == true),
                    nameof(GeographicVariation.GeographicVariationEnum.Gvn) => query.Where(x => x.GeographicVariationInCategory == false),
                    _ => null
                };

                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery;
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyClimateEffects(string[] climateEffects, IQueryable<AlienSpeciesAssessment2023> query)
        {
            var newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();

            foreach (var effect in climateEffects)
            {
                var assessments = effect switch
                {
                    nameof(ClimateEffects.ClimateEffectsEnum.Cepi) => query.Where(x => x.ClimateEffectsInvasionpotential == true),
                    nameof(ClimateEffects.ClimateEffectsEnum.Cepo) => query.Where(x => x.ClimateEffectsEcoEffect == true),
                    nameof(ClimateEffects.ClimateEffectsEnum.Ceii) => query.Where(x => x.ClimateEffectsInvasionpotential == false),
                    nameof(ClimateEffects.ClimateEffectsEnum.Ceio) => query.Where(x => x.ClimateEffectsEcoEffect == false),
                    _ => null
                };

                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery.Distinct();
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplySpreadWays(string[] spreadWays, IQueryable<AlienSpeciesAssessment2023> query)
        {
            var newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();

            foreach (var way in spreadWays)
            {
                var assessments = way switch
                {
                    nameof(SpreadWays.SpreadWaysEnum.Swidi) => query.Where(x => x.ImportPathways.Any(y => y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.ImportDirect)),
                    nameof(SpreadWays.SpreadWaysEnum.Swifo) => query.Where(x => x.ImportPathways.Any(y => y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Transportpolution)),
                    nameof(SpreadWays.SpreadWaysEnum.Swibl) => query.Where(x => x.ImportPathways.Any(y => y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Stowaway)),
                    nameof(SpreadWays.SpreadWaysEnum.Swnbe) => query.Where(x => x.IntroductionAndSpreadPathways.Any(y => y.IntroductionSpread == AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.Introduction && y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Released)),
                    nameof(SpreadWays.SpreadWaysEnum.Swnro) => query.Where(x => x.IntroductionAndSpreadPathways.Any(y => y.IntroductionSpread == AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.Introduction && y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Escaped)),
                    nameof(SpreadWays.SpreadWaysEnum.Swnfo) => query.Where(x => x.IntroductionAndSpreadPathways.Any(y => y.IntroductionSpread == AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.Introduction && y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Transportpolution)),
                    nameof(SpreadWays.SpreadWaysEnum.Swnbl) => query.Where(x => x.IntroductionAndSpreadPathways.Any(y => y.IntroductionSpread == AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.Introduction && y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Stowaway)),
                    nameof(SpreadWays.SpreadWaysEnum.Swnme) => query.Where(x => x.IntroductionAndSpreadPathways.Any(y => y.IntroductionSpread == AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.Introduction && y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Corridor)),
                    nameof(SpreadWays.SpreadWaysEnum.Swneg) => query.Where(x => x.IntroductionAndSpreadPathways.Any(y => y.IntroductionSpread == AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.Introduction && y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.NaturalDispersal)),
                    nameof(SpreadWays.SpreadWaysEnum.Swsti) => query.Where(x => x.IntroductionAndSpreadPathways.Any(y => y.IntroductionSpread == AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.Spread && y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Released)),
                    nameof(SpreadWays.SpreadWaysEnum.Swsfo) => query.Where(x => x.IntroductionAndSpreadPathways.Any(y => y.IntroductionSpread == AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.Spread && y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Transportpolution)),
                    nameof(SpreadWays.SpreadWaysEnum.Swsbl) => query.Where(x => x.IntroductionAndSpreadPathways.Any(y => y.IntroductionSpread == AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.Spread && y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Stowaway)),
                    nameof(SpreadWays.SpreadWaysEnum.Swsme) => query.Where(x => x.IntroductionAndSpreadPathways.Any(y => y.IntroductionSpread == AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.Spread && y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.Corridor)),
                    nameof(SpreadWays.SpreadWaysEnum.Swseg) => query.Where(x => x.IntroductionAndSpreadPathways.Any(y => y.IntroductionSpread == AlienSpeciesAssessment2023IntroductionPathway.IntroductionSpread.Spread && y.MainCategory == AlienSpeciesAssessment2023IntroductionPathway.MainCategory.NaturalDispersal)),
                    _ => null
                };

                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery.Distinct();
        }

        private static IQueryable<AlienSpeciesAssessment2023> ApplyRegionallyAlien(string[] regionFilters, IQueryable<AlienSpeciesAssessment2023> query)
        {
            var newQuery = Enumerable.Empty<AlienSpeciesAssessment2023>().AsQueryable();

            foreach (var regionFilter in regionFilters)
            {
                IQueryable<AlienSpeciesAssessment2023> assessments;
                // Rae and Rai are not regions, so they are treated differently
                if (regionFilter != nameof(RegionallyAlien.RegionallyAlienEnum.Rae) && regionFilter != nameof(RegionallyAlien.RegionallyAlienEnum.Rai) && Enum.TryParse(regionFilter, out RegionallyAlien.RegionallyAlienEnum filterEnum))
                {
                    assessments = query.Where(x => x.FreshWaterRegionModel.FreshWaterRegions.Any(y => y.WaterRegionName == filterEnum.DisplayName() && y.IsIncludedInAssessmentArea == true && (y.IsKnown || y.IsAssumedToday || y.IsAssumedInFuture)));
                }
                else
                {
                    assessments = regionFilter switch
                    {
                        nameof(RegionallyAlien.RegionallyAlienEnum.Rae) => query.Where(x => x.AlienSpeciesCategory != AlienSpeciecAssessment2023AlienSpeciesCategory.RegionallyAlien),
                        nameof(RegionallyAlien.RegionallyAlienEnum.Rai) => query.Where(x => x.AlienSpeciesCategory == AlienSpeciecAssessment2023AlienSpeciesCategory.RegionallyAlien),
                        _ => null
                    };
                }

                if (assessments != null)
                    newQuery = newQuery.Concat(assessments);
            }
            return newQuery.Distinct();
        }
    }
}
