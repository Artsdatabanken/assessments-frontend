using Assessments.Mapping.AlienSpecies.Models;
using AutoMapper;

namespace Assessments.Mapping.AlienSpecies
{
    public class AlienSpeciesAssessment2023ExportProfile : Profile
    {
        public AlienSpeciesAssessment2023ExportProfile()
        {
            CreateMap<AlienSpeciesAssessment2023, AlienSpeciesAssessment2023Export>();
        }
    }
}
