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

        public const string invasionPotential = "invasjonspotensial";
        public const string ecologicalEffect = "økologiske effekt";

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

        public const string AlienSpecies2023FirstPublished = "11.08.2023"; // TODO: Need publishing date

        public const string AlienSpecies2023FirstPublishedYear = "2023";

        public const int AlienSpecies2023PageMenuContentId = 239657; //239645; //239644; //239646;

        public const string AlienSpecies2023PageMenuHeaderText = "Fremmedartslista 2023";

        public const string AlienSpecies2023PageMenuHeaderTextShort = "Fremmedartslista";

        public const string AlienSpecies2023HeaderText = "Fremmedartslista 2023";

        public const string AlienSpecies2023HeaderByline = "Publisert: 22. februar 2023"; // TODO: change to correct publishing date when we know

        public const string AlienSpecies2023PageManuExpandButtonText = "Fremmede arter";

        public const string AlienSpecies2023CitationHeading = "Siden siteres som:";

        public const string AlienSpecies2023CitationString = "Artsdatabanken (2023, 11. august). Fremmede arter i Norge - med økologisk risiko 2023."; // TODO: insert correct publishing date for citation

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

        public const string criteriaExplanationString = "Artens risikokategori bestemmes av artens høyeste skår på invasjonspotensial (x-aksen i risikomatrisa) og på økologisk effekt (y-aksen i risikomatrisa). Kriteriet(ene) arten skårer høyest på for hver av aksene i matrisa er artens avgjørende kriterier.";
        public const string readMoreAboutCriterias = "Les mer om kriteriene";

        public const string xAxisExplanation = "<b>Artens invasjonspotensial</b> bestemmes av tre kriterier: Artens mediane levetid i Norge (A-kriteriet), artens ekspansjonshastighet (B-kriteriet) og størrelsen på naturtypeareal som arten koloniserer (C-kriteriet).";
        public const string yAxisExplanation = "<b>Artens økologiske effekt</b> bestemmes av seks kriterier: Artens effekter på stedegne arter (D- og E-kriteriet), artens effekter på naturtyper (F- og G-kriteriet), genetisk forurensning av stedegne arter (H-kriteriet) og overføring av parasitter eller patogener til stedegne arter (I-kriteriet).";

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

        public const string years = "år";
        public const string to = "til";
        public const string on = "på";
        public const string whichIs = "som er";
        public const string downTo = "ned mot";
        public const string upTo = "opp mot";
        public const string mPerYear = "m/år";
        public const string speciesHas = "Arten har";
        public const string medianLifeEst = "Basert på de demografiske nøkkeltallene er det beste anslaget for artens mediane levetid i Norge estimert til ";

        public const string modelAndProgram = "Beskrivelse av modeller og programvare som er brukt: ";
        public const string estMedianLifeSpanThisYear = "Estimert median levetid (i år)";
        public const string lowEstimate = "lavt anslag";
        public const string highEstimate = "høyt anslag";

        
        public const string expansionSpeedGuess = "Det beste anslaget på artens ekspansjonshastighet er";
        public const string expansionSpeedIs = "er ekspansjonshastigheten anslått til";
        public const string expansionSpeedEst = "er ekspansjonshastigheten estimert til";
        public const string expansion = "ekspansjon";

        public const string isScore = "Dette tilsvarer skår";
        public const string atBCrit = "på B-kriteriet";
        public const string methodDescriptionUnaidedFuture = "Denne estimeringsmetoden anslår ekspansjonshastigheten ut fra forventet endring i forekomstareal framover i tid.";
        public const string commentData = "Kommentar til datagrunnlaget:";
        public const string basedOnIncrease = "Basert på økningen i artens forekomstareal i perioden fra";
        public const string andA = "og et";
        public const string darkNumber = "mørketall på";
        
        
       

        public const string noEcoEffect = "Arten har ingen kjent økologisk effekt og har dermed ingen utslag på kriterier på effektaksen.";
        public const string effectAfterCriterium = "Økologiske effekter etter kriterium";
        public const string evaluatedAsUnlikely = "er vurdert som fraværende (usannsynlige)";

        


        public class AlienSpeciesTables
        {
            /*General*/
            public const string TimeHorizonTableColumn = "Tidshorisont";
            public const string BackgroundTableColumn = "Vurderings<span>&#8208;</span><br/>grunnlag";
            public const string AverageRow = "beste anslag";
            public const string LowRow = "lavt anslag";
            public const string HighRow = "høyt anslag";

            /*Criteria A and B*/
            public const string CriteriaAMedianLifespanNumericalEstimationTableTitle = "Artens demografiske nøkkeltall.";
            public const string CriteriaAMedianLifespanNumericalEstimationTableDescription = "Tabellen viser artens demografiske nøkkeltall brukt for å estimere den fremmede artens levetid i Norge. Les mer om parameterne i ";
            public const string CriteriaANumericalEstimationTableLinkText = "retningslinjene";
            public const string CurrentPopSize = "Nåværende populasjonsstørrelse (N, i antall individer)";
            public const string GrowthRate = "Vekstrate";
            public const string EnvironmentVar = "Miljøvarians";
            public const string DemographicVar = "Demografisk varians";
            public const string CarryingCapasity = "Bæreevne (K, i antall individer)";
            public const string QuasiExtinctionThreshold = "Terskel for kvasiutdøing (C, i antall individer)";

            public const string CriteriaBExpansionSpeedSpatioTemporalParameterTableTitle = "Modell og parametere.";
            public const string CriteriaBExpansionSpeedSpatioTemporalParameterTableDescription = "Tabellen viser hvilke parametere og antagelser som er brukt for estimering av ekspansjonshastighet. Les mer om metoden her: ";
            public const string MedianLifespanAndExpansionSpeedParameterColumn1 = "Parameter";
            public const string MedianLifespanAndExpansionSpeedParameterColumn2 = "Verdi";
            public const string AreaDarkNumbers = "forekomstarealets mørketall";
            public const string Model = "modell";
            public const string SitesListed = "lokalitetene i datafila er oppført";
            public const string CriteriaBExpansionSpeedSpatioTemporalResultTableTitle = "Artens ekspansjonshastighet.";
            public const string CriteriaBExpansionSpeedSpatioTemporalResultTableDescription = "Tabellen viser artens estimerte ekspansjonshastighet (m/år) med bakgrunn i parametervalgene angitt over, samt datasett med tid- og stedfesta observasjoner av arten.";
            public const string ExpansionSpeedResultColumn1 = "Ekspansjonshastighet";
            public const string ExpansionSpeedResultColumn2 = "Estimert verdi (m/år)";

            public const string CriteriaBExpansionSpeedIncreaseAOOTableTitle = "Artens endring i forekomstareal.";
            public const string CriteriaBExpansionSpeedIncreaseAOOTableDescription = "Tabellen viser artens kjente forekomstareal ved to ulike år.";
            public const string ExpansionSpeedAOOColumn1 = "År";
            public const string ExpansionSpeedAOOKnownArea = "Kjent forekomstareal (km<sup>2</sup>)";
            public const string ExpansionSpeedAOOKnownAreaCorrected = "Kjent forekomstareal (km<sup>2</sup>) <br/>korrigert for tiltak";

            /*Criteria D, E, H and I*/
            public const string CriteriaDSpeciesNaturetypesTableTitle = "Artens negative effekter på grupper av arter (inkludert trua arter eller nøkkelarter).";
            public const string CriteriaDSpeciesNaturetypesTableDescription = "Tabellen viser hvilken type interaksjon den fremmede arten har med grupper av stedegne arter (hvor minst én av artene er trua eller nøkkelart), samt interaksjonens styre og omfang. Den negative interaksjonen med stedegne arter er gitt for hver naturtype. Kun effekter som er dokumentert i Norge eller i utlandet (for arten selv eller en sammenlignbar art), eller som sannsynlig vil opptre i Norge i løpet av 50 år, er inkludert.";
            public const string CriteriaESpeciesNaturetypesTableTitle = "Artens negative effekter på grupper av stedegne arter.";
            public const string CriteriaESpeciesNaturetypesTableDescription = "Tabellen viser hvilken type interaksjon den fremmede arten har med grupper av stedegne arter, samt interaksjonens styre og omfang. Den negative interaksjonen med stedegne arter er gitt for hver naturtype. Kun effekter som er dokumentert i Norge eller i utlandet (for arten selv eller en sammenlignbar art), eller som sannsynlig vil opptre i Norge i løpet av 50 år, er inkludert.";
            public const string CriteriaDSpeciesTableTitle = "Artens negative effekter på trua arter eller nøkkelarter.";
            public const string CriteriaDSpeciesTableDescription = "Tabellen viser hvilken type interaksjon den fremmede arten har med stedegne trua arter eller nøkkelarter, samt interaksjonens styre og omfang. Kun effekter som er dokumentert i Norge eller i utlandet (for arten selv eller en sammenlignbar art), eller som sannsynlig vil opptre i Norge i løpet av 50 år, er inkludert.";

            public const string CriteriaESpeciesTableTitle = "Artens negative effekter på stedegne arter (ikke trua eller sjelden).";
            public const string CriteriaESpeciesTableDescription = "Tabellen viser hvilken type interaksjon den fremmede arten har med stedegne arter, samt interaksjonens styre og omfang. Kun effekter som er dokumentert i Norge eller i utlandet (for arten selv eller en sammenlignbar art), eller som sannsynlig vil opptre i Norge i løpet av 50 år, er inkludert.";

            public const string CriteriaHIntrogressionTableTitle = "Overføring av genetisk materiale.";
            public const string CriteriaHIntrogressionTableDescription = "Tabellen viser hvilke stedegne arter som blir, eller kan bli, genetisk forurenset av den fremmede arten. Med genetisk forurensning menes introgresjon, hybridisering alene er ikke tilstrekkelig. Kun genetisk forurensing som er dokumentert eller sannsynlig er inkludert.";
            public const string CriteriaIParasitesTableTitle = "Overføring av parasitter og patogener.";
            public const string CriteriaIParasitesTableDescription = "Tabellen viser hvilke parasitter eller patogener (inkludert bakterier og virus) arten er vurdert å overføre til stedegne verter, om parasitten er kjent for verten eller ei, samt om parasitten er fremmed eller stedegen. Den økologiske effekten av overføringen kan ikke være større enn den økologiske effekten parasitten selv vurderes å ha etter kriteriene D til H. Kun overføringer av parasitter og patogener som er dokumentert eller sannsynlig er inkludert.";

            public const string KeyStoneSpeciesTableColumn = "Nøkkelart?";
            public const string RedListCategoryTableColumn = "Kategori <br/>Rødlista 2021";
            public const string InteractionStrengthTableColumn = "Interaksjonens styrke";
            public const string ScaleTableColumn = "Geografisk omfang";
            public const string InteractionTypeTableColumn = "Type interaksjon";
            public const string NaturetypeDAndETableColumn1 = "Påvirkede <br/>arter i";
            public const string NaturetypeDAndETableColumn2 = "Nøkkelarter <br/>eller truede <br/>arter?";

            /*Criteria C, F, G and impacted naturetypes*/
            public const string CriteriaCNaturetypesTableTitle = "Artens koloniserte naturtypeareal.";
            public const string CriteriaCNaturetypesTableDescription = "Tabellen viser hvilke(n) naturtype(r) den fremmede arten koloniserer nå eller i framtida. Andel kolonisert areal (%) av totalt naturtypeareal og vurderingsgrunnlag er gitt for hver naturtype.";
            public const string CriteriaFNaturetypesTableTitle = "Artens negative effekter på truede eller sjeldne naturtyper.";
            public const string CriteriaGNaturetypesTableTitle = "Artens negative effekter på naturtyper (ikke trua eller sjelden).";
            public const string CriteriaFAndGNaturetypesTableDescription = "Tabellen viser hvilke(n) naturtype(r) som påvirkes av den fremmede arten nå eller i framtida. Type tilstandsendring, hvor stor del av naturtypearealet som påvirkes og vurderingsgrunnlag er gitt for hver naturtype. Se retningslinjene for beskrivelse av tydelig tilstandsendring.";
            public const string ImpactedNatureTypesCurrentTableTitle = "Truede, sjeldne eller øvrige naturtyper arten er observert i. ";
            public const string ImpactedNatureTypesFutureTableTitle = "Truede, sjeldne eller øvrige naturtyper som er potensielle habitater for arten i Norge. ";
            public const string ImpactedNatureTypesCurrentTableDescription = "Tabellen viser anslått kolonisert areal (C-kriteriet) i de naturtypene arten er  observert i, samt artens påvirkning i naturtypen og anslått andel av naturtypens areal som blir påvirket (F- og G-kriteriet).";
            public const string ImpactedNatureTypesFutureTableDescription = "Tabellen viser anslått kolonisert areal (C-kriteriet) i de naturtypene arten regnes med å observeres i innen 50 år eller 5 generasjoner (det av tallene som er størst), samt artens framtidige påvirkning i naturtypen og anslått andel av naturtypens areal som vil bli påvirket (F- og G-kriteriet).";
            public const string NaturetypeNameTableColumn = "naturtype";
            public const string ColonizedAreaTableColumn = "kolonisert <br/>areal (%)";
            public const string StateChangeTableColumn = "tydelig <br/>tilstandsendring";
            public const string AffectedAreaTableColumn = "tydelig <br/>påvirka <br/>areal (%)";
            public const string ImpactedNatureTypesTableColumn6 = "vurderingsgrunnlag";

            /*area of occupancy (AOO)*/
            public const string AooTableTitle = "Artens forekomstareal.";
            public const string AooTableDescription = "Tabellen viser artens kjente og antatte forekomstareal i dag og i fremtiden.";
            public const string AooTableDescription2 = "Kjent forekomstareal er basert på perioden ";
            public const string AooDoorknockersTableDescription = "Tabellen viser anslag på antall forekomster, med utgangspunkt i én introduksjon, og antallet ytterligere introduksjoner i løpet av en periode på 10 år. Anslag på artens forekomstareal 10 år etter første introduksjon er gitt.";
            public const string AooTableColumn1 = "Anslag";
            public const string AooDoorknockersTableColumn2 = "Antall forekomster fra én introduksjon";
            public const string AooDoorknockersTableColumn3 = "Antall ytterligere introduksjoner til norsk natur";
            public const string AooDoorknockersTableColumn4 = "Forekomstareal etter 10 år";

            /*First observation*/
            public const string FirstObsTableTitle = "Artens første observasjoner.";
            public const string FirstObsTableDescription = "Tabellen viser årstall for første observasjonen av arten for hver aktuelle etableringsstatus.";
            public const string FirstObsTableColumn1 = "Etableringsstatus";
            public const string FirstObsTableColumn2 = "Årstall for første observasjon";
            public const string FirstObsTableColumn3 = "Usikkerhet i årstall <br/>(> ± 5 år)";

        }


        public const string FigureMainText = "Her finner du resultater fra Fremmedartslista 2023 presentert i figurer. Figurene er reaktive, og viser kun resultater for det utvalget du har gjort i filteret. Om ingen filterutvalg er gjort, vises resultater for alle risikovurderte arter, både for Fastlands-Norge og Svalbard. Arter som ikke er risikovurderte (NR-arter) er ekskludert fra datagrunnlaget i alle figurer, det samme gjelder underarter og kultivarer som er inkludert i vurderingen av moderarten.";

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
        public const string natureTypesEffectsHeader = "Arter i truede eller sjeldne naturtyper";
        public const string natureTypesEffectsFigureHeader1 = "Antall vurderinger per natursystem eller landform";
        public const string natureTypesEffectsFigureHeader2 = "Antall vurderinger per sjeldne eller truede naturtype";
        public const string natureTypesEffectsText1 = "Antall vurderinger per natursystem eller landform med truede eller sjeldne naturtyper (Rødlista for Naturtyper 2018). Den vurderte arten kan være observert i et natursystem eller landform i dag, eller den forventes å kolonisere natursystemet eller landformen i fremtiden. Hvert natursystem og landform telles kun én gang per vurdering, selv om en art kan finnes i flere truede eller sjeldne naturtyper innenfor hver (se neste figur).";
        public const string natureTypesEffectsText2 = "Antall vurderinger per sjeldne eller truede naturtype fordelt på natursystem og landform (Rødlista for Naturtyper 2018). Den vurderte arten kan være observert i naturtypen i dag, eller den forventes å kolonisere naturtypen i fremtiden. Én art kan være i flere naturtyper, og totalantallet kan derfor overstige antall vurderinger i utvalget. Merk at et lavt antall observasjoner i en naturtype kan skyldes at naturtypen er lite kartlagt, eller at kartleggingsdata ikke er tilgjengelig.";
        public const string spreadWaysHeader = "Spredningsveier til norsk natur";
        public const string spreadWaysFigureHeader1 = "Antall vurderinger per hovedspredningsvei til norsk natur";
        public const string spreadWaysFigureHeader2 = "Antall vurderinger per spredningsvei til norsk natur";
        public const string spreadWaysFigureText1 = "Antall vurderinger i utvalget per hovedspredningsvei til natur. En fremmed art kan ha flere hovedspredningsveier til naturen, og det totale antallet kan derfor overstige antall vurderinger.";
        public const string spreadWaysFigureText2 = "Antall vurderinger per spredningsvei til norsk natur fordelt på hovedspredningsvei. En fremmed art kan ha flere spredningsveier til naturen, og det totale antallet kan derfor overstige antall vurderinger.";
        public const string establishmentClassHeader = "Artens etableringsstatus i dag";
        public const string establishmentClassFigureText = "En fremmed arts etableringsstatus, altså hvor godt etablert arten er i dag, klassifiseres gjennom et standardisert system med etableringsklasser. Den <i>høyeste</i> etableringsklassen arten oppfyller i dag - det være etablert eller å kun finnes utenlands - avgjør artens etableringsstatus.";
    }
}
