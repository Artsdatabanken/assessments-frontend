using Assessments.Mapping.AlienSpecies.Source;
using AutoMapper;

namespace Assessments.Mapping.AlienSpecies.Profiles
{
    public class AlienSpeciesAssessment2023Profile : Profile
    {
        public AlienSpeciesAssessment2023Profile()
        {
            CreateMap<FA4, AlienSpeciesAssessment2023>()

                .ForMember(dest => dest.ScientificName, opt => opt.MapFrom(src => src.EvaluatedScientificName))

                ;
        }
    }
}