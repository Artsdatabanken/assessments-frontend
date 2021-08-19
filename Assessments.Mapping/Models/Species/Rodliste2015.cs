using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Assessments.Mapping.Models.Species
{
    /// <summary>
    ///  https://github.com/Artsdatabanken/interne-raadata/blob/main/models/CSharp/Rodliste2015/Rodliste2015Domain.cs
    ///  formatert, sortert alfabetisk, slettet kommentarer, tatt bort kode som var utkommentert eller ikke i bruk
    /// </summary>
    public class Rodliste2015
    {
        public List<string> A1EndringBasertpåKode { get; set; } = new();

        public string A1OpphørtOgReversibel { get; set; }

        public List<string> A2EndringBasertpåKode { get; set; } = new();

        public string A2Forutgående10År { get; set; }

        public List<string> A3EndringBasertpåKode { get; set; } = new();

        public string A3Kommende10År { get; set; }

        public List<string> A4EndringBasertpåKode { get; set; } = new();

        public string A4Intervall10År { get; set; }

        public string AndelNåværendeBestand { get; set; }

        public string ArtenVurderesIkkeBegrunnelse { get; set; }

        public string Artsgruppe { get; set; }

        public string B1UtbredelsesområdeKjentAndel { get; set; }

        public string B1UtbredelsesområdeKode { get; set; }

        public string B1UtbredelsesområdeMørketall { get; set; }

        public string B1UtbredelsesområdeProdukt { get; set; }

        public string B2ForekomstarealKjentAndel { get; set; }

        public string B2ForekomstarealKode { get; set; }

        public string B2ForekomstarealMørketall { get; set; }

        public string B2ForekomstarealProdukt { get; set; }

        public string BA1KraftigFragmenteringKode { get; set; }

        public string BA2FåLokaliteterKode { get; set; }

        public List<string> BBPågåendeArealreduksjonKode { get; set; } = new();

        public List<string> BCEksterneFluktuasjonerKode { get; set; } = new();

        public string BegrensetForekomstNA { get; set; }

        public string BERN { get; set; }

        public string BONN { get; set; }

        public string C1PågåendePopulasjonsreduksjonKode { get; set; }

        public string C2A1PågåendePopulasjonsreduksjonKode { get; set; }

        public string C2A2PågåendePopulasjonsreduksjonKode { get; set; }

        public string C2BPågåendePopulasjonsreduksjonKode { get; set; }

        public string CDirekteFastsattEtterSkjønn { get; set; }

        public string CITES { get; set; }

        public string CKjentPopulasjonsstørrelse { get; set; }

        public string CKjentPopulasjonsstørrelseMørketall { get; set; }

        public string CKjentPopulasjonsstørrelseProdukt { get; set; }

        public string CVurdertpopulasjonsstørrelseMax { get; set; }

        public string CVurdertpopulasjonsstørrelseMin { get; set; }

        public string CVurdertpopulasjonsstørrelseProdukt { get; set; }

        public string D1FåReproduserendeIndividKode { get; set; }

        public string D2MegetBegrensetForekomstarealKode { get; set; }

        public string Ekspertgruppe { get; set; }

        public string EKvantitativUtryddingsmodellKode { get; set; }

        public List<Rodliste2015Fylkesforekomst> Fylkesforekomster { get; set; }

        public string Generasjonslengde { get; set; }

        public string GlobalRødlistestatusKode { get; set; }

        public string[] HovedKriterier { get; set; }

        public string Id { get; set; }

        public bool IUCNVurdert { get; set; }

        public string Kategori { get; set; }

        public string KategoriEndretFra { get; set; }

        public string KategoriFraForrigeListe { get; set; }

        public string Kriteriedokumentasjon { get; set; }

        public string Kriterier { get; set; }

        public string KriterierFraForrigeListe { get; set; }

        public string KunnskapsStatusNE { get; set; }

        public int LatinsknavnId { get; set; }

        public string MaxAndelAvEuropeiskBestand { get; set; }

        public string MaxAndelAvGlobalBestand { get; set; }

        public List<Rodliste2015Naturtype> NaturtypeHovedenhet { get; set; }

        public string OppsummeringAKriterier { get; set; }

        public string OppsummeringBKriterier { get; set; }

        public string OppsummeringCKriterier { get; set; }

        public string OppsummeringDKriterier { get; set; }

        public string OppsummeringEKriterier { get; set; }

        public string OverordnetKlassifiseringGruppeKode { get; set; }

        public string OverordnetKlassifiseringTekst { get; set; }

        public List<Rodliste2015Pavirkningsfaktor> Påvirkningsfaktorer { get; set; }

        public List<Rodliste2015Reference> Referanser { get; set; } = new();

        public string RodlisteVurdertArt { get; set; }

        public string StatusIHenholdTilNaturmangfoldloven { get; set; }

        public string StatusIHenholdTilNaturvernloven { get; set; }

        public bool TilførselFraNaboland { get; set; }

        public bool TroligUtdodd { get; set; }

        public string UtdøingSterktPåvirket { get; set; }

        public string VurderingsContext { get; set; }

        public int VurderingsId2010 { get; set; }

        public int Vurderingsår { get; set; }

        public string VurdertVitenskapeligNavn { get; set; }

        public string ÅrsakTilEndringAvKategori { get; set; }

        public string ÅrsakTilNedgraderingAvKategori { get; set; }

        public class Rodliste2015Fylkesforekomst
        {
            public string Fylke { get; set; }

            public bool Sikker { get; set; }
        }

        public class Rodliste2015Naturtype
        {
            public string Forkortelse { get; set; }

            public string HovedøkosystemKLD { get; set; }

            public string Kortnavn { get; set; }

            public string Navn { get; set; }

            public string NavnR2010 { get; set; }
        }

        public class Rodliste2015Pavirkningsfaktor
        {
            public string Alvorlighetsgrad { get; set; }

            public string Beskrivelse { get; set; }

            public string Forkortelse { get; set; }

            public string Omfang { get; set; }

            public string OverordnetTittel { get; set; }

            public string Tidspunkt { get; set; }

            public string Tittel { get; set; }

            public string ØversteTittel { get; set; }
        }

        public class Rodliste2015Reference
        {
            public string FormattedReference { get; set; }

            public Guid ReferenceId { get; set; }
            public string Type { get; set; }
        }
    }
}