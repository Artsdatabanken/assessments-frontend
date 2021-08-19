// ReSharper disable InconsistentNaming
namespace Assessments.Mapping.Models.Species
{
    /// <summary>
    /// https://github.com/Artsdatabanken/interne-raadata/blob/main/models/CSharp/Rodliste2006/Redlist2006Assessment.cs
    /// sortert alfabetisk
    /// </summary>
    public class Redlist2006Assessment
    {
        public string A1 { get; set; }

        public string A2 { get; set; }

        public string AndelNåværenedBestand { get; set; }

        public string Artgruppenavn { get; set; }

        public string ArtsGruppeBildeUrl { get; set; }

        public int ArtsgruppeID { get; set; }

        public string ArtsID { get; set; }

        public string Author { get; set; }

        public string B1UtbredelsesområdeProdukt { get; set; }

        public string B2ForekomstarealProdukt { get; set; }

        public string Bern1 { get; set; }

        public string Bern2 { get; set; }

        public string Bern3 { get; set; }

        public string Bonn1 { get; set; }

        public string Bonn2 { get; set; }

        public string C1 { get; set; }

        public int CDirekteFastsattEtterSkjønn { get; set; }

        public string Cites1 { get; set; }

        public string Cites2 { get; set; }

        public int CVurdertpopulasjonsstørrelseMax { get; set; }

        public int CVurdertpopulasjonsstørrelseMin { get; set; }

        public string[] Forfattere { get; set; }

        public string Fredet { get; set; }

        public string Generasjonslengde { get; set; }

        public string GlobalRødliste2006 { get; set; }

        public string[] HabitatForklaring { get; set; }

        public string Habitatkoder { get; set; }

        public byte[] Illustrasjon { get; set; }

        public string Kategori { get; set; }

        public string Kriteriedokumentasjon { get; set; }

        public string Kriterier { get; set; }

        public string KriterierIUCN { get; set; }

        public string LatinskArtsnavn { get; set; }

        public string LC_NA_NE_Forklaring { get; set; }

        public string MaxAndelAvEuropeiskBestand { get; set; }

        public string MaxAndelAvGlobalBestand { get; set; }

        public string NorskArtsnavnBrukRødlista { get; set; }

        public string OriginalUrl { get; set; }

        public string[] Påvirkningsfaktorer { get; set; }

        public string Påvirkningsfaktorkoder { get; set; }

        public string[] Referanser { get; set; }

        public string Substratkoder { get; set; }

        public string UnderartKode { get; set; }

        public string ÅrsakTilEndringAvKategori { get; set; }
    }
}