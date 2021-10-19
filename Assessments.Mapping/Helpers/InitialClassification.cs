using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessments.Mapping.Models.Source.Species;
using Assessments.Mapping.Models.Species;
using Assessments.Shared.Helpers;

namespace Assessments.Mapping.Helpers
{
    /// <summary>
    /// Helper method for transforming Initial Classification from production model to viewmodel
    /// </summary>
    static class InitialClassification
    {
        private static readonly string descRedlistedSpecies = SpeciesAssessment2021.InitialClassification.RodlisteVurdertArt.Description();
        private static readonly string descOkPopulationLC = SpeciesAssessment2021.InitialClassification.SikkerBestandLC.Description();
        private static readonly string descExtinctRE = SpeciesAssessment2021.InitialClassification.UtdoddINorgeRE.Description();
        private static readonly string descLimitedPopulationNA = SpeciesAssessment2021.InitialClassification.BegrensetForekomstNA.Description();
        private static readonly string descAlienSpeciesNA = SpeciesAssessment2021.InitialClassification.FremmedArtNA.Description();
        private static readonly string descLimitedKnowlegdeNE = SpeciesAssessment2021.InitialClassification.KunnskapsStatusNE.Description();
        private static readonly string descDataDeficientDD = SpeciesAssessment2021.InitialClassification.StorUsikkerhetOmKorrektKategoriDD.Description();
        // RodlisteVurdertArt
        private static readonly string descEstablishedInNorway = SpeciesAssessment2021.InitialSubClassification.EtablertBestandINorge.Description();
        private static readonly string descNotReproducing = SpeciesAssessment2021.InitialSubClassification.IkkeReproduserendeINorge.Description();
        private static readonly string descEstablishedbefore1800 = SpeciesAssessment2021.InitialSubClassification.EtablertFør1800.Description();

        private static readonly string descikkeReproduserendeGjestNA = SpeciesAssessment2021.InitialSubClassification.IkkeReproduserendeGjestNA.Description();
        private static readonly string descobservertReproduserendeIkkeEtablertNA = SpeciesAssessment2021.InitialSubClassification.ObservertReproduserendeIkkeEtablertNA.Description();
        private static readonly string descobservertReproduktivIkkeEtablertNA = SpeciesAssessment2021.InitialSubClassification.ObservertReproduktivIkkeEtablertNA.Description();
        private static readonly string descuregelmessigGjestIkkeReproduserendeNA = SpeciesAssessment2021.InitialSubClassification.UregelmessigGjestIkkeReproduserendeNA.Description();
        private static readonly string descikkeDokumentertForekomstNA = SpeciesAssessment2021.InitialSubClassification.IkkeDokumentertForekomstNA.Description();
        private static readonly string deschybridartUtenReproduksjonNA = SpeciesAssessment2021.InitialSubClassification.HybridartUtenReproduksjonNA.Description();
        private static readonly string descforekommerBareIHybridkombinasjonNA = SpeciesAssessment2021.InitialSubClassification.ForekommerBareIHybridkombinasjonNA.Description();
        private static readonly string deschybridartUvisstOmReproduserendeNA = SpeciesAssessment2021.InitialSubClassification.HybridartUvisstOmReproduserendeNA.Description();
        private static readonly string descFremmedArtNA = SpeciesAssessment2021.InitialSubClassification.FremmedArtNA.Description();
        
        private static string descmangelfullKunnskapNE = SpeciesAssessment2021.InitialSubClassification.MangelfullKunnskapNE.Description();
        private static string descuavklartSystematikkNE = SpeciesAssessment2021.InitialSubClassification.UavklartSystematikkNE.Description();
        private static string descuklartOmReproduserendeBestandNE = SpeciesAssessment2021.InitialSubClassification.UklartOmReproduserendeBestandNE.Description();
        private static string descartsgruppeIkkeRisikovurdertNE = SpeciesAssessment2021.InitialSubClassification.ArtsgruppeIkkeRisikovurdertNE.Description();
        private static string descannetNE = SpeciesAssessment2021.InitialSubClassification.AnnetNE.Description();

        public static void Map(Rodliste2019 src, SpeciesAssessment2021 dest)
        {
            switch (src.OverordnetKlassifiseringGruppeKode)
            {
                case "rodlisteVurdertArt":
                    dest.AssessmentInitialClassificationCode =
                        SpeciesAssessment2021.InitialClassification.RodlisteVurdertArt;
                    dest.AssessmentInitialClassification = descRedlistedSpecies;
                    RedlistedSubCategoryMap(src, dest);
                    // todo - remove not needed fields if any
                    break;
                case "sikkerBestandLC":
                    dest.AssessmentInitialClassificationCode =
                        SpeciesAssessment2021.InitialClassification.SikkerBestandLC;
                    dest.AssessmentInitialClassification = descOkPopulationLC;
                    RedlistedSubCategoryMap(src, dest);
                    break;
                case "utdoddINorgeRE":
                    dest.AssessmentInitialClassificationCode =
                        SpeciesAssessment2021.InitialClassification.UtdoddINorgeRE;
                    dest.AssessmentInitialClassification = descExtinctRE;
                    RedlistedSubCategoryMap(src, dest);
                    break;
                case "begrensetForekomstNA":
                    dest.AssessmentInitialClassificationCode =
                        SpeciesAssessment2021.InitialClassification.BegrensetForekomstNA;
                    dest.AssessmentInitialClassification = descLimitedPopulationNA;
                    BegrensetSubCategoryMap(src, dest);
                    break;
                case "fremmedArtNA":
                    dest.AssessmentInitialClassificationCode =
                        SpeciesAssessment2021.InitialClassification.FremmedArtNA;
                    dest.AssessmentInitialClassification = descAlienSpeciesNA;
                    dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.FremmedArtNA;
                    dest.AssessmentInitialSubClassification = descFremmedArtNA;
                    break;
                case "kunnskapsStatusNE":
                    dest.AssessmentInitialClassificationCode =
                        SpeciesAssessment2021.InitialClassification.KunnskapsStatusNE;
                    dest.AssessmentInitialClassification = descLimitedKnowlegdeNE;
                    KunnskapsStatusSubCategoryMap(src, dest);
                    break;
                case "storUsikkerhetOmKorrektKategoriDD":
                    dest.AssessmentInitialClassificationCode =
                        SpeciesAssessment2021.InitialClassification.StorUsikkerhetOmKorrektKategoriDD;
                    dest.AssessmentInitialClassification = descDataDeficientDD;
                    RedlistedSubCategoryMap(src, dest);
                    break;
                default:
                        throw new Exception("Ukjent overordnet klassifiseringskode");
            }

            static void RedlistedSubCategoryMap(Rodliste2019 src, SpeciesAssessment2021 dest)
            {
                switch (src.RodlisteVurdertArt)
                {
                    case "etablertBestandINorge":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.EtablertBestandINorge;
                        dest.AssessmentInitialSubClassification = descEstablishedInNorway;
                        break;
                    case "ikkeReproduserendeINorge":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.IkkeReproduserendeINorge;
                        dest.AssessmentInitialSubClassification = descNotReproducing;
                        break;
                    case "etablertFør1800":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.EtablertFør1800;
                        dest.AssessmentInitialSubClassification = descEstablishedbefore1800;
                        break;

                    default:
                        // default for de som mangler pr nå
                        //Console.WriteLine($"Art;{src.VurdertVitenskapeligNavn};{src.Ekspertgruppe};{src.OverordnetKlassifiseringGruppeKode};mangler underkategori");
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.EtablertBestandINorge;
                        dest.AssessmentInitialSubClassification = descEstablishedInNorway;
                        break;
                        //throw new Exception("Ukjent overordnet klassifiseringskode");
                }
            }

            static void BegrensetSubCategoryMap(Rodliste2019 src, SpeciesAssessment2021 dest)
            {
                switch (src.BegrensetForekomstNA)
                {
                    case "ikkeReproduserendeGjestNA":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.IkkeReproduserendeGjestNA;
                        dest.AssessmentInitialSubClassification = descikkeReproduserendeGjestNA;
                        break;
                    case "observertReproduserendeIkkeEtablertNA":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.ObservertReproduserendeIkkeEtablertNA;
                        dest.AssessmentInitialSubClassification = descobservertReproduserendeIkkeEtablertNA;
                        break;
                    case "observertReproduktivIkkeEtablertNA":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.ObservertReproduktivIkkeEtablertNA;
                        dest.AssessmentInitialSubClassification = descobservertReproduktivIkkeEtablertNA;
                        break;
                    case "uregelmessigGjestIkkeReproduserendeNA":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.UregelmessigGjestIkkeReproduserendeNA;
                        dest.AssessmentInitialSubClassification = descuregelmessigGjestIkkeReproduserendeNA;
                        break;
                    case "ikkeDokumentertForekomstNA":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.IkkeDokumentertForekomstNA;
                        dest.AssessmentInitialSubClassification = descikkeDokumentertForekomstNA;
                        break;
                    case "hybridartUtenReproduksjonNA":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.HybridartUtenReproduksjonNA;
                        dest.AssessmentInitialSubClassification = deschybridartUtenReproduksjonNA;
                        break;
                    case "hybridartUvisstOmReproduserendeNA":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.HybridartUvisstOmReproduserendeNA;
                        dest.AssessmentInitialSubClassification = deschybridartUvisstOmReproduserendeNA;
                        break;
                    case "forekommerBareIHybridkombinasjonNA":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.ForekommerBareIHybridkombinasjonNA;
                        dest.AssessmentInitialSubClassification = descforekommerBareIHybridkombinasjonNA;
                        break;

                    default:
                        // default for de som mangler pr nå
                        //Console.WriteLine($"Art;{src.VurdertVitenskapeligNavn};{src.Ekspertgruppe};{src.OverordnetKlassifiseringGruppeKode};mangler underkategori");
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.IkkeReproduserendeGjestNA;
                        dest.AssessmentInitialSubClassification = descikkeReproduserendeGjestNA;
                        break;
                        //throw new Exception("Ukjent underordnet klassifiseringskode");
                }
            }
            static void KunnskapsStatusSubCategoryMap(Rodliste2019 src, SpeciesAssessment2021 dest)
            {
                switch (src.KunnskapsStatusNE)
                {
                    case "mangelfullKunnskapNE":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.MangelfullKunnskapNE;
                        dest.AssessmentInitialSubClassification = descmangelfullKunnskapNE;
                        break;
                    case "uavklartSystematikkNE":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.UavklartSystematikkNE;
                        dest.AssessmentInitialSubClassification = descuavklartSystematikkNE;
                        break;
                    case "uklartOmReproduserendeBestandNE":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.UklartOmReproduserendeBestandNE;
                        dest.AssessmentInitialSubClassification = descuklartOmReproduserendeBestandNE;
                        break;
                    case "artsgruppeIkkeRisikovurdertNE":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.ArtsgruppeIkkeRisikovurdertNE;
                        dest.AssessmentInitialSubClassification = descartsgruppeIkkeRisikovurdertNE;
                        break;
                    case "annetNE":
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.AnnetNE;
                        dest.AssessmentInitialSubClassification = descannetNE;
                        break;
                    
                    default:
                        // default for de som mangler pr nå
                        //.WriteLine($"Art;{src.VurdertVitenskapeligNavn};{src.Ekspertgruppe};{src.OverordnetKlassifiseringGruppeKode};mangler underkategori");
                        dest.AssessmentInitialSubClassificationCode =
                            SpeciesAssessment2021.InitialSubClassification.MangelfullKunnskapNE;
                        dest.AssessmentInitialSubClassification = descmangelfullKunnskapNE;
                        break;
                        //throw new Exception("Ukjent underordnet klassifiseringskode");
                }
            }
        }
    }
}
