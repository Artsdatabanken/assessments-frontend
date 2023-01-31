using Assessments.Mapping.AlienSpecies.Model.Enums;
using System.Collections.Generic;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class Constants
    {
        public const string CacheFolder = "Cache";

        public const string AssessmentsMappingAssembly = "Assessments.Mapping";

        public static readonly Dictionary<string, string> AllAreas = new()
        {
            {"Norge", "N"},
            {"Svalbard", "S"}
        };

        public static readonly Dictionary<string, string> AllCriterias = new()
        {
            {"A", "populasjonsreduksjon"},
            {"B", "lite areal"},
            {"C", "liten populasjon"},
            {"D", "svært liten populasjon eller forekomst"}
        };

        public const string RiskMatrix = "RiskMatrix";
        public const string Conclusion = "Conclusion";
        public const string TableOfContents = "TableOfContents";
        public const string ExpertSummary = "ExpertSummary";
        public const string AssesmentReasoning = "AssesmentReasoning";
        public const string RiskCategoryExplanation = "RiskCategoryExplanation";
        public const string CategoryChange = "CategoryChange";
        public const string ClimateEffectsInvationpotential = "ClimateEffectsInvationpotential";
        public const string GeographicVariationInCategory = "GeographicVariationInCategory";
        public const string RegionalSpread = "RegionalSpread";
        public const string Attachments = "Attachments";
        public const string ImpactedNatureTypes = "ImpactedNatureTypes";
        public const string References = "References";

        public class HeadingsNo
        {
            public static readonly string Citation = "Sitering";
            public static readonly string RiskMatrix = "Risikomatrisen";
            public static readonly string Conclusion = "Konklusjon";
            public static readonly string TableOfContents = "Innhold";
            public static readonly string ExpertSummary = "Ekspertenes oppsummering";
            public static readonly string AssesmentReasoning = "Begrunnelse";
            public static readonly string RiskCategoryExplanation = "Hva forklarer artens risikokategori";
            public static readonly string CategoryChange = "Endring av risikokategori fra 2018";
            public static readonly string ClimateEffectsInvationpotential = "Effekt av klimaendringer";
            public static readonly string GeographicVariationInCategory = "Geografisk variasjon i risiko";
            public static readonly string RegionalSpread = "Utbredelse";
            public static readonly string Attachments = "Filvedlegg";
            public static readonly string ImpactedNatureTypes = "Naturtypetilhørighet";
            public static readonly string References = "Referanser";
        }

        public class HeadingsIds
        {
            public static readonly string Citation = "Citation";
            public static readonly string RiskMatrix = "RiskMatrix";
            public static readonly string Conclusion = "Conclusion";
            public static readonly string TableOfContents = "TableOfContents";
            public static readonly string ExpertSummary = "ExpertSummary";
            public static readonly string AssesmentReasoning = "AssesmentReasoning";
            public static readonly string RiskCategoryExplanation = "RiskCategoryExplanation";
            public static readonly string CategoryChange = "CategoryChange";
            public static readonly string ClimateEffectsInvationpotential = "ClimateEffectsInvationpotential";
            public static readonly string GeographicVariationInCategory = "GeographicVariationInCategory";
            public static readonly string RegionalSpread = "RegionalSpread";
            public static readonly string Attachments = "Attachments";
            public static readonly string ImpactedNatureTypes = "ImpactedNatureTypes";
            public static readonly string References = "References";
        }


        public const string CriteriaDocumentationSpeciesStatus = "CriteriaDocumentationSpeciesStatus";
        public const string UncertaintyStatusDescription = "UncertaintyStatusDescription";
        public const string CriteriaDocumentationDomesticSpread = "CriteriaDocumentationDomesticSpread";
        public const string SpreadWays = "SpreadWays";
        public const string CriteriaDocumentationInvasionPotential = "CriteriaDocumentationInvasionPotential";
        public const string CriteriaDocumentationEcoEffect = "CriteriaDocumentationEcoEffect";

        public static readonly Dictionary<string, string> ExpertStatementSubHeadingsNO = new()
        {
            {CriteriaDocumentationSpeciesStatus, "Generelt om "},
            {UncertaintyStatusDescription, "Usikkerhet rundt etableringsklasse"},
            {CriteriaDocumentationDomesticSpread, "Utbredelse "},
            {SpreadWays, "Spredningsmåter"},
            {CriteriaDocumentationInvasionPotential, "Invasjonspotensial"},
            {CriteriaDocumentationEcoEffect, "Økologisk effekt"},
        };

        public static readonly Dictionary<string, Dictionary<string, string>> SubHeadingsNO = new()
        {
            {ExpertSummary, ExpertStatementSubHeadingsNO},
        };

        public static bool ShowHeading(string value, AlienSpeciesAssessment2023Category category)
        {
            if (value == ImpactedNatureTypes || value == GeographicVariationInCategory)
            {
                return category != AlienSpeciesAssessment2023Category.NR;
            }
            return false;
        }

        public static readonly Dictionary<string, string> AllEuropeanPopulationPercentages = new()
        {
            {Constants.EuropeanPopulationPercentages.EuropeanPopLt5, "< 5 %"},
            {Constants.EuropeanPopulationPercentages.EuropeanPopRange5To25, "5 - 25 %"},
            {Constants.EuropeanPopulationPercentages.EuropeanPopRange25To50, "25 - 50 %"},
            {Constants.EuropeanPopulationPercentages.EuropeanPopGt50, "> 50 %"}
        };

        public static readonly string[] AllInsects = new string[]
        {
            "Biller",
            "Døgnfluer",
            "Kakerlakker",
            "Kamelhalsfluer",
            "Mudderfluer",
            "Nebbfluer",
            "Nebbmunner",
            "Nettvinger",
            "Rettvinger",
            "Saksedyr",
            "Sommerfugler",
            "Steinfluer",
            "Tovinger",
            "Vepser",
            "Vårfluer",
            "Øyenstikkere"
        };

        public class EuropeanPopulationPercentages
        {
            public const string EuropeanPopLt5 = "Lt5";
            public const string EuropeanPopRange5To25 = "Fr5To25";
            public const string EuropeanPopRange25To50 = "Fr25To50";
            public const string EuropeanPopGt50 = "Gt50";
            public const string Lt1 = "< 1 %";
            public const string Lt5 = "< 5 %";
            public const string Gt50 = "> 50 %";
            public const string Range1To5 = "1 - 5 %";
            public const string Range5To25 = "5 - 25 %";
            public const string Range25To50 = "25 - 50 %";
        }

        public class SpeciesCategories
        {
            public class Extinct
            {
                public const string Nb = "Regionalt utdødd";
                public const string ShortHand = "RE";
            }

            public class CriticallyEndangered
            {
                public const string Nb = "Kritisk truet";
                public const string ShortHand = "CR";
            }

            public class Endangered
            {
                public const string Nb = "Sterkt truet";
                public const string ShortHand = "EN";
            }

            public class Vulnerable
            {
                public const string Nb = "Sårbar";
                public const string ShortHand = "VU";
            }

            public class NearThreatened
            {
                public const string Nb = "Nær truet";
                public const string ShortHand = "NT";
            }

            public class DataDeficient
            {
                public const string Nb = "Datamangel";
                public const string ShortHand = "DD";
            }

            public class Viable
            {
                public const string Nb = "Livskraftig";
                public const string ShortHand = "LC";
            }

            public class NotAppropriate
            {
                public const string Nb = "Ikke egnet";
                public const string ShortHand = "NA";
            }

            public class NotEvalueted
            {
                public const string Nb = "Ikke vurdert";
                public const string ShortHand = "NE";
            }
        }

        public class SearchAndFilter
        {
            public const string ChooseEndangered = "Marker alle truede arter";
            public const string ChooseRedlisted = "Marker alle rødlistearter";
            public const string ProductionSpecies = "Bruksart";
            public const string RemoveFilters = "remove_filters";
            public const string RemoveSearch = "remove_search";
            public const string ResetAllFilters = "Nullstill";
            public const string SearchChangedCategory = "Vis arter med endret kategori fra 2015";
            public const string SearchChooseArea = "Vurderingsområde";
            public const string SearchChooseCategory = "Kategori";
            public const string SearchChooseCriteria = "Kriterier";
            public const string SearchChooseSpeciesGroup = "Artsgruppe";
            public const string SearchFilterSpecies = "Søk art/slekt";
            public const string SearchFilterTaxonRank = "Taksonomisk nivå";
        }

        public static class TaxonCategoriesEn
        {
            public static readonly int Unknown = 0;
            public static readonly int Kingdom = 1;
            public static readonly int SubKingdom = 2;
            public static readonly int Phylum = 3;
            public static readonly int SubPhylum = 4;
            public static readonly int SuperClass = 5;
            public static readonly int Class = 6;
            public static readonly int SubClass = 7;
            public static readonly int InfraClass = 8;
            public static readonly int Cohort = 9;
            public static readonly int SuperOrder = 10;
            public static readonly int Order = 11;
            public static readonly int SubOrder = 12;
            public static readonly int InfraOrder = 13;
            public static readonly int SuperFamily = 14;
            public static readonly int Family = 15;
            public static readonly int SubFamily = 16;
            public static readonly int Tribe = 17;
            public static readonly int SubTribe = 18;
            public static readonly int Genus = 19;
            public static readonly int SubGenus = 20;
            public static readonly int Section = 21;
            public static readonly int Species = 22;
            public static readonly int SubSpecies = 23;
            public static readonly int Variety = 24;
            public static readonly int Form = 25;
        };

        public static readonly Dictionary<string, string> TaxonCategoriesNbToEn = new()
        {
            { "Unknown", "Unknown" },
            { "Rike", "Kingdom" },
            { "SubKingdom", "SubKingdom" },
            { "Rekke", "Phylum" },
            { "Underrekke", "SubPhylum" },
            { "SuperClass", "SuperClass" },
            { "Klasse", "Class" },
            { "SubClass", "SubClass" },
            { "InfraClass", "InfraClass" },
            { "Cohort", "Cohort" },
            { "SuperOrder", "SuperOrder" },
            { "Orden", "Order" },
            { "SubOrder", "SubOrder" },
            { "InfraOrder", "InfraOrder" },
            { "SuperFamily", "SuperFamily" },
            { "Familie", "Family" },
            { "SubFamily", "SubFamily" },
            { "Tribe", "Tribe" },
            { "SubTribe", "SubTribe" },
            { "Slekt", "Genus" },
            { "SubGenus", "SubGenus" },
            { "Section", "Section" },
            { "Art", "Species" },
            { "Underart", "SubSpecies" },
            { "Varietet", "Variety" },
            { "Form", "Form" }
        };


        public const string Artsdatabanken = "Artsdatabanken";

        // Redlist species constants

        public const string RedlistSpecies2021FirstPublished = "24.11.2021";

        public const int RedlistSpecies2021PageMenuContentId = 314303;

        public const string RedlistSpecies2021PageMenuHeaderText = "Rødlista for arter 2021";

        public const string RedlistSpecies2021HeaderText = "Norsk rødliste for arter 2021";

        public const string RedlistSpecies2021HeaderByline = "Publisert: 24. november 2021";

        public const string RedlistSpecies2021PageManuExpandButtonText = "Om Rødlista";

        public const string RedlistSpecies2021CitationString = "Artsdatabanken (2021, 24. november). Norsk rødliste for arter 2021.";

        public const string RedlistSpecies2021Introduction = "Norsk rødliste for arter 2021 er en oversikt over arter som har risiko for å dø ut fra Norge." +
            " Rødlista er utarbeidet av Artsdatabanken i samarbeid med fageksperter.";

        // Alien species constants

        public const string AlienSpecies2023PageMenuAssessmentAreaText = "områder der arten er regionalt fremmed i Norge (uten Svalbard)";

        public const string AlienSpecies2023FirstPublished = "18.08.2023"; // TODO: Need publishing date

        public const int AlienSpecies2023PageMenuContentId = 239646;

        public const string AlienSpecies2023PageMenuHeaderText = "Fremmedartslista 2023";

        public const string AlienSpecies2023PageMenuHeaderTextShort = "Fremmedartslista";

        public const string AlienSpecies2023HeaderText = "Norsk fremmedartsliste for 2023";

        public const string AlienSpecies2023HeaderByline = "Publisert: 24. november 2023"; // TODO: change to correct publishing date

        public const string AlienSpecies2023PageManuExpandButtonText = "Om Fremmedartslista";

        public const string AlienSpecies2023CitationHeading = "Siden siteres som:";

        public const string AlienSpecies2023CitationString = "Artsdatabanken (2023, 24. november). Norsk fremmedartsliste 2023."; // TODO: insert correct publishing date for citation

        public const string AlienSpecies2023Introduction = "Fremmedartslista viser hvilken økologisk risiko fremmede arter kan utgjøre for naturmangfoldet i Norge." +
            " Den er utarbeidet av Artsdatabanken i samarbeid med fageksperter.";

        public const string AlienSpecies2023NoListViewResults = "Kombinasjonen av søk og filter gir ingen treff i Fremmedartslista for 2023.";

        public const string AlienSpecies2023KnownOccurrence = "Kjent utbredelse i dag";

        public const string AlienSpecies2023AssumedOccurrence = "Antatt utbredelse i dag";

        public const string AlienSpecies2023AssumedInFutureOccurrence = "Antatt utbredelse om 50 år";

        public const string ClimateEffectExplanationEnding = "vært lavere i fravær av pågående eller fremtidige klimaendringer.";
        public const string ClimateEffectExplanationInvationPotential = "Delkategori for invasjonspotensial ville ";
        public const string ClimateEffectExplanationEcoEffect = "Delkategori for økologisk effekt ville ";
        public const string ClimateEffectExplanationNeither = "Hverken delkategori for økologisk effekt eller invasjonspotensial ville ";
        public const string ClimateEffectExplanationBoth = " Både delkategori for økologisk effekt og invasjonspotensial ville ";


        public const string HasGeographicVariationDocumentation = "Nærmere beskrivelse av artens geografiske variasjon i risiko: ";
        public const string NoLowerCategoryThan = "Arten kunne ikke ha fått lavere risikokategori enn ";
        public const string LowerCategoryThan = "Arten kunne ha fått lavere risikokategori enn ";
        public const string LowerCategoryThanEnding = "i deler av sitt potensielle forekomstareal.";

        public const string ImpactedNatureTypesDescription = "Naturtyper arten er observert i og/eller som er potensielle habitater for arten i Norge. Hvis arten fører til endringer i naturtypen er det angitt.";
        public const string ImpactedNatureTypesDescriptionSvalbard = "Naturtyper arten er observert i og/eller som er potensielle habitater for arten på Svalbard. Hvis arten fører til endringer i naturtypen er det angitt.";
        public const string ImpactedNatureTypesTableTitle = "Valgte truede, sjeldne og øvrige naturtyper ";
        public const string ImpactedNatureTypesTableDescription = "Oversikten viser anslått kolonisert areal (C-kriteriet) i de naturtypene arten er  observert i eller regnes med å observeres i innen 50 år eller 5 generasjoner (det av tallene som er størst), samt artens(eventuelt framtidige) påvirkning i naturtypen og anslått andel av naturtypens areal som blir eller vil bli påvirket (F- og G-kriteriet).";
        public const string ImpactedNatureTypesTableColumn1 = "naturtype";
        public const string ImpactedNatureTypesTableColumn2 = "tidshorisont";
        public const string ImpactedNatureTypesTableColumn3 = "kolonisert <br/>areal (%)";
        public const string ImpactedNatureTypesTableColumn4 = "tydelig <br/>tilstandsendring";
        public const string ImpactedNatureTypesTableColumn5 = "tydelig <br/>påvirka <br/>areal (%)";
        public const string ImpactedNatureTypesTableColumn6 = "vurderingsgrunnlag";

        public const string CategoryChangeNotAssessed2018 = "Denne arten er risikovurdert for første gang i 2023.";
        public const string CategoryChangeShowSameAs2018 = "Denne arten er vurdert til samme risikokategori som i Fremmedartslista 2018 (forrige revisjon).";
        public const string CategoryChangeReasonsForChangeDescription = "Utfyllende beskrivelse av årsaken(e) for endret risikokategori:";

    }
}
