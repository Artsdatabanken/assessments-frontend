using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Databank.Domain
{
    /// <summary>
    /// all IUCN criteria data values used to make and redlist category
    /// (used in Loading.KategoriKriterier.fs, the inteface should make it possible to assess future redlists)
    /// </summary>
    public interface IRodlisteKriterier
    {
        string A1OpphørtOgReversibel { get; set; }
        List<string> A1EndringBasertpåKode { get; set; }
        string A2Forutgående10År { get; set; }
        List<string> A2EndringBasertpåKode { get; set; }
        string A3Kommende10År { get; set; }
        List<string> A3EndringBasertpåKode { get; set; }
        string A4Intervall10År { get; set; }
        List<string> A4EndringBasertpåKode { get; set; }
        string B1UtbredelsesområdeKjentAndel { get; set; } // not part of the criteria evaluation, but part of the used criterias
        string B1UtbredelsesområdeMørketall { get; set; } // not part of the criteria evaluation, but part of the used criterias
        string B1UtbredelsesområdeProdukt { get; set; } // not part of the criteria evaluation, but part of the used criterias
        string B1UtbredelsesområdeKode { get; set; }
        string B2ForekomstarealKjentAndel { get; set; } // not part of the criteria evaluation, but part of the used criterias
        string B2ForekomstarealMørketall { get; set; } // not part of the criteria evaluation, but part of the used criterias
        string B2ForekomstarealProdukt { get; set; } // not part of the criteria evaluation, but part of the used criterias
        string B2ForekomstarealKode { get; set; }
        string BA1KraftigFragmenteringKode { get; set; }
        string BA2FåLokaliteterKode { get; set; }
        List<string> BBPågåendeArealreduksjonKode { get; set; }
        List<string> BCEksterneFluktuasjonerKode { get; set; }
        string CKjentPopulasjonsstørrelse { get; set; }
        string CKjentPopulasjonsstørrelseMørketall { get; set; }
        string CKjentPopulasjonsstørrelseProdukt { get; set; }
        //string CVurdertpopulasjonsstørrelseMin { get; set; }
        //string CVurdertpopulasjonsstørrelseMax { get; set; }
        string CVurdertpopulasjonsstørrelseProdukt { get; set; }
        string CDirekteFastsattEtterSkjønn { get; set; }
        string CPopulasjonsstørrelseKode { get; set; }
        string C1PågåendePopulasjonsreduksjonKode { get; set; }
        string C2A1PågåendePopulasjonsreduksjonKode { get; set; }
        string C2A2PågåendePopulasjonsreduksjonKode { get; set; }
        string C2A2SannhetsverdiKode { get; set; }
        string C2A2ReproduksjonsdyktigeIndivid { get; set; }
        string C2BPågåendePopulasjonsreduksjonKode { get; set; }
        string D1FåReproduserendeIndividKode { get; set; }
        string D2MegetBegrensetForekomstarealKode { get; set; }
        string EKvantitativUtryddingsmodellKode { get; set; }

        string OppsummeringAKriterier { get; set; }
        string OppsummeringBKriterier { get; set; }
        string OppsummeringCKriterier { get; set; }
        string OppsummeringDKriterier { get; set; }
        string OppsummeringEKriterier { get; set; }
        string Kriterier { get; set; }
    }
 }


