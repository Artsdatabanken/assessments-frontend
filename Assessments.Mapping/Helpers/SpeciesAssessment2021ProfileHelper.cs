using System;
using Assessments.Mapping.Models.Source.Species;

namespace Assessments.Mapping.Helpers
{
    internal static class SpeciesAssessment2021ProfileHelper
    {
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
    }
}
