using System.Collections.Generic;
// ReSharper disable InconsistentNaming

namespace Assessments.Mapping.Models.Species
{
    /// <summary>
    /// Basert på Rodliste2019
    /// https://github.com/Artsdatabanken/Rodliste2019/blob/master/Prod.Domain/Rodliste2019.cs
    /// </summary>
    public class SpeciesAssessment2021
    {
        /// <summary>
        /// The unique identifier
        /// </summary>
        public int Id { get; set; }

        public SpeciesAssessment2021A1 A1 { get; set; } = new();

        public SpeciesAssessment2021A2 A2 { get; set; } = new();

        public SpeciesAssessment2021A3 A3 { get; set; } = new();

        public SpeciesAssessment2021A4 A4 { get; set; } = new();

        /// <summary>
        /// Current population size as percentage of maximum population size after 1900, given as predefined interval within the assessed area for the species.
        /// </summary>
        public string ProportionOfMaxPopulation { get; set; } // AndelNåværendeBestand

        public SpeciesAssessment2021B1 B1 { get; set; } = new();

        public SpeciesAssessment2021B2 B2 { get; set; } = new();

        /// <summary>
        /// Whether or not the taxon is severely fragmented, and if "yes" to what degree of certainty - Ba(i) or Ba(ii).
        /// </summary>
        public string BaiSevereFragmentation { get; set; } // BA1KraftigFragmenteringKode

        public SpeciesAssessment2021BAii BAii { get; set; } = new();

        /// <summary>
        /// Continuing decline observed, estimated, inferred or projected in any of: (i) extent of occurence; (ii) area of occupancy; (iii) area, extent and/or quality of habitat; (iv) number of locations or subpopulations; (v) number of mature individuals
        /// </summary>
        public List<string> BbContinuingDecline { get; set; } = new(); // BBPågåendeArealreduksjonKode

        /// <summary>
        /// Extreme fluctuations in any of: (i) extent of occurence; (ii) area of occupancy; (iii) number of locations or subpopulations; (iv) number of mature individuals
        /// </summary>
        public List<string> ExtremeFluctuations { get; set; } = new(); // BCEksterneFluktuasjonerKode

        /// <summary>
        /// For reasons specified herein, the taxon is Not Applicable (NA) for Red list evaluation in the AssessmentArea.
        /// </summary>
        public string RationaleNotApplicable { get; set; } // BegrensetForekomstNA

        public SpeciesAssessment2021C1 C1 { get; set; } = new();

        public SpeciesAssessment2021C2Ai C2Ai { get; set; } = new();

        public SpeciesAssessment2021C2Aii C2Aii { get; set; } = new();

        /// <summary>
        /// Whether or not there are extreme fluctuations in the number of mature individuals. 
        /// </summary>
        public string C2bExtremeFluctuations { get; set; } // C2BPågåendePopulasjonsreduksjonKode

        public SpeciesAssessment2021C C { get; set; } = new();

        /// <summary>
        /// Preliminary category that just the number of mature individuals on the D1-criterion represents. 
        /// </summary>
        public string D1PreliminaryCategory { get; set; } // D1FåReproduserendeIndividKode

        /// <summary>
        /// Preliminary category that just the area of occupancy or number of locations on the D2-criterion represents. 
        /// </summary>
        public string D2PreliminaryCategory { get; set; } // D2MegetBegrensetForekomstarealKode

        /// <summary>
        /// Name of ekspert committee that conducted the assessments.
        /// </summary>
        public string ExpertCommittee { get; set; } // Ekspertgruppe

        /// <summary>
        /// Preliminary category based on a quantitative analysis (the E-criterion).
        /// </summary>
        public string EPreliminaryCategory { get; set; } // EKvantitativUtryddingsmodellKode

        public List<SpeciesAssessment2021RegionOccurrence> RegionOccurrences { get; set; } = new();

        /// <summary>
        /// Average age of reproducing individuals.
        /// </summary>
        public string GenerationLength { get; set; } // Generasjonslengde

        // TODO public TrackInfo ImportInfo { get; set; } = new(); 

        // TODO public string Kategori { get; set; } 

        // TODO public string KategoriEndretFra { get; set; } 

        // TODO public string KategoriEndretTil { get; set; } 

        public string ExpertStatement { get; set; } // Kriteriedokumentasjon

        /// <summary>
        /// Criteria summarized according to IUCN Guidelines and Norwegian national adaptations, written on the standard IUCN format. 
        /// </summary>
        public string CriteriaSummarized { get; set; } // Kriterier

        /// <summary>
        /// Rationale for why a taxon is set to the category Not Evaluated NE, i.e., why it is not evaluated for the Red List
        /// </summary>
        public string RationaleNotEvaluated { get; set; } // KunnskapsStatusNE

        /// <summary>
        /// Percentage of the European population that the taxon's population in the AssessmenArea constitutes.
        /// </summary>
        public string PercentageEuropeanPopulation { get; set; } // MaxAndelAvEuropeiskBestand

        /// <summary>
        /// Percentage of the global population that the taxon's population in the AssessmentArea constitutes.
        /// </summary>
        public string PercentageGlobalPopulation { get; set; } // MaxAndelAvGlobalBestand

        /// <summary>
        /// The habitat type(s) of importance for the taxon. A MainHabitat type corresponds to one or several EcoSyst (Natur i Norge version 2.0) codes.
        /// </summary>
        public List<string> MainHabitat { get; set; } = new(); // NaturtypeHovedenhet

        // TODO public string OppsummeringAKriterier { get; set; } 

        // TODO public string OppsummeringBKriterier { get; set; } 

        // TODO public string OppsummeringCKriterier { get; set; } 

        // TODO public string OppsummeringDKriterier { get; set; } 

        // TODO public string OppsummeringEKriterier { get; set; } 

        /// <summary>
        /// Initial assessment of the taxon, either (in)directly to a category or to be thoroughly evaluated against Red List criteria.
        /// </summary>
        public string RedlistAssessmentClassification { get; set; } // OverordnetKlassifiseringGruppeKode

        /// <summary>
        /// Norwegian common names
        /// </summary>
        public string PopularName { get; set; }

        // TODO public List<Pavirkningsfaktor> Påvirkningsfaktorer { get; set; } = new();

        public List<SpeciesAssessment2021Reference> References { get; set; } = new(); // Referanser

        /// <summary>
        /// Justification for why the taxon is evaluated, i.e., which one of the three Norwegian inclusion criteria that is met.
        /// </summary>
        public string EvaluationJustification { get; set; } // RodlisteVurdertArt

        /// <summary>
        /// Publication year of the latest previous assessment of the taxon. 
        /// </summary>
        public int YearPreviousAssessment { get; set; } // SistVurdertAr

        public List<SpeciesAssessment2021TaxonHistory> TaxonomicHistory { get; set; } = new();

        /// <summary>
        /// Taxonomic level of the assessed taxon, either "Species" or "SubSpecies". Note that "SubSpecies" encompasses different forms of within-species taxonomic levels (e.g., subspecies and varieties).
        /// </summary>
        public string TaxonRank { get; set; }

        // TODO public bool TilførselFraNaboland { get; set; }

        /// <summary>
        /// The tag "Possibly Extinct" is used on Critically Endangered CR taxa that assessors suspect to be extinct.
        /// </summary>
        public bool PresumedExtinct { get; set; } // TroligUtdodd

        /// <summary>
        /// Justification for why the taxon is evaluated, i.e., which one of the three Norwegian inclusion criteria that was met before the taxon became regionally extinct.
        /// </summary>
        public string RationaleRE { get; set; } // UtdoddINorgeRE

        // TODO public string UtdøingSterktPåvirket { get; set; } 

        /// <summary>
        /// Geographic area assessed
        /// </summary>
        public string AssessmentArea { get; set; } // VurderingsContext

        /// <summary>
        /// Year when species was red list assessed. This is the latest valid assessment for the species.
        /// </summary>
        public int AssessmentYear { get; set; } // Vurderingsår

        /// <summary>
        /// The scientific name. When forming part of an Identification, this should be the name in lowest level taxonomic rank that can be determined.
        /// </summary>
        public string ScientificName { get; set; } // VurdertVitenskapeligNavn

        /// <summary>
        /// Author of the scienfic name
        /// </summary>
        public string ScientificNameAuthor { get; set; } // VurdertVitenskapeligNavnAutor

        // TODO public string VurdertVitenskapeligNavnHierarki { get; set; }

        /// <summary>
        /// An identifier for the nomenclatural (not taxonomic) details of a scientific name
        /// </summary>
        public int ScientificNameId { get; set; } // VurdertVitenskapeligNavnId

        // TODO public string ÅrsakTilEndringAvKategori { get; set; } // ÅrsakTilEndringAvKategori

        // TODO public string ÅrsakTilNedgraderingAvKategori { get; set; } // ÅrsakTilNedgraderingAvKategori
    }

    //public class Pavirkningsfaktor
    //{
    //    public string Alvorlighetsgrad { get; set; }

    //    public string Beskrivelse { get; set; }

    //    public string Forkortelse { get; set; }

    //    public string Id { get; set; }

    //    public string Omfang { get; set; }

    //    public string OverordnetTittel { get; set; }

    //    public string Tidspunkt { get; set; }

    //    public string Tittel { get; set; }

    //    public string ØversteTittel { get; set; }
    //}

    //public class TrackInfo
    //{
    //    public string Kategori2010 { get; set; }

    //    public string Kategori2015 { get; set; }

    //    public string Kriterier2010 { get; set; }

    //    public string Kriterier2015 { get; set; }

    //    public string MultipleUrl2010 { get; set; }

    //    public string MultipleUrl2015 { get; set; }

    //    public string OrgVitenskapeligNavn { get; set; }

    //    public int OrgVitenskapeligNavnId { get; set; }

    //    public string ScientificName2010 { get; set; }

    //    public string ScientificName2015 { get; set; }

    //    public int ScientificNameId2010 { get; set; }

    //    public int ScientificNameId2015 { get; set; }

    //    public string Url2010 { get; set; }

    //    public string Url2015 { get; set; }

    //    public int VurderingsId2010 { get; set; }

    //    public string VurderingsId2015 { get; set; }

    //    public string VurderingsId2015Databank { get; set; }
    //}
}