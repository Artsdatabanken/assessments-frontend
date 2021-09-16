using System;
using System.Collections.Generic;
using System.Linq;
using Assessments.Mapping.Models.Source.Species;
using Assessments.Mapping.Models.Species;

namespace Assessments.Mapping.Helpers
{
    internal static class SpeciesAssessment2021ProfileHelper
    {
        private static readonly Dictionary<string, string> _impactFactorsReplaceTextDictionary = new()
        {
            {
                "Skogbruk/avvirkning",
                "Skogbruk (kommersielt)"
            },
            {
                "Åpne hogstformer (flatehogst og frøtrehogst som også inkluderer uttak av rotvelt, råtne trær, tørrgran etc.)",
                "Åpne hogstformer (flatehogst og frøtrestillingshogst som også inkluderer uttak av rotvelt, råtne trær, tørrgran etc.)"
            },
            {
                "Habitatpåvirkning på ikke landbruksarealer (terrestrisk)",
                "Habitatpåvirkning - ikke jord- eller skogbruksaktivitet (terrestrisk)"
            },
            {
                "Oppdemming / vannstandsregulering / overføring av vassdrag",
                "Oppdemming/vannstandsregulering/overføring av vassdrag"
            },
            {
                "Tynning, vedhogst, avvirkning av spesielle type trær (gamle, hule, brannskade)",
                "Vedhogst, avvirkning av spesielle type trær (gamle, hule, brannskade)"
            }
        };

        private static readonly Dictionary<string, string> _impactFactorsReplaceIdDictionary = new()
        {
            {
                "10.1",
                "10."
            },
            {
                "11.1",
                "11."
            },
            {
                "12.1",
                "12."
            },
            {
                "0.1",
                "0."
            },
            {
                "0.1.",
                "0."
            }
        };

        private static readonly Dictionary<string, Tuple<string, string, string>> _impactFactorsRemapFrom2010Dictionary =
                new()
                {
                    {
                        "1.1.2.Skogbruk/avvirkning",
                        new Tuple<string, string, string>("1.1.2.1.",
                            "Skogsdrift, hogst og skjøtsel",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt)")
                    },
                    {
                        "1.1.2.1.Flatehogst",
                        new Tuple<string, string, string>("1.1.2.1.1.",
                            "Åpne hogstformer (flatehogst og frøtrehogst som også inkluderer uttak av rotvelt, råtne trær, tørrgran etc.)",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogsdrift, hogst og skjøtsel")
                    },
                    {
                        "1.1.2.2.Plukkhogst, tynning, vedhogst",
                        new Tuple<string, string, string>("1.1.2.1.2",
                            "Lukkede hogstformer (plukkhogst, skjermstilling, tynning, uttak av enkelttrær, inkludert uttak av rotvelt, råtne trær, tørrgran etc.)",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogsdrift, hogst og skjøtsel")
                    },
                    {
                        "1.1.2.3.Fjerning av dødt virke", new Tuple<string, string, string>("1.1.2.1.3.",
                            "Ungskogrydding (rydding i ungskog)",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogsdrift, hogst og skjøtsel")
                    },
                    {
                        "1.1.2.4.Avvirking av spesielle typer trær (gamle, hule, brannskade)",
                        new Tuple<string, string, string>("1.1.2.1.10.",
                            "Andre faktorer",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogsdrift, hogst og skjøtsel")
                    },
                    {
                        "1.1.2.5.Skogsbilveier",
                        new Tuple<string, string, string>("1.1.2.1.8.",
                            "Skogsbilveger og kjørespor etter skogsmaskiner (den direkte effekten av inngrepet)",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogsdrift, hogst og skjøtsel")
                    },
                    {
                        "1.1.2.6.Motorferdsel",
                        new Tuple<string, string, string>("1.1.2.1.8.",
                            "Skogsbilveger og kjørespor etter skogsmaskiner (den direkte effekten av inngrepet)",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogsdrift, hogst og skjøtsel")
                    },
                    {
                        "1.1.2.7.Andre",
                        new Tuple<string, string, string>("1.1.2.1.10.",
                            "Andre faktorer",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogsdrift, hogst og skjøtsel")
                    },
                    {
                        "1.1.3.Skogreising/treplantasjer",
                        new Tuple<string, string, string>("1.1.2.2.",
                        "Skogreising/treslagskifte",
                        "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt)")
                    },
                    {
                        "1.1.3.1.Treslagskifte",
                        new Tuple<string, string, string>("1.1.2.2.1.",
                            "Treslagsskifte (gran på Vestlandet og nord for Saltfjellet, fremmede treslag)",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogreising/treslagskifte")
                    },
                    {
                        "1.1.3.2.Skogplanting",
                        new Tuple<string, string, string>("1.1.2.2.2.",
                            "Skogreising (aktiv gjenplanting av tidligere åpen mark)",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogreising/treslagskifte")
                    },
                    {
                        "1.1.3.4.Skogbrannslukking/gjenplanting av brannflater",
                        new Tuple<string, string, string>("1.1.2.3.",
                            "Skogbrannslukking",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt)")
                    },
                    {
                        "1.1.3.5.Drenering (grøfting)",
                        new Tuple<string, string, string>("1.1.2.2.3.",
                            "Grøfting og grøfterens (f.eks. myr og sumpskog)",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogreising/treslagskifte")
                    },
                    {
                        "1.1.3.6.Andre",
                        new Tuple<string, string, string>("1.1.2.2.4.",
                            "Andre faktorer",
                            "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogreising/treslagskifte")
                    },
                    {
                        "4.2.Andre",
                        new Tuple<string, string, string>("4.",
                            "Tilfeldig mortalitet",
                            "")
                    }
                };

        private static readonly Dictionary<string, Tuple<string, string>> _impactFactorFixTextIn2010Dictionary =
            new()
            {
                {
                    "1.1.2.1.",
                    new Tuple<string, string>(
                        "Skogsdrift, hogst og skjøtsel",
                        "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt)")
                },
                {
                    "1.1.2.1.1.",
                    new Tuple<string, string>(
                        "Åpne hogstformer (flatehogst og frøtrehogst som også inkluderer uttak av rotvelt, råtne trær, tørrgran etc.)",
                        "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogsdrift, hogst og skjøtsel")
                },
                {
                    "1.1.2.1.2",
                    new Tuple<string, string>(
                        "Lukkede hogstformer (plukkhogst, skjermstilling, tynning, uttak av enkelttrær, inkludert uttak av rotvelt, råtne trær, tørrgran etc.)",
                        "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogsdrift, hogst og skjøtsel")
                },
                {
                    "1.1.2.1.3.", new Tuple<string, string>(
                        "Ungskogrydding (rydding i ungskog)",
                        "Påvirkning på habitat > Landbruk > Skogbruk (kommersielt) > Skogsdrift, hogst og skjøtsel")
                },
                {
                    "1.2.4.1.", new Tuple<string, string>(
                        "Uttak av død ved (stående *gadd* og liggende *læger*)",
                        "Påvirkning på habitat > Habitatpåvirkning - ikke jord- eller skogbruksaktivitet (terrestrisk) > Annen påvirkning på habitat")
                },
                {
                    "4.",
                    new Tuple<string, string>(
                        "Tilfeldig mortalitet",
                        "")
                }
            };

        private static readonly string _uttakAvDødVedStåendeGaddOgLiggendeLæger =
            "Uttak av død ved (stående gadd og liggende læger)";

        internal static string ResolveRegion(string fylke)
        {
            return fylke.ToLowerInvariant() switch
            {
                "aa" => "Aust-Agder",
                "bn" => "Polhavet",
                "bs" => "Barentshavet",
                "bu" => "Buskerud",
                "fi" => "Finnmark",
                "gh" => "Grønlandshavet",
                "he" => "Hedmark",
                "ho" => "Hordaland",
                "jm" => "Jan Mayen",
                "mr" => "Møre og Romsdal",
                "nh" => "Norskehavet",
                "no" => "Nordland",
                "ns" => "Nordsjøen",
                "op" => "Oppland",
                "osa" => "Oslo og Akershus",
                "ro" => "Rogaland",
                "sf" => "Sogn og Fjordane",
                "te" => "Telemark",
                "tr" => "Troms",
                "tø" => "Trøndelag",
                "va" => "Vest-Agder",
                "ve" => "Vestfold",
                "øs" => "Østfold",
                _ => string.Empty
            };
        }

        internal static string ResolveSpeciesGroupName(Rodliste2019 rl2021)
        {
            // https://github.com/Artsdatabanken/Rodliste2019/blob/4918668043d7d5b2e5978e29e5028bc68fd1a643/Prod.LoadingCSharp/TransformRodliste2019toDatabankRL2021.cs#L510

            if (rl2021.Ekspertgruppe == "Nebbfluer, kamelhalsfluer, mudderfluer, nettvinger")
            {
                if (rl2021.VurdertVitenskapeligNavnHierarki.Contains("/Mecoptera"))
                    rl2021.Ekspertgruppe = "Nebbfluer";
                else if (rl2021.VurdertVitenskapeligNavnHierarki.Contains("/Raphidioptera"))
                    rl2021.Ekspertgruppe = "Kamelhalsfluer";
                else if (rl2021.VurdertVitenskapeligNavnHierarki.Contains("/Megaloptera"))
                    rl2021.Ekspertgruppe = "Mudderfluer";
                else if (rl2021.VurdertVitenskapeligNavnHierarki.Contains("/Neuroptera"))
                    rl2021.Ekspertgruppe = "Nettvinger";
            }

            if (rl2021.Ekspertgruppe == "Døgnfluer, øyenstikkere, steinfluer, vårfluer")
            {
                if (rl2021.VurdertVitenskapeligNavnHierarki.Contains("/Ephemeroptera"))
                    rl2021.Ekspertgruppe = "Døgnfluer";
                else if (rl2021.VurdertVitenskapeligNavnHierarki.Contains("/Odonata"))
                    rl2021.Ekspertgruppe = "Øyenstikkere";
                else if (rl2021.VurdertVitenskapeligNavnHierarki.Contains("/Plecoptera"))
                    rl2021.Ekspertgruppe = "Steinfluer";
                else if (rl2021.VurdertVitenskapeligNavnHierarki.Contains("/Trichoptera"))
                    rl2021.Ekspertgruppe = "Vårfluer";
            }

            if (rl2021.Ekspertgruppe == "Rettvinger, kakerlakker, saksedyr")
            {
                if (rl2021.VurdertVitenskapeligNavnHierarki.Contains("/Orthoptera"))
                    rl2021.Ekspertgruppe = "Rettvinger";
                else if (rl2021.VurdertVitenskapeligNavnHierarki.Contains("/Blattodea"))
                    rl2021.Ekspertgruppe = "Kakerlakker";
                else if (rl2021.VurdertVitenskapeligNavnHierarki.Contains("/Dermaptera"))
                    rl2021.Ekspertgruppe = "Saksedyr";
            }

            var speciesGroupName = RemoveAssessmentArea(rl2021.Ekspertgruppe).Trim();

            return speciesGroupName;
        }

        internal static string RemoveAssessmentArea(string src)
        {
            return src
                .Replace("(Svalbard)", string.Empty, StringComparison.InvariantCultureIgnoreCase)
                .Replace("(Norge)", string.Empty, StringComparison.InvariantCultureIgnoreCase).Trim();
        }

        /// <summary>
        /// Mapper om bl.a. 2010 id'er og beskrivelser over til 2015 versjonen av påvirkningsfaktorer - samt fixer eldre tekster som er blitt endret
        /// </summary>
        public static void CorrectImpactFactors(Rodliste2019.Pavirkningsfaktor src,
            SpeciesAssessment2021ImpactFactor dest)
        {
            var pOverordnetTittel = src.OverordnetTittel;
            var pBeskrivelse = src.Beskrivelse;
            var pId = src.Id;

            // map old 2010 factors to correct id and text
            foreach (var item in _impactFactorsRemapFrom2010Dictionary.Where(item =>
                item.Key == pId.Trim() + pBeskrivelse.Trim()))
            {
                //Console.WriteLine(assessment.VurdertVitenskapeligNavn);
                pBeskrivelse = item.Value.Item2;
                pId = item.Value.Item1;
                pOverordnetTittel = item.Value.Item3;
            }

            // fix som old texts 
            foreach (var item in _impactFactorFixTextIn2010Dictionary.Where(item => item.Key == pId.Trim()))
            {
                //Console.WriteLine(assessment.VurdertVitenskapeligNavn);
                if (pBeskrivelse != item.Value.Item1) pBeskrivelse = item.Value.Item1;

                //pId = item.Value.Item1;
                if (pOverordnetTittel == item.Value.Item2) pOverordnetTittel = item.Value.Item2;
            }

            foreach (var item in _impactFactorsReplaceTextDictionary.Where(item =>
                pOverordnetTittel.IndexOf(item.Key, StringComparison.InvariantCulture) > -1))
                pOverordnetTittel = pOverordnetTittel.Replace(item.Key, item.Value, StringComparison.InvariantCulture);

            foreach (var item in _impactFactorsReplaceTextDictionary.Where(item =>
                pBeskrivelse.IndexOf(item.Key, StringComparison.InvariantCulture) > -1))
                pBeskrivelse = pBeskrivelse.Replace(item.Key, item.Value, StringComparison.InvariantCulture);

            foreach (var item in _impactFactorsReplaceIdDictionary.Where(item => pId == item.Key)) pId = item.Value;

            var level = dest.Id.Split(".", StringSplitOptions.RemoveEmptyEntries).Length;

            if (pId == "1.1.2.1.4." || pId == "1.2.4.1.")
                // fjern alternativ med * og " brukt i disse
                pBeskrivelse = _uttakAvDødVedStåendeGaddOgLiggendeLæger;

            // todo: kanskje bruke denne.... inneholder sti, men Factorpath er hele stien...
            //var under = level > 1
            //    ? string.Join(" > ", pOverordnetTittel.Split(" > ").Skip(1)) + " - " + pBeskrivelse
            //    : pBeskrivelse;

            dest.Id = pId;
            dest.Factor = pBeskrivelse;
            dest.FactorPath =
                pOverordnetTittel.Split(" > ").Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToArray(); //.Union(new[] { pBeskrivelse }).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            dest.GroupingFactor = pOverordnetTittel == "" ? pBeskrivelse : pOverordnetTittel.Split(" > ")[0];
        }

        private static string[] _CategoriesToBlank = new[] { "LC", "NA", "NE" };
        public static void BlankCriteriaSumarizedBasedOnCategory(SpeciesAssessment2021 dest)
        {
            foreach (var s in _CategoriesToBlank)
            {
                if (dest.Category.StartsWith(s) && !string.IsNullOrWhiteSpace(dest.CriteriaSummarized))
                {
                    dest.CriteriaSummarized = string.Empty;
                }

            }
        }
    }
}