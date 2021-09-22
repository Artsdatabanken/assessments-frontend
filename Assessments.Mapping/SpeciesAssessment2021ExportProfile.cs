using System.Linq;
using Assessments.Mapping.Models.Species;
using AutoMapper;

namespace Assessments.Mapping
{
    public class SpeciesAssessment2021ExportProfile : Profile
    {
        public SpeciesAssessment2021ExportProfile()
        {
            CreateMap<SpeciesAssessment2021, SpeciesAssessment2021Export>()
                .ForMember(dest => dest.AssessmentArea, opt => opt.MapFrom(src => src.AssessmentArea))
                .ForMember(dest => dest.ExpertCommittee, opt => opt.MapFrom(src => src.ExpertCommittee))
                .ForMember(dest => dest.SpeciesGroup, opt => opt.MapFrom(src => src.SpeciesGroup))
                .ForMember(dest => dest.VurdertVitenskapeligNavnHierarki, opt => opt.MapFrom(src => src.VurdertVitenskapeligNavnHierarki))
                .ForMember(dest => dest.ScientificName, opt => opt.MapFrom(src => src.ScientificName))
                .ForMember(dest => dest.ScientificNameAuthor, opt => opt.MapFrom(src => src.ScientificNameAuthor))
                .ForMember(dest => dest.PopularName, opt => opt.MapFrom(src => src.PopularName))
                .ForMember(dest => dest.TaxonRank, opt => opt.MapFrom(src => src.TaxonRank))
                .ForMember(dest => dest.AssessmentYear, opt => opt.MapFrom(src => src.AssessmentYear))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.CriteriaSummarized, opt => opt.MapFrom(src => src.CriteriaSummarized))
                .ForMember(dest => dest.ExpertStatement, opt => opt.MapFrom(src => src.ExpertStatement))
                .ForMember(dest => dest.RationaleCategoryAdjustment, opt => opt.MapFrom(src => src.RationaleCategoryAdjustment))
                .ForMember(dest => dest.ExtinctionRiskAffected, opt => opt.MapFrom(src => src.ExtinctionRiskAffected))
                .ForMember(dest => dest.PresumedExtinct, opt => opt.MapFrom(src => src.PresumedExtinct))
                .ForMember(dest => dest.ReasonCategoryChange, opt => opt.MapFrom(src => src.ReasonCategoryChange))
                
                // TODO: .ForMember(dest => dest.Category2015, opt => opt.MapFrom(src => src.)) // KategoriFraForrigeListe
                // TODO: .ForMember(dest => dest.CriteriaSummarized2015, opt => opt.MapFrom(src => src.)) // ImportInfo

                // TODO: .ForMember(dest => dest.Category2010, opt => opt.MapFrom(src => src.)) // ImportInfo
                // TODO: .ForMember(dest => dest.CriteriaSummarized2010, opt => opt.MapFrom(src => src.)) // ImportInfo

                .ForMember(dest => dest.PercentageEuropeanPopulation, opt => opt.MapFrom(src => src.PercentageEuropeanPopulation))
                .ForMember(dest => dest.PercentageGlobalPopulation, opt => opt.MapFrom(src => src.PercentageGlobalPopulation))
                .ForMember(dest => dest.ProportionOfMaxPopulation, opt => opt.MapFrom(src => src.ProportionOfMaxPopulation))
                
                .ForMember(dest => dest.MainHabitat, opt => opt.MapFrom(src => string.Join(",", src.MainHabitat)))
                
                
                .ForMember(dest => dest.ImpactFactors, opt => opt.MapFrom(src => string.Join(";", src.ImpactFactors.Select(x => $"{x.GroupingFactor}"))))

                ;
        }
    }
}