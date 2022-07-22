using Assessments.Mapping.Helpers;
using System.Linq;
using Assessments.Mapping.Models.Source.Species;
using Assessments.Mapping.Models.Species;
using AutoMapper;
using Prod.Domain;
using Public.Domain;

namespace Assessments.Mapping
{
    public class SpeciesAssessment2023FAProfile : Profile
    {
        public SpeciesAssessment2023FAProfile()
        {
            CreateMap<FA4.NaturalOrigin, FA2023.NaturalOrigin>();
            CreateMap<FA4.RedlistedNatureType, FA2023.RedlistedNatureType>();
            CreateMap<FA4.SimpleReference, FA2023.SimpleReference>();
            // CreateMap<FA4.RegionalRiskAssessment, FA2023.RegionalRiskAssessment>();
            CreateMap<Prod.Domain.RiskAssessment.Criterion, Public.Domain.RiskAssessment.Criterion>();
            CreateMap<Prod.Domain.RiskAssessment.HostParasiteInteraction,
                    Public.Domain.RiskAssessment.HostParasiteInteraction>();
            CreateMap<Prod.Domain.RiskAssessment.Interaction, Public.Domain.RiskAssessment.Interaction>();
            CreateMap<Prod.Domain.RiskAssessment.NaturetypeInteraction,
                    Public.Domain.RiskAssessment.NaturetypeInteraction>();
            CreateMap<Prod.Domain.RiskAssessment.SpeciesInteraction,
                    Public.Domain.RiskAssessment.SpeciesInteraction>();
            CreateMap<Prod.Domain.RiskAssessment.SpeciesNaturetypeInteraction,
                    Public.Domain.RiskAssessment.SpeciesNaturetypeInteraction>();
            CreateMap<Prod.Domain.RiskAssessment.SpeciesSpeciesInteraction,
                    Public.Domain.RiskAssessment.SpeciesSpeciesInteraction>();

            CreateMap<Prod.Domain.RiskAssessment, Public.Domain.RiskAssessment>();

            CreateMap<Prod.Domain.CTaxon, Public.Domain.CTaxon>();
            CreateMap<Prod.Domain.Fylkesforekomst, Public.Domain.Fylkesforekomst>();
            CreateMap<Prod.Domain.ArtskartModel, Public.Domain.ArtskartModel>();
            CreateMap<Prod.Domain.ArtskartWaterModel, Public.Domain.ArtskartWaterModel>();
            CreateMap<Prod.Domain.ArtskartWaterAreaModel, Public.Domain.ArtskartWaterAreaModel>();
            CreateMap<FA4.CoastLineSection, FA2023.CoastLineSection>();
            CreateMap<FA4.BioClimateZones, FA2023.BioClimateZones>();
            CreateMap<FA4.BioClimateZonesArctic, FA2023.BioClimateZonesArctic>();
            CreateMap<FA4.Habitat, FA2023.Habitat>();
            CreateMap<FA4.PreviousAssessment, FA2023.PreviousAssessment>();


            CreateMap<Prod.Domain.MigrationPathway, Public.Domain.MigrationPathway>();
            CreateMap<Prod.Domain.MigrationPathwayCode, Public.Domain.MigrationPathwayCode>();
            CreateMap<Prod.Domain.SpreadHistory, Public.Domain.SpreadHistory>();
            CreateMap<Prod.Domain.RedlistedNatureTypeCode, Public.Domain.RedlistedNatureTypeCode>();
            CreateMap<Prod.Domain.RedlistedNatureTypeCodeGroup, Public.Domain.RedlistedNatureTypeCodeGroup>();

            CreateMap<Prod.Domain.RegionalPresence, Public.Domain.RegionalPresence>();
            CreateMap<Prod.Domain.RegionalPresenceWithPotential, Public.Domain.RegionalPresenceWithPotential>();
            CreateMap<FA4.ImpactedNatureType, FA2023.ImpactedNatureType>();
            CreateMap<FA4.TimeAndPlace, FA2023.TimeAndPlace>();
            CreateMap<FA4.ObservedAndEstablished, FA2023.ObservedAndEstablished>();
            CreateMap<FA4.ObservedAndEstablishedInCountry, FA2023.ObservedAndEstablishedInCountry>();
            CreateMap<FA4, FA2023>();
        }
    }
}