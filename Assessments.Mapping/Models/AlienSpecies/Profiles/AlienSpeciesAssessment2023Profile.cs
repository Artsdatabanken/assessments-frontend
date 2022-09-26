using Assessments.Mapping.Models.AlienSpecies.Source;
using AutoMapper;

namespace Assessments.Mapping.Models.AlienSpecies.Profiles
{
    public class AlienSpeciesAssessment2023Profile : Profile
    {
        public AlienSpeciesAssessment2023Profile()
        {
            CreateMap<FA4.NaturalOrigin, AlienSpeciesAssessment2023.NaturalOrigin>();
            CreateMap<FA4.RedlistedNatureType, AlienSpeciesAssessment2023.RedlistedNatureType>();
            CreateMap<FA4.SimpleReference, AlienSpeciesAssessment2023.SimpleReference>();
            // CreateMap<FA4.RegionalRiskAssessment, FA2023.RegionalRiskAssessment>();
            CreateMap<Source.RiskAssessment.Criterion, RiskAssessment.Criterion>();
            CreateMap<Source.RiskAssessment.HostParasiteInteraction,
                    RiskAssessment.HostParasiteInteraction>();
            CreateMap<Source.RiskAssessment.Interaction, RiskAssessment.Interaction>();
            CreateMap<Source.RiskAssessment.NaturetypeInteraction,
                    RiskAssessment.NaturetypeInteraction>();
            CreateMap<Source.RiskAssessment.SpeciesInteraction,
                    RiskAssessment.SpeciesInteraction>();
            CreateMap<Source.RiskAssessment.SpeciesNaturetypeInteraction,
                    RiskAssessment.SpeciesNaturetypeInteraction>();
            CreateMap<Source.RiskAssessment.SpeciesSpeciesInteraction,
                    RiskAssessment.SpeciesSpeciesInteraction>();

            CreateMap<Source.RiskAssessment, RiskAssessment>();

            CreateMap<Source.CTaxon, CTaxon>();
            CreateMap<Source.Fylkesforekomst, Fylkesforekomst>();
            CreateMap<Source.ArtskartModel, ArtskartModel>();
            CreateMap<Source.ArtskartWaterModel, ArtskartWaterModel>();
            CreateMap<Source.ArtskartWaterAreaModel, ArtskartWaterAreaModel>();
            CreateMap<FA4.CoastLineSection, AlienSpeciesAssessment2023.CoastLineSection>();
            CreateMap<FA4.BioClimateZones, AlienSpeciesAssessment2023.BioClimateZones>();
            CreateMap<FA4.BioClimateZonesArctic, AlienSpeciesAssessment2023.BioClimateZonesArctic>();
            CreateMap<FA4.Habitat, AlienSpeciesAssessment2023.Habitat>();
            CreateMap<FA4.PreviousAssessment, AlienSpeciesAssessment2023.PreviousAssessment>();


            CreateMap<Source.MigrationPathway, MigrationPathway>();
            CreateMap<Source.MigrationPathwayCode, MigrationPathwayCode>();
            CreateMap<Source.SpreadHistory, SpreadHistory>();
            CreateMap<Source.RedlistedNatureTypeCode, RedlistedNatureTypeCode>();
            CreateMap<Source.RedlistedNatureTypeCodeGroup, RedlistedNatureTypeCodeGroup>();

            CreateMap<Source.RegionalPresence, RegionalPresence>();
            CreateMap<Source.RegionalPresenceWithPotential, RegionalPresenceWithPotential>();
            CreateMap<FA4.ImpactedNatureType, AlienSpeciesAssessment2023.ImpactedNatureType>();
            CreateMap<FA4.TimeAndPlace, AlienSpeciesAssessment2023.TimeAndPlace>();
            CreateMap<FA4.ObservedAndEstablished, AlienSpeciesAssessment2023.ObservedAndEstablished>();
            CreateMap<FA4.ObservedAndEstablishedInCountry, AlienSpeciesAssessment2023.ObservedAndEstablishedInCountry>();

            CreateMap<FA4, AlienSpeciesAssessment2023>().ForMember(dest => dest.EvaluatedScientificName, opt => opt.MapFrom(src => src.EvaluatedScientificName.ToUpper()));
        }
    }
}