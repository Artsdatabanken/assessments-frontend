using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Assessments.Mapping.RedlistSpecies.Source
{
    /// <summary>
    /// https://github.com/Artsdatabanken/Rodliste2019/blob/master/Prod.Domain/Rodliste2019.cs
    /// sortert alfabetisk, slettet kommentarer og tatt bort utkommentert kode
    /// </summary>
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Rodliste2019
    {
        public Rodliste2019()
        {
            ArtskartModel = new ArtskartModel
            {
                ExcludeGbif = false,
                FromMonth = 1,
                IncludeNorge = true,
                IncludeObjects = true,
                IncludeObservations = true,
                IncludeSvalbard = true,
                ObservationFromYear = 1950,
                ObservationToYear = 2022,
                ToMonth = 12
            };
        }

        public List<string> A1EndringBasertpåKode { get; set; } = new();

        public string A1OpphørtOgReversibel { get; set; }

        public MinMaxProbable A1OpphørtOgReversibelAntatt { get; set; } = new();

        public List<string> A2EndringBasertpåKode { get; set; } = new();

        public string A2Forutgående10År { get; set; }

        public MinMaxProbable A2Forutgående10ÅrAntatt { get; set; } = new();

        public List<string> A3EndringBasertpåKode { get; set; } = new();

        public string A3Kommende10År { get; set; }

        public MinMaxProbable A3Kommende10ÅrAntatt { get; set; } = new();

        public List<string> A4EndringBasertpåKode { get; set; } = new();

        public string A4Intervall10År { get; set; }

        public MinMaxProbable A4Intervall10ÅrAntatt { get; set; } = new();

        public string AndelNåværendeBestand { get; set; }

        public string AntallLokaliteterPunktestimat { get; set; }

        public string ArtenVurderesIkkeBegrunnelse { get; set; }

        public string ArtskartAdded { get; set; }

        public string ArtskartManuellKommentar { get; set; }

        public ArtskartModel ArtskartModel { get; set; }

        public string ArtskartRemoved { get; set; }

        public string ArtskartSelectionGeometry { get; set; }

        public string ArtskartSistOverført { get; set; }

        public string B1BeregnetAreal { get; set; }

        public MinMaxProbableIntervall B1IntervallUtbredelsesområde { get; set; } = new();

        public string B1UtbredelsesområdeKjentAndel { get; set; }

        public string B1UtbredelsesområdeKode { get; set; }

        public string B1UtbredelsesområdeMørketall { get; set; }

        public string B1UtbredelsesområdeProdukt { get; set; }

        public string B2BeregnetAreal { get; set; }

        public string B2ForekomstarealKjentAndel { get; set; }

        public string B2ForekomstarealKode { get; set; }

        public string B2ForekomstarealMørketall { get; set; }

        public string B2ForekomstarealProdukt { get; set; }

        public MinMaxProbableIntervall B2IntervallForekomstareal { get; set; } = new();

        public string BA1KraftigFragmenteringKode { get; set; }

        public string BA2FåLokaliteterKode { get; set; }

        public string BA2FåLokaliteterProdukt { get; set; }

        public MinMaxProbableIntervall BaIntervallAntallLokaliteter { get; set; } = new();

        public List<string> BBPågåendeArealreduksjonKode { get; set; } = new();

        public List<string> BCEksterneFluktuasjonerKode { get; set; } = new();

        public string BegrensetForekomstNA { get; set; }

        public string BERN { get; set; }

        public string BONN { get; set; }

        public MinMaxProbable C1PågåendePopulasjonsreduksjonAntatt { get; set; } = new();

        public string C1PågåendePopulasjonsreduksjonKode { get; set; }

        public MinMaxProbable C2A1PågåendePopulasjonsreduksjonAntatt { get; set; } = new();

        public string C2A1PågåendePopulasjonsreduksjonKode { get; set; }

        public string C2A2PågåendePopulasjonsreduksjonKode { get; set; }

        public string C2A2ReproduksjonsdyktigeIndivid { get; set; }

        public string C2A2SannhetsverdiKode { get; set; }

        public string C2BPågåendePopulasjonsreduksjonKode { get; set; }

        public string CAntallGeneter { get; set; }

        public string CAntallRameter { get; set; }

        public string CDirekteFastsattEtterSkjønn { get; set; }

        public string CITES { get; set; }

        public string CKjentPopulasjonsstørrelse { get; set; }

        public string CKjentPopulasjonsstørrelseMørketall { get; set; }

        public string CKjentPopulasjonsstørrelseProdukt { get; set; }

        public string CNumberOfLocations { get; set; }

        public string CPopulasjonsstørrelse { get; set; } = "Ikke aktuelt";

        public MinMaxProbableIntervall CPopulasjonsstørrelseAntatt { get; set; } = new();

        public string CPopulasjonsstørrelseKode { get; set; }

        public string CReproductionDefinitionPerLocation { get; set; }

        public string CReproductionDefinitionPerTree { get; set; }

        public string CReproductionDefinitionTemplate { get; set; }

        public string CReproductionDefinitionTemplateScale { get; set; }

        public string CReproductionDefinitionType { get; set; }

        public string CSubstratenheter { get; set; }

        public string CVurdertpopulasjonsstørrelseProdukt { get; set; }

        public string D1FåReproduserendeIndividKode { get; set; }

        public string D2MegetBegrensetForekomstarealKode { get; set; }

        public string Ekspertgruppe { get; set; }

        public string EKvantitativUtryddingsmodellKode { get; set; }

        public string EvaluationStatus { get; set; }

        public string ForekomstarealPunktestimat { get; set; }

        public List<Fylkesforekomst> Fylkesforekomster { get; set; }

        public string Generasjonslengde { get; set; }

        public string GlobalRødlistestatusKode { get; set; }

        public string[] HovedKriterier { get; set; }

        public string Id { get; set; }

        public TrackInfo ImportInfo { get; set; } = new();

        public bool IUCNVurdert { get; set; }

        public string Kategori { get; set; }

        public string KategoriEndretFra { get; set; }

        public string KategoriEndretTil { get; set; }

        public string KategoriFraForrigeListe { get; set; }

        public string Kommentarer { get; set; }

        public string Kriteriedokumentasjon { get; set; }

        public string Kriterier { get; set; }

        public string KriterierFraForrigeListe { get; set; }

        public string KunnskapsStatusNE { get; set; }

        public string LastUpdatedBy { get; set; }

        public DateTime LastUpdatedOn { get; set; }

        public int LatinsknavnId { get; set; }

        public DateTime LockedForEditAt { get; set; }

        public string LockedForEditByUser { get; set; }

        public string MaxAndelAvEuropeiskBestand { get; set; }

        public string MaxAndelAvGlobalBestand { get; set; }

        public List<string> NaturtypeHovedenhet { get; set; } = new();

        public string OppsummeringAKriterier { get; set; }

        public string OppsummeringBKriterier { get; set; }

        public string OppsummeringCKriterier { get; set; }

        public string OppsummeringDKriterier { get; set; }

        public string OppsummeringEKriterier { get; set; }

        public string OverordnetKlassifiseringGruppeKode { get; set; }

        public string OverordnetKlassifiseringTekst { get; set; }

        public string PopularName { get; set; }

        public string PopulasjonsstørrelsePunktestimat { get; set; }

        public List<Pavirkningsfaktor> Påvirkningsfaktorer { get; set; } = new();

        public List<Reference> Referanser { get; set; } = new();

        public string RodlisteVurdertArt { get; set; }

        public int SistVurdertAr { get; set; }

        public bool Slettet { get; set; }

        public string StatusIHenholdTilNaturmangfoldloven { get; set; }

        public string StatusIHenholdTilNaturvernloven { get; set; }

        public int TaxonId { get; set; }

        public List<TaxonHistory> TaxonomicHistory { get; set; } = new();

        public string TaxonRank { get; set; }

        public string Tilbakemeldinger { get; set; }

        public bool TilførselFraNaboland { get; set; }

        public bool TroligUtdodd { get; set; }

        public string UtbredelsesområdePunktestimat { get; set; }

        public string UtdoddINorgeRE { get; set; }

        public string UtdøingSterktPåvirket { get; set; }

        public string VurderingsContext { get; set; }

        public int Vurderingsår { get; set; }

        public string VurdertVitenskapeligNavn { get; set; }

        public string VurdertVitenskapeligNavnAutor { get; set; }

        public string VurdertVitenskapeligNavnHierarki { get; set; }

        public int VurdertVitenskapeligNavnId { get; set; }

        public string WktPolygon { get; set; }

        public string ÅrsakTilEndringAvKategori { get; set; }

        public string ÅrsakTilNedgraderingAvKategori { get; set; }

        public Taxonomy TaxonomyInfo { get; set; }
        public string Endringslogg { get; set; }

        // enhansed props - not really there
        public DateTime RevisionDate { get; set; }
        public int Revision { get; set; }
        public List<Rodliste2019> Revisions { get; set; }
        public string RevisionReason { get; set; }

        public class Taxonomy
        {
            public string Rank { get; set; }
            public int TaxonId { get; set; }
            public int ScientificNameId { get; set; }
            public string ScientificName { get; set; }
            public string ScientificNameAuthor { get; set; }
            public NameInfo[] HigherClassification { get; set; }

            public class NameInfo
            {
                public int ScientificNameId { get; set; }
                public string ScientificName { get; set; }
                public string ScientificNameAuthor { get; set; }
                public string Rank { get; set; }
            }
        }

        public class Fylkesforekomst
        {
            public string Fylke { get; set; }

            public int State { get; set; }
        }

        public class MinMaxProbable
        {
            public string Max { get; set; } = "";

            public string Min { get; set; } = "";

            public string Probable { get; set; } = "";

            public string Quantile { get; set; } = "";
        }

        public class MinMaxProbableIntervall
        {
            public string Max { get; set; } = "";

            public string Maxintervall { get; set; } = "";

            public string Min { get; set; } = "";

            public string Minintervall { get; set; } = "";

            public string Probable { get; set; } = "";

            public string Punktestimat { get; set; } = "true";

            public string Quantile { get; set; } = "";
        }

        public class Pavirkningsfaktor
        {
            public string Alvorlighetsgrad { get; set; }

            public string Beskrivelse { get; set; }

            public string Forkortelse { get; set; }

            public string Id { get; set; }

            public string Omfang { get; set; }

            public string OverordnetTittel { get; set; }

            public string Tidspunkt { get; set; }

            public string Tittel { get; set; }

            public string ØversteTittel { get; set; }
        }

        public class Reference
        {
            public string FormattedReference { get; set; }

            public Guid ReferenceId { get; set; }

            public string Type { get; set; }
        }

        public class TaxonHistory
        {
            public DateTime date { get; set; }

            public string Ekspertgruppe { get; set; }

            public int TaxonId { get; set; }

            public string TaxonRank { get; set; }

            public string username { get; set; }

            public string VitenskapeligNavn { get; set; }

            public string VitenskapeligNavnAutor { get; set; }

            public string VitenskapeligNavnHierarki { get; set; }

            public int VitenskapeligNavnId { get; set; }
        }

        public class TrackInfo
        {
            public string Kategori2010 { get; set; }

            public string Kategori2015 { get; set; }

            public string Kriterier2010 { get; set; }

            public string Kriterier2015 { get; set; }

            public string MultipleUrl2010 { get; set; }

            public string MultipleUrl2015 { get; set; }

            public string OrgVitenskapeligNavn { get; set; }

            public int OrgVitenskapeligNavnId { get; set; }

            public string ScientificName2010 { get; set; }

            public string ScientificName2015 { get; set; }

            public int ScientificNameId2010 { get; set; }

            public int ScientificNameId2015 { get; set; }

            public string Url2010 { get; set; }

            public string Url2015 { get; set; }

            public int VurderingsId2010 { get; set; }

            public string VurderingsId2015 { get; set; }

            public string VurderingsId2015Databank { get; set; }
        }
    }
}