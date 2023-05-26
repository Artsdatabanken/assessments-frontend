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

        public class HeadingsNo
        {
            public static class SubHeadings
            {
                public static readonly string CriteriaDocumentationSpeciesStatus = "Generelt om ";
                public static readonly string UncertaintyStatusDescription = "Usikkerhet rundt etableringsklasse";
                public static readonly string CriteriaDocumentationDomesticSpread = "Utbredelse";
                public static readonly string SpreadWays = "Spredningsmåter";
                public static readonly string CriteriaDocumentationInvasionPotential = "Invasjonspotensial";
                public static readonly string CriteriaDocumentationEcoEffect = "Økologisk effekt";
                public static readonly string RiskCategoryExplanationInvasionPotential = "Invasjonspotensial";
                public static readonly string RiskCategoryExplanationEcoEffect = "Økologisk effekt";
                public static readonly string RegionalSpreadArea = "Forekomstareal";
                public static readonly string RegionalSpreadObservations = "Fylkesforekomster";
            }

            public static readonly string Citation = "Sitering";
            public static readonly string RiskMatrix = "Risikomatrisen";
            public static readonly string Conclusion = "Konklusjon";
            public static readonly string TableOfContents = "Innhold på siden";
            public static readonly string ExpertSummary = "Ekspertenes oppsummering";
            public static readonly string AssesmentReasoning = "Begrunnelse";
            public static readonly string RiskCategoryExplanation = "Hva forklarer artens risikokategori";
            public static readonly string CategoryChange = "Endring av risikokategori fra 2018";
            public static readonly string ClimateEffectsInvationpotential = "Effekt av klimaendringer";
            public static readonly string GeographicVariationInCategory = "Geografisk variasjon i risiko";
            public static readonly string RegionalSpread = "Utbredelse";
            public static readonly string Attachments = "Filvedlegg";
            public static readonly string ImpactedNatureTypes = "Naturtypetilhørighet";
            public static readonly string SpreadWays = "Spredningsmåter";
            public static readonly string KnowMore = "Vil du vite mer om";
            public static readonly string References = "Referanser";
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

        public const string xAxisLabel = "Invasjonspotensial";
        public const string yAxisLabel = "Økologisk effekt";

        public static readonly Dictionary<string, string> categoryFromMatrix = new()
        {
            { "14", "ph" },
            { "24", "hi" },
            { "34", "se" },
            { "44", "se" },
            { "13", "lo" },
            { "23", "hi" },
            { "33", "hi" },
            { "43", "se" },
            { "12", "lo" },
            { "22", "lo" },
            { "32", "lo" },
            { "42", "hi" },
            { "11", "nk" },
            { "21", "lo" },
            { "31", "lo" },
            { "41", "ph" },
        };

        public static readonly Dictionary<string, string> categoryStringFromCode = new()
        {
            { "nr", "Ikke risikovurdert" },
            { "nk", "Ingen kjent risiko" },
            { "lo", "Lav risiko" },
            { "ph", "Potensielt høy risiko" },
            { "hi", "Høy risiko" },
            { "se", "Svært høy risiko" },
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

        public const int AlienSpecies2023PageMenuContentId = 239657; //239645; //239644; //239646;

        public const string AlienSpecies2023PageMenuHeaderText = "Fremmedartslista 2023";

        public const string AlienSpecies2023PageMenuHeaderTextShort = "Fremmedartslista";

        public const string AlienSpecies2023HeaderText = "Fremmedartslista 2023";

        public const string AlienSpecies2023HeaderByline = "Publisert: 22. februar 2023"; // TODO: change to correct publishing date when we know

        public const string AlienSpecies2023PageManuExpandButtonText = "Fremmede arter";

        public const string AlienSpecies2023CitationHeading = "Siden siteres som:";

        public const string AlienSpecies2023CitationString = "Artsdatabanken (2023, 24. november). Fremmede arter i Norge - med økologisk risiko 2023."; // TODO: insert correct publishing date for citation

        public const string AlienSpecies2023Introduction = "Fremmedartslista viser hvilken økologisk risiko fremmede arter kan utgjøre for naturmangfoldet i Norge." +
                                                                                                                                                                                                                                                                               " Den er utarbeidet av Artsdatabanken i samarbeid med fageksperter.";

        public const string AlienSpecies2023NoListViewResults = "Kombinasjonen av søk og filter gir ingen treff i Fremmedartslista for 2023.";

        public const string AlienSpecies2023KnownOccurrence = "Kjent utbredelse i dag";

        public const string AlienSpecies2023AssumedOccurrence = "Antatt utbredelse i dag";

        public const string AlienSpecies2023KnownOrAssumedOccurrence = "Utbredelse i dag";

        public const string AlienSpecies2023AssumedInFutureOccurrence = "Antatt utbredelse om 50 år";

        public const string ClimateEffectExplanationEnding = "vært lavere i fravær av pågående eller fremtidige klimaendringer.";
        public const string ClimateEffectExplanationInvationPotential = "Delkategori for invasjonspotensial ville ";
        public const string ClimateEffectExplanationEcoEffect = "Delkategori for økologisk effekt ville ";
        public const string ClimateEffectExplanationNeither = "Hverken delkategori for økologisk effekt eller invasjonspotensial ville ";
        public const string ClimateEffectExplanationBoth = " Både delkategori for økologisk effekt og invasjonspotensial ville ";


        public const string NoLowerCategoryThan = "Arten kunne ikke ha fått lavere risikokategori enn ";
        public const string LowerCategoryThan = "Arten kunne ha fått lavere risikokategori enn ";
        public const string LowerCategoryThanEnding = "i deler av sitt potensielle forekomstareal.";

        public const string ImpactedNatureTypesDescription = "Naturtyper arten er observert i og/eller som er potensielle habitater for arten i Norge. Hvis arten fører til endringer i naturtypen er det angitt.";
        public const string ImpactedNatureTypesDescriptionSvalbard = "Naturtyper arten er observert i og/eller som er potensielle habitater for arten på Svalbard. Hvis arten fører til endringer i naturtypen er det angitt.";
        public const string ImpactedNatureTypesCurrentTableTitle = "Truede, sjeldne eller øvrige naturtyper arten er observert i. ";
        public const string ImpactedNatureTypesFutureTableTitle = "Truede, sjeldne eller øvrige naturtyper som er potensielle habitater for arten i Norge. ";
        public const string ImpactedNatureTypesCurrentTableDescription = "Oversikten viser anslått kolonisert areal (C-kriteriet) i de naturtypene arten er  observert i, samt artens påvirkning i naturtypen og anslått andel av naturtypens areal som blir påvirket (F- og G-kriteriet).";
        public const string ImpactedNatureTypesFutureTableDescription = "Oversikten viser anslått kolonisert areal (C-kriteriet) i de naturtypene arten regnes med å observeres i innen 50 år eller 5 generasjoner (det av tallene som er størst), samt artens framtidige påvirkning i naturtypen og anslått andel av naturtypens areal som vil bli påvirket (F- og G-kriteriet).";
        public const string ImpactedNatureTypesTableColumn1 = "naturtype";
        public const string ImpactedNatureTypesTableColumn2 = "tidshorisont";
        public const string ImpactedNatureTypesTableColumn3 = "kolonisert <br/>areal (%)";
        public const string ImpactedNatureTypesTableColumn4 = "tydelig <br/>tilstandsendring";
        public const string ImpactedNatureTypesTableColumn5 = "tydelig <br/>påvirka <br/>areal (%)";
        public const string ImpactedNatureTypesTableColumn6 = "vurderingsgrunnlag";

        public const string CategoryChangeNotAssessed2018 = "Denne arten er risikovurdert for første gang i 2023.";
        public const string CategoryChangeShowSameAs2018 = "Denne arten er vurdert til samme risikokategori som i Fremmedartslista 2018 (forrige revisjon).";
        public const string CategoryChangeReasonsForChangeDescription = "Utfyllende beskrivelse av årsaken(e) for endret risikokategori:";


        public const string PathwaysMainCategory = "hovedkategori";
        public const string PathwaysCategory = "kategori";
        public const string PathwaysInfluenceFactor = "hyppighet";
        public const string PathwaysMagnitude = "antall <br/>individer";
        public const string PathwaysTimeOfIncident = "tidsrom";

        public const string hasIndoorProtectionTitle = "Til innendørs- eller produksjonsareal";
        public const string hasIndoorProtectionParagraph = "Spredningsmåter til innendørs- eller produksjonsareal omfatter artens spredningsmåter til Norge eller Svalbard, og ikke artens spredningsmåter til norsk natur. ";
        public const string hasIndoorProtectionParagraph2 = "Herunder tilfaller enhver (a) tilsikta eller utilsikta innførsel av en art fra utlandet og til 'Innendørs-Norge' (f.eks. butikker, privathus, lagerbygninger) og (b) tilsikta innførsel av en art fra utlandet og til artens eget produksjonsareal.";
        public const string hasIndoorProtectionTableTitle = "Artens importveier til innendørs- eller produksjonsareal.";
        public const string hasIndoorProtectionTableDescription = "Følgende aktuelle, fortidige og sannsynlig fremtidige importveier til innendørs- eller produksjonsareal er angitt for arten.";

        public const string hasNoIndoorProtectionTitle = "Introduksjon til natur";
        public const string hasNoIndoorProtectionParagraph = "Introduksjon til natur omfatter artens spredningsmåter til norsk natur fra utland, innendørsareal eller artens produksjonsareal. Med introduksjon menes enhver tilsikta eller utilsikta form for antropogen innførsel til norsk natur. Introduksjon kan altså enten skje uten eller etter en separat importhendelse.";
        public const string hasNoIndoorProtectionTableTitle = "Artens introduksjonsveier til norsk natur.";
        public const string hasNoIndoorProtectionTableDescription = "Følgende aktuelle, fortidige og sannsynlig fremtidige introduksjonsveier til norsk natur er angitt for arten. ";

        public const string furtherSpreadWaysTitle = "Videre spredning i natur";
        public const string furtherSpreadWaysParagraph = "Artens videre spredning i norsk natur omfatter spredning innad i naturen, altså fra norsk natur til norsk natur.";
        public const string furtherSpreadWaysTableTitle = "Artens videre spredning i norsk natur.";
        public const string furtherSpreadWaysTableDescription = "Følgende aktuelle, fortidige og sannsynlig fremtidige spredningsveier fra norsk natur til norsk natur er angitt for arten.  ";
        public const string noFurtherSpreadWays = "Det er ikke angitt spredningsmåter i norsk natur for denne arten";


        /* Criteria Explanation */
        public const string speciesEvaluatedTo = "Arten er vurdert til ";
        public const string noRisk = "ingen kjent risiko";
        public const string noRiskExplanation = "NK og har dermed ingen avgjørende kriterier.";

        public const string criteriaScoresAt = "Kriteriene arten skårer høyest på for hver av de to aksene. ";
        public const string readMoreAboutCriterias = "Les mer om kriteriene";

        public const string xAxisExplanation = "Artens invasjonspotensial bestemmes av tre kriterier: Artens mediane levetid i Norge (A-kriteriet), artens ekspansjonshastighet (B-kriteriet) og størrelsen på naturtypeareal som arten koloniserer (C-kriteriet). Invasjonspotensialet bestemmer artens plassering langs risikomatrisens x-akse.";
        public const string yAxisExplanation = "Artens økologiske effekt bestemmes av seks kriterier: Artens effekter på stedegne arter (D- og E-kriteriet), artens effekter på naturtyper (F- og G-kriteriet), genetisk forurensning av stedegne arter (H-kriteriet) og overføring av parasitter eller patogener til stedegne arter (I-kriteriet). Artens økologiske effekter bestemmer artens plassering langs risikomatrisens y-akse.";

        public const string seeOtherTab = "Se fanen Øvrige kriterier.";
        public const string noDecisiveCriteriaXAxis = "Arten har lite invasjonspotensial og har dermed ingen utslag på kriterier på invasjonsaksen.";

        public const string showDetailsButton = "Vis detaljer";
        public const string hideDetailsButton = "Skjul detaljer";
        public const string determeningCriteriaHeading = "Avgjørende kriterier";
        public const string otherCriteriaHeading = "Øvrige kriterier";
        public const string estimationMethod = "Estimeringsmetode:";
        public const string ScoreExplanationScore = "Dette tilsvarer skår";
        public const string JustScore = "skår";

        public const string basedOnEstimatesPlural = "Basert på de beste anslagene på ";
        public const string basedOnEstimatesSingular = "Basert på det beste anslaget på";
        public const string basedOnArea = "forekomstareal";
        public const string basedOnAreaSingular = "forekomstarealet";
        public const string basedOnArea10years = "forekomster i løpet av 10 år";
        public const string today = "i dag";
        public const string moreIntroductions = "ytterligere introduksjon(er) i samme tidsperiode ";
        public const string and = "og";
        public const string andIn50 = "og om 50 år";
        public const string aCriteriaScoredAs = "er A-kriteriet skåret som";
        public const string bCriteriaScoredAs = "er B-kriteriet skåret som ";
        public const string aCriteriaPreScoredAs = "ble A-kriteriet forhåndsskåret som";
        public const string withUuncertainty = "med usikkerhet";
        public const string medianLifeSpan = "Dette innebærer at artens mediane levetid er ";
        public const string riskOfDeath50 = "eller at sannsynligheten for utdøing innen 50 år er på ";
        public const string adjustedTo = "Med bakgrunn i retningslinjene ble skår og/eller usikkerhet justert til gjeldende verdier ";
        public const string adjustedUncertainty = "Begrunnelse for justering av skår og/eller usikkerhet:";

        public const string demoKeyNumbers = "Demografiske nøkkeltall";
        public const string currentPopSize = "Nåværende populasjonsstørrelse (N, i antall individer):";
        public const string growthRate = "Vekstrate";
        public const string environmentVar = "Miljøvarians";
        public const string demographicVar = "Demografisk varians";
        public const string sustainability = "Bæreevne (K, i antall individer): ";
        public const string extinctLimit = "Terskel for kvasiutdøing (C, i antall individer): ";
        public const string years = "år";
        public const string yearCaps = "År";
        public const string to = "til";
        public const string on = "på";
        public const string whichIs = "som er";
        public const string downTo = "ned mot";
        public const string upTo = "opp mot";
        public const string corrected = "korrigert for tiltak";
        public const string mPerYear = "m/år";
        public const string speciesHas = "Arten har";
        public const string medianLifeEst = "Basert på de demografiske nøkkeltallene er det beste anslaget for artens mediane levetid i Norge estimert til ";

        public const string modelAndProgram = "Beskrivelse av modeller og programvare som er brukt: ";
        public const string estMedianLifeSpanThisYear = "Estimert median levetid (i år)";
        public const string lowEstimate = "lavt anslag";
        public const string highEstimate = "høyt anslag";

        public const string expansionSpeed = "Ekspansjonshastighet";
        public const string expansionSpeedGuess = "Det beste anslaget på artens ekspansjonshastighet er";
        public const string expansionSpeedIs = "er ekspansjonshastigheten anslått til";
        public const string expansionSpeedEst = "er ekspansjonshastigheten estimert til";
        public const string expansion = "ekspansjon";

        public const string isScore = "Dette tilsvarer skår";
        public const string atBCrit = "på B-kriteriet";
        public const string methodDescriptionUnaidedFuture = "Denne estimeringsmetoden anslår ekspansjonshastigheten ut fra forventet endring i forekomstareal framover i tid.";
        public const string methodDescriptionReproducingUnaided = "Denne estimeringsmetoden anslår ekspansjonshastigheten ut fra endringen i forekomstareal mellom to år tilbake i tid, hvor antall år mellom første og andre år, er på mellom 10 og 20 år. Følgende data ligger til grunn:";
        public const string commentData = "Kommentar til datagrunnlaget:";
        public const string basedOnIncrease = "Basert på økningen i artens forekomstareal i perioden fra";
        public const string andA = "og et";
        public const string darkNumber = "mørketall på";
        public const string knownArea = "Kjent forekomstareal";
        public const string areaDarkNumbers = "Forekomstarealets mørketall";
        public const string average = "Gjennomsnittlig (m/år)";

        public const string noEcoEffect = "Arten har ingen kjent økologisk effekt og har dermed ingen utslag på kriterier på effektaksen.";
        public const string effectAfterCriterium = "Økologiske effekter etter kriterium";
        public const string evaluatedAsUnlikely = "er vurdert som fraværende (usannsynlige)";

        public const string spatioTemporalTableTitle = "Parametervalg for estimering av ekspansjonshastighet ";
        public const string readMoreMethod = "les mer om metoden her";
        public const string model = "Modell";
        public const string sitesListed = "Lokalitetene i datafila er oppført";

        public const string figureCategoryStart = "Antall vurderinger i hver av de fem risikokategoriene, fra";
        public const string figureCategoryMiddle = "er vurdert å være høyrisikoarter, dvs. de utgjør enten en";
        public const string figureCategoryEnd = "for norsk natur";

        public const string riskMatrixFigureHeader = "Antall vurderinger for hver kombinasjon av invasjonspotensial og økologisk effekt";
        public const string riskMatrixFigureText = "Når en fremmed art risikovurderes, vurderes både artens <i>invasjonspotensial</i> og artens negative <i>økologiske effekter</i> i norsk natur. Vurderingen resulterer dermed i to skår, én for artens invasjonspotensial (1 – 4) og én for artens økologiske effekter (1 – 4). Kombinasjonen av disse to skårene gir artens plassering i risikomatrisen og bestemmer risikokategori (NK: <i>ingen kjent risiko</i>, LO: <i>lav risiko</i>, PH: <i>potensielt høy risiko</i>, HI: <i>høy risiko</i>, SE: <i>svært høy risiko</i>). Tallet i en celle viser antall vurderinger i utvalget med gitte kombinasjon av økologisk effekt og invasjonspotensial.";
        public const string decisiveCriteriaFigureHeader = "Antall vurderinger per avgjørende kriterium";
        public const string decisiveCriteriaFigureText1 = "Artens risiko i norsk natur vurderes mot totalt ni kriterier: Kriteriene A - C beskriver artens invasjonspotensial og kriteriene D – I beskriver artens økologiske effekter. Kriteriet(ene) som skårer høyest for invasjonspotensial og økologisk effekt bestemmer risikokategorien. Én vurdering kan ha flere avgjørende kriterier, og totalantallet kan derfor overstige antall vurderinger i utvalget. Arter i kategorien <i>ingen kjent risiko</i> NK er ekskludert. Utvalget ditt omfatter";
        public const string decisiveCriteriaFigureText2 = "vurderinger med totalt";
        public const string decisiveCriteriaFigureText3 = "avgjørende kriterier (";
        public const string decisiveCriteriaFigureText4 = "vurderinger i utvalget har <i>ingen kjent risiko</i>).";



    }
}
