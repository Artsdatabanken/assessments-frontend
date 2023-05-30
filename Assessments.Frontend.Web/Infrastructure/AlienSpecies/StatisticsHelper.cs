using Assessments.Frontend.Web.Models;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Model.Enums;
using Assessments.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure.AlienSpecies
{
    public class StatisticsHelper
    {
        private readonly IQueryable<AlienSpeciesAssessment2023> _query;
        private readonly IQueryable<AlienSpeciesAssessment2023> _unfilteredQuery;

        public StatisticsHelper(IQueryable<AlienSpeciesAssessment2023> query, IQueryable<AlienSpeciesAssessment2023> unfilteredQuery)
        {
            // NR and TaxonEvaluatedAtAnotherLevel should never appear in the statistics figures
            _query = query.Where(x => x.Category != AlienSpeciesAssessment2023Category.NR && x.AlienSpeciesCategory != AlienSpeciecAssessment2023AlienSpeciesCategory.TaxonEvaluatedAtAnotherLevel);
            _unfilteredQuery = unfilteredQuery;
        }

        public AlienSpeciesStatistics2023 GetStatistics()
        {
            var statistics = new AlienSpeciesStatistics2023();

            statistics.DecisiveCriteria = this.GetDecisiveCriteria();
            statistics.RiskCategories = this.GetRiskCategories();
            statistics.RiskMatrix = this.GetRiskMatrixValues();
            statistics.SpeciesGroups = this.GetSpeciesGroups();
            statistics.MajorNatureTypesEffect = this.GetMajorNatureTypesEffect();
            statistics.NatureTypesEffect = this.GetNatureTypesEffect();

            return statistics;
        }

        private BarChart GetRiskCategories()
        {
            var distinctCategories = new List<AlienSpeciesAssessment2023Category>((IEnumerable<AlienSpeciesAssessment2023Category>)Enum.GetValues(typeof(AlienSpeciesAssessment2023Category))).Where(x => x != AlienSpeciesAssessment2023Category.NR);

            var barChartDatas = distinctCategories.Select(x => new BarChart.BarChartData
            {
                Name = x.DisplayName(),
                NameShort = x.ToString(),
                Count = _query.Where(y => y.Category == x).Count()
            }).OrderBy(x => x.NameShort.ToString(), new AlienSpeciesCategoryComparer()).ToList();

            return new BarChart()
            {
                Data = barChartDatas,
                MaxValue = barChartDatas.MaxBy(x => x.Count).Count
            };
        }

        private BarChart GetSpeciesGroups()
        {
            var distinctSpeciesGroups = new List<AlienSpeciesAssessment2023SpeciesGroups>((IEnumerable<AlienSpeciesAssessment2023SpeciesGroups>)Enum.GetValues(typeof(AlienSpeciesAssessment2023SpeciesGroups)));
            var singleAlgae = "Alger";
            var singleCrayfish = AlienSpeciesAssessment2023SpeciesGroups.Crustacea.DisplayName();
            var singleInsect = AlienSpeciesAssessment2023SpeciesGroups.Insecta.DisplayName();
            var algae = new AlienSpeciesAssessment2023SpeciesGroups[]
            {
                AlienSpeciesAssessment2023SpeciesGroups.Rhodophyta,
                AlienSpeciesAssessment2023SpeciesGroups.Phaeophyceae,
                AlienSpeciesAssessment2023SpeciesGroups.Chlorophyta
            };
            var crayfish = new AlienSpeciesAssessment2023SpeciesGroups[]
            {
                AlienSpeciesAssessment2023SpeciesGroups.Malacostraca,
                AlienSpeciesAssessment2023SpeciesGroups.Branchiopoda,
                AlienSpeciesAssessment2023SpeciesGroups.Copepoda,
                AlienSpeciesAssessment2023SpeciesGroups.Thecostraca
            };
            var insects = new AlienSpeciesAssessment2023SpeciesGroups[]
            {
                AlienSpeciesAssessment2023SpeciesGroups.Coleoptera,
                AlienSpeciesAssessment2023SpeciesGroups.Zygentoma,
                AlienSpeciesAssessment2023SpeciesGroups.Phthiraptera,
                AlienSpeciesAssessment2023SpeciesGroups.Hemiptera,
                AlienSpeciesAssessment2023SpeciesGroups.Lepidoptera,
                AlienSpeciesAssessment2023SpeciesGroups.Psocoptera,
                AlienSpeciesAssessment2023SpeciesGroups.Diptera,
                AlienSpeciesAssessment2023SpeciesGroups.Thysanoptera,
                AlienSpeciesAssessment2023SpeciesGroups.Hymenoptera
            };

            var algaeBarChart = new BarChart()
            {
                Data = distinctSpeciesGroups.Where(x => algae.Any(y => x == y)).Select(x => new BarChart.BarChartData
                {
                    Name = singleAlgae,
                    Count = _query.Where(y => y.SpeciesGroup == x.DisplayName()).Count()
                }).ToList()
            };

            var crayfishBarChart = new BarChart()
            {
                Data = distinctSpeciesGroups.Where(x => crayfish.Any(y => x == y)).Select(x => new BarChart.BarChartData
                {
                    Name = singleCrayfish,
                    Count = _query.Where(y => y.SpeciesGroup == x.DisplayName()).Count()
                }).ToList()
            };

            var insectsBarChart = new BarChart()
            {
                Data = distinctSpeciesGroups.Where(x => insects.Any(y => x == y)).Select(x => new BarChart.BarChartData
                {
                    Name = singleInsect,
                    Count = _query.Where(y => y.SpeciesGroup == x.DisplayName()).Count()
                }).ToList()
            };

            var speciesBarChart = new BarChart()
            {
                Data = distinctSpeciesGroups.Where(x => !algae.Contains(x) && !crayfish.Contains(x) && !insects.Contains(x)).Select(x => new BarChart.BarChartData
                {
                    Name = x.DisplayName(),
                    Count = _query.Where(y => y.SpeciesGroup == x.DisplayName()).Count()
                }).ToList()
            };

            var algaeBarChartData = new BarChart.BarChartData()
            {
                Name = singleAlgae,
                Count = algaeBarChart.Data.Sum(x => x.Count)
            };
            var crayFishBarChartData = new BarChart.BarChartData()
            {
                Name = singleCrayfish,
                Count = crayfishBarChart.Data.Sum(x => x.Count)
            };
            var insectsBarChartData = new BarChart.BarChartData()
            {
                Name = singleInsect,
                Count = insectsBarChart.Data.Sum(x => x.Count)
            };

            speciesBarChart.Data.Add(algaeBarChartData);
            speciesBarChart.Data.Add(crayFishBarChartData);
            speciesBarChart.Data.Add(insectsBarChartData);

            speciesBarChart.Data = speciesBarChart.Data.OrderByDescending(x => x.Count).DistinctBy(x => x.Name).ToList();
            speciesBarChart.MaxValue = speciesBarChart.Data.MaxBy(x => x.Count).Count;

            return speciesBarChart;
        }

        private List<List<int>> GetRiskMatrixValues()
        {
            var riskMatrix = new List<List<int>>()
            {
                new List<int>() {0, 0, 0, 0},
                new List<int>() {0, 0, 0, 0},
                new List<int>() {0, 0, 0, 0},
                new List<int>() {0, 0, 0, 0}
            };

            foreach (var assessment in _query)
            {
                riskMatrix[(int)assessment.ScoreInvasionPotential - 1][(int)assessment.ScoreEcologicalEffect - 1] += 1;
            }

            return riskMatrix;
        }

        private BarChart GetDecisiveCriteria()
        {
            var decisiveCriteria = new List<AlienSpeciesAssessment2023CriteriaLetter>((IEnumerable<AlienSpeciesAssessment2023CriteriaLetter>)Enum.GetValues(typeof(AlienSpeciesAssessment2023CriteriaLetter)));
            var AxBText = "A×B Levetid × Ekspansjonshastighet";

            var AxB = decisiveCriteria.Where(x => x == AlienSpeciesAssessment2023CriteriaLetter.A || x == AlienSpeciesAssessment2023CriteriaLetter.B).Select(x => new BarChart.BarChartData
            {
                Name = AxBText,
                Count = _query.Where(y => y.DecisiveCriteria.Contains(x.ToString())).Count()
            }).ToList();

            var aXbBarChartData = new BarChart.BarChartData()
            {
                Name = AxBText,
                Count = AxB.Sum(x => x.Count)
            };

            var allDecisiveCriteria = new BarChart()
            {
                Data = decisiveCriteria.Where(x => x != AlienSpeciesAssessment2023CriteriaLetter.A && x != AlienSpeciesAssessment2023CriteriaLetter.B).Select(x => new BarChart.BarChartData
                {
                    Name = $"{x.ToString()} {x.DisplayName()}",
                    Count = _query.Where(y => y.DecisiveCriteria.Contains(x.ToString())).Count()
                }).OrderBy(x => x.Name).ToList()
            };

            allDecisiveCriteria.Data.Insert(0, aXbBarChartData);
            allDecisiveCriteria.MaxValue = allDecisiveCriteria.Data.MaxBy(x => x.Count).Count;
            return allDecisiveCriteria;
        }

        private BarChart GetMajorNatureTypesEffect()
        {
            var threatenedMajorTypeGroups = new List<AlienSpeciesAssessment2023MajorTypeGroup>();
            foreach (var assessment in _unfilteredQuery.Where(x => x.Category != AlienSpeciesAssessment2023Category.NR && x.AlienSpeciesCategory != AlienSpeciecAssessment2023AlienSpeciesCategory.TaxonEvaluatedAtAnotherLevel))
            {
                var typeGroups = assessment.ImpactedNatureTypes.Where(x => x.IsThreatened).Select(x => x.MajorTypeGroup);
                threatenedMajorTypeGroups = threatenedMajorTypeGroups.Concat(typeGroups).ToList();
            }
            threatenedMajorTypeGroups = threatenedMajorTypeGroups.Distinct().ToList();

            var majorNatureTypesEffects = new BarChart()
            {
                Data = threatenedMajorTypeGroups.Select(x => new BarChart.BarChartData()
                {
                    Name = x.DisplayName(),
                    Count = _query.Where(y => y.ImpactedNatureTypes.Any(z => z.MajorTypeGroup == x)).Count()
                }).OrderByDescending(x => x.Count).ToList()
            };
            majorNatureTypesEffects.MaxValue = majorNatureTypesEffects.Data.MaxBy(x => x.Count).Count;

            return majorNatureTypesEffects;
        }

        private List<BarChart> GetNatureTypesEffect()
        {
            var unfilteredQuery = _unfilteredQuery.Where(x => x.Category != AlienSpeciesAssessment2023Category.NR && x.AlienSpeciesCategory != AlienSpeciecAssessment2023AlienSpeciesCategory.TaxonEvaluatedAtAnotherLevel);

            var impactedNatureTypes = unfilteredQuery.SelectMany(x => x.ImpactedNatureTypes).Where(x => x.IsThreatened);

            var barCharts = new List<BarChart>();

            foreach (var impactedNatureType in impactedNatureTypes.GroupBy(x => x.MajorTypeGroup).OrderBy(x => x.Key))
            {
                var data = impactedNatureType.GroupBy(x => x.Name).Select(y => new
                {
                    Name = y.Key,
                    Count = _query.SelectMany(y => y.ImpactedNatureTypes).Where(z => z.Name == y.Key).Count()
                });

                var barChart = new BarChart
                {
                    Name = impactedNatureType.Key.DisplayName()
                };

                foreach (var item in data.OrderBy(x => x.Name))
                {
                    barChart.Data.Add(new()
                    {
                        Name = item.Name,
                        Count = item.Count
                    });
                }

                barCharts.Add(barChart);
            }

            foreach (var chart in barCharts)
            {
                chart.MaxValue = barCharts.SelectMany(x => x.Data).Max(y => y.Count);
            }

            return barCharts;
        }
    }
}
