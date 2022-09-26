using AutoMapper;

namespace Assessments.Mapping.Models.AlienSpecies.Profiles
{
    public class AlienSpeciesAssessment2023ExportProfile : Profile
    {
        public AlienSpeciesAssessment2023ExportProfile()
        {
            CreateMap<AlienSpeciesAssessment2023, AlienSpeciesAssessment2023Export>();
        }
    }
}
