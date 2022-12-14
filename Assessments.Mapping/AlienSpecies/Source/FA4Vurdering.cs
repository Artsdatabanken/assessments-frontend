using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Assessments.Mapping.AlienSpecies.Helpers;

//using System.Text.Json.Serialization;

// https://github.com/Artsdatabanken/Fremmedartsbase2023/blob/main/Prod.Domain/FA4Vurdering.cs

namespace Assessments.Mapping.AlienSpecies.Source
{
    //public class VelgArtInfo
    //{
    //    public string TaxonId { get; set; }
    //    public string VurderingsContext { get; set; }
    //    public string Ekspertgruppe { get; set; }
    //}
    //public class NyVurderingsInfo
    //{
    //    //public string VurderingId { get; set; }
    //    public string ScientificName { get; set; }
    //    public int ScientificNameId { get; set; }
    //    public int TaxonId { get; set; }
    //    public string Author { get; set; }
    //    //public string VernacularName { get; set; }
    //    public string TaxonRank { get; set; }   // "Species" or "SupSpecies"
    //    public string VurderingsContext { get; set; } // not set in the request, but used in the process of validate the creation of new vurdering // not needed becauso ekspertgruppe contains context - no need to validate
    //    //public string VurderingsStatus { get; set; }
    //    public string Ekspertgruppe { get; set; } // vurderingscontext is derived from Ekspertgruppe
    //    public DateTime SistOppdatert { get; set; }
    //    public string SistOppdatertAv { get; set; }
    //    //public string Kategori { get; set; }

    //    //public Guid[] References { get; set; }
    //}
    public class TaxonHistory
    {
        public DateTime date { get; set; }
        public string username { get; set; } // The user that changed the name of the assesment to a new name (not this name)
        public string VitenskapeligNavn { get; set; }
        public string VitenskapeligNavnAutor { get; set; }
        public string VitenskapeligNavnHierarki { get; set; }
        public int VitenskapeligNavnId { get; set; }
        public int TaxonId { get; set; }
        public string TaxonRank { get; set; }   // "Species" or "SupSpecies"
        public string Ekspertgruppe { get; set; }
    }

    public class CTaxon
    {
        public string Id { get; set; }
        //[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonConverter(typeof(JsonHelpers.CrazyIntJsonConverter))]
        public int TaxonID { get; set; }
        public string ScientificName { get; set; }
        //[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        [JsonConverter(typeof(JsonHelpers.CrazyIntJsonConverter))]
        public int ScientificNameId { get; set; }

        public string ScientificNameAuthor { get; set; }

        public string VernacularName { get; set; }

        public string RedListCategory { get; set; }

        public List<string> TaxonSearchResult { get; set; }

        public string TaxonSearchString { get; set; }

        public string TaxonRank { get; set; }

    }

    public class TrackInfo
    {
        public string VurderingsId2015 { get; set; }
        public int OrgVitenskapeligNavnId { get; set; }
        public string OrgVitenskapeligNavn { get; set; }
        public string Url2015 { get; set; }
        public string Kategori2015 { get; set; }
        public string Kriterier2015 { get; set; }
        public int ScientificNameId2015 { get; set; }
        public string ScientificName2015 { get; set; }
        public string MultipleUrl2015 { get; set; }
        public int VurderingsId2010 { get; set; }
        public string Url2010 { get; set; }
        public string Kategori2010 { get; set; }
        public string Kriterier2010 { get; set; }
        public int ScientificNameId2010 { get; set; }
        public string ScientificName2010 { get; set; }
        public string MultipleUrl2010 { get; set; }
        public string VurderingsId2015Databank { get; set; }
    }
    public partial class FA4 // () Id-informjosjon
    {
        public static FA4 CreateNewFA4()
        {
            var newfa = new FA4();
            newfa.initNaturalOrigins();
            newfa.InitFylkesforekomster();
            newfa.RiskAssessment.Criteria = RiskAssessment.CreateDefaultCriteria();
            return newfa;
        }

        [JsonExtensionData]
        public Dictionary<string, JsonElement> ExtensionData { get; set; }

        public List<TaxonHistory> TaxonomicHistory { get; set; } = new List<TaxonHistory>();
        public TrackInfo ImportInfo { get; set; } = new TrackInfo();
        public int Id { get; set; }
        //public string VurderingId2018 { get; set; }
        //public int VurderingId2012 { get; set; } // sah 21-09-2021 - flyttet til PreviousAssessments.assessmentsid
        //public int RiskLevel2012 { get; set; } // sah 21-09-2021 - flyttet til PreviousAssessments
        //public int SpreadRiskLevel2012 { get; set; }// sah 21-09-2021 - flyttet til PreviousAssessments
        //public int EcologicalRiskLevel2012 { get; set; }// sah 21-09-2021 - flyttet til PreviousAssessments

        public string EvaluationContext { get; set; }

        //public string ExpertGroupId { get; set; } // removed sah 20210502

        //public Taxon Taxon { get; set; }
        public int TaxonId { get; set; }
        public string ExpertGroup { get; set; }
        //public string EvaluationGroup { get; set; } // slettet 06.12.2016 - this is propably connected to databank grouping in 2012, we will propably see this resurface for the next Databank application!
        //public string EvaluationCategory { get; set; } // slettet 10.01.2017

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
        public string EvaluatedScientificNameAuthor { get; set; } //added 23.08.2017
        public string EvaluatedVernacularName { get; set; } //added 29.09.2017

        public string TaxonHierarcy { get; set; }

        //public string VurdertVitenskapeligNavn { get; set; }

        //        public string SynonymSpecies_________ { get; set; } // fab: Synonym_Species

        //public Datasett Datasett { get; set; } = new Datasett();
        public string EvaluatedScientificNameRank { get; set; }
    }

    public partial class FA4 // Horisontskanning
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




    public partial class FA4 // (3.1) Artens status
    {
        public string AlienSpeciesCategory2012 { get; set; } // added 10.01.2017
        public string DoorKnockerDescription { get; set; } // fab: Door_Knocker_Description
        public string NotReproductiveDescription2012 { get; set; } // fab: Not_Reproductive_Description 
        public string NotReproductiveFutureDescription2012 { get; set; } // fab: Not_Reproductive_Future_Description
        public string AssesmentNotApplicableDescription { get; set; } // todo: fjern dette // fab: Assesment_Not_Applicable_Description

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

        /// <summary>
        /// The species was misidentified in previous assessment
        /// </summary>
        public bool MisIdentified { get; set; } = false;

        /// <summary>
        /// Reason for misidentification
        /// </summary>
        public string MisIdentifiedDescription { get; set; } = "";


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

        public bool? AlienSpecieUncertainIfEstablishedBefore1800 { get; set; } // lagt til: 19.10.2016 - renamed 15.11.2016
        public bool AlienSpecieUncertainAntropochor { get; set; } // lagt til: 19.10.2016
        public string AlienSpecieUncertainDescription { get; set; } // lagt til: 22.12.2016

        public bool? AssumedReproducing50Years { get; set; }

        public bool SkalVurderes { get; set; }

        //public string EtableringsmulighetINorge { get; set; } // lagt til 22.08.2016 //fjernet 25.08.2016
        public string DoorKnockerCategory { get; set; } // lagt til 25.08.2016 // fjernet 14.12.2016 // lagt til 21.12.2016
        public string RegionallyAlienCategory { get; set; } // lagt til 25.08.2016
        public string NotApplicableCategory { get; set; } // lagt til 25.08.2016
        //public bool LongDistanceEffect { get; set; } // lagt til 22.08.2016 // fjernet 29.08.2016
        //public bool IndoorObserved { get; set; } // lagt til 22.08.2016 // fjernet 30.08.2016
        //public bool IndoorEstablished { get; set; } // lagt til 22.08.2016 // fjernet 30.08.2016
        //public bool OutdoorObserved { get; set; } // lagt til 22.08.2016 // fjernet 30.08.2016
        //public bool OutdoorEstablished { get; set; } // lagt til 22.08.2016 // fjernet 30.08.2016
        //public bool NorwegianNatureObserved { get; set; } // lagt til 22.08.2016 // fjernet 30.08.2016
        //public bool NorwegianNatureEstablished { get; set; } // lagt til 22.08.2016 // fjernet 30.08.2016
        
        public string FurtherInfo { get; set; } = ""; // ny

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
            public string SpecimenCount { get; set; } // lagt til 26.09.2016
        }
        public class ObservedAndEstablishedInCountry
        {
            public ObservedAndEstablished Indoor { get; set; } = new ObservedAndEstablished();
            public ObservedAndEstablished ProductionArea { get; set; } = new ObservedAndEstablished();
            public ObservedAndEstablished NorwegianNature { get; set; } = new ObservedAndEstablished();
        }
        public ObservedAndEstablishedInCountry ObservedAndEstablishedStatusInCountry { get; set; } = new ObservedAndEstablishedInCountry(); // lagt til 30.08.2016 //
    }

    public partial class FA4 // Fylkesforekomster
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

        ///// <summary>
        ///// live test, replace with '_fylkesforekomster' after deleting State from Fylkesforekomst
        ///// </summary>
        ///// <returns></returns>
        //private List<Fylkesforekomst> FixOldState()
        //{
        //    foreach (var fylkesforekomst in _fylkesforekomster)
        //    {
        //        switch (fylkesforekomst.State)
        //        {
        //            case 0:
        //                // 0 - kjent
        //                fylkesforekomst.State0 = 1;
        //                break;
        //            case 1:
        //                // 1 - antatt i dag
        //                fylkesforekomst.State1 = 1;
        //                break;
        //            case 2:
        //                // 2 - ikke kjent
        //                fylkesforekomst.State2 = 1;
        //                break;
        //            case 3:
        //                // 3 - antatt om 50 år
        //                fylkesforekomst.State3 = 1;
        //                break;
        //            default:
        //                // unused value - set to 2 - ikke kjent
        //                fylkesforekomst.State2 = 1;
        //                break;
        //        }

        //        if (fylkesforekomst.State0 == 0 && fylkesforekomst.State1 == 0 && fylkesforekomst.State3 == 0)
        //            fylkesforekomst.State2 = 1;
        //        else
        //            fylkesforekomst.State2 = 0;

        //        fylkesforekomst.State = -1;
        //    }

        //    return _fylkesforekomster;
        //}

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

public partial class FA4 // (3.2) Artsegenskaper
    {
        //public string LimnicTerrestrialMarine { get; set; } // lagt til 2.9.2016 // fjernet 26.09.2016
        public bool Limnic { get; set; } // lagt til 26.9.2016
        public bool Terrestrial { get; set; } // lagt til 26.9.2016
        public bool Marine { get; set; } // lagt til 26.9.2016
        public bool BrackishWater { get; set; } // lagt til 26.9.2017 (for sfab)

        public string FirstDomesticObservation { get; set; } // fab: First_Domestic_Observation
        public string FirstDomesticObservationLocation { get; set; } // fab: First_Domestic_Observation_Location
        public string FirstDomesticEstablishmentObserved { get; set; } // fab: First_Domestic_Observed_Establishment
        public string FirstDomesticEstablishmentObservedLocation { get; set; } // fab: First_Domestic_Observed_Establishment_Location


        public List<string> ArrivedCountryFrom { get; set; } = new List<string>(); // fab: string Arived_Norway_From_Code
        public string ArrivedCountryFromDetails { get; set; } = ""; // fab: Natural_Origin 'NaturalOrigin'  - lagt til 14.11.2016
        //public string ArivedNorwayFromOther { get; set; } // fab: Arived_Norway_From_Otherm_Other - slettet 14.11.2016

        //public string NaturalOrigin { get; set; } // fab: Natural_Origin // slettet 1.9.2016
        //public List<string> NaturalOriginCodeItems { get; set; } // fab: List<int> Natural_Origin_Code // slettet 1.9.2016
        //public bool? NaturalOriginIsUnknown { get; set; } // fab: Natural_Origin_UnknownUnknown // slettet 1.9.2016

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

        public List<NaturalOrigin> NaturalOrigins { get; set; } = new List<NaturalOrigin>(); // lagt til 09.01.2017
        public string NaturalOriginUnknownDocumentation { get; set; }
        public List<NaturalOrigin> CurrentInternationalExistenceAreas { get; set; } = new List<NaturalOrigin>(); // lagt til 09.01.2017

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

       

    //public NaturalOrigin createDefaultNaturalOrigin(string climateZone, string climateZoneSubType)
    //{
    //    return new NaturalOrigin()
    //    {
    //        ClimateZone = climateZone,
    //        ClimateZoneSubtype = climateZoneSubType,
    //    };
    //}
    //public List<NaturalOrigin> createDefaultNaturalOrigins()
    //{
    //    return new List<NaturalOrigin> {
    //        createDefaultNaturalOrigin("polart","inkl alpint"),
    //        createDefaultNaturalOrigin("temperert","boreal"),
    //        createDefaultNaturalOrigin("temperert","nemoral"),
    //        createDefaultNaturalOrigin("temperert","tørt"),
    //        createDefaultNaturalOrigin("subtropisk","middelhavsklima"),
    //        createDefaultNaturalOrigin("subtropisk","fuktig"),
    //        createDefaultNaturalOrigin("subtropisk","tørt"),
    //        createDefaultNaturalOrigin("subtropisk","høydeklima"),
    //        createDefaultNaturalOrigin("subtropisk","kappregionen"),
    //        createDefaultNaturalOrigin("tropisk","")
    //    };
    //}


    public void initNaturalOrigins()
        {
            //NaturalOrigins = createDefaultNaturalOrigins();
            //NaturalOrigins = new List<NaturalOrigin> {
            //    new NaturalOrigin() {ClimateZone = "polart",             ClimateZoneSubtype="inkl alpint",     Europe=false,Asia=false,Africa=null, Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
            //    new NaturalOrigin() {ClimateZone = "temperert",          ClimateZoneSubtype="boreal",          Europe=false,Asia=false,Africa=null, Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
            //    new NaturalOrigin() {ClimateZone = "temperert",          ClimateZoneSubtype="nemoral",         Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
            //    new NaturalOrigin() {ClimateZone = "temperert",          ClimateZoneSubtype="tørt",            Europe=false,Asia=false,Africa=null, Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
            //    new NaturalOrigin() {ClimateZone = "subtropisk",         ClimateZoneSubtype="Middelhavsklima", Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
            //    new NaturalOrigin() {ClimateZone = "subtropisk",         ClimateZoneSubtype="fuktig",          Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
            //    new NaturalOrigin() {ClimateZone = "subtropisk",         ClimateZoneSubtype="tørt",            Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
            //    new NaturalOrigin() {ClimateZone = "subtropisk",         ClimateZoneSubtype="høydeklima",      Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
            //    new NaturalOrigin() {ClimateZone = "subtropisk/tropisk", ClimateZoneSubtype="kappregionen",    Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false },
            //    new NaturalOrigin() {ClimateZone = "tropisk",            ClimateZoneSubtype="",                Europe=false,Asia=false,Africa=false,Oceania=false,NorthAndCentralAmerica=false,SouthAmerica=false }
            //};

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



            //CurrentInternationalExistenceAreas = createDefaultNaturalOrigins();
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
        public List<string> NaturalOriginMarine { get; set; } = new List<string>(); // lagt til 05.09.2016
        public string NaturalOriginMarineDetails { get; set; } // lagt til 21.04.2017
        public List<string> CurrentInternationalExistenceMarineAreas { get; set; } = new List<string>(); // lagt til 05.09.2016
        public string CurrentInternationalExistenceMarineAreasDetails { get; set; } // lagt til 21.04.2017
        
        public bool SurvivalBelow5c { get; set; } // lagt til 27.09.2016

        public List<string> IntroductionCourse { get; set; } // fab: List<int> Introduction_Course  //Årsak til tilstedeværelse

        public bool? DomesticRiskEvaluationExists { get; set; } // fab: Domestic_RiskEvaluation_Exists
        public bool? DomesticRiskEvaluationExists2007 { get; set; } // lagt til 26.09.2016
        public bool? ForeignRiskEvaluationExists { get; set; } // fab: Foreign_RiskEvaluation_Exists_Exists
        public string ForeignRiskEvaluationComment { get; set; } // fab: Foreign_RiskEvaluation_Comment

        public string Regeneration { get; set; } // fab: Regeneration
        public int? RegenerationYears { get; set; } // fab: Regeneration_Years
        public string Reproduction { get; set; } // fab: Reproduction
        public bool? ReproductionAsexual { get; set; } // fab: Reproduction_Asexual
        public double? ReproductionGenerationTime { get; set; } // fab: Reproduction_Geteration_Time
        public bool? ReproductionSexual { get; set; } // fab: Reproduction_Sexual
        //public string ReproductiveCapability { get; set; } // fab: Int64? Reproductive_Capability // removed 17.01.2017
        public bool? SimilarDemographicComparison { get; set; } // fab: Similar_Demographic_Comparison



        //Ikke-vurderte effekter  - Har vi disse fra 2012?
        public string HealthEffects { get; set; } // lagt til 31.08.2016
        public string EconomicEffects { get; set; } // lagt til 31.08.2016
        //public string EcosystemServiceEffects { get; set; } // lagt til 31.08.2016 // fjernet 16.09.2016
        public List<string> EcosystemServiceEffectsBasicLifeProcesses { get; set; } = new List<string>(); // lagt til 02.09.2016
        public List<string> EcosystemServiceEffectsProvisioningServices { get; set; } = new List<string>(); // lagt til 02.09.2016
        public List<string> EcosystemServiceEffectsRegulatingServices { get; set; } = new List<string>(); // lagt til 02.09.2016
        public List<string> EcosystemServiceEffectsHumanSpiritualServices { get; set; } = new List<string>(); // :-) // lagt til 02.09.2016
        public string PositiveEcologicalEffects { get; set; } // lagt til 31.08.2016
        public string EffectsOnPopulationOfOrigin { get; set; } // lagt til 31.08.2016

        // OsA, He, Fi
        public string RegionalPresenceKnown { get; set; }
        public string RegionalPresenceAssumed { get; set; }
        public string RegionalPresencePotential { get; set; }
    }
    public partial class FA4 // (3.3) Import
    {
        public List<MigrationPathway> ImportPathways { get; set; } = new List<MigrationPathway>();
        public bool ImportedToIndoorOrProductionArea { get; set; } = false; // trolig ikke i pruk - rest fra fa3 og erstattet av den under

        public string IndoorProduktion { get; set; }
    }
    public partial class FA4 // (3.4) Spredningsveier
    {
        public List<MigrationPathway> AssesmentVectors { get; set; } = new List<MigrationPathway>(); // lagt til 09.01.2017
        public string Vector { get; set; }  // ???!!
        public string SpreadIndoorFurtherInfo { get; set; } = "";
        public string SpreadIndoorFurtherInfoGeneratedText { get; set; } = "";
        public string SpreadIntroductionFurtherInfo { get; set; } = "";
        public string SpreadIntroductionFurtherInfoGeneratedText { get; set; } = "";
        public string SpreadFurtherSpreadFurtherInfo { get; set; } = "";
        public string SpreadFurtherSpreadFurtherInfoGeneratedText { get; set; } = "";



    }
    public partial class FA4 // (3.5) Spredningshistorikk
    {
        public List<SpreadHistory> SpreadHistory { get; set; } = new List<SpreadHistory>();

        //[DisplayName("Fremtidig spredningsprognose i Norge, inkl. potensielt utbredelsesområde, antatte kritiske parametre for arten, og forventede endringer i disse:")] // 
        public string SpreadHistoryDomesticDocumentation { get; set; } // fab: SpreadHistoryDomesticDocumentation
        //[DisplayName("Detaljinformasjon for Naturtyper:")] // 
        public string SpreadHistoryForeignDocumentation { get; set; } // fab: SpreadHistoryForeignDocumentation

        //public bool? FutureDistributionChangeExpected { get; set; } // fab: Future_Distribution_Change_Expected // ikke i bruk i 2012
        public string FutureDistributionChangeExpectedDescription { get; set; } // fab: Future_Distribution_Change_Expected_Description
        public string FutureDistributionCriticalParameters { get; set; } // fab: Future_Distribution_Critical_Parameters

        public Int64? PotentialAreaDistribution { get; set; } // fab: Potential_Area_Distribution -  ikke i bruk?
        public string PotentialAreaDistributionInTheFuture { get; set; } // fab: Potential_Area_Distribution_Future_Future @steinho - ikke i bruk?



        public Int64? CurrentIndividualCount { get; set; }
        public Int64? CurrentIndividualCountLowCalculated { get; set; }
        public string CurrentIndividualCountLowMultiplier { get; set; }
        public Int64? CurrentIndividualCountCalculated { get; set; }
        public string CurrentIndividualCountMultiplier { get; set; }
        public string CurrentIndividualCountHighMultiplier { get; set; }
        public Int64? CurrentIndividualCountHighCalculated { get; set; }

        public Int64? CurrentSpreadArea { get; set; }
        //public Int64? CurrentSpreadAreaLowMultiplier { get; set; }
        //public Int64? CurrentSpreadAreaHighMultiplier { get; set; }
        //public Int64? CurrentSpreadAreaMultiplier { get; set; }
        public Int64? CurrentSpreadAreaLowCalculated { get; set; }
        public Int64? CurrentSpreadAreaHighCalculated { get; set; }
        public Int64? CurrentSpreadAreaCalculated { get; set; }






        public string CurrentPresenceComment { get; set; }

        public string SpreadAreaInChangedNature { get; set; }

        public string SpeciesEstablishmentCategory { get; set; }

    }
    public partial class FA4 // (4) Naturtyper
    {
        //public List<NatureType> AssessmentNatureTypes { get; set; } // removed 03.11.2016 - * see comment for NatureType class
        public List<ImpactedNatureType> ImpactedNatureTypes { get; set; } = new List<ImpactedNatureType>();
        
        /// <summary>
        /// Naturetypes from 2018 after NIN2_2 which are not compatible with NIN2_3 - for reference - not for edit
        /// </summary>
        public List<ImpactedNatureType> ImpactedNatureTypesFrom2018 { get; set; } = new List<ImpactedNatureType>();

        public List<RedlistedNatureType> RedlistedNatureTypes { get; set; } = new List<RedlistedNatureType>(); //lagt til 18.11.2016

        public List<Habitat> Habitats { get; set; } = new List<Habitat>();

        //public string SpeciesNatureTypesDetails { get; set; } // fab: SpeciesNatureTypesDetails // removed 03.11.2016

        public bool UsesLivingSpeciesAsHabitat { get; set; }
        public string UsesLivingSpeciesAsHabitatScientificName { get; set; }
    }

    public partial class FA4 // (5) Risikovurdering
    {
        public class RegionalRiskAssessment
        {
            public string Name { get; set; }
            public RiskAssessment RiskAssessment { get; set; }
        }

        public RiskAssessment RiskAssessment { get; set; } = new RiskAssessment();
        public List<RegionalRiskAssessment> RegionalRiskAssessments { get; set; } = new List<RegionalRiskAssessment>();


    }



    public partial class RiskAssessment // FA4 // () Risikovurdering (dette er avledet informasjon!!)
    {
        //-------------------------------------------------------------------------------
        // --------------------------- Risikovurdering ----------------------------------
        //-------------------------------------------------------------------------------

        //public Int64? RiskLevel { get; set; }
        ////public Int64? RiskUncertantyLevel { get; set; }
        //public Int64? SpreadRiskLevel { get; set; }
        //public Int64? EcologicalEffectRiskLevel { get; set; }
        ////public Int64? SpreadRiskUncertantyLevel { get; set; }
        ////public Int64? EcologicalEffectRiskUncertantyLevel { get; set; }
        //public string SpreadRiskDecisiveCriterias { get; set; }
        //public string EcologicalEffectDecisiveCriterias { get; set; }
        [JsonExtensionData()]
        public Dictionary<string, JsonElement> ExtensionData { get; set; }

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
            //public bool Uncertain { get; set; }
            //public bool HasValue { get; set; }
            public string NoValueInformation { get; set; }  // skal være med??
            //public string Type;
            //public int UncertaintyValue { get; set; }
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
        //public List<Criterion> Criteria { get; set; } = new List<Criterion>
        //{
        //    new Criterion {Id = "InvasionPopulationLifetimeExpectancy",              Value = 0, Akse = Criterion.Axis.Invasion,  CriteriaLetter = "A", UncertaintyValues = new int[] {0}},
        //    new Criterion {Id = "InvasionExpansionSpeed",                            Value = 0, Akse = Criterion.Axis.Invasion,  CriteriaLetter = "B", UncertaintyValues = new int[] {0}},
        //    new Criterion {Id = "InvasionColonizationOfNaturetypeAfter50Years",      Value = 0, Akse = Criterion.Axis.Invasion,  CriteriaLetter = "C", UncertaintyValues = new int[] {0}},
        //    new Criterion {Id = "EcologicalEffectInteractionWithThreatenedSpecies",  Value = 0, Akse = Criterion.Axis.EcoEffect, CriteriaLetter = "D", UncertaintyValues = new int[] {0}},
        //    new Criterion {Id = "EcologicalEffectInteractionWithDomesticSpecies",    Value = 0, Akse = Criterion.Axis.EcoEffect, CriteriaLetter = "E", UncertaintyValues = new int[] {0}},
        //    new Criterion {Id = "EcologicalEffectInfluenceOnThreatenedNatureTypes",  Value = 0, Akse = Criterion.Axis.EcoEffect, CriteriaLetter = "F", UncertaintyValues = new int[] {0}},
        //    new Criterion {Id = "EcologicalEffectInfluenceOnCommonNatureTypes",      Value = 0, Akse = Criterion.Axis.EcoEffect, CriteriaLetter = "G", UncertaintyValues = new int[] {0}},
        //    new Criterion {Id = "EcologicalEffectTransferOfGeneticMaterial",         Value = 0, Akse = Criterion.Axis.EcoEffect, CriteriaLetter = "H", UncertaintyValues = new int[] {0}},
        //    new Criterion {Id = "EcologicalEffectTransferOfDiseasesAndParasites",    Value = 0, Akse = Criterion.Axis.EcoEffect, CriteriaLetter = "I", UncertaintyValues = new int[] {0}}
        //};
        public static RiskAssessment.Criterion CreateDomainCriterion(string id, string criteraLetter, RiskAssessment.Criterion.Axis akse)
        {
            return new RiskAssessment.Criterion()
            {
                Id = id,
                Akse = akse,
                CriteriaLetter = criteraLetter,
                Value = 0,
                NoValueInformation = null,
                //Type = crit.Type, =====>                spread  ecologicaleffect
                UncertaintyValues = new[] { 0 }
            };
        }

        public static List<Criterion> CreateDefaultCriteria()
        {
            var criteria = new List<RiskAssessment.Criterion>();
            criteria.Add(CreateDomainCriterion("InvasionPopulationLifetimeExpectancy",             "A", RiskAssessment.Criterion.Axis.Invasion));
            criteria.Add(CreateDomainCriterion("InvasionExpansionSpeed",                           "B", RiskAssessment.Criterion.Axis.Invasion));
            criteria.Add(CreateDomainCriterion("InvasionColonizationOfNaturetypeAfter50Years",     "C", RiskAssessment.Criterion.Axis.Invasion));
            criteria.Add(CreateDomainCriterion("EcologicalEffectInteractionWithThreatenedSpecies", "D", RiskAssessment.Criterion.Axis.EcoEffect));
            criteria.Add(CreateDomainCriterion("EcologicalEffectInteractionWithDomesticSpecies",   "E", RiskAssessment.Criterion.Axis.EcoEffect));
            criteria.Add(CreateDomainCriterion("EcologicalEffectInfluenceOnThreatenedNatureTypes", "F", RiskAssessment.Criterion.Axis.EcoEffect));
            criteria.Add(CreateDomainCriterion("EcologicalEffectInfluenceOnCommonNatureTypes",     "G", RiskAssessment.Criterion.Axis.EcoEffect));
            criteria.Add(CreateDomainCriterion("EcologicalEffectTransferOfGeneticMaterial",        "H", RiskAssessment.Criterion.Axis.EcoEffect));
            criteria.Add(CreateDomainCriterion("EcologicalEffectTransferOfDiseasesAndParasites",   "I", RiskAssessment.Criterion.Axis.EcoEffect));
            return criteria;
        }


        //        [{Id: "InvasionPopulationLifetimeExpectancy", Value: 0, Akse: 0, CriteriaLetter: "A",…},…]
        //0
        //:
        //{Id: "InvasionPopulationLifetimeExpectancy", Value: 0, Akse: 0, CriteriaLetter: "A",…}
        //1
        //:
        //{Id: "InvasionExpansionSpeed", Value: 0, Akse: 0, CriteriaLetter: "B", NoValueInformation: null,…}
        //2
        //:
        //{Id: "InvasionColonizationOfNaturetypeAfter50Years", Value: 0, Akse: 0, CriteriaLetter: "C",…}
        //3
        //:
        //{Id: "EcologicalEffectInteractionWithThreatenedSpecies", Value: 0, Akse: 1, CriteriaLetter: "D",…}
        //4
        //:
        //{Id: "EcologicalEffectInteractionWithDomesticSpecies", Value: 0, Akse: 1, CriteriaLetter: "E",…}
        //5
        //:
        //{Id: "EcologicalEffectInfluenceOnThreatenedNatureTypes", Value: 0, Akse: 1, CriteriaLetter: "F",…}
        //6
        //:
        //{Id: "EcologicalEffectInfluenceOnCommonNatureTypes", Value: 0, Akse: 1, CriteriaLetter: "G",…}
        //7
        //:
        //{Id: "EcologicalEffectTransferOfGeneticMaterial", Value: 0, Akse: 1, CriteriaLetter: "H",…}
        //8
        //:
        //{Id: "EcologicalEffectTransferOfDiseasesAndParasites", Value: 0, Akse: 1, CriteriaLetter: "I",…}



        #endregion
    }
    public partial class RiskAssessment // (5.1) Ivasjonspotensial
    {
        // ---------- invasjonspotensial -------------
        public bool? QuantitativeDataForDomesticSpreadExsists { get; set; }  // Quantitative_Domestic_Spread_Data_Exsists
        public bool? QuantitativeDataForForeignSpreadExsists { get; set; }   // Quantitative_Foreign_Spread_Data_Exsists
        public string QuantitativeDataComment { get; set; }         // Quantitative_Spread_Data_Comment

        // -- forventet levetid for norsk populasjon
        public Int64? EstimatedSpeciesCount { get; set; }   // Estimated_Species_Count
        public string EstimatedSpeciesCountMethod { get; set; }   // Estimated_Species_Count_Estimation_Method
        public string EstimatedSpeciesCountAssumption { get; set; }   // Estimated_Species_Count_Assumption
        public bool? EstimatedSpeciesLongevityMoreThan1000Years { get; set; }   // Estimated_Species_Longevity_More_than_1000_years
        public string EstimatedSpeciesLongevity { get; set; }  // Estimated_Species_Longevity
        public string EstimatedSpeciesLongevityMethod { get; set; }  // Estimated_Species_Longevity_Method





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


        // -------- disse (forekomstareal i dag) er erstattet:  
        //todo: *sjekk konvertering fra FAB3 før sletting av utkommentert kode*
        //public Int64? CurrentExistenceArea { get; set; }
        //public Int64? CurrentExistenceAreaLowCalculated { get; set; }
        //public string CurrentExistenceAreaLowMultiplier { get; set; }
        //public Int64? CurrentExistenceAreaCalculated { get; set; }
        //public string CurrentExistenceAreaMultiplier { get; set; }
        //public string CurrentExistenceAreaHighMultiplier { get; set; }
        //public Int64? CurrentExistenceAreaHighCalculated { get; set; }
        //*******************************************************************





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
        [System.Text.Json.Serialization.JsonPropertyName("AOOfirstOccurenceLessThan10Years")]
        public string AOOfirstOccurenceLessThan10Years { get; set; } = "yes";
        public string CommentOrDescription {get; set;} //fritekstfelt metode B2a
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
       
        //[System.Text.Json.Serialization.JsonPropertyName("AOOestimationPeriod10yrPossible")]
        //public string AOOestimationPeriod10yrPossible { get; set; } = "yes";
        // -------- disse (forekomstareal om 50år) er erstattet:  
        //todo: *sjekk konvertering fra FAB3 før sletting av utkommentert kode*
        //public Int64? PotentialExistenceAreaLowQuartile { get; set; }
        //public Int64? PotentialExistenceArea { get; set; }
        //public Int64? PotentialExistenceAreaHighQuartile { get; set; }
        //public string PotentialPresenceComment { get; set; }
        //*******************************************************************

        // end nye


        //public Int64? SpeciesCount { get; set; } // fab: Species_Count  // ikke i bruk som egen attributt (ligger i spredningshistorikk item) i 2012


        public double? SpreadHistoryDomesticAreaInStronglyChangedNatureTypes { get; set; }
        public double? SpreadHistoryDomesticAreaInStronglyChangedNatureTypesLow { get; set; }
        public double? SpreadHistoryDomesticAreaInStronglyChangedNatureTypesBest { get; set; }
        public double? SpreadHistoryDomesticAreaInStronglyChangedNatureTypesHigh { get; set; }



        //        public bool hasPVA { get; set; } // = !string.IsNullOrWhiteSpace(detailsinfo.Spread_PVA_Analysis);
        #region (A) Populasjonens mediane levetid
        // todo: find unused properties in this region
        // ikke i bruk i 2012 applikasjon (?)
        //public string SpreadingDescription { get; set; } //Spreading_Description

        public string AcceptOrAdjustCritA { get; set; } = "accept";  // ametod submetod (radio)
        public string ChosenSpreadMedanLifespan { get; set; } = "";  // ametod (radio)
        public string ReasonForAdjustmentCritA { get; set; } = ""; // added 06.01.2022

        public bool ActiveSpreadPVAAnalysisSpeciesLongevity { get; set; } // added 27.09.2016

        [DisplayName("PVA-analyse beskrivelse")]
        public string SpreadPVAAnalysis { get; set; } //Spread_PVA_Analysis
        [DisplayName("Forventet levetid")]
        public bool ActiveSpreadPVAAnalysisEstimatedSpeciesLongevity { get; set; } // lagt til 27.09.2016
        public string SpreadPVAAnalysisEstimatedSpeciesLongevity { get; set; }  //Spread_PVA_Analysis_Estimated_Species_Longevity
        public string SpreadPVAAnalysisEstimatedSpeciesLongevityLowerQuartile { get; set; }  // lagt til 07.09.2016
        public string SpreadPVAAnalysisEstimatedSpeciesLongevityUpperQuartile { get; set; }  // lagt til 07.09.2016 

        public string FilesDescription { get; set; } //Spread_PVA_Analysis


        //todo: is this section in use???
        //Rødliste info
        public bool ActiveRedListCategoryLevel { get; set; } // lagt til 27.09.2016
        public string RedListUsedCriteria { get; set; }  // lagt til 07.09.2016
        public string RedListDataDescription { get; set; }  // lagt til 07.09.2016
        public string RedListCategory { get; set; }  // lagt til 07.09.2016
        public string RedListSubCategory { get; set; }  // lagt til 07.09.2016
                                                        // -----------------------------------------------------------------------------------------



        // ****************************  (A2) Numerisk estimering  ****************************
        public long? PopulationSize { get; set; } // bestandens nåværende størrelse (individtall) 
        public double? GrowthRate { get; set; } // bestandens multiplikative vekstrate 
        public double? EnvVariance { get; set; } // miljøvarians 
        public double? DemVariance { get; set; } // demografisk varians 
        public long? CarryingCapacity { get; set; } // bestandens bæreevne (individtall) 
        public long? ExtinctionThreshold { get; set; } // kvasiutdøingsterskel (individtall) 
        // -------- disse ((A2) Numerisk estimering) er erstattet:  
        //todo: *sjekk konvertering fra FAB3 før sletting av utkommentert kode*
        //////public bool ActiveSpreadRscriptSpeciesCount { get; set; } // lagt til 27.09.2016

        //[DisplayName("Bestandstørrelse")]
        //public int? SpreadRscriptSpeciesCount { get; set; }  //Spread_Rscript_Species_Count
        //[DisplayName("Vekstrate")]
        ////public double SpreadRscriptPopulationGrowth { get; set; } //Spread_Rscript_Population_Growth
        //public string SpreadRscriptPopulationGrowth { get; set; } // type change 01.11.2017
        ///// <summary>
        ///// R-script input - environmant (stocastic) variance - Description
        ///// </summary>
        //[DisplayName("Miljø varians")]
        //public string SpreadRscriptEnvironmantVariance { get; set; } //Spread_Rscript_Environmant_Variance

        ///// <summary>
        ///// R-script input - demographic variance - Description
        ///// </summary>
        //[DisplayName("Demografisk varians")]
        //public string SpreadRscriptDemographicVariance { get; set; }  //Spread_Rscript_Demographic_Variance
        ///// <summary>
        ///// R-script input - Sustainability K - Description
        ///// </summary>
        //[DisplayName("Bæreevne K")]
        //public string SpreadRscriptSustainabilityK { get; set; } //Spread_Rscript_Sustainability_K
        //public bool ActiveSpreadRscriptEstimatedSpeciesLongevity { get; set; } // lagt til 08.11.2016
        ///// <summary>
        ///// Estimated species longevity  Conclusion
        ///// </summary>
        //public string SpreadRscriptEstimatedSpeciesLongevity { get; set; } //Spread_Rscript_Sustainability_K

        ///// <summary>
        ///// R-script input - Quasi-extinction Threshold - Description
        ///// </summary>
        //[DisplayName("Terskel for kvasiutdøing")]
        //public string SpreadRscriptQuasiExtinctionThreshold { get; set; }  //Spread_Rscript_Quasi_Extinction_Threshold
        // ************************************************************************************
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

        [JsonConverter(typeof(JsonHelpers.CrazyStringJsonConverter))]
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


        //-----------------------------------------------------------------------
        // todo: slett dette (etter hvert)
        // erstattet disse i 61 - 16.8.21 - dette er kun for referanse. 
        //PopulationSize ACritSpeciesCount
        //GrowthRate ACritPopGrowth
        //EnvVariance ACritEnvirVariance
        //DemVariance ACritDemoVariance
        //CarryingCapacity ACritSustainability
        //ExtinctionThreshold ACritExtThreshold
        //MedianLifetime ACritMedian
        //ExpansionSpeed BCritExpansion
        //ExpansionLowerQ BCritLower
        //ExpansionUpperQ BCritHigher
        //-----------------------------------------------------------------------






        #region (B) Ekspansjonshastighet

        public string ChosenSpreadYearlyIncrease { get; set; } = "";  // bmetod (radio)
        public bool ActiveSpreadYearlyIncreaseObservations { get; set; } //lagt til 29.09.2016


        // ********************** (b) Forekomstareal – dørstokkarter  ****************************
        public long? Occurrences1Best { get; set; }	// beste anslag på antall forekomster fra 1 introduksjon 
        public long? Occurrences1Low { get; set; }	// lavt anslag på antall forekomster fra 1 introduksjon 
        public long? Occurrences1High { get; set; }	// høyt anslag på antall forekomster fra 1 introduksjon 
        public long? IntroductionsBest { get; set; }	// beste anslag på antall introduksjoner i løpet av 10 år 
        public long? IntroductionsLow { get; set; }	    // lavt anslag på antall introduksjoner i løpet av 10 år 
        public long? IntroductionsHigh { get; set; }	// høyt anslag på antall introduksjoner i løpet av 10 år 
        // -------- disse (forekomstareal - dørstokkarter) er erstattet:  
        //todo: *sjekk konvertering fra FAB3 før sletting av utkommentert kode*
        //public string SpreadYearlyIncreaseObservations { get; set; } //lagt til 29.09.2016
        //public string SpreadYearlyIncreaseObservationsLowerQuartile { get; set; } //lagt til 29.09.2016
        //public string SpreadYearlyIncreaseObservationsUpperQuartile { get; set; } //lagt til 29.09.2016
        // ****************************************************************************************


        // ********************** ((B1) ekspansjonshastighet  ****************************
        public long? ExpansionSpeedInput { get; set; }  // ekspansjonshastighet i meter per år 
        public long? ExpansionSpeed { get; set; }  // ekspansjonshastighet i meter per år 
        public long? ExpansionLowerQInput { get; set; } // nedre kvartil for ekspansjonshastighet i meter per år 
        public long? ExpansionLowerQ { get; set; } // nedre kvartil for ekspansjonshastighet i meter per år 
        public long? ExpansionUpperQInput { get; set; } // øvre kvartil for ekspansjonshastighet i meter per år 
        public long? ExpansionUpperQ { get; set; } // øvre kvartil for ekspansjonshastighet i meter per år 


        // -------- disse ((B1) ekspansjonshastighet) er erstattet:  
        //todo: *sjekk konvertering fra FAB3 før sletting av utkommentert kode*
        //public bool ActiveSpreadYearlyIncreaseOccurrenceArea { get; set; } //lagt til 29.09.2016
        //public string SpreadYearlyIncreaseOccurrenceArea { get; set; } //lagt til 29.09.2016
        //public string SpreadYearlyIncreaseOccurrenceAreaLowerQuartile { get; set; } //lagt til 29.09.2016
        //public string SpreadYearlyIncreaseOccurrenceAreaUpperQuartile { get; set; } //lagt til 29.09.2016
        //
        // sjekk ogsa disse:
        // // SpreadYearlyIncreaseCalculatedExpansionSpeed? SpreadYearlyIncreaseObservations?
        // *********************************************************************************


        public bool ActiveSpreadYearlyLiteratureData { get; set; } //lagt til 29.09.2016
        public string SpreadYearlyLiteratureDataExpansionSpeed { get; set; } // lagt til 14.10.2016
        public string SpreadYearlyLiteratureDataUncertainty { get; set; } //lagt til 29.09.2016
        public string SpreadYearlyLiteratureDataNumberOfIntroductionSources { get; set; } //lagt til 29.09.2016  
        public string SpreadYearlyLiteratureData { get; set; } //lagt til 29.09.2016 
        //public string SpreadYearlyLiteratureDataAssumptions { get; set; } //lagt til 29.09.2016 // fjernet 03.11.2016
        public string SpreadYearlyLiteratureDataSource { get; set; } //lagt til 29.09.2016


        public bool ActiveSpreadYearlyIncreaseCalculatedExpansionSpeed { get; set; } //lagt til 29.09.2016 // changed from ActiveSpreadYearlyIncreaseEstimate 09.11.2016
        public string SpreadYearlyIncreaseEstimate { get; set; } //lagt til 29.09.2016
        public string SpreadYearlyIncreaseEstimateDescription { get; set; } //lagt til 29.09.2016
        public string SpreadYearlyIncreaseCalculatedExpansionSpeed { get; set; } //lagt til 14.10.2016




        #endregion (B) Ekspansjonshastighet



        #region unused ???????
        // -- spredningshastighet
        
        public double? SpreadYearlyIncrease { get; set; }   // Spread_Yearly_Increase
        public string SpreadYearlyIncreaseMethod { get; set; }  // Spread_Yearly_Increase_EstimationMethod
        #endregion unused ???????




        #region unused ???????
        [DisplayName("Beskrivelse")]
        public string SpreadManualEstimate { get; set; } // fab: Spread_Manual_Estimate
        public string SpreadManualEstimateSpeciesLongevity { get; set; } // fab: Spread_Manual_Estimate_Species_Longevity
        public bool? SpreadManualEstimateSpeciesLongevityIsMoreThan1000years { get; set; } // fab: Spread_Manual_Estimate_Species_Longevity_More_than_1000_years



        // -- fortetningsrate
        [DisplayName("Fortetningsrate, konklusjon")]
        public string IncreasingDensity { get; set; }  // Increasing_Density_Conclusion
        [DisplayName("Grunnlag for fortetningsrate")]
        public string IncreasingDensityMethod { get; set; }  // Increasing_Density_Method
        #endregion





        #region unused keys fortetningsrate - PVA - manual estimates
        [DisplayName("Resultat fra script")]
        public string IncreasingDensityPVAAnalysis { get; set; } //Increasing_Density_PVA_Analysis
        [DisplayName("Verdi")]
        public string IncreasingDensityPercentualComputation { get; set; } //Increasing_Density_Percentual_Computation
        [DisplayName("Tidsperiode")]
        public string IncreasingDensityPercentualComputationPeriod { get; set; } //Increasing_Density_Percentual_Computation_Period
        [DisplayName("Anslag")]
        public string IncreasingDensityManualEstimate { get; set; } //Increasing_Density_Manual_Estimate
        [DisplayName("Begrunnelse")]
        public string IncreasingDensityManualEstimateDescription { get; set; } //Increasing_Density_Manual_Estimate_Description
        #endregion

        // -- naturtype forventet kolonisert
        [DisplayName("Beskrivelse")]
        public string NaturetypeExpectedColonized { get; set; }  // Spread_Naturetype_Expected_Colonization_Description
    }
    public partial class RiskAssessment // (5.2) Økologisk effekt
    {

        // slettet 09.09.2016
        //public class SpeciesSpeciesInteractions
        //{
        //    public bool DomesticDocumented { get; set; }
        //    public bool DomesticObserved { get; set; }
        //    public bool ForeignDocumented { get; set; }
        //    public bool SpecieThreatened { get; set; }
        //    public bool SpecieOther { get; set; }
        //    //public string Description { get; set; }   //  intern informasjon
        //    public bool HasSpeciesInteractions()
        //    {
        //        return SpecieThreatened || SpecieOther;
        //    }
        //}

        //// ---------- økologisk effekt -------------
        //// -- (A + B) art-artinteraksjoner
        //#region SpeciesSpeciesInteractions
        //public SpeciesSpeciesInteractions HabitatPressure { get; set; } //Habitat_Pressure
        //public SpeciesSpeciesInteractions ComparativeSpeciesAffected { get; set; } //Comparative_Species_Affected
        //public SpeciesSpeciesInteractions PredatorPreyInteractions { get; set; } //Predator_Prey_Interactions
        //public SpeciesSpeciesInteractions HostParasiteInteractions { get; set; } //Host_Parasite_Interactions
        //public SpeciesSpeciesInteractions TroficInteractions { get; set; }//Trofic_Interactions
        //#endregion 


        public abstract class Interaction
        {
            //public string ScientificName { get; set; }
            //public string ScientificNameId { get; set; }
            //public string ScientificNameAuthor { get; set; } = "";
            //public string VernacularName { get; set; }
            //public string TaxonRank { get; set; }
            //public string TaxonId { get; set; }
            public string RedListCategory { get; set; }
            public bool KeyStoneSpecie { get; set; }
            //public bool KeyStoneOrEndangeredSpecie { get; set; } // fjernet 27.04.2023
            public string Effect { get; set; } // lagt til 10.10.2016
            public bool EffectLocalScale { get; set; } // lagt til 10.10.2016
            public string InteractionType { get; set; }
            public List<string> InteractionTypes { get; set; } = new List<string>();
            public List<string> BasisOfAssessment { get; set; } = new List<string>();
            public string Scale { get; set; }

            public bool LongDistanceEffect { get; set; }
            public bool ConfirmedOrAssumed { get; set; }
            //public string NorwayOrAbroad { get; set; }
            public string DomesticOrAbroad { get; set; }

        }

        public abstract class SpeciesInteraction : Interaction
        {
            public string ScientificName { get; set; }

            //[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
            [JsonConverter(typeof(JsonHelpers.CrazyIntJsonConverter))]
            public int ScientificNameId { get; set; }
            public string ScientificNameAuthor { get; set; } = "";
            public string VernacularName { get; set; }
            public string TaxonRank { get; set; }
            //[JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
            [JsonConverter(typeof(JsonHelpers.CrazyIntJsonConverter))]
            public int TaxonId { get; set; }
        }

        public class SpeciesSpeciesInteraction : SpeciesInteraction // lagt til 09.09.2016
        {

            //public string ScientificName { get; set; }
            //public string VernacularName { get; set; }
            //public string RedListCategory { get; set; }
            //public bool? KeyStoneSpecie { get; set; }
            //public string Effect { get; set; } // lagt til 10.10.2016
            //public bool EffectLocalScale { get; set; } // lagt til 10.10.2016
            //public string InteractionType { get; set; }
            //public bool LongDistanceEffect { get; set; }
            //public bool ConfirmedOrAssumed { get; set; }
            //public string NorwayOrAbroad { get; set; }
        }

        public abstract class NaturetypeInteraction : Interaction
        {

        }
        public class SpeciesNaturetypeInteraction : NaturetypeInteraction // lagt til 22.12.2016
        {
            public string NiNCode { get; set; }
            public string Name { get; set; }
            public List<string> NiNVariation { get; set; } = new List<string>(); // lagt til 23.12.23
        }



        //// - D kriteriet
        //public List<SpeciesSpeciesInteractions> SpeciesSpeciesInteractionsThreatenedSpecies { get; set; } = new List<SpeciesSpeciesInteractions>(); // lagt til 09.09.2016 // slettet 11.10.2016
        //// - E kriteriet
        //public List<SpeciesSpeciesInteractions> SpeciesSpeciesInteractionsDomesticSpecies { get; set; } = new List<SpeciesSpeciesInteractions>(); // lagt til 12.09.2016 // slettet 11.10.2016

        // - D + E kriteriet
        public List<SpeciesSpeciesInteraction> SpeciesSpeciesInteractions { get; set; } = new List<SpeciesSpeciesInteraction>(); // lagt til 11.10.2016
        public List<SpeciesNaturetypeInteraction> SpeciesNaturetypeInteractions { get; set; } = new List<SpeciesNaturetypeInteraction>(); // lagt til 22.12.2016
        public List<SpeciesNaturetypeInteraction> SpeciesNaturetypeInteractions2018 { get; set; } = new List<SpeciesNaturetypeInteraction>();
        public string SpeciesSpeciesInteractionsSupplementaryInformation { get; set; }
        public string DCritInsecurity { get; set; }
        public string ECritInsecurity { get; set; }

        // - H kriteriet
        public List<SpeciesSpeciesInteraction> GeneticTransferDocumented { get; set; } = new List<SpeciesSpeciesInteraction>(); // lagt til 12.09.2016



        public class HostParasiteInteraction : SpeciesInteraction // lagt til 12.09.2016
        {
            //public string ScientificName { get; set; }
            //public string VernacularName { get; set; }
            //public string RedListCategory { get; set; }
            //public bool? KeyStoneSpecie { get; set; }
            //public bool NewHost { get; set; } // fjernet 17.01.2017
            public string ParasiteScientificName { get; set; }
            public string ParasiteVernacularName { get; set; }
            public string ParasiteEcoEffect { get; set; }

            public string Status { get; set; }
            public bool ParasiteNewForHost { get; set; }
            //public bool ParasiteNewForNorway { get; set; } // lagt til 09.11.2016
            public bool ParasiteIsAlien { get; set; } // nytt navn  17.01.2017 (ParasiteNewForNorway)
            public bool DiseaseConfirmedOrAssumed { get; set; }
            //public string NorwayOrAbroad { get; set; }
        }

        public string HCritInsecurity { get; set; }

        // I kriterie
        public List<HostParasiteInteraction> HostParasiteInformations { get; set; } = new List<HostParasiteInteraction>(); // lagt til 09.09.2016

        public string ICritInsecurity { get; set; }


        // -- (C) potensiale for å endre én eller flere truete/sjeldne naturtyper
        public List<string> ThreatenedNatureTypes { get; set; } = new List<string>(); // 09.01.2017  // Threatened_Nature_Types
        // public string Threatened_Nature_Types_Affected_Documentation  { get; set; }             // ************ intern informasjon *************
        public bool? ThreatenedNatureTypesDomesticObserved { get; set; }  // Threatened_Nature_Types_Affected_Domestic_Observed
        public bool? ThreatenedNatureTypesDomesticDocumented { get; set; }  // Threatened_Nature_Types_Affected_Domestic_Documented
        public bool? ThreatenedNatureTypesForeignDocumented { get; set; }  // Threatened_Nature_Types_Affected_Foreign_Documented
        public string ThreatenedNatureTypesAffectedDomesticDescription { get; set; }    //  Threatened_Nature_Types_Affected_Domestic_Description  ????????????
        public string ThreatenedNatureTypesAffectedAbroadDescription { get; set; } = "";   //  lagt til 15.11.2016

        // -- (D) potensiale for å endre én eller flere øvrige naturtyper
        public List<string> CommonNatureTypes { get; set; } = new List<string>(); // 09.01.2017  // Common_Nature_Types
        //public string Common_Nature_Types_Affected_Documentation { get; set; }               //intern informasjon

        public List<string> Naturetype2018 { get; set; } = new List<string>();        
        public List<string> NaturetypeNIN2 { get; set; } = new List<string>();

        public List<string> BackgroundC { get; set; } = new List<string>();

        public List<string> BackgroundF { get; set; } = new List<string>();

        public List<string> BackgroundG { get; set; } = new List<string>();
        public List<string> Hovedøkosystem { get; set; } = new List<string>();






        //// todo: delete this section when fixed (uses criterion instead)
        //public List<string> ScoreA { get; set; } = new List<string>();
        //public List<string> UnsureA { get; set; } = new List<string>();
        //public List<string> ScoreB { get; set; } = new List<string>();
        //public List<string> UnsureB { get; set; } = new List<string>();
        //public List<string> ScoreC { get; set; } = new List<string>();
        //public List<string> UnsureC { get; set; } = new List<string>();
        //public List<string> ScoreD { get; set; } = new List<string>();
        //public List<string> UnsureD { get; set; } = new List<string>();
        //public List<string> ScoreE { get; set; } = new List<string>();
        //public List<string> UnsureE { get; set; } = new List<string>();
        //public List<string> ScoreF { get; set; } = new List<string>();
        //public List<string> UnsureF { get; set; } = new List<string>();
        //public List<string> ScoreG { get; set; } = new List<string>();
        //public List<string> UnsureG { get; set; } = new List<string>();
        //public List<string> ScoreI { get; set; } = new List<string>();
        //public List<string> UnsureI { get; set; } = new List<string>();
        //public List<string> ScoreH { get; set; } = new List<string>();
        //public List<string> UnsureH { get; set; } = new List<string>();
        //// ----------------------------------------------------


        public string NatureAffectedAbroadF { get; set; }

        public string NatureAffectedAbroadG { get; set; }

        public bool? CommonNatureTypesDomesticObserved { get; set; }  // Common_Nature_Types_Affected_Domestic_Observed
        public bool? CommonNatureTypesDomesticDocumented { get; set; }  // Common_Nature_Types_Affected_Domestic_Documented
        public bool? CommonNatureTypesForeignDocumented { get; set; }  // Common_Nature_Types_Affected_Foreign_Documented
        public string CommonNatureTypesAffectedDomesticDescription { get; set; }         // Common_Nature_Types_Affected_Domestic_Description??????????????
        public string CommonNatureTypesAffectedAbroadDescription { get; set; } = "";        // lagt til 15.11.2016
        
        // -- (E) kan overføre genetisk materiale til stedegne arter
        public string GeneticTransferDomesticDescription { get; set; }        //Genetic_Transfer_Domestic_Description intern informasjon
        public bool? GeneticTransferDomesticObserved { get; set; }  // Genetic_Transfer_Domestic_Observed
        public bool? GeneticTransferDomesticDocumented { get; set; }  // Genetic_Transfer_Domestic_Documented
        public bool? GeneticTransferForeignDocumented { get; set; }  // Genetic_Transfer_Foreign_Documented

        // -- (F) Kan overføre bakterier, parasitter eller virus til stedegne arter
        public string VectorBiologicalDiseaseSpreadingDomesticDescription { get; set; }    //Vector_Biological_Disease_Spreading_Domestic_Description intern informasjon
        public bool? BiologicalDiseaseSpreadingDomesticObserved { get; set; }  // Vector_Biological_Disease_Spreading_Domestic_Observed
        public bool? BiologicalDiseaseSpreadingDomesticDocumented { get; set; }  // Vector_Biological_Disease_Spreading_Domestic_Documented
        public bool? BiologicalDiseaseSpreadingForeignDocumented { get; set; }
    }

    public partial class RiskAssessment // (5.3) Geografisk Variasjon
    {
        public List<string> GeographicalVariation { get; set; } = new List<string>(); // lagt til 23.09.2016
        public string GeographicalVariationDocumentation { get; set; } // lagt til 23.09.2016

        public string PossibleLowerCategory { get; set; }

    }

    public partial class RiskAssessment // (5.4) Klimaeffekter
    {
        public string ClimateEffectsInvationpotential { get; set; } // lagt til 23.09.2016
        public string ClimateEffectsEcoEffect { get; set; } // lagt til 23.09.2016
        public string ClimateEffectsDocumentation { get; set; } // lagt til 23.09.2016
    }



    public partial class RiskAssessment // (5.5) Kriteriedokumentasjon
    {
        public string CriteriaDocumentation { get; set; }
        public string CriteriaDocumentationSpeciesStatus { get; set; }
        public string CriteriaDocumentationDomesticSpread { get; set; }
        //public string CriteriaDocumentationMigrationPathways { get; set; } // fjernet 20.02.2020 - erstattet av spreadIntroductionFurtherInfo
        public string CriteriaDocumentationInvationPotential { get; set; }
        public string CriteriaDocumentationEcoEffect { get; set; }


        //public string NotEvaluatedBackgroundInformation { get; set; } // Dette var et aggregat av beskrivelser i 'artens status'. Vi bruker de sepparate egenskapene
    }


    public partial class FA4 // (8) Referanser
    {
        public List<SimpleReference> References { get; set; } = new List<SimpleReference>();
    }
    public partial class FA4 // History
    { 
        public List<PreviousAssessment> PreviousAssessments { get; set; } = new List<PreviousAssessment>();
    }


    public partial class FA4 // Disse variablene er sjekket og var ikke i bruk i 2012 fab Prod
    {

        // public bool? AlienGenotypOfDomesticSpecie { get; set; } // fab: Alien_Genotyp_Of_Domestic_Specie // ikke i bruk i 2012
        //        public string AuthoritySpecies { get; set; } // fab: Authority_Species

        //public string CompetitionImposeDescription { get; set; } // fab: Competition_Impose_Description // ikke i bruk i 2012
        //public bool? DomescicSpreadToNewAreas { get; set; } // fab: Domescic_Spreading_To_New_Areas // ikke i bruk i 2012
        //public string EcoClimate { get; set; } // fab: Eco_Climate // ikke i bruk i 2012



        //public string InteractionWithOtherSpecies { get; set; } // fab: Interaction_Other_Species // ikke i bruk i 2012
        //        public string KingdomSpecies_______ { get; set; } // fab: Kingdom_Species
        //public string Order___ { get; set; } // fab: Order_Species
        //public string P_SpeciesName { get; set; } // fab: P_SpeciesName
        //public string Predation { get; set; } // fab: Predation // ikke i bruk i 2012

        //public string Purpose { get; set; } // fab: Purpose // ikke i bruk i 2012
        //public string SpeciesStatus { get; set; } // fab: Species_Status // ikke i bruk i 2012


        //public string Substrate { get; set; } // fab: Substrate // ikke i bruk i 2012


        // Vector_Biological_Disease_Spreading_Foreign_Documented


        // ikke i bruk
        //public string Ecosystem_Processes_Description { get; set; }
        //public bool? Ecosystem_Processes_Domestic_Documented { get; set; }
        //public bool? Ecosystem_Processes_Foreign_Documented { get; set; }


        // ikke i bruk
        //public string Important_Species_Affected_Domestic_Description { get; set; }
        //public bool? Important_Species_Affected_Domestic_Observed { get; set; }
        //public bool? Important_Species_Affected_Domestic_Documented { get; set; }
        //public bool? Important_Species_Affected_Foreign_Documented { get; set; }

    }

    public partial class FA4 // FA4 Internal classes
    {

        // depricated 03.11.2016 - this class is from fab2012 and can be of interest for viewing old naturetype information
        //public class NatureType
        //{
        //    public string Name { get; set; }
        //    //public string NatureTypeCode { get; set; }  // internal code in allienspeciesassessment

        //    public string Period; // type NatureTypePeriod???
        //    public string NatureTypeCategoryDescription;
        //    public string NatureTypeDescription;
        //    public List<string> NatureTypeVariation;
        //}

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
            public List<string> DominanceForrest { get; set; } = new List<string>(); // changed datatype from string 18.11.2016
            public long? NatureTypeArea { get; set; }
            public List<string> Background { get; set; } = new List<string>();
            public string TimeHorizon { get; set; }
            public string ColonizedArea { get; set; }
            public List<string> StateChange { get; set; } = new List<string>(); // changed datatype from string 19.12.2016
            public string AffectedArea { get; set; }
        }

        public class RedlistedNatureType
        {
            public string RedlistedNatureTypeName { get; set; }
            public string Category { get; set; }
            //public List<string> NiNVariation { get; set; } = new List<string>();
            //public List<string> DominanceForrest { get; set; } = new List<string>(); 
            public List<string> Background { get; set; } = new List<string>();
            public string TimeHorizon { get; set; }
            public string ColonizedArea { get; set; }
            public List<string> StateChange { get; set; } = new List<string>(); // changed datatype from string 19.12.2016
            public string AffectedArea { get; set; }
        }

        public class Habitat
        {
            public string NiNCode { get; set; }
            public string Name { get; set; }
            public string RedlistedNatureTypeName { get; set; }
            public string Category { get; set; }
            //public List<string> NiNVariation { get; set; } = new List<string>();
            //public List<string> DominanceForrest { get; set; } = new List<string>(); 
            public List<string> Background { get; set; } = new List<string>();
            public string TimeHorizon { get; set; }
            public string ColonizedArea { get; set; }
            public List<string> StateChange { get; set; } = new List<string>(); // changed datatype from string 19.12.2016
            public string AffectedArea { get; set; }

            public CTaxon Taxon { get; set; }
        }




        public class SimpleReference
        {
            public string Type { get; set; }

            public Guid ReferenceId { get; set; }

            public string FormattedReference { get; set; }
        }

        public string LockedForEditByUser { get; set; }
        public Guid? LockedForEditByUserId { get; set; }
        public string LockedForEditTimeStamp { get; set; }
    }

    public partial class FA4
    {
        public string ArtskartAdded { get; set; }
        public string ArtskartRemoved { get; set; }
        public string ArtskartSelectionGeometry { get; set; }
        public string ArtskartSistOverført { get; set; }
        public ArtskartModel ArtskartModel { get; set; } = new ArtskartModel();
        public ArtskartWaterModel ArtskartWaterModel { get; set; } = new ArtskartWaterModel();
        public string ArtskartManuellKommentar { get; set; } = "";

        public int ArtskartManuellAdd { get; set; }
        public int ArtskartManuellRemove { get; set; }
        public int ArtskartExcludedLocalities { get; set; }

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


    // todo: Move into Fremmedart2012  (conflict with propertyname)
    public class SpreadHistory
    {
        public SpreadHistory()
        {
/*            this.RegionalPresence = new List<RegionalPresenseWithAssumed>()
                                               {
                                                   new RegionalPresenseWithAssumed { Id = "Øs", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "OsA", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "He", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Op", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Bu", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Ve", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Te", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Aa", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Va", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Ro", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Ho", Known = true, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Sf", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Mr", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "St", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Nt", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "No", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Tr", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Fi", Known = false, Assumed = true },
                                                   new RegionalPresenseWithAssumed { Id = "Sv", Known = false, Assumed = false },
                                                   new RegionalPresenseWithAssumed { Id = "Jm", Known = false, Assumed = false },
    };*/
        }

        public Guid Id { get; set; }
        public string Location { get; set; }
        public string Comment { get; set; } //, SpeciesCount, ExistenceArea, ExistenceAreaCount, SpreadArea;
        public string Regions { get; set; } = "";

        public string RegionsAssumed { get; set; } = "";

        //public DateTime? ObservationSortDate;
        //public DateTime? ObservationFromDate, ObservationDate;
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

        public string SelectionGeometry { get; set; }// = "{\\\"type\\\": \\\"Feature\\\",\\\"geometry\\\": {\\\"type\\\": \\\"Polygon\\\", \\\"coordinates\\\": [[[10.33, 63.45], [11.951, 63.451], [10.949, 64.45]]]}}";
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
        //public int CodeItemId { get; set; }
        //public string Comments { get; set; }
        //public string EditedBy { get; set; }
        //public string Factor { get; set; }
        //public int Id { get; set; }
        public string IntroductionSpread { get; set; } //lagt til 07.09.2016
        public string InfluenceFactor { get; set; }
        public string Magnitude { get; set; }
        public string TimeOfIncident { get; set; }
        public string ElaborateInformation { get; set; }



        //public string ItemPath { get; set; }
        public string Category { get; set; }
        public string MainCategory { get; set; } //Added 14.06.2022
        //public bool IsValid { get; set; } = false;  // IsValid == false means this MigrationPathway is depricated and should be edited/removed // removed 15.12.2016 - no longer needed becaus we no longer import MigrationPathways
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
    public class FA4WithComments : FA4
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