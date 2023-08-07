using System.Linq;
using Assessments.Mapping.AlienSpecies.Helpers;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Shared.Helpers;
using AutoMapper;

namespace Assessments.Mapping.AlienSpecies.Profiles
{
    public class AlienSpeciesAssessment2023ExportProfile : Profile
    {
        public AlienSpeciesAssessment2023ExportProfile()
        {
            CreateMap<AlienSpeciesAssessment2023, AlienSpeciesAssessment2023Export>()
                .ForMember(dest => dest.AlienSpeciesCategory, opt => opt.MapFrom(src => src.AlienSpeciesCategory.DisplayName()))
                .ForMember(dest => dest.GeographicalVariation, opt => opt.MapFrom(src => AlienSpeciesAssessment2023ExportProfileHelper.GetGeographicalVariation(src.GeographicalVariation)))
                .ForMember(dest => dest.PreviousAssessmentCategory2018, opt =>
                {
                    opt.PreCondition(src => src.PreviousAssessments.Any(x => x.RevisionYear == 2018));
                    opt.MapFrom(src => src.PreviousAssessments.First(x => x.RevisionYear == 2018).Category);
                })
                .ForMember(dest => dest.ScientificName, opt => opt.MapFrom(src => src.ScientificName.ScientificName))
                .ForMember(dest => dest.ScientificNameId, opt => opt.MapFrom(src => src.ScientificName.ScientificNameId))
                .ForMember(dest => dest.ScientificNameAuthor, opt => opt.MapFrom(src => src.ScientificName.ScientificNameAuthor))
                .ForMember(dest => dest.TaxonHierarcy, opt => opt.MapFrom(src => string.Join("\\", src.NameHiearchy.Select(x=>x.ScientificName).ToArray())))
                .ForMember(dest => dest.Ecosystems, opt => opt.MapFrom(src => string.Join("; ", src.ImpactedNatureTypes.DefaultIfEmpty().Select(x => x.Name).Distinct().ToArray())))
                .ForMember(dest => dest.AssessmentArea, opt => opt.MapFrom(src => src.EvaluationContext.DisplayName()))
                .ForMember(dest => dest.CriterionAScore, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR);
                    opt.MapFrom(src => src.Criteria.FirstOrDefault(x => x.CriteriaLetter == Model.Enums.AlienSpeciesAssessment2023CriteriaLetter.A).Value);
                })
                .ForMember(dest => dest.CriterionBScore, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR);
                    opt.MapFrom(src => src.Criteria.FirstOrDefault(x => x.CriteriaLetter == Model.Enums.AlienSpeciesAssessment2023CriteriaLetter.B).Value);
                })
                .ForMember(dest => dest.CriterionCScore, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR);
                    opt.MapFrom(src => src.Criteria.FirstOrDefault(x => x.CriteriaLetter == Model.Enums.AlienSpeciesAssessment2023CriteriaLetter.C).Value);
                })
                .ForMember(dest => dest.CriterionDScore, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR);
                    opt.MapFrom(src => src.Criteria.FirstOrDefault(x => x.CriteriaLetter == Model.Enums.AlienSpeciesAssessment2023CriteriaLetter.D).Value);
                })
                .ForMember(dest => dest.CriterionEScore, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR);
                    opt.MapFrom(src => src.Criteria.FirstOrDefault(x => x.CriteriaLetter == Model.Enums.AlienSpeciesAssessment2023CriteriaLetter.E).Value);
                })
                .ForMember(dest => dest.CriterionFScore, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR);
                    opt.MapFrom(src => src.Criteria.FirstOrDefault(x => x.CriteriaLetter == Model.Enums.AlienSpeciesAssessment2023CriteriaLetter.F).Value);
                })
                .ForMember(dest => dest.CriterionGScore, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR);
                    opt.MapFrom(src => src.Criteria.FirstOrDefault(x => x.CriteriaLetter == Model.Enums.AlienSpeciesAssessment2023CriteriaLetter.G).Value);
                })
                .ForMember(dest => dest.CriterionHScore, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR);
                    opt.MapFrom(src => src.Criteria.FirstOrDefault(x => x.CriteriaLetter == Model.Enums.AlienSpeciesAssessment2023CriteriaLetter.H).Value);
                })
                .ForMember(dest => dest.CriterionIScore, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR);
                    opt.MapFrom(src => src.Criteria.FirstOrDefault(x => x.CriteriaLetter == Model.Enums.AlienSpeciesAssessment2023CriteriaLetter.I).Value);
                })
                .ForMember(dest => dest.MedianLifetimeBestEstimate, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR & src.AlienSpeciesCategory != Model.Enums.AlienSpeciecAssessment2023AlienSpeciesCategory.TaxonEvaluatedAtAnotherLevel);
                    opt.MapFrom(src => AlienSpeciesAssessment2023ExportProfileHelper.GetMedianLifespan(src.MedianLifetimeEstimationMethod, src.MedianLifetimeBestEstimate, src.Criteria.FirstOrDefault(x => x.CriteriaLetter == Model.Enums.AlienSpeciesAssessment2023CriteriaLetter.A).Value));
                })
                .ForMember(dest => dest.ScoreInvasionPotential, opt => opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR))
                .ForMember(dest => dest.ScoreEcologicalEffect, opt => opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR))
                .ForMember(dest => dest.ExpansionSpeedBestEstimate, opt => opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR & src.AlienSpeciesCategory != Model.Enums.AlienSpeciecAssessment2023AlienSpeciesCategory.TaxonEvaluatedAtAnotherLevel))
                .ForMember(dest => dest.GeographicVariationInCategory, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR); opt.MapFrom(src => src.GeographicVariationInCategory.GetValueOrDefault() ? "Ja" : "Nei");
                })
                .ForMember(dest => dest.ClimateEffectsInvasionPotential, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR); opt.MapFrom(src => src.ClimateEffectsInvasionpotential.GetValueOrDefault() ? "Ja" : "Nei");
                })
                .ForMember(dest => dest.ClimateEffectsEcoEffect, opt =>
                {
                    opt.PreCondition(src => src.Category != Model.Enums.AlienSpeciesAssessment2023Category.NR); opt.MapFrom(src => src.ClimateEffectsEcoEffect.GetValueOrDefault() ? "Ja" : "Nei");
                })
                ;
        }
    }
}
