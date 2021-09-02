using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Databank.Domain
{
    public class RL2021 : Databank.Domain.IRodlisteKriterier
    {
        public RL2021()
        {
            ArtskartModel = new ArtskartModel
            {
                ObservationFromYear = 1950,
                ObservationToYear = 2022,
                FromMonth = 1,
                ToMonth = 12,
                IncludeNorge = true,
                IncludeObjects = true,
                IncludeObservations = true,
                IncludeSvalbard = true,
                ExcludeGbif = false


            };
            ImportInfo = new TrackInfo();
        }
        public int Id { get; set; }  
        public DateTime LastUpdatedOn { get; set; }
        public string LastUpdatedBy { get; set; }

        //public DateTime SistOppdatert { get; set; }
        public int LatinsknavnId { get; set; } // Todo: to be removed when rl2015 loading and app is fixed
        public int Vurderingsår { get; set; } // år denne vurderingen er sist revidert. Det kan være aktuellt med vurderingsdato i tillegg!!
        public string VurdertVitenskapeligNavn { get; set; }
        public string VurdertVitenskapeligNavnAutor { get; set; }
        public string VurdertVitenskapeligNavnHierarki { get; set; }
        public int VurdertVitenskapeligNavnId { get; set; } // added 12.01.2020
        public int TaxonId { get; set; }
        public string TaxonRank { get; set; }   // "Species" or "SupSpecies"

        public string Ekspertgruppe { get; set; }
        //public string Artsgruppe   { get; set; }



        public string VurderingsContext { get; set; }   // N eller S  (Norge/Svalbard)
        //public string VurderingsStatus { get; set; }  // depricated 24.02.2020 !!

        //public string ArtenKanRisikovurderesEtterIUCNKriterier { get; set; } // denne blir ikke brukt i r2015 data fra r2010 er overført til Overordnet klassifisering
        public string UtdoddINorgeRE { get; set; }

        public string BegrensetForekomstNA { get; set; }
        //public string BegrensetForekomstAnnetBegrunnelseNA { get; set; } // vi har ikke brukt denne i 2015basen. Det finnes heller ikke data fra 2010
        public string KunnskapsStatusNE { get; set; }
        //public string KunnskapsStatusAnnetBegrunnelseNE { get; set; } // vi har ikke brukt denne i 2015basen. Det finnes data på noen få objekt i 2015basen overført fra 2010
        public string RodlisteVurdertArt { get; set; }
        public bool TroligUtdodd { get; set; }

        public string ArtenVurderesIkkeBegrunnelse { get; set; }
        //public string ArtMedBegrensetForekomstEllerFremmedartBegrunnelse { get; set; }
        //public bool DDStorUsikkerhetOmKorrektKategori { get; set; }

        public string Generasjonslengde { get; set; }
        public string BERN { get; set; }
        public string BONN { get; set; }
        public string CITES { get; set; }
        public string StatusIHenholdTilNaturvernloven { get; set; }
        public string StatusIHenholdTilNaturmangfoldloven { get; set; }
        public string MaxAndelAvEuropeiskBestand { get; set; }
        public string MaxAndelAvGlobalBestand { get; set; }
        public string AndelNåværendeBestand { get; set; }
        //public bool UtdoddINorge { get; set; }
        public bool IUCNVurdert { get; set; } // name changed from IkkeRodlisteartIUCN 27.2.2015

        public string A1OpphørtOgReversibel { get; set; }
        public MinMaxProbable A1OpphørtOgReversibelAntatt { get; set; } = new MinMaxProbable(); // lagt til 18.12.2019

        public List<string> A1EndringBasertpåKode { get; set; } = new List<string>();
        public string A2Forutgående10År { get; set; }
        public MinMaxProbable A2Forutgående10ÅrAntatt { get; set; } = new MinMaxProbable(); // lagt til 18.12.2019

        public List<string> A2EndringBasertpåKode { get; set; } = new List<string>();
        public string A3Kommende10År { get; set; }
        public MinMaxProbable A3Kommende10ÅrAntatt { get; set; } = new MinMaxProbable(); // lagt til 18.12.2019
        public List<string> A3EndringBasertpåKode { get; set; } = new List<string>();
        public string A4Intervall10År { get; set; }
        public MinMaxProbable A4Intervall10ÅrAntatt { get; set; } = new MinMaxProbable(); // lagt til 18.12.2019
        public List<string> A4EndringBasertpåKode { get; set; } = new List<string>();
        public string B1UtbredelsesområdeKjentAndel { get; set; }
        public string B1UtbredelsesområdeMørketall { get; set; }
        public string B1UtbredelsesområdeProdukt { get; set; }

        public MinMaxProbableIntervall B1IntervallUtbredelsesområde { get; set; } = new MinMaxProbableIntervall(); // lagt til 15/01/2020

        public string UtbredelsesområdePunktestimat { get; set; }

        public string ForekomstarealPunktestimat { get; set; }

        public string AntallLokaliteterPunktestimat { get; set; }

        public MinMaxProbableIntervall B2IntervallForekomstareal { get; set; } = new MinMaxProbableIntervall(); // lagt til 15/01/2020


        public string BA2FåLokaliteterProdukt { get; set; }
        public string B1BeregnetAreal { get; set; }
        public string B2BeregnetAreal { get; set; }

        public string B1UtbredelsesområdeKode { get; set; }
        public string B2ForekomstarealKjentAndel { get; set; }
        public string B2ForekomstarealMørketall { get; set; }
        public string B2ForekomstarealProdukt { get; set; }
        public string B2ForekomstarealKode { get; set; }
        public string BA1KraftigFragmenteringKode { get; set; }
        public string BA2FåLokaliteterKode { get; set; }

        public MinMaxProbableIntervall BaIntervallAntallLokaliteter { get; set; } = new MinMaxProbableIntervall(); // lagt til 15/01/2020

        //public bool BA1Trolig { get; set; }
        public List<string> BBPågåendeArealreduksjonKode { get; set; } = new List<string>();
        public List<string> BCEksterneFluktuasjonerKode { get; set; } = new List<string>();
        public string CReproductionDefinitionType { get; set; }
        public string CPopulasjonsstørrelse { get; set; } = "Ikke aktuelt";
        public string CReproductionDefinitionTemplateScale { get; set; }
        public string CReproductionDefinitionTemplate { get; set; }
        public string CReproductionDefinitionPerTree { get; set; }
        public string CReproductionDefinitionPerLocation { get; set; }

        public string CNumberOfLocations { get; set; }

        public string CSubstratenheter { get; set; }

        public string CAntallRameter { get; set; }

        public string CAntallGeneter { get; set; }

        public string CKjentPopulasjonsstørrelse { get; set; }
        public string CKjentPopulasjonsstørrelseMørketall { get; set; }
        public string CKjentPopulasjonsstørrelseProdukt { get; set; }
        //public string CVurdertpopulasjonsstørrelseMin { get; set; }
        //public string CVurdertpopulasjonsstørrelseMax { get; set; }
        public string CVurdertpopulasjonsstørrelseProdukt { get; set; }
        public string CDirekteFastsattEtterSkjønn { get; set; }

        public MinMaxProbableIntervall CPopulasjonsstørrelseAntatt { get; set; } = new MinMaxProbableIntervall(); // lagt til 15/01/2020

        public string PopulasjonsstørrelsePunktestimat { get; set; }

        public string CPopulasjonsstørrelseKode { get; set; }  // lagt til 10.01.2020
        public string C1PågåendePopulasjonsreduksjonKode { get; set; }
        public MinMaxProbable C1PågåendePopulasjonsreduksjonAntatt { get; set; } = new MinMaxProbable(); // lagt til 18.12.2019

        public string C2A1PågåendePopulasjonsreduksjonKode { get; set; }
        public MinMaxProbable C2A1PågåendePopulasjonsreduksjonAntatt { get; set; } = new MinMaxProbable(); // lagt til 16.12.2019
        public string C2A2PågåendePopulasjonsreduksjonKode { get; set; }
        public string C2A2SannhetsverdiKode { get; set; }
        public string C2A2ReproduksjonsdyktigeIndivid { get; set; }
        public string C2BPågåendePopulasjonsreduksjonKode { get; set; }
        public string D1FåReproduserendeIndividKode { get; set; }
        public string D2MegetBegrensetForekomstarealKode { get; set; }
        public string EKvantitativUtryddingsmodellKode { get; set; }

        public string OverordnetKlassifiseringGruppeKode { get; set; } // endret 27.2.2015
        public string OverordnetKlassifiseringTekst { get; set; } // lagt til 27.2.2015

        public string OppsummeringAKriterier { get; set; }  // slettet 3.3.2015
        public string OppsummeringBKriterier { get; set; }  // slettet 3.3.2015
        public string OppsummeringCKriterier { get; set; }  // slettet 3.3.2015
        public string OppsummeringDKriterier { get; set; }  // slettet 3.3.2015
        public string OppsummeringEKriterier { get; set; }  // slettet 3.3.2015

        public string Kriteriedokumentasjon { get; set; }

        public bool TilførselFraNaboland { get; set; }
        public string ÅrsakTilNedgraderingAvKategori { get; set; }
        public string ÅrsakTilEndringAvKategori { get; set; }
        public string UtdøingSterktPåvirket { get; set; }
        public string Kategori { get; set; }
        public string Kriterier { get; set; }
        public string[] HovedKriterier { get; set; }
        public string KategoriFraForrigeListe { get; set; }
        public string KriterierFraForrigeListe { get; set; }

        public string KategoriEndretTil { get; set; }
        public string KategoriEndretFra { get; set; }  // 11.11.2015 This makes more sense since the Kategori will be the adjusted Kategori
        public string GlobalRødlistestatusKode { get; set; }
        //public string Kommentarer { get; set; } // html-text

        // Artskart koplinger
        /// <summary>
        /// Punkter lagt til
        /// </summary>
        public string ArtskartAdded { get; set; }
        public string ArtskartRemoved { get; set; }
        public string ArtskartManuellKommentar { get; set; }
        public string ArtskartSistOverført { get; set; }
        public ArtskartModel ArtskartModel { get; set; }



        public List<Pavirkningsfaktor> Påvirkningsfaktorer { get; set; } = new List<Pavirkningsfaktor>();
        public List<Reference> Referanser { get; set; } = new List<Reference>();

        public List<Fylkesforekomst> Fylkesforekomster { get; set; }
        public List<string> NaturtypeHovedenhet { get; set; } = new List<string>();

        //public List<AssessmentComment> AssessmentComments { get; set; } = new List<AssessmentComment>(); // 25.10.2019
        public DateTime LockedForEditAt { get; set; }
        public string LockedForEditByUser { get; set; }
        public string EvaluationStatus { get; set; }
        public string PopularName { get; set; }
        public string Kommentarer { get; set; }
        public string Tilbakemeldinger { get; set; }
        public string WktPolygon { get; set; }
        public string ArtskartSelectionGeometry { get; set; }
        //public int OrgVitenskapeligNavnId { get; set; }
        //public string OrgVitenskapeligNavn { get; set; }
        public int SistVurdertAr { get; set; }
        //public string Url2015 { get; set; }
        //public string Kategori2015 { get; set; }
        //public string Kriterier2015 { get; set; }
        ////public int VurderingsId2015Int { get; set; }
        //public int ScientificNameId2015 { get; set; }
        //public string ScientificName2015 { get; set; }
        //public string MultipleUrl2015 { get; set; }
        //public string Url2010 { get; set; }
        //public string Kategori2010 { get; set; }
        //public string Kriterier2010 { get; set; }
        //public int ScientificNameId2010 { get; set; }
        //public string ScientificName2010 { get; set; }
        //public string MultipleUrl2010 { get; set; }
        public bool Slettet { get; set; }
        //public string VurderingsId2015Databank { get; set; }

        public List<TaxonHistory> TaxonomicHistory { get; set; } = new List<TaxonHistory>();
        public class TaxonHistory
        {
            public DateTime date { get; set; }
            public string username { get; set; } // The user that changed the name of the Assessment to a new name (not this name)
            public string VitenskapeligNavn { get; set; }
            public string VitenskapeligNavnAutor { get; set; }
            public string VitenskapeligNavnHierarki { get; set; }
            public int VitenskapeligNavnId { get; set; }
            public int TaxonId { get; set; }
            public string TaxonRank { get; set; }   // "Species" or "SupSpecies"
            public string Ekspertgruppe { get; set; }
        }




        public TrackInfo ImportInfo { get; set; }
        public string[] Regioner { get; set; }

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

        public class Reference
        {
            public string Type { get; set; }
            public Guid ReferenceId { get; set; }
            public string FormattedReference { get; set; }
        }
        public class Fylkesforekomst
        {
            public string Fylke { get; set; }
            //public bool Sikker { get; set; }
            public int State { get; set; }
        }
        public class Pavirkningsfaktor
        {
            /// <summary>
            /// accumulated from parent påvirkningsfaktor.beskrivelse
            /// </summary>
            public string Id { get; set; }
            public string OverordnetTittel { get; set; }
            public string Beskrivelse { get; set; }
            public string Tidspunkt { get; set; }
            public string Omfang { get; set; }
            public string Alvorlighetsgrad { get; set; }

            public string Tittel { get; set; }
            public string ØversteTittel { get; set; }
            public string Forkortelse { get; set; }
            //public string Tittel
            //{
            //    get
            //    {
            //        return string.IsNullOrEmpty(OverordnetTittel)
            //            ? Beskrivelse
            //            : OverordnetTittel + " > " + Beskrivelse;
            //    }
            //}
            //public string ØversteTittel
            //{
            //    get
            //    {
            //        return string.IsNullOrEmpty(OverordnetTittel)
            //            ? Beskrivelse
            //            : OverordnetTittel.Split(new[] { " > " }, StringSplitOptions.None)[0];
            //    }
            //}
        }

        /// <summary>
        /// Used to contain the Påvirkningsfaktor tree definitions
        /// </summary>
        public class PavirkningsfaktorClass
        {
            public string Id { get; set; }
            public IEnumerable<PavirkningsfaktorKode> Påvirkningsfaktorer { get; set; }
        }
        /// <summary>
        /// The elements of the Påvirkningsfaktor tree
        /// </summary>
        public class PavirkningsfaktorKode
        {
            public string Id { get; set; }
            public string Beskrivelse { get; set; }
            //public IEnumerable<PåvirkningsfaktorKode> Detaljer { get; set; }
        }
        public class Dominans
        {
            /// <summary>
            /// accumulation of overordnet beskriverse
            /// </summary>
            public string Tittel { get; set; }
            public List<string> Beskrivelse { get; set; } = new List<string>();
        }
        public class MinMaxProbable
        {
            public string Min { get; set; } = "";
            public string Probable { get; set; } = "";
            public string Max { get; set; } = "";
            public string Quantile { get; set; } = "";
            public string Calculated { get; set; } = "";
        }

        public class MinMaxProbableIntervall
        {
            public string Min { get; set; } = "";

            public string Minintervall { get; set; } = "";
            public string Probable { get; set; } = "";
            public string Max { get; set; } = "";
            public string Maxintervall { get; set; } = "";
            public string Quantile { get; set; } = "";

            public string Punktestimat { get; set; } = "true";
            public string Calculated { get; set; } = "";

        }

        public class Kode
        {
            public string Navn { get; set; }
            public string Tekst { get; set; }
            public string Verdi { get; set; }
        }
        public class KodeGrupper
        {
            public string Id { get; set; }
            public Dictionary<string, IEnumerable<Kode>> Grupper { get; set; }
        }

        public class Naturtype
        {
            public string Navn { get; set; }
            public string NavnR2010 { get; set; }
            public string NavnR2015 { get; set; }
            //public string DBnøkkel { get; set; }
            public string Forkortelse { get; set; }
            public string Kortnavn { get; set; }
            public string HovedøkosystemKLD { get; set; }
        }


    }

    //public class AssessmentComment
    //{
    //    public int Id { get; set; }
    //    public int AssessmentId { get; set; }
    //    public Assessment Assessment { get; set; }
    //    public string Comment { get; set; }
    //    public DateTime CommentDate { get; set; }
    //    public Bruker User { get; set; }
    //    public string UserId { get; set; }
    //    public bool Closed { get; set; }
    //    public string ClosedById { get; set; }
    //    public Bruker ClosedBy { get; set; }
    //    public DateTime? ClosedDate { get; set; }
    //    public bool IsDeleted { get; set; }
    //}

    public class ArtskartModel
    {
        public int ObservationFromYear { get; set; }
        public int ObservationToYear { get; set; }
        public int FromMonth { get; set; }
        public int ToMonth { get; set; }
        public bool IncludeObjects { get; set; }
        public bool IncludeObservations { get; set; }
        public bool IncludeNorge { get; set; }
        public bool IncludeSvalbard { get; set; }
        public bool ExcludeGbif { get; set; }
    }

    //public class VurderingsTaxon
    //    {
    //        public string TaxonId { get; set; }
    //        public string ScientificName { get; set; }
    //        public string VernacularName { get; set; }
    //        public string TaxonRank { get; set; }   // "Species" or "SupSpecies"
    //        public string VurderingsContext { get; set; }
    //        //public string VurderingsStatus { get; set; }
    //        public string Ekspertgruppe { get; set; }
    //        public DateTime SistOppdatert { get; set; }
    //        public string SistOppdatertAv { get; set; }
    //        public string Kategori { get; set; }

    //        public Guid[] References { get; set; }

    //        public IEnumerable<string> Query { get; set; }


    //        //        ekspertgruppe: "Tovinger"
    //        //scientificName: "Elipsocus hyalinus"
    //        //taxonId: 87620
    //        //taxonRank: "species"
    //        //vernacularName: undefined
    //        //vurderingsContext: "S"
    //        //__proto__: Object

    //    }


    public class VurderingsGruppe
    {
        public string Id { get; set; }
        //public string VurderingsGruppeNavn { get; set; }
        public string EkspertgruppeLeder { get; set; }
        public string ArtsGruppeNavn { get; set; }
        public string EkspertGruppeNavn { get; set; }
        public string VurderingsContext { get; set; }
        public int TotaltVurdert { get; set; }
        public Dictionary<string, int> Kategorier { get; set; }
    }

    //public class TaxonAndVurdering
    //{

    //    //public string Id { get; set; }
    //    public string ScientificName { get; set; }
    //    public string VernacularName { get; set; }
    //    public string Family { get; set; }
    //    public string Ekspertgruppe { get; set; }
    //    //public string VurderingsStatus { get; set; }
    //    //public Rodliste2015 Vurdering { get; set; }
    //    public string VurderingId { get; set; }

    //    public string Criteria { get; set; }
    //}

    //public class VurderingSearchResult
    //{
    //    public int TaxonId { get; set; }
    //    public string TaxonRank { get; set; }
    //    public string ScientificName { get; set; }
    //    public string VernacularName { get; set; }
    //    public string VurderingsContext { get; set; }
    //    public string Category { get; set; }
    //    public string Criteria { get; set; }
    //    public string Hovedhabitat { get; set; }
    //    public string Påvirkning { get; set; }
    //    public string[] Fylker { get; set; }

    //    public string Rødliste2010Ekspertgruppe { get; set; }
    //    public string[] Query { get; set; } // anything searchable
    //    public string VurderingId { get; set; }

    //}



}


