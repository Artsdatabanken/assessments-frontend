using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Assessments.Mapping.Models.Species;
using Assessments.Shared.Helpers;
using AutoMapper;

namespace Assessments.Mapping
{
    public class SpeciesAssessment2021ExportProfile : Profile
    {
        public SpeciesAssessment2021ExportProfile()
        {
            CreateMap<SpeciesAssessment2021, SpeciesAssessment2021Export>()
                .ForMember(dest => dest.AssessmentArea, opt => opt.MapFrom(src => src.AssessmentArea == "S" ? "Svalbard" : "Norge"))
                .ForMember(dest => dest.ExpertCommittee, opt => opt.MapFrom(src => src.ExpertCommittee))
                .ForMember(dest => dest.SpeciesGroup, opt => opt.MapFrom(src => src.SpeciesGroup))
                .ForMember(dest => dest.VurdertVitenskapeligNavnHierarki, opt => opt.MapFrom(src => src.VurdertVitenskapeligNavnHierarki))
                .ForMember(dest => dest.ScientificName, opt => opt.MapFrom(src => src.ScientificName))
                .ForMember(dest => dest.ScientificNameAuthor, opt => opt.MapFrom(src => src.ScientificNameAuthor))
                .ForMember(dest => dest.PopularName, opt => opt.MapFrom(src => src.PopularName))
                .ForMember(dest => dest.TaxonRank, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.TaxonRank));
                    opt.MapFrom(src => ConvertRangToNorwegian(src.TaxonRank));
                })
                .ForMember(dest => dest.AssessmentYear, opt => opt.MapFrom(src => src.AssessmentYear))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Replace("º", "°")))
                .ForMember(dest => dest.CriteriaSummarized, opt => opt.MapFrom(src => src.CriteriaSummarized))
                .ForMember(dest => dest.ExpertStatement, opt => opt.MapFrom(src => StripHtml(src.ExpertStatement)))
                .ForMember(dest => dest.RationaleCategoryAdjustment, opt => opt.MapFrom(src => src.ExtinctionRiskAffected == "Nei" ?
                string.Empty : src.RationaleCategoryAdjustment))
                .ForMember(dest => dest.ExtinctionRiskAffected, opt => opt.MapFrom(src => src.ExtinctionRiskAffected))
                .ForMember(dest => dest.PresumedExtinct, opt => opt.MapFrom(src => src.PresumedExtinct ? "Ja" : "Nei"))
                .ForMember(dest => dest.ReasonCategoryChange, opt => opt.MapFrom(src => src.ReasonCategoryChange.Description()))
                .ForMember(dest => dest.Category2015, opt => opt.MapFrom(src => src.PreviousAssessments.Any(x => x.Year == 2015) ? src.PreviousAssessments.Single(x => x.Year == 2015).Category : string.Empty))
                .ForMember(dest => dest.CriteriaSummarized2015, opt => opt.MapFrom(src => src.PreviousAssessments.Any(x => x.Year == 2015) ? src.PreviousAssessments.Single(x => x.Year == 2015).CriteriaSummarized : string.Empty))
                .ForMember(dest => dest.Category2010, opt => opt.MapFrom(src => src.PreviousAssessments.Any(x => x.Year == 2010) ? src.PreviousAssessments.Single(x => x.Year == 2010).Category : string.Empty))
                .ForMember(dest => dest.CriteriaSummarized2010, opt => opt.MapFrom(src => src.PreviousAssessments.Any(x => x.Year == 2010) ? src.PreviousAssessments.Single(x => x.Year == 2010).CriteriaSummarized : string.Empty))
                .ForMember(dest => dest.PercentageEuropeanPopulation, opt => opt.MapFrom(src => src.PercentageEuropeanPopulation != "NA" ? src.PercentageEuropeanPopulation : string.Empty))
                .ForMember(dest => dest.PercentageGlobalPopulation, opt => opt.MapFrom(src => src.PercentageGlobalPopulation != "NA" ? src.PercentageGlobalPopulation : string.Empty))
                .ForMember(dest => dest.ProportionOfMaxPopulation, opt => opt.MapFrom(src => src.ProportionOfMaxPopulation))
                .ForMember(dest => dest.MainHabitat, opt => opt.MapFrom(src => ResolveMainHabitat(src.MainHabitat)))
                .ForMember(dest => dest.ImpactFactors, opt => opt.MapFrom(src => string.Join(";", src.ImpactFactors.Select(x => $"{string.Join(" > ", x.FactorPath)} > {x.Factor}_{x.TimeScope}_{x.PopulationScope}_{x.Severity}"))))
                .ForMember(dest => dest.Ostfold, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.OsloOgAkershus, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Hedmark, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Oppland, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Buskerud, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Vestfold, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Telemark, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.AustAgder, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.VestAgder, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Rogaland, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Hordaland, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.SognOgFjordane, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.MoreOgRomsdal, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Trondelag, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Nordland, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Troms, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Finnmark, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.JanMayen, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Nordsjoen, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Norskehavet, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.BarentshavetNordOgPolhavet, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.BarentshavetSor, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())))
                .ForMember(dest => dest.Gronlandshavet, opt => opt.MapFrom(src => ResolveRegionState(src.RegionOccurrences, opt.DestinationMember.DisplayName())));
        }

        private static string ConvertRangToNorwegian(string taxonRank)
        {
            switch (taxonRank.ToLowerInvariant())
            {
                case "subspecies": return "Underart";
                case "variety": return "Varietet";
                case "form": return "Form";
            }
            return "Art";
        }

        private static string ResolveMainHabitat(IEnumerable<string> mainHabitats)
        {
            static string GetProperDescription(string mainHabitat) => mainHabitat switch
            {
                "ArktiskAlpineJorddektFastmark" => "Alpin jorddekt fastmark",
                "BergUrAndreGrunnjordsystemer" => "Berg, ur og andre grunnjordsystemer",
                "IsSnø" => "Is og snø",
                "KysttilknyttedeFastmarkssystemer" => "Kysttilknyttede fastmarkssystemer",
                "SterktEndretFastmark" => "Sterkt endret fastmark",
                _ => mainHabitat
            };

            return string.Join(";", mainHabitats.Select(GetProperDescription).ToList());
        }

        private static string StripHtml(string input) => Regex.Replace(input, "<.*?>", string.Empty);

        private static string ResolveRegionState(IEnumerable<SpeciesAssessment2021RegionOccurrence> regionOccurrences, string name)
        {
            var regionOccurrence = regionOccurrences.FirstOrDefault(x => x.Fylke == name);

            if (regionOccurrence == null)
                return string.Empty;

            return regionOccurrence.State switch
            {
                0 => "kjent",
                1 => "antatt",
                2 => "ikke kjent",
                3 => "antatt utdødd",
                4 => "utdødd",
                _ => string.Empty
            };
        }
    }
}