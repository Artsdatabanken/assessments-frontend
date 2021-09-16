using System;
using System.Collections.Generic;
using System.Globalization;
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
                    //{
                    //    "1.2.4.1.Fjerning av dødt virke", new Tuple<string, string, string>("1.1.2.1.4.",
                    //    "Uttak av død ved (stående *gadd* og liggende *læger*)",
                    //    "Påvirkning på habitat > Habitatpåvirkning - ikke jord- eller skogbruksaktivitet (terrestrisk) > Annen påvirkning på habitat")
                    //},
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
                "bn" => "Barentshavet nord og Polhavet",
                "bs" => "Barentshavet sør",
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
        public static int GetAssessmentYear(string ekspertgruppenavn)
        {
            if (ekspertgruppenavn == "Spretthaler"
                || ekspertgruppenavn == "Spretthaler (Svalbard)")
            {
                return 2010;
            }
            else
            {
                return 2021;
            }

        }
        private static string[] _romanNumbers = new[] { "i", "ii", "iii", "iv", "v", "vi", "vii", "viii", "ix", "x" };
        public static int RomanNumberSort(string roman)
        {
            // for this purpose this is enough
            var result = Array.IndexOf<string>(_romanNumbers, roman);
            return result;
        }

        private static void SetQuantile(SpeciesAssessment2021MinMaxProbable minmaxprobable, double quantileValue)
        {
            var q = GetQuantile(minmaxprobable, quantileValue);
            //minmaxprobable.Calculated = q == null ? "" : (Math.Round((double)q)).ToString("#,0.##");
            minmaxprobable.Calculated = q == null ? "" : q.ToString();
        }

        private static void SetQuantile(SpeciesAssessment2021MinMaxProbableIntervall minmaxprobable, double quantileValue)
        {
            var q = GetQuantile(minmaxprobable, quantileValue);
            //minmaxprobable.Calculated = q == null ? "" : (Math.Round((double)q)).ToString("#,0.##");
            minmaxprobable.Calculated = q == null ? "" : q.ToString();
        }

        private static int? GetQuantile(SpeciesAssessment2021MinMaxProbableIntervall minmaxprobable, double quantileValue)
        {
            if (minmaxprobable == null)
            {
                throw new Exception("missing minmaxprobable");
            }

            var min = parseNullableInt(minmaxprobable.Min);
            var minintervall = parseNullableInt(minmaxprobable.Minintervall);
            int? max = parseNullableInt(minmaxprobable.Max);
            int? maxintervall = parseNullableInt(minmaxprobable.Maxintervall);
            int? probable = parseNullableInt(minmaxprobable.Probable);
            bool punktestimat = minmaxprobable.Punktestimat == "true";

            //double? test = 
            //    min == null && max == null
            //    ? minintervall == null
            //        ? maxintervall
            //        : maxintervall == null
            //        ? minintervall
            //        : minintervall < maxintervall
            //        ? MyQuantile(quantileValue, minintervall, maxintervall)
            //        : (double?)null
            //    : (double?)null;

            double? q =
                punktestimat
                ? min == null && max == null
                    ? probable
                    : min == null && probable == null
                    ? max
                    : max == null && probable == null
                    ? min
                    : probable == null && min <= max
                    ? MyQuantile(quantileValue, min, max)
                    : min == null && probable <= max
                    ? MyQuantile(quantileValue, max, probable)
                    : max == null && min <= probable
                    ? MyQuantile(quantileValue, min, probable)
                    : min != null && max != null && probable != null && min < max && probable > min && probable < max
                    ? MyQuantile(quantileValue, min, probable, max)
                    : (double?)null

                // intervall (ikke punktestimat)
                : min == null && max == null
                ? minintervall == null
                    ? maxintervall
                    : maxintervall == null
                    ? minintervall
                    : minintervall < maxintervall
                    ? MyQuantile(quantileValue, minintervall, maxintervall)
                    : (double?)null

                : minintervall == null && maxintervall == null
                ? min == null
                    ? max
                    : max == null
                    ? min
                    : min < max
                    ? MyQuantile(quantileValue, min, max)
                    : (double?)null
                : minintervall == null
                ? min < maxintervall //(min < max)&& (maxintervall < max) && (min < maxintervall)
                    ? MyQuantile(quantileValue, min, maxintervall)
                    : (double?)null
                : maxintervall == null
                ? min < minintervall //(min < max) && (maxintervall < max) && (min < maxintervall)
                    ? MyQuantile(quantileValue, min, minintervall, max)
                    : (double?)null
                : min < max && maxintervall < max && min < minintervall && minintervall < maxintervall
                    ? MyQuantile(quantileValue, min, minintervall, maxintervall, max)
                    : (double?)null;

            //if (q != null)
            //{
            //    double a = (double)q * 100d;
            //    double b = Math.Round(a);
            //    double c = b / 100d;
            //    q = c;
            //    //Console.WriteLine("q " + q);
            //}
            int? result = q == null ? (int?)null : (int)(q + 0.500000001d);
            return result;
        }

        private static int? GetQuantile(SpeciesAssessment2021MinMaxProbable minmaxprobable, double quantileValue)
        {
            if (minmaxprobable == null)
            {
                throw new Exception("missing minmaxprobable");
            }
            var min = parseNullableInt(minmaxprobable.Min);
            int? max = parseNullableInt(minmaxprobable.Max);
            int? probable = parseNullableInt(minmaxprobable.Probable);
            double? q =
                min == null && max == null
                    ? probable
                    : min == null && probable == null
                        ? max
                        : max == null && probable == null
                            ? min
                            : probable == null && min <= max
                                ? MyQuantile(quantileValue, min, max)
                                : min == null && probable <= max
                                    ? MyQuantile(quantileValue, max, probable)
                                    : max == null && min <= probable
                                        ? MyQuantile(quantileValue, min, probable)
                                        : min != null && max != null && probable != null && min < max && probable > min && probable < max
                                            ? MyQuantile(quantileValue, min, probable, max)
                                            : (double?)null;
            //if (q != null)
            //{
            //    double a = (double)q * 100d;
            //    double b = Math.Round(a);
            //    double c = b / 100d;
            //    q = c;
            //    //Console.WriteLine("q " + q);
            //}
            int? result = q == null ? (int?)null : (int)(q + 0.500000001d);
            return result;
        }

        private static int? parseNullableInt(string s)
        {
            return string.IsNullOrWhiteSpace(s) ? (int?)null : Convert.ToInt32(double.Parse(s.Replace(" ", "", StringComparison.InvariantCultureIgnoreCase).Replace(",", ".", StringComparison.InvariantCultureIgnoreCase).Trim(), NumberStyles.Float, CultureInfo.InvariantCulture)); // balla mye søppel i fritekst tall gitt
        }

        private static double MyQuantile(double percentile, int? int1, int? int2)
        {
            if (int1 == null || int2 == null)
            {
                throw new ArgumentException("MyQuantile");
            }
            var arr = new double[] { (double)int1, (double)int2 };
            var result = Percentile(arr, percentile);
            return result;
        }

        private static double Percentile(double[] sequence, double percentile)
        {
            Array.Sort(sequence);
            int N = sequence.Length;
            double n = (N - 1) * percentile + 1;
            if (n == 1d)
            {
                return sequence[0];
            }
            else if (n == N)
            {
                return sequence[N - 1];
            }
            else
            {
                int k = (int)n;
                double d = n - k;
                return sequence[k - 1] + d * (sequence[k] - sequence[k - 1]);
            }
        }

        private static double MyQuantile(double percentile, int? int1, int? int2, int? int3)
        {
            if (int1 == null || int2 == null || int3 == null)
            {
                throw new ArgumentException("MyQuantile");
            }
            var arr = new double[] { (double)int1, (double)int2, (double)int3 };
            var result = Percentile(arr, percentile);
            return result;
        }

        private static double MyQuantile(double percentile, int? int1, int? int2, int? int3, int? int4)
        {
            if (int1 == null || int2 == null || int3 == null || int4 == null)
            {
                throw new ArgumentException("MyQuantile");
            }
            var arr = new double[] { (double)int1, (double)int2, (double)int3, (double)int4 };
            var result = Percentile(arr, percentile);
            return result;
        }

        public static void CalculateQuantiles(SpeciesAssessment2021 dest)
        {
            SetQuantile(dest.A1.QuantifiedReduction, 0.7);
            SetQuantile(dest.A2.QuantifiedReduction, 0.7);
            SetQuantile(dest.A3.QuantifiedReduction, 0.7);
            SetQuantile(dest.A4.QuantifiedReduction, 0.7);

            SetQuantile(dest.B1.Statistics, 0.3); //.B1IntervallUtbredelsesområde
            SetQuantile(dest.B2.Statistics , 0.3); // rl2021.B2IntervallForekomstareal

            // I henhold til IUCNs retningslinjer skal EOO (utbredelsesområdet) settes likt AOO (forekomstareal) når AOO>EOO.
            if (GetQuantile(dest.B1.Statistics, 0.3) < GetQuantile(dest.B2.Statistics, 0.3))
            {
                dest.B1.Statistics.Calculated = dest.B2.Statistics.Calculated;
            }



            SetQuantile(dest.BAii.Statistics , 0.3); // rl2021.BaIntervallAntallLokaliteter

            SetQuantile(dest.C.Statistics, 0.3); //  rl2021.CPopulasjonsstørrelseAntatt

            SetQuantile(dest.C1.Statistics, 0.7); // rl2021.C1PågåendePopulasjonsreduksjonAntatt
            SetQuantile(dest.C2Ai.Statistics, 0.3); //  rl2021.C2A1PågåendePopulasjonsreduksjonAntatt
        }
    }
}