using Assessments.Mapping.AlienSpecies.Profiles;
using AutoMapper;

namespace Assessments.Tests.Mapping
{
    public class AlienSpeciesAssessment2023ProfileTests
    {
        private readonly MapperConfiguration _mapper;

        public AlienSpeciesAssessment2023ProfileTests()
        {
            _mapper = new MapperConfiguration(config => config.AddProfile(new AlienSpeciesAssessment2023Profile()));
        }

        [Fact]
        public void AlienSpeciesAssessment2023ProfileShouldBeValid() => _mapper.AssertConfigurationIsValid();
    }
}
