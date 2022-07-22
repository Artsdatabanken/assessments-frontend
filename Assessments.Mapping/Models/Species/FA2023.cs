using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
//using Prod.Domain.Helpers;


namespace Public.Domain
{
    public class CTaxon
    {
        public string Id { get; set; }
        public int TaxonID { get; set; }
        public string ScientificName { get; set; }
        public int ScientificNameId { get; set; }

        public string ScientificNameAuthor { get; set; }

        public string VernacularName { get; set; }

        public string RedListCategory { get; set; }

        public List<string> TaxonSearchResult { get; set; }

        public string TaxonSearchString { get; set; }

        public string TaxonRank { get; set; }

    }



    public partial class FA2023
    {
        public static FA2023 CreateNewFA4()
        {
            var newfa = new FA2023();
            newfa.initNaturalOrigins();
            newfa.InitFylkesforekomster();
            newfa.RiskAssessment.Criteria = RiskAssessment.CreateDefaultCriteria();
            return newfa;
        }

        [JsonExtensionData]
        public Dictionary<string, JsonElement>? ExtensionData { get; set; }

        //public List<TaxonHistory> TaxonomicHistory { get; set; } = new List<TaxonHistory>();
        //public TrackInfo ImportInfo { get; set; } = new TrackInfo();
        public int Id { get; set; }

        public string EvaluationContext { get; set; }

        //public Taxon Taxon { get; set; }
        public int TaxonId { get; set; }
        public string ExpertGroup { get; set; }

        public string Citation { get; set; }
        public string Category { get; set; }
        public string Criteria { get; set; }
        public string AlienSpeciesCategory { get; set; }
        public string AssessmentConclusion { get; set; }

        public string DescriptionOfReasonsForChangeOfCategory { get; set; }

        public List<string> ReasonForChangeOfCategory { get; set; } = new List<string>();
        public DateTime LastUpdatedAt { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime LockedForEditAt { get; set; }
        public string LockedForEditBy { get; set; }
        public bool IsEvaluated { get; set; }  // ???
        public bool IsDeleted { get; set; }
        public string EvaluationStatus { get; set; }

        /// <summary>
        /// Scientific name Id (from Artsnavnebase) used for Risk Evaluation (at the time of evaluation)
        /// </summary>
        public int? EvaluatedScientificNameId { get; set; }

        /// <summary>
        /// Scientific name used for Risk Evaluation (at the time of evaluation)
        /// </summary>
        public string EvaluatedScientificName { get; set; }
        public string EvaluatedScientificNameAuthor { get; set; }
        public string EvaluatedVernacularName { get; set; }

        public string TaxonHierarcy { get; set; }

        //public Datasett Datasett { get; set; } = new Datasett();
        public string EvaluatedScientificNameRank { get; set; }
    }

    public partial class FA2023 // Horisontskanning
    {
        /// <summary>
        /// If true this assessment is marked for horizon scanning prior to risk assessment
        /// </summary>
        public bool HorizonDoScanning { get; set; } = false;

        /// <summary>
        /// Signal if Horizonscan has been done and result
        /// </summary>
        /// <remarks>
        /// scanned_fullAssessment = Do full alienspecies assessment 
        /// scanned_noAssessment = Don't do full alienspecies assessment
        /// </remarks>
        public string HorizonScanResult { get; set; } = "";
        public string HorizonEstablismentPotential { get; set; }
        public string HorizonEstablismentPotentialDescription { get; set; } = "";
        public string HorizonEcologicalEffect { get; set; }
        public string HorizonEcologicalEffectDescription { get; set; } = "";
        public string HorizonScanningStatus { get; set; } = "notStarted";
    }




    public partial class FA2023 // (3.1) Artens status
    {
        public string AlienSpeciesCategory2012 { get; set; }
        public string DoorKnockerDescription { get; set; }
        public string NotReproductiveDescription2012 { get; set; }
        public string NotReproductiveFutureDescription2012 { get; set; }
        public string AssesmentNotApplicableDescription { get; set; }

        /// <summary>
        /// Tekstlig informasjon knytt til at arter er koblet til vurdering for høyere eller lavere taxonomi
        /// </summary>
        public string ConnectedToHigherLowerTaxonDescription { get; set; } = "";

        /// <summary>
        /// Tekstlig informasjon knytt til at art vurderes sammen med ett annet taxon
        /// </summary>
        public string ConnectedToAnotherTaxonDescription { get; set; } = "";

        /// <summary>
        /// Tekstlig informasjon knytt til usikkerhet rundt etableringstidspunkt
        /// </summary>
        public string UncertainityEstablishmentTimeDescription { get; set; } = "";

        /// <summary>
        /// Tekstlig informasjon knytt til tradisjonell produksjonarter fra 2018
        /// </summary>
        public string ProductionSpeciesDescription { get; set; } = "";

        public string UncertainityStatusDescription { get; set; }

        public bool? IsAlienSpecies { get; set; }

        public string IsAlien { get; set; } // new in 2021
        public bool? IsRegionallyAlien { get; set; }

        public bool? ConnectedToAnother { get; set; }

        public bool? HigherOrLowerLevel { get; set; }

        public string Connected { get; set; }

        public CTaxon ConnectedTaxon { get; set; }

        public string SpeciesStatus { get; set; }

        public bool? ProductionSpecies { get; set; } // = false; sah #358

        public string ChangedFromAlien { get; set; }

        /// <summary>
        /// Beskriv hva som ligger til grunn for endringa i artens status
        /// </summary>
        public string ChangedAssessment { get; set; }

        public bool? AlienSpecieUncertainIfEstablishedBefore1800 { get; set; }
        public bool AlienSpecieUncertainAntropochor { get; set; }
        public string AlienSpecieUncertainDescription { get; set; }

        public bool? AssumedReproducing50Years { get; set; }

        public bool SkalVurderes { get; set; }

        public string DoorKnockerCategory { get; set; }
        public string RegionallyAlienCategory { get; set; }
        public string NotApplicableCategory { get; set; }

        public class TimeAndPlace
        {
            public string Place { get; set; }
            public string Time { get; set; }
        }
        public class ObservedAndEstablished
        {
            public TimeAndPlace ObservedInCountry { get; set; } = new TimeAndPlace();
            public TimeAndPlace FertileSpecimenObserved { get; set; } = new TimeAndPlace();
            public TimeAndPlace Established { get; set; } = new TimeAndPlace();
            public TimeAndPlace Population { get; set; } = new TimeAndPlace();
            public string SpecimenCount { get; set; }
        }
        public class ObservedAndEstablishedInCountry
        {
            public ObservedAndEstablished Indoor { get; set; } = new ObservedAndEstablished();
            public ObservedAndEstablished ProductionArea { get; set; } = new ObservedAndEstablished();
            public ObservedAndEstablished NorwegianNature { get; set; } = new ObservedAndEstablished();
        }
        public ObservedAndEstablishedInCountry ObservedAndEstablishedStatusInCountry { get; set; } = new ObservedAndEstablishedInCountry();
    }

    public partial class FA2023 // Fylkesforekomster
    {
        private List<Fylkesforekomst> _fylkesforekomster;

        public List<Fylkesforekomst> Fylkesforekomster
        {
            get
            {
                if (_fylkesforekomster == null || _fylkesforekomster.Count == 0)
                {
                    _fylkesforekomster = GetInitialFylkesforekomster();
                }
                return _fylkesforekomster;
            }
            set { _fylkesforekomster = value; }
        }
        private void InitFylkesforekomster()
        {
            Fylkesforekomster = GetInitialFylkesforekomster();
        }

        private static List<Fylkesforekomst> GetInitialFylkesforekomster()
        {
            return new List<Fylkesforekomst>
            {
                new Fylkesforekomst { Fylke = "Øs", State2 = 1 },
                new Fylkesforekomst { Fylke = "OsA", State2 = 1 },
                new Fylkesforekomst { Fylke = "He", State2 = 1 },
                new Fylkesforekomst { Fylke = "Op", State2 = 1 },
                new Fylkesforekomst { Fylke = "Bu", State2 = 1 },
                new Fylkesforekomst { Fylke = "Ve", State2 = 1 },
                new Fylkesforekomst { Fylke = "Te", State2 = 1 },
                new Fylkesforekomst { Fylke = "Aa", State2 = 1 },
                new Fylkesforekomst { Fylke = "Va", State2 = 1 },
                new Fylkesforekomst { Fylke = "Ro", State2 = 1 },
                new Fylkesforekomst { Fylke = "Ho", State2 = 1 },
                new Fylkesforekomst { Fylke = "Sf", State2 = 1 },
                new Fylkesforekomst { Fylke = "Mr", State2 = 1 },
                new Fylkesforekomst { Fylke = "St", State2 = 1 },
                new Fylkesforekomst { Fylke = "Nt", State2 = 1 },
                new Fylkesforekomst { Fylke = "No", State2 = 1 },
                new Fylkesforekomst { Fylke = "Tr", State2 = 1 },
                new Fylkesforekomst { Fylke = "Fi", State2 = 1 },
                new Fylkesforekomst { Fylke = "Sv", State2 = 1 },
                new Fylkesforekomst { Fylke = "Jm", State2 = 1 },
                new Fylkesforekomst { Fylke = "Ns", State2 = 1 },
                new Fylkesforekomst { Fylke = "Nh", State2 = 1 },
                new Fylkesforekomst { Fylke = "Gh", State2 = 1 },
                new Fylkesforekomst { Fylke = "Bn", State2 = 1 },
                new Fylkesforekomst { Fylke = "Bs", State2 = 1 }
            };
        }
    }

    public partial class FA2023 // (3.2) Artsegenskaper
    {
        public bool Limnic { get; set; }
        public bool Terrestrial { get; set; }
        public bool Marine { get; set; }
        public bool BrackishWater { get; set; }

        public string FirstDomesticObservation { get; set; }
        public string FirstDomesticObservationLocation { get; set; }
        public string FirstDomesticEstablishmentObserved { get; set; }
        public string FirstDomesticEstablishmentObservedLocation { get; set; }


        public List<string> ArrivedCountryFrom { get; set; } = new List<string>();
        public string ArrivedCountryFromDetails { get; set; } = "";
        public class NaturalOrigin
        {
            public string ClimateZone { get; set; }
            //public string ClimateZoneSubtype { get; set; }
            public bool Europe { get; set; }
            public bool Asia { get; set; }
            public bool Africa { get; set; }
            public bool Oceania { get; set; }
            public bool NorthAndCentralAmerica { get; set; }
            public bool SouthAmerica { get; set; }
        }

        public class CoastLineSection
        {
            public string ClimateZone { get; set; }
            //public string ClimateZoneSubtype { get; set; }
            public bool None { get; set; }
            public bool OpenCoastLine { get; set; }
            public bool Skagerrak { get; set; }
        }

        public class BioClimateZones
        {
            public string ClimateZone { get; set; }
            //public string ClimateZoneSubtype { get; set; }
            public bool StrongOceanic { get; set; }
            public bool ClearOceanic { get; set; }
            public bool WeakOceanic { get; set; }
            public bool TransferSection { get; set; }
            public bool WeakContinental { get; set; }
        }

        public class BioClimateZonesArctic
        {
            public string ClimateZone { get; set; }
            //public string ClimateZoneSubtype { get; set; }

            public bool WeakOceanic { get; set; }
            public bool TransferSection { get; set; }
            public bool WeakContinental { get; set; }

            public bool ClearContinental { get; set; }
        }

        public List<NaturalOrigin> NaturalOrigins { get; set; } = new List<NaturalOrigin>();
        public string NaturalOriginUnknownDocumentation { get; set; }
        public List<NaturalOrigin> CurrentInternationalExistenceAreas { get; set; } = new List<NaturalOrigin>();

        public List<CoastLineSection> CoastLineSections { get; set; } = new List<CoastLineSection>()  {
                new CoastLineSection() {ClimateZone = "northSeaAndSkagerrak",       None=false,OpenCoastLine=false,Skagerrak=false },
                new CoastLineSection() {ClimateZone = "norwegianSea",               None=false,OpenCoastLine=false,Skagerrak=false },
                new CoastLineSection() {ClimateZone = "barentsSea",                 None=false,OpenCoastLine=false,Skagerrak=false },
                new CoastLineSection() {ClimateZone = "greenlandSea",               None=false,OpenCoastLine=false,Skagerrak=false },
                new CoastLineSection() {ClimateZone = "polarSea",                   None=false,OpenCoastLine=false,Skagerrak=false }
            };

        public List<BioClimateZones> CurrentBioClimateZones { get; set; } = new List<BioClimateZones>() {
                new BioClimateZones() {ClimateZone = "boreonemoral",                  StrongOceanic=false,ClearOceanic=false,WeakOceanic=false,TransferSection=false,WeakContinental=false },
                new BioClimateZones() {ClimateZone = "southBoreal",                   StrongOceanic=false,ClearOceanic=false,WeakOceanic=false,TransferSection=false,WeakContinental=false },
                new BioClimateZones() {ClimateZone = "midBoreal",                     StrongOceanic=false,ClearOceanic=false,WeakOceanic=false,TransferSection=false,WeakContinental=false },
                new BioClimateZones() {ClimateZone = "northBoreal",                   StrongOceanic=false,ClearOceanic=false,WeakOceanic=false,TransferSection=false,WeakContinental=false },
                new BioClimateZones() {ClimateZone = "alpineZones",                   StrongOceanic=false,ClearOceanic=false,WeakOceanic=false,TransferSection=false,WeakContinental=false }
            };
        public List<BioClimateZonesArctic> ArcticBioClimateZones { get; set; } = new List<BioClimateZonesArctic>(){
                new BioClimateZonesArctic() {ClimateZone = "midArctic",                  WeakOceanic=false,TransferSection=false,WeakContinental=false,ClearContinental=false },
                new BioClimateZonesArctic() {ClimateZone = "northArctic",                 WeakOceanic=false,TransferSection=false,WeakContinental=false,ClearContinental=false },
                new BioClimateZonesArctic() {ClimateZone = "northArcticDesert",          WeakOceanic=false,TransferSection=false,WeakContinental=false,ClearContinental=false }
            };
        public string CurrentInternationalExistenceAreasUnknownDocumentation { get; set; }

        public void initNaturalOrigins()
        {
            NaturalOrigins = new List<NaturalOrigin> {
                new NaturalOrigin() {ClimateZone = "polar;",                  Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "temperate;boreal",        Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "temperate;nemoral",       Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "temperate;dry",           Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "subtropic;unspecified",   Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "subtropic;mediterranean", Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "subtropic;humid",         Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "subtropic;dry",           Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "subtropic;caperegion",    Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "subtropic;highlands",     Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "tropic;",                 Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "unknown;",                Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false }
            };

            CurrentInternationalExistenceAreas = new List<NaturalOrigin> {
                new NaturalOrigin() {ClimateZone = "polar;",                  Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "temperate;boreal",        Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "temperate;nemoral",       Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "temperate;dry",           Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "subtropic;unspecified",   Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "subtropic;mediterranean", Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "subtropic;humid",         Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "subtropic;dry",           Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "subtropic;caperegion",    Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "subtropic;highlands",     Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "tropic;",                 Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
                new NaturalOrigin() {ClimateZone = "unknown;",                Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false }
            };

            CoastLineSections = new List<CoastLineSection> {
                new CoastLineSection() {ClimateZone = "northSeaAndSkagerrak",       None=false,OpenCoastLine=false,Skagerrak=false },
                new CoastLineSection() {ClimateZone = "norwegianSea",               None=false,OpenCoastLine=false,Skagerrak=false },
                new CoastLineSection() {ClimateZone = "barentsSea",                 None=false,OpenCoastLine=false,Skagerrak=false },
                new CoastLineSection() {ClimateZone = "greenlandSea",               None=false,OpenCoastLine=false,Skagerrak=false },
                new CoastLineSection() {ClimateZone = "polarSea",                   None=false,OpenCoastLine=false,Skagerrak=false }
            };

            CurrentBioClimateZones = new List<BioClimateZones> {
                new BioClimateZones() {ClimateZone = "boreonemoral",                  StrongOceanic=false,ClearOceanic=false,WeakOceanic=false,TransferSection=false,WeakContinental=false },
                new BioClimateZones() {ClimateZone = "southBoreal",                   StrongOceanic=false,ClearOceanic=false,WeakOceanic=false,TransferSection=false,WeakContinental=false },
                new BioClimateZones() {ClimateZone = "midBoreal",                     StrongOceanic=false,ClearOceanic=false,WeakOceanic=false,TransferSection=false,WeakContinental=false },
                new BioClimateZones() {ClimateZone = "northBorealnorthBoreal",        StrongOceanic=false,ClearOceanic=false,WeakOceanic=false,TransferSection=false,WeakContinental=false },
                new BioClimateZones() {ClimateZone = "alpineZones",                   StrongOceanic=false,ClearOceanic=false,WeakOceanic=false,TransferSection=false,WeakContinental=false }
            };

            ArcticBioClimateZones = new List<BioClimateZonesArctic> {
                new BioClimateZonesArctic() {ClimateZone = "midArctic;",                  WeakOceanic=false,TransferSection=false,WeakContinental=false,ClearContinental=false },
                new BioClimateZonesArctic() {ClimateZone = "northArctic",                 WeakOceanic=false,TransferSection=false,WeakContinental=false,ClearContinental=false },
                new BioClimateZonesArctic() {ClimateZone = "northArcticDesert;",          WeakOceanic=false,TransferSection=false,WeakContinental=false,ClearContinental=false }
            };
        }
        public List<string> NaturalOriginMarine { get; set; } = new List<string>();
        public string NaturalOriginMarineDetails { get; set; }
        public List<string> CurrentInternationalExistenceMarineAreas { get; set; } = new List<string>();
        public string CurrentInternationalExistenceMarineAreasDetails { get; set; }

        public bool SurvivalBelow5c { get; set; }

        public List<string> IntroductionCourse { get; set; }

        public bool? DomesticRiskEvaluationExists { get; set; }
        public bool? DomesticRiskEvaluationExists2007 { get; set; }
        public bool? ForeignRiskEvaluationExists { get; set; }
        public string ForeignRiskEvaluationComment { get; set; }

        public string Regeneration { get; set; }
        public int? RegenerationYears { get; set; }
        public string Reproduction { get; set; }
        public bool? ReproductionAsexual { get; set; }
        public double? ReproductionGenerationTime { get; set; }
        public bool? ReproductionSexual { get; set; }
        public bool? SimilarDemographicComparison { get; set; }

        // public string HealthEffects { get; set; }
        // public string EconomicEffects { get; set; }
        public List<string> EcosystemServiceEffectsBasicLifeProcesses { get; set; } = new List<string>();
        public List<string> EcosystemServiceEffectsProvisioningServices { get; set; } = new List<string>();
        public List<string> EcosystemServiceEffectsRegulatingServices { get; set; } = new List<string>();
        public List<string> EcosystemServiceEffectsHumanSpiritualServices { get; set; } = new List<string>(); // :-)
        public string PositiveEcologicalEffects { get; set; }
        public string EffectsOnPopulationOfOrigin { get; set; }

        public string RegionalPresenceKnown { get; set; }
        public string RegionalPresenceAssumed { get; set; }
        public string RegionalPresencePotential { get; set; }
    }
    public partial class FA2023 // (3.3) Import
    {
        public List<MigrationPathway> ImportPathways { get; set; } = new List<MigrationPathway>();
        //public bool ImportedToIndoorOrProductionArea { get; set; } = false;

        public string IndoorProduktion { get; set; }
    }
    public partial class FA2023 // (3.4) Spredningsveier
    {
        public List<MigrationPathway> AssesmentVectors { get; set; } = new List<MigrationPathway>();
        //public string Vector { get; set; }  // ???!!
        public string SpreadIndoorFurtherInfo { get; set; } = "";
        public string SpreadIndoorFurtherInfoGeneratedText { get; set; } = "";
        public string SpreadIntroductionFurtherInfo { get; set; } = "";
        public string SpreadIntroductionFurtherInfoGeneratedText { get; set; } = "";
        public string SpreadFurtherSpreadFurtherInfo { get; set; } = "";
        public string SpreadFurtherSpreadFurtherInfoGeneratedText { get; set; } = "";



    }
    public partial class FA2023 // (3.5) Spredningshistorikk
    {
        public List<SpreadHistory> SpreadHistory { get; set; } = new List<SpreadHistory>();

        //[DisplayName("Fremtidig spredningsprognose i Norge, inkl. potensielt utbredelsesområde, antatte kritiske parametre for arten, og forventede endringer i disse:")] // 
        public string SpreadHistoryDomesticDocumentation { get; set; }
        //[DisplayName("Detaljinformasjon for Naturtyper:")] // 
        public string SpreadHistoryForeignDocumentation { get; set; }

        public string FutureDistributionChangeExpectedDescription { get; set; }
        public string FutureDistributionCriticalParameters { get; set; }

        public Int64? PotentialAreaDistribution { get; set; }
        public string PotentialAreaDistributionInTheFuture { get; set; }

        public Int64? CurrentIndividualCount { get; set; }
        public Int64? CurrentIndividualCountLowCalculated { get; set; }
        public string CurrentIndividualCountLowMultiplier { get; set; }
        public Int64? CurrentIndividualCountCalculated { get; set; }
        public string CurrentIndividualCountMultiplier { get; set; }
        public string CurrentIndividualCountHighMultiplier { get; set; }
        public Int64? CurrentIndividualCountHighCalculated { get; set; }

        public Int64? CurrentSpreadArea { get; set; }
        public Int64? CurrentSpreadAreaLowCalculated { get; set; }
        public Int64? CurrentSpreadAreaHighCalculated { get; set; }
        public Int64? CurrentSpreadAreaCalculated { get; set; }


        public string CurrentPresenceComment { get; set; }

        public string SpreadAreaInChangedNature { get; set; }

        public string SpeciesEstablishmentCategory { get; set; }

    }
    public partial class FA2023 // (4) Naturtyper
    {
        public List<ImpactedNatureType> ImpactedNatureTypes { get; set; } = new List<ImpactedNatureType>();

        /// <summary>
        /// Naturetypes from 2018 after NIN2_2 which are not compatible with NIN2_3 - for reference - not for edit   ???
        /// </summary>
        public List<ImpactedNatureType> ImpactedNatureTypesFrom2018 { get; set; } = new List<ImpactedNatureType>();

        public List<RedlistedNatureType> RedlistedNatureTypes { get; set; } = new List<RedlistedNatureType>();

        public List<Habitat> Habitats { get; set; } = new List<Habitat>();

        public bool UsesLivingSpeciesAsHabitat { get; set; }
        public string UsesLivingSpeciesAsHabitatScientificName { get; set; }
    }

    public partial class FA2023 // (5) Risikovurdering
    {
        //public class RegionalRiskAssessment
        //{
        //    public string Name { get; set; }
        //    public RiskAssessment RiskAssessment { get; set; }
        //}

        public RiskAssessment RiskAssessment { get; set; } = new RiskAssessment();
        //public List<RegionalRiskAssessment> RegionalRiskAssessments { get; set; } = new List<RegionalRiskAssessment>();
    }



    public partial class RiskAssessment // FA2023 // () Risikovurdering (dette er avledet informasjon!!)
    {
        //-------------------------------------------------------------------------------
        // --------------------------- Risikovurdering ----------------------------------
        //-------------------------------------------------------------------------------

        //[JsonExtensionData()]
        //public Dictionary<string, JsonElement>? ExtensionData { get; set; }

        public int RiskLevel { get; set; } = -1;
        public string DecisiveCriteria { get; set; }
        public string RiskLevelCode { get; set; }
        public string RiskLevelText { get; set; }

        public int EcoEffectLevel { get; set; }
        public int[] EcoEffectUncertaintyLevels { get; set; }

        public int InvationPotentialLevel { get; set; }
        public int[] InvationPotentialUncertaintyLevels { get; set; }


        public int? YearFirstIndoors { get; set; }
        public bool YearFirstIndoorsInsecure { get; set; }
        public int? YearFirstReproductionIndoors { get; set; }
        public bool YearFirstReproductionIndoorsInsecure { get; set; }
        public int? YearFirstProductionOutdoors { get; set; }
        public bool YearFirstProductionOutdoorsInsecure { get; set; }
        public int? YearFirstReproductionOutdoors { get; set; }
        public bool YearFirstReproductionOutdoorsInsecure { get; set; }
        public int? YearFirstEstablishmentProductionArea { get; set; }
        public bool YearFirstEstablishmentProductionAreaInsecure { get; set; }
        public int? YearFirstNature { get; set; }
        public bool YearFirstNatureInsecure { get; set; }
        public int? YearFirstReproductionNature { get; set; }
        public bool YearFirstReproductionNatureInsecure { get; set; }
        public int? YearFirstEstablishedNature { get; set; }
        public bool YearFirstEstablishedNatureInsecure { get; set; }
        public string YearFirstDomesticObservation { get; set; }
    }

    public partial class RiskAssessment // (5.1+5.2) Klassifisering (Ivasjonspotensial+Økologisk effekt)
    {
        public class Criterion
        {
            public string Id { get; set; }

            public int Value { get; set; }
            public Axis Akse { get; set; }
            public string CriteriaLetter { get; set; }
            public string NoValueInformation { get; set; }  // skal være med??
            public int[] UncertaintyValues { get; set; } = new int[] { };
            public bool Auto { get; set; } = false;
            public enum Axis
            {
                Invasion,
                EcoEffect
            }
        }

        // ---------- klassifisering -------------
        #region Criterion
        public List<Criterion> Criteria { get; set; }
        public static RiskAssessment.Criterion CreateDomainCriterion(string id, string criteraLetter, RiskAssessment.Criterion.Axis akse)
        {
            return new RiskAssessment.Criterion()
            {
                Id = id,
                Akse = akse,
                CriteriaLetter = criteraLetter,
                Value = 0,
                NoValueInformation = null,
                UncertaintyValues = new[] { 0 }
            };
        }

        public static List<Criterion> CreateDefaultCriteria()
        {
            var criteria = new List<RiskAssessment.Criterion>();
            criteria.Add(CreateDomainCriterion("InvasionPopulationLifetimeExpectancy", "A", RiskAssessment.Criterion.Axis.Invasion));
            criteria.Add(CreateDomainCriterion("InvasionExpansionSpeed", "B", RiskAssessment.Criterion.Axis.Invasion));
            criteria.Add(CreateDomainCriterion("InvasionColonizationOfNaturetypeAfter50Years", "C", RiskAssessment.Criterion.Axis.Invasion));
            criteria.Add(CreateDomainCriterion("EcologicalEffectInteractionWithThreatenedSpecies", "D", RiskAssessment.Criterion.Axis.EcoEffect));
            criteria.Add(CreateDomainCriterion("EcologicalEffectInteractionWithDomesticSpecies", "E", RiskAssessment.Criterion.Axis.EcoEffect));
            criteria.Add(CreateDomainCriterion("EcologicalEffectInfluenceOnThreatenedNatureTypes", "F", RiskAssessment.Criterion.Axis.EcoEffect));
            criteria.Add(CreateDomainCriterion("EcologicalEffectInfluenceOnCommonNatureTypes", "G", RiskAssessment.Criterion.Axis.EcoEffect));
            criteria.Add(CreateDomainCriterion("EcologicalEffectTransferOfGeneticMaterial", "H", RiskAssessment.Criterion.Axis.EcoEffect));
            criteria.Add(CreateDomainCriterion("EcologicalEffectTransferOfDiseasesAndParasites", "I", RiskAssessment.Criterion.Axis.EcoEffect));
            return criteria;
        }

        #endregion
    }
    public partial class RiskAssessment // (5.1) Ivasjonspotensial
    {
        // ---------- invasjonspotensial -------------
        public bool? QuantitativeDataForDomesticSpreadExsists { get; set; }
        public bool? QuantitativeDataForForeignSpreadExsists { get; set; }
        public string QuantitativeDataComment { get; set; }

        public Int64? EstimatedSpeciesCount { get; set; }
        public string EstimatedSpeciesCountMethod { get; set; }
        public string EstimatedSpeciesCountAssumption { get; set; }
        public bool? EstimatedSpeciesLongevityMoreThan1000Years { get; set; }
        public string EstimatedSpeciesLongevity { get; set; }
        public string EstimatedSpeciesLongevityMethod { get; set; }

        //*************** Forekomstareal i dag ************************************
        [System.Text.Json.Serialization.JsonPropertyName("AOOknownInput")]
        public Int64? AOOknownInput { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOOknown")]
        public Int64? AOOknown { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOOknown1")]
        public Int64? AOOknown1 { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOOknown2")]
        public Int64? AOOknown2 { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOOtotalBestInput")]
        public Int64? AOOtotalBestInput { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOOtotalBest")]
        public Int64? AOOtotalBest { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOOtotalLowInput")]
        public Int64? AOOtotalLowInput { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOOtotalLow")]
        public Int64? AOOtotalLow { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOOtotalHighInput")]
        public Int64? AOOtotalHighInput { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOOtotalHigh")]
        public Int64? AOOtotalHigh { get; set; }

        [System.Text.Json.Serialization.JsonPropertyName("AOOchangeBest")]
        public double? AOOchangeBest { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOOchangeLow")]
        public double? AOOchangeLow { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOOchangeHigh")]
        public double? AOOchangeHigh { get; set; }

        public int? AdefaultBest { get; set; }
        public int? AdefaultLow { get; set; }
        public int? AdefaultHigh { get; set; }

        public int? ApossibleLow { get; set; }
        public int? ApossibleHigh { get; set; }

        public bool NotUseSpeciesMap { get; set; } = false;

        // *******  (B2a) Økning i forekomstareal – selvstendig reproduserende arter  **********
        [System.Text.Json.Serialization.JsonPropertyName("AOOyear1")]
        public long? AOOyear1 { get; set; } // fra-årstallet for det første forekomstarealet 
        [System.Text.Json.Serialization.JsonPropertyName("AOOendyear1")]
        public long? AOOendyear1 { get; set; } // basert på periode: f.o.m. år (t0) - (NB!! //todo: denne egenskaper bør skifte navn i neste FAB)
        [System.Text.Json.Serialization.JsonPropertyName("AOOyear2")]
        public long? AOOyear2 { get; set; } // fra-årstallet for det andre forekomstarealet 
        [System.Text.Json.Serialization.JsonPropertyName("AOOendyear2")]
        public long? AOOendyear2 { get; set; } // basert på periode: t.o.m. år  - (NB!! //todo: denne egenskaper bør skifte navn i neste FAB)
        [System.Text.Json.Serialization.JsonPropertyName("AOO1")]
        public long? AOO1 { get; set; } // forekomstarealet i år 1 
        [System.Text.Json.Serialization.JsonPropertyName("AOO2")]
        public long? AOO2 { get; set; } // forekomstarealet i år 2 
        // ************************************************************************************


        //*************** Forekomstareal om 50år ************************************
        [System.Text.Json.Serialization.JsonPropertyName("AOO50yrBestInput")]
        public Int64? AOO50yrBestInput { get; set; } // beste anslag på totalt forekomstareal om 50 år 
        [System.Text.Json.Serialization.JsonPropertyName("AOO50yrBest")]
        public Int64? AOO50yrBest { get; set; } // beste anslag på totalt forekomstareal om 50 år 
        [System.Text.Json.Serialization.JsonPropertyName("AOO50yrLowInput")]
        public Int64? AOO50yrLowInput { get; set; } // lavt anslag på totalt forekomstareal om 50 år 
        [System.Text.Json.Serialization.JsonPropertyName("AOO50yrLow")]
        public Int64? AOO50yrLow { get; set; } // lavt anslag på totalt forekomstareal om 50 år 
        [System.Text.Json.Serialization.JsonPropertyName("AOO50yrHighInput")]
        public Int64? AOO50yrHighInput { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOO50yrHigh")]
        public Int64? AOO50yrHigh { get; set; }
        [System.Text.Json.Serialization.JsonPropertyName("AOOfirstOccurenceLessThan10Years")]
        public string AOOfirstOccurenceLessThan10Years { get; set; } = "yes";

        public double? SpreadHistoryDomesticAreaInStronglyChangedNatureTypes { get; set; }
        public double? SpreadHistoryDomesticAreaInStronglyChangedNatureTypesLow { get; set; }
        public double? SpreadHistoryDomesticAreaInStronglyChangedNatureTypesBest { get; set; }
        public double? SpreadHistoryDomesticAreaInStronglyChangedNatureTypesHigh { get; set; }



        #region (A) Populasjonens mediane levetid

        public string AcceptOrAdjustCritA { get; set; } = "accept";  // ametod submetod (radio)
        public string ChosenSpreadMedanLifespan { get; set; } = "";  // ametod (radio)
        public string ReasonForAdjustmentCritA { get; set; } = "";
        public bool ActiveSpreadPVAAnalysisSpeciesLongevity { get; set; }

        [DisplayName("PVA-analyse beskrivelse")]
        public string SpreadPVAAnalysis { get; set; }
        [DisplayName("Forventet levetid")]
        public bool ActiveSpreadPVAAnalysisEstimatedSpeciesLongevity { get; set; }
        public string SpreadPVAAnalysisEstimatedSpeciesLongevity { get; set; }
        public string SpreadPVAAnalysisEstimatedSpeciesLongevityLowerQuartile { get; set; }
        public string SpreadPVAAnalysisEstimatedSpeciesLongevityUpperQuartile { get; set; }

        public string FilesDescription { get; set; }


        ////todo: is this section in use???
        ////Rødliste info
        //public bool ActiveRedListCategoryLevel { get; set; }
        //public string RedListUsedCriteria { get; set; }
        //public string RedListDataDescription { get; set; }
        //public string RedListCategory { get; set; }
        //public string RedListSubCategory { get; set; }


        // ****************************  (A2) Numerisk estimering  ****************************
        public long? PopulationSize { get; set; } // bestandens nåværende størrelse (individtall) 
        public double? GrowthRate { get; set; } // bestandens multiplikative vekstrate 
        public double? EnvVariance { get; set; } // miljøvarians 
        public double? DemVariance { get; set; } // demografisk varians 
        public long? CarryingCapacity { get; set; } // bestandens bæreevne (individtall) 
        public long? ExtinctionThreshold { get; set; } // kvasiutdøingsterskel (individtall) 
        #endregion

        #region Median life time
        public double? MedianLifetimeInput { get; set; } // artens mediane levetid i Norge i år (brukerinput)
        public long MedianLifetime { get; set; } // artens mediane levetid i Norge i år (beregnet/avrundet)
        public long? LifetimeLowerQInput { get; set; } // nedre kvartil for artens levetid i Norge i år 
        public long LifetimeLowerQ { get; set; } // nedre kvartil for artens levetid i Norge i år 
        public long? LifetimeUpperQInput { get; set; } // øvre kvartil for artens levetid i Norge i år 
        public long LifetimeUpperQ { get; set; } // øvre kvartil for artens levetid i Norge i år 
        #endregion Median life time

        public string Amethod { get; set; } // metode som ble brukt for å beregne A-kriteriet 
        public int Ascore { get; set; } // skår for A-kriteriet

        /// <summary>
        /// Score for metode C rødlistekriterier fra 2018 vurdering
        /// </summary>
        public int? ROAscore2018 { get; set; } // skår for A-kriteriet 
        public int Alow { get; set; } // nedre skår for A-kriteriet (inkludert usikkerhet) 
        public int Ahigh { get; set; } // øvre skår for A-kriteriet (inkludert usikkerhet) 
        public string Bmethod { get; set; } // metode som ble brukt for å beregne B-kriteriet 
        public int Bscore { get; set; } // skår for B-kriteriet 
        public int Blow { get; set; } // nedre skår for B-kriteriet (inkludert usikkerhet) 
        public int Bhigh { get; set; } // øvre skår for B-kriteriet (inkludert usikkerhet) 

        //[JsonConverter(typeof(JsonHelpers.CrazyStringJsonConverter))]
        public string BCritMCount { get; set; } = "";
        public string BCritExact { get; set; } = "false";
        public string BCritP { get; set; }

        public string BCritModel { get; set; } = "1";

        public string BCritOccurrences { get; set; } = "a";
        public string BCritNewObs { get; set; } = "True";


        public int StartYear { get; set; } // startår for B-kriteriet / utbredelse

        public int EndYear { get; set; } // sluttår for B-kriteriet / utbredelse

        [System.Text.Json.Serialization.JsonPropertyName("AOOdarkfigureBest")]
        public float? AOOdarkfigureBest { get; set; } // beste anslag på forekomstarealets mørketall 
        [System.Text.Json.Serialization.JsonPropertyName("AOOdarkfigureLow")]
        public float? AOOdarkfigureLow { get; set; } // lavt anslag på forekomstarealets mørketall 
        [System.Text.Json.Serialization.JsonPropertyName("AOOdarkfigureHigh")]
        public float? AOOdarkfigureHigh { get; set; } // høyt anslag på forekomstarealets mørketall 
        [System.Text.Json.Serialization.JsonPropertyName("AOO10yrBest")]
        public long? AOO10yrBest { get; set; } // beste anslag på totalt forekomstareal om 10 år
        [System.Text.Json.Serialization.JsonPropertyName("AOO10yrLow")]
        public long? AOO10yrLow { get; set; } // lavt anslag på totalt forekomstareal om 10 år
        [System.Text.Json.Serialization.JsonPropertyName("AOO10yrHigh")]
        public long? AOO10yrHigh { get; set; } // høyt anslag på totalt forekomstareal om 10 år


        #region (B) Ekspansjonshastighet

        public string ChosenSpreadYearlyIncrease { get; set; } = "";  // bmetod (radio)
        public bool ActiveSpreadYearlyIncreaseObservations { get; set; }


        // ********************** (b) Forekomstareal – dørstokkarter  ****************************
        public long? Occurrences1Best { get; set; }	// beste anslag på antall forekomster fra 1 introduksjon 
        public long? Occurrences1Low { get; set; }	// lavt anslag på antall forekomster fra 1 introduksjon 
        public long? Occurrences1High { get; set; }	// høyt anslag på antall forekomster fra 1 introduksjon 
        public long? IntroductionsBest { get; set; }	// beste anslag på antall introduksjoner i løpet av 10 år 
        public long? IntroductionsLow { get; set; }	    // lavt anslag på antall introduksjoner i løpet av 10 år 
        public long? IntroductionsHigh { get; set; }	// høyt anslag på antall introduksjoner i løpet av 10 år 
        // ****************************************************************************************


        // ********************** ((B1) ekspansjonshastighet  ****************************
        public long? ExpansionSpeedInput { get; set; }  // ekspansjonshastighet i meter per år 
        public long? ExpansionSpeed { get; set; }  // ekspansjonshastighet i meter per år 
        public long? ExpansionLowerQInput { get; set; } // nedre kvartil for ekspansjonshastighet i meter per år 
        public long? ExpansionLowerQ { get; set; } // nedre kvartil for ekspansjonshastighet i meter per år 
        public long? ExpansionUpperQInput { get; set; } // øvre kvartil for ekspansjonshastighet i meter per år 
        public long? ExpansionUpperQ { get; set; } // øvre kvartil for ekspansjonshastighet i meter per år 
        // *********************************************************************************


        public bool ActiveSpreadYearlyLiteratureData { get; set; }
        public string SpreadYearlyLiteratureDataExpansionSpeed { get; set; }
        public string SpreadYearlyLiteratureDataUncertainty { get; set; }
        public string SpreadYearlyLiteratureDataNumberOfIntroductionSources { get; set; }
        public string SpreadYearlyLiteratureData { get; set; }
        public string SpreadYearlyLiteratureDataSource { get; set; }


        public bool ActiveSpreadYearlyIncreaseCalculatedExpansionSpeed { get; set; }
        public string SpreadYearlyIncreaseEstimate { get; set; }
        public string SpreadYearlyIncreaseEstimateDescription { get; set; }
        public string SpreadYearlyIncreaseCalculatedExpansionSpeed { get; set; }

        #endregion (B) Ekspansjonshastighet

        //#region unused ???????
        //// -- spredningshastighet
        //public double? SpreadYearlyIncrease { get; set; }
        //public string SpreadYearlyIncreaseMethod { get; set; }
        //#endregion unused ???????


        //#region unused ???????
        //[DisplayName("Beskrivelse")]
        //public string SpreadManualEstimate { get; set; } // fab: Spread_Manual_Estimate
        //public string SpreadManualEstimateSpeciesLongevity { get; set; } // fab: Spread_Manual_Estimate_Species_Longevity
        //public bool? SpreadManualEstimateSpeciesLongevityIsMoreThan1000years { get; set; } // fab: Spread_Manual_Estimate_Species_Longevity_More_than_1000_years
        //// -- fortetningsrate
        //[DisplayName("Fortetningsrate, konklusjon")]
        //public string IncreasingDensity { get; set; }  // Increasing_Density_Conclusion
        //[DisplayName("Grunnlag for fortetningsrate")]
        //public string IncreasingDensityMethod { get; set; }  // Increasing_Density_Method
        //#endregion





        //#region unused keys fortetningsrate - PVA - manual estimates
        //[DisplayName("Resultat fra script")]
        //public string IncreasingDensityPVAAnalysis { get; set; } //Increasing_Density_PVA_Analysis
        //[DisplayName("Verdi")]
        //public string IncreasingDensityPercentualComputation { get; set; } //Increasing_Density_Percentual_Computation
        //[DisplayName("Tidsperiode")]
        //public string IncreasingDensityPercentualComputationPeriod { get; set; } //Increasing_Density_Percentual_Computation_Period
        //[DisplayName("Anslag")]
        //public string IncreasingDensityManualEstimate { get; set; } //Increasing_Density_Manual_Estimate
        //[DisplayName("Begrunnelse")]
        //public string IncreasingDensityManualEstimateDescription { get; set; } //Increasing_Density_Manual_Estimate_Description
        //#endregion

        // -- naturtype forventet kolonisert
        [DisplayName("Beskrivelse")]
        public string NaturetypeExpectedColonized { get; set; }  // Spread_Naturetype_Expected_Colonization_Description
    }
    public partial class RiskAssessment // (5.2) Økologisk effekt
    {
        public abstract class Interaction
        {
            public string RedListCategory { get; set; }
            public bool KeyStoneSpecie { get; set; }
            public string Effect { get; set; }
            public bool EffectLocalScale { get; set; }
            public string InteractionType { get; set; }
            public List<string> InteractionTypes { get; set; } = new List<string>();
            public List<string> BasisOfAssessment { get; set; } = new List<string>();
            public string Scale { get; set; }

            public bool LongDistanceEffect { get; set; }
            public bool ConfirmedOrAssumed { get; set; }
            public string DomesticOrAbroad { get; set; }

        }

        public abstract class SpeciesInteraction : Interaction
        {
            public string ScientificName { get; set; }

            //[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
            //[JsonConverter(typeof(JsonHelpers.CrazyIntJsonConverter))]
            public int ScientificNameId { get; set; }
            public string ScientificNameAuthor { get; set; } = "";
            public string VernacularName { get; set; }
            public string TaxonRank { get; set; }
            //[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
            //[JsonConverter(typeof(JsonHelpers.CrazyIntJsonConverter))]
            public int TaxonId { get; set; }
        }

        public class SpeciesSpeciesInteraction : SpeciesInteraction
        {

            //public string ScientificName { get; set; }
            //public string VernacularName { get; set; }
            //public string RedListCategory { get; set; }
            //public bool? KeyStoneSpecie { get; set; }
            //public string Effect { get; set; }
            //public bool EffectLocalScale { get; set; }
            //public string InteractionType { get; set; }
            //public bool LongDistanceEffect { get; set; }
            //public bool ConfirmedOrAssumed { get; set; }
            //public string NorwayOrAbroad { get; set; }
        }

        public abstract class NaturetypeInteraction : Interaction
        {

        }
        public class SpeciesNaturetypeInteraction : NaturetypeInteraction
        {
            public string NiNCode { get; set; }
            public string Name { get; set; }
            public List<string> NiNVariation { get; set; } = new List<string>();
        }




        // - D + E kriteriet
        public List<SpeciesSpeciesInteraction> SpeciesSpeciesInteractions { get; set; } = new List<SpeciesSpeciesInteraction>();
        public List<SpeciesNaturetypeInteraction> SpeciesNaturetypeInteractions { get; set; } = new List<SpeciesNaturetypeInteraction>();
        public List<SpeciesNaturetypeInteraction> SpeciesNaturetypeInteractions2018 { get; set; } = new List<SpeciesNaturetypeInteraction>();
        public string SpeciesSpeciesInteractionsSupplementaryInformation { get; set; }
        public string DCritInsecurity { get; set; }
        public string ECritInsecurity { get; set; }

        // - H kriteriet
        public List<SpeciesSpeciesInteraction> GeneticTransferDocumented { get; set; } = new List<SpeciesSpeciesInteraction>();



        public class HostParasiteInteraction : SpeciesInteraction
        {
            public string ParasiteScientificName { get; set; }
            public string ParasiteVernacularName { get; set; }
            public string ParasiteEcoEffect { get; set; }

            public string Status { get; set; }
            public bool ParasiteNewForHost { get; set; }
            public bool ParasiteIsAlien { get; set; }
            public bool DiseaseConfirmedOrAssumed { get; set; }
        }

        public string HCritInsecurity { get; set; }

        // I kriterie
        public List<HostParasiteInteraction> HostParasiteInformations { get; set; } = new List<HostParasiteInteraction>();

        public string ICritInsecurity { get; set; }


        // -- (C) potensiale for å endre én eller flere truete/sjeldne naturtyper
        public List<string> ThreatenedNatureTypes { get; set; } = new List<string>();
        public bool? ThreatenedNatureTypesDomesticObserved { get; set; }
        public bool? ThreatenedNatureTypesDomesticDocumented { get; set; }
        public bool? ThreatenedNatureTypesForeignDocumented { get; set; }
        public string ThreatenedNatureTypesAffectedDomesticDescription { get; set; } // ???
        public string ThreatenedNatureTypesAffectedAbroadDescription { get; set; } = "";

        // -- (D) potensiale for å endre én eller flere øvrige naturtyper
        public List<string> CommonNatureTypes { get; set; } = new List<string>();

        public List<string> Naturetype2018 { get; set; } = new List<string>();
        public List<string> NaturetypeNIN2 { get; set; } = new List<string>();

        public List<string> BackgroundC { get; set; } = new List<string>();

        public List<string> BackgroundF { get; set; } = new List<string>();

        public List<string> BackgroundG { get; set; } = new List<string>();
        public List<string> Hovedøkosystem { get; set; } = new List<string>();


        public string NatureAffectedAbroadF { get; set; }

        public string NatureAffectedAbroadG { get; set; }

        public bool? CommonNatureTypesDomesticObserved { get; set; }
        public bool? CommonNatureTypesDomesticDocumented { get; set; }
        public bool? CommonNatureTypesForeignDocumented { get; set; }
        public string CommonNatureTypesAffectedDomesticDescription { get; set; }
        public string CommonNatureTypesAffectedAbroadDescription { get; set; } = "";

        // -- (E) kan overføre genetisk materiale til stedegne arter
        public string GeneticTransferDomesticDescription { get; set; }
        public bool? GeneticTransferDomesticObserved { get; set; }
        public bool? GeneticTransferDomesticDocumented { get; set; }
        public bool? GeneticTransferForeignDocumented { get; set; }

        // -- (F) Kan overføre bakterier, parasitter eller virus til stedegne arter
        public string VectorBiologicalDiseaseSpreadingDomesticDescription { get; set; }
        public bool? BiologicalDiseaseSpreadingDomesticObserved { get; set; }
        public bool? BiologicalDiseaseSpreadingDomesticDocumented { get; set; }
        public bool? BiologicalDiseaseSpreadingForeignDocumented { get; set; }
    }

    public partial class RiskAssessment // (5.3) Geografisk Variasjon
    {
        public List<string> GeographicalVariation { get; set; } = new List<string>();
        public string GeographicalVariationDocumentation { get; set; }
        public string PossibleLowerCategory { get; set; }
    }

    public partial class RiskAssessment // (5.4) Klimaeffekter
    {
        public string ClimateEffectsInvationpotential { get; set; }
        public string ClimateEffectsEcoEffect { get; set; }
        public string ClimateEffectsDocumentation { get; set; }
    }

    public partial class RiskAssessment // (5.5) Kriteriedokumentasjon
    {
        public string CriteriaDocumentation { get; set; }
        public string CriteriaDocumentationSpeciesStatus { get; set; }
        public string CriteriaDocumentationDomesticSpread { get; set; }
        public string CriteriaDocumentationInvationPotential { get; set; }
        public string CriteriaDocumentationEcoEffect { get; set; }
    }


    public partial class FA2023 // (8) Referanser
    {
        public List<SimpleReference> References { get; set; } = new List<SimpleReference>();
    }
    public partial class FA2023 // History
    {
        public List<PreviousAssessment> PreviousAssessments { get; set; } = new List<PreviousAssessment>();
    }


    public partial class FA2023 // FA2023 Internal classes
    {
        /// <summary>
        /// Static copy of information from previous assesment - for historical purposes
        /// </summary>
        public class PreviousAssessment
        {
            public int RevisionYear { get; set; } = 2018;
            public string AssessmentId { get; set; }
            public int RiskLevel { get; set; }
            public int SpreadRiskLevel { get; set; }
            public int EcologicalRiskLevel { get; set; }
            public string MainCategory { get; set; }
            public string MainSubCategory { get; set; }
            public string DecisiveCriteria { get; set; }
            //public bool? IsAlienSpecies { get; set; }
            //public bool? ConnectedToAnother { get; set; }
        }

        public class ImpactedNatureType
        {
            public string NiNCode { get; set; }
            public string Name { get; set; }
            public List<string> NiNVariation { get; set; } = new List<string>();
            public List<string> DominanceForrest { get; set; } = new List<string>();
            public long? NatureTypeArea { get; set; }
            public List<string> Background { get; set; } = new List<string>();
            public string TimeHorizon { get; set; }
            public string ColonizedArea { get; set; }
            public List<string> StateChange { get; set; } = new List<string>();
            public string AffectedArea { get; set; }
        }

        public class RedlistedNatureType
        {
            public string RedlistedNatureTypeName { get; set; }
            public string Category { get; set; }
            public List<string> Background { get; set; } = new List<string>();
            public string TimeHorizon { get; set; }
            public string ColonizedArea { get; set; }
            public List<string> StateChange { get; set; } = new List<string>();
            public string AffectedArea { get; set; }
        }

        public class Habitat
        {
            public string NiNCode { get; set; }
            public string Name { get; set; }
            public string RedlistedNatureTypeName { get; set; }
            public string Category { get; set; }
            public List<string> Background { get; set; } = new List<string>();
            public string TimeHorizon { get; set; }
            public string ColonizedArea { get; set; }
            public List<string> StateChange { get; set; } = new List<string>();
            public string AffectedArea { get; set; }

            public CTaxon Taxon { get; set; }
        }




        public class SimpleReference
        {
            public string Type { get; set; }

            public Guid ReferenceId { get; set; }

            public string FormattedReference { get; set; }
        }

        //public string LockedForEditByUser { get; set; }
        //public Guid? LockedForEditByUserId { get; set; }
        //public string LockedForEditTimeStamp { get; set; }
    }

    public partial class FA2023
    {
        public string ArtskartAdded { get; set; }  // ?
        public string ArtskartRemoved { get; set; } // ?
        public string ArtskartSelectionGeometry { get; set; }
        public string ArtskartSistOverført { get; set; }
        public ArtskartModel ArtskartModel { get; set; } = new ArtskartModel();
        public ArtskartWaterModel ArtskartWaterModel { get; set; } = new ArtskartWaterModel();
        public string ArtskartManuellKommentar { get; set; } = "";

        public int ArtskartManuellAdd { get; set; }
        public int ArtskartManuellRemove { get; set; }

    }

    public class ArtskartModel
    {
        public int ObservationFromYear { get; set; } = 1950;
        public int ObservationToYear { get; set; } = 2021;
        public bool IncludeNorge { get; set; } = true;
        public bool IncludeSvalbard { get; set; } = true;
        public bool ExcludeObjects { get; set; } = false;
        public bool ExcludeGbif { get; set; } = false;
    }

    public class ArtskartWaterModel
    {
        public bool IsWaterArea { get; set; }
        public IList<ArtskartWaterAreaModel> Areas { get; set; }
    }

    public class ArtskartWaterAreaModel
    {
        public string GlobalId { get; set; }
        public string Name { get; set; }
        public string VannregionId { get; set; }
        public int Disabled { get; set; }
        public int Selected { get; set; }
        public int State0 { get; set; }
        public int State1 { get; set; }
        public int State2 { get; set; }
        public int State3 { get; set; }
    }


    public class SpreadHistory
    {
        public SpreadHistory()
        {
        }

        public Guid Id { get; set; }
        public string Location { get; set; }
        public string Comment { get; set; }
        public string Regions { get; set; } = "";

        public string RegionsAssumed { get; set; } = "";

        public int ObservationYear { get; set; }
        public int ObservationFromYear { get; set; }
        public int ObservationMonth { get; set; }
        public int ObservationFromMonth { get; set; }
        public Int64? SpeciesCount { get; set; }
        public Int64? ExistenceArea { get; set; }
        public Int64? ExistenceAreaCount { get; set; }
        public Int64? SpreadArea { get; set; }

        public double? SpeciesCountDarkFigure { get; set; }

        public double? ExistenceAreaDarkFigure { get; set; }

        public double? ExistenceAreaCountDarkFigure { get; set; }

        public double? SpreadAreaDarkFigure { get; set; }

        public double? SpeciesCountCalculated { get; set; }

        public double? ExistenceAreaCalculated { get; set; }

        public double? ExistenceAreaCountCalculated { get; set; }

        public double? SpreadAreaCalculated { get; set; }

        public string SelectionGeometry { get; set; }
    }

    public class RegionalPresence
    {
        public string Id { get; set; }

        public bool Known { get; set; }
    }

    public class RegionalPresenceWithPotential
    {
        public string Id { get; set; }
        public bool Assumed { get; set; }
        public bool Known { get; set; }
        public bool Potential { get; set; }
    }

    public class RegionalPresenseWithAssumed : RegionalPresence
    {
        public bool Assumed { get; set; }
        //private string v;

        public RegionalPresenseWithAssumed()
        {
        }

        public RegionalPresenseWithAssumed(string id)
        {
            this.Id = id;
            this.Known = true;
        }
    }

    // todo: Move into Fremmedart2012  (conflict with propertyname)
    public class MigrationPathway // Vector
    {
        public string CodeItem { get; set; }
        public string IntroductionSpread { get; set; }
        public string InfluenceFactor { get; set; }
        public string Magnitude { get; set; }
        public string TimeOfIncident { get; set; }
        public string ElaborateInformation { get; set; }

        public string Category { get; set; }
    }

    public class MigrationPathwayCode
    {
        public string Id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public bool selectable { get; set; } = true; // should only select (raise event (to create new MigrationPath)) when true
        public List<MigrationPathwayCode> children { get; set; } = new List<MigrationPathwayCode>(); // 09.01.2017
    }


    public class RedlistedNatureTypeCodeGroup
    {
        public string Id { get; set; }

        public bool collapsed { get; set; } = true; // gui thing
        public List<RedlistedNatureTypeCode> children { get; set; } = new List<RedlistedNatureTypeCode>(); // 09.01.2017

    }
    public class RedlistedNatureTypeCode
    {
        public string Id { get; set; }
        public string theme { get; set; }
        public string link { get; set; }
        public string name { get; set; }
        public string NiN1TypeCode { get; set; }
        public string KTVNin1 { get; set; }
        public string category { get; set; }
    }
    public class FA4WithComments : FA2023
    {
        public string NewestCommentDate { get; set; }
        public int CommentClosed { get; set; }
        public int CommentOpen { get; set; }
        //public int CommentNew { get; set; }
        public int TaxonChange { get; set; }
    }

    public class Fylkesforekomst
    {
        public string Fylke { get; set; }
        public int State { get; set; }
        /// <summary>
        /// Kjent
        /// </summary>
        public int State0 { get; set; } = 0;

        /// <summary>
        /// Antatt nå
        /// </summary>
        public int State1 { get; set; } = 0;

        /// <summary>
        /// Ukjent
        /// </summary>
        public int State2 { get; set; } = 0;

        /// <summary>
        /// Antatt om 50 år
        /// </summary>
        public int State3 { get; set; } = 0;
    }
}