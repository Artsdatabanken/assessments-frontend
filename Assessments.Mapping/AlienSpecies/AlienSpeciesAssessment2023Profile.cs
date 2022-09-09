using Assessments.Mapping.AlienSpecies.Models;
using Assessments.Mapping.AlienSpecies.Models.Source;
using AutoMapper;
using ArtskartModel = Assessments.Mapping.AlienSpecies.Models.ArtskartModel;
using ArtskartWaterAreaModel = Assessments.Mapping.AlienSpecies.Models.ArtskartWaterAreaModel;
using ArtskartWaterModel = Assessments.Mapping.AlienSpecies.Models.ArtskartWaterModel;
using CTaxon = Assessments.Mapping.AlienSpecies.Models.CTaxon;
using Fylkesforekomst = Assessments.Mapping.AlienSpecies.Models.Fylkesforekomst;
using MigrationPathway = Assessments.Mapping.AlienSpecies.Models.MigrationPathway;
using MigrationPathwayCode = Assessments.Mapping.AlienSpecies.Models.MigrationPathwayCode;
using RedlistedNatureTypeCode = Assessments.Mapping.AlienSpecies.Models.RedlistedNatureTypeCode;
using RedlistedNatureTypeCodeGroup = Assessments.Mapping.AlienSpecies.Models.RedlistedNatureTypeCodeGroup;
using RegionalPresence = Assessments.Mapping.AlienSpecies.Models.RegionalPresence;
using RegionalPresenceWithPotential = Assessments.Mapping.AlienSpecies.Models.RegionalPresenceWithPotential;
using RiskAssessment = Assessments.Mapping.AlienSpecies.Models.RiskAssessment;
using SpreadHistory = Assessments.Mapping.AlienSpecies.Models.SpreadHistory;

namespace Assessments.Mapping.AlienSpecies
{
    public class AlienSpeciesAssessment2023Profile : Profile
    {
        public AlienSpeciesAssessment2023Profile()
        {
            CreateMap<FA4.NaturalOrigin, AlienSpeciesAssessment2023.NaturalOrigin>();
            CreateMap<FA4.RedlistedNatureType, AlienSpeciesAssessment2023.RedlistedNatureType>();
            CreateMap<FA4.SimpleReference, AlienSpeciesAssessment2023.SimpleReference>();
            // CreateMap<FA4.RegionalRiskAssessment, FA2023.RegionalRiskAssessment>();
            CreateMap<Models.Source.RiskAssessment.Criterion, RiskAssessment.Criterion>();
            CreateMap<Models.Source.RiskAssessment.HostParasiteInteraction,
                    RiskAssessment.HostParasiteInteraction>();
            CreateMap<Models.Source.RiskAssessment.Interaction, RiskAssessment.Interaction>();
            CreateMap<Models.Source.RiskAssessment.NaturetypeInteraction,
                    RiskAssessment.NaturetypeInteraction>();
            CreateMap<Models.Source.RiskAssessment.SpeciesInteraction,
                    RiskAssessment.SpeciesInteraction>();
            CreateMap<Models.Source.RiskAssessment.SpeciesNaturetypeInteraction,
                    RiskAssessment.SpeciesNaturetypeInteraction>();
            CreateMap<Models.Source.RiskAssessment.SpeciesSpeciesInteraction,
                    RiskAssessment.SpeciesSpeciesInteraction>();

            CreateMap<Models.Source.RiskAssessment, RiskAssessment>();

            CreateMap<Models.Source.CTaxon, CTaxon>();
            CreateMap<Models.Source.Fylkesforekomst, Fylkesforekomst>();
            CreateMap<Models.Source.ArtskartModel, ArtskartModel>();
            CreateMap<Models.Source.ArtskartWaterModel, ArtskartWaterModel>();
            CreateMap<Models.Source.ArtskartWaterAreaModel, ArtskartWaterAreaModel>();
            CreateMap<FA4.CoastLineSection, AlienSpeciesAssessment2023.CoastLineSection>();
            CreateMap<FA4.BioClimateZones, AlienSpeciesAssessment2023.BioClimateZones>();
            CreateMap<FA4.BioClimateZonesArctic, AlienSpeciesAssessment2023.BioClimateZonesArctic>();
            CreateMap<FA4.Habitat, AlienSpeciesAssessment2023.Habitat>();
            CreateMap<FA4.PreviousAssessment, AlienSpeciesAssessment2023.PreviousAssessment>();


            CreateMap<Models.Source.MigrationPathway, MigrationPathway>();
            CreateMap<Models.Source.MigrationPathwayCode, MigrationPathwayCode>();
            CreateMap<Models.Source.SpreadHistory, SpreadHistory>();
            CreateMap<Models.Source.RedlistedNatureTypeCode, RedlistedNatureTypeCode>();
            CreateMap<Models.Source.RedlistedNatureTypeCodeGroup, RedlistedNatureTypeCodeGroup>();

            CreateMap<Models.Source.RegionalPresence, RegionalPresence>();
            CreateMap<Models.Source.RegionalPresenceWithPotential, RegionalPresenceWithPotential>();
            CreateMap<FA4.ImpactedNatureType, AlienSpeciesAssessment2023.ImpactedNatureType>();
            CreateMap<FA4.TimeAndPlace, AlienSpeciesAssessment2023.TimeAndPlace>();
            CreateMap<FA4.ObservedAndEstablished, AlienSpeciesAssessment2023.ObservedAndEstablished>();
            CreateMap<FA4.ObservedAndEstablishedInCountry, AlienSpeciesAssessment2023.ObservedAndEstablishedInCountry>();
            CreateMap<FA4, AlienSpeciesAssessment2023>();
        }
    }
}