using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class Helpers
    {
        public static QueryParameters GetQueryParameters(this HttpContext context, Dictionary<string, string> parameters)
        {
            var dictionary = context.Request.Query.ToDictionary(d => d.Key, d => d.Value.ToString());

            foreach (var (key, value) in parameters)
            {
                if (dictionary.ContainsKey(key))
                    dictionary.Remove(key);

                dictionary.Add(key, value);
            }

            return new QueryParameters(dictionary);
        }

        public class QueryParameters : Dictionary<string, string>
        {
            public QueryParameters(IDictionary<string, string> dictionary) : base(dictionary) { }

            public QueryParameters WithRoute(string routeParam, string routeValue)
            {
                this[routeParam] = routeValue;

                return this;
            }
        }
        public static string[] findSelectedCategories( bool redlisted, bool endangered,
            string[] categoriesSelected) 
        {
            List<string> selectedCategories = new List<string>();

            List<string> redlist = new List<string>
            {
                Constants.SpeciesCategories.Extinct.ShortHand,
                Constants.SpeciesCategories.CriticallyEndangered.ShortHand,
                Constants.SpeciesCategories.Endangered.ShortHand,
                Constants.SpeciesCategories.Vulnerable.ShortHand,
                Constants.SpeciesCategories.NearThreatened.ShortHand,
                Constants.SpeciesCategories.DataDeficient.ShortHand
            };

            List<string> endangeredList = new List<string>
            {
                Constants.SpeciesCategories.CriticallyEndangered.ShortHand,
                Constants.SpeciesCategories.Endangered.ShortHand,
                Constants.SpeciesCategories.Vulnerable.ShortHand
            };

            if (redlisted) 
                foreach (var category in redlist)
                    selectedCategories.Add(category);
            else if (endangered) 
                foreach (var category in endangeredList)
                    selectedCategories.Add(category);
            foreach (var s in categoriesSelected)
            {
                if (!selectedCategories.Contains(s))
                {
                    selectedCategories.Add(s);
                }
            }
            return selectedCategories.ToArray();
        }

        public static string[] findSelectedRegions(string[] selectedRegions)
        {
            List<string> regions = new List<string>();
            foreach (var region in selectedRegions)
            {
                switch (region)
                {
                    case Constants.Regions.Ag:
                        regions.Add(Constants.Regions.VestAgder);
                        regions.Add(Constants.Regions.AustAgder);
                        break;

                    case Constants.Regions.In:
                        regions.Add(Constants.Regions.Oppland);
                        regions.Add(Constants.Regions.Hedmark);
                        break;

                    case Constants.Regions.VT:
                        regions.Add(Constants.Regions.Vestfold);
                        regions.Add(Constants.Regions.Telemark);
                        break;

                    case Constants.Regions.MR:
                        regions.Add(Constants.Regions.MoreRomsdal);
                        break;

                    case Constants.Regions.No:
                        regions.Add(Constants.Regions.Nordland);
                        break;

                    case Constants.Regions.Ro:
                        regions.Add(Constants.Regions.Rogaland);
                        break;

                    case Constants.Regions.TF:
                        regions.Add(Constants.Regions.Troms);
                        regions.Add(Constants.Regions.Finnmark);
                        break;

                    case Constants.Regions.Tr:
                        regions.Add(Constants.Regions.Trondelag);
                        break;

                    case Constants.Regions.Ve:
                        regions.Add(Constants.Regions.SognFjordane);
                        regions.Add(Constants.Regions.Hordaland);
                        break;

                    case Constants.Regions.VO:
                        regions.Add(Constants.Regions.OsloAkershus);
                        regions.Add(Constants.Regions.Buskerud);
                        regions.Add(Constants.Regions.Ostfold);
                        break;

                    case Constants.Regions.Ha:
                        regions.Add(Constants.Regions.Nordsjoen);
                        regions.Add(Constants.Regions.Norskehavet);
                        regions.Add(Constants.Regions.Gronlandshavet);
                        regions.Add(Constants.Regions.Polhavet);
                        regions.Add(Constants.Regions.Barentshavet);
                        break;

                    default:
                        break;
                }
            }
            return regions.ToArray();
        }

        public static string[] findEuropeanPopProcentages(string[] europeanPopulation)
        {
            List<string> selectedPercenteges = new List<string>();

            foreach (var item in europeanPopulation)
            {
                if (item == Constants.EuropeanPopulationPercentages.EuropeanPopLt5)
                {
                    selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Lt1);
                    selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Lt5);
                    selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Range1To5);
                }
                else if (item == Constants.EuropeanPopulationPercentages.EuropeanPopRange5To25)
                    selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Range5To25);
                else if (item == Constants.EuropeanPopulationPercentages.EuropeanPopRange25To50)
                    selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Range25To50);
                else if (item == Constants.EuropeanPopulationPercentages.EuropeanPopGt50)
                    selectedPercenteges.Add(Constants.EuropeanPopulationPercentages.Gt50);
            }
            return selectedPercenteges.ToArray();
        }
    }

    public static class Constants
    {
        public const string CacheFolder = "Cache";

        public const string AssessmentsMappingAssembly = "Assessments.Mapping";

        public static readonly Dictionary<string, string> AllAreas = new Dictionary<string, string>
        {
            {"Norge", "N"},
            {"Svalbard", "S"}
        };

        public static readonly string[] AllCategories = new[]
        {
            Constants.SpeciesCategories.Extinct.ShortHand,
            Constants.SpeciesCategories.CriticallyEndangered.ShortHand,
            Constants.SpeciesCategories.Endangered.ShortHand,
            Constants.SpeciesCategories.Vulnerable.ShortHand,
            Constants.SpeciesCategories.NearThreatened.ShortHand,
            Constants.SpeciesCategories.DataDeficient.ShortHand,
            Constants.SpeciesCategories.Viable.ShortHand,
            Constants.SpeciesCategories.NotEvalueted.ShortHand,
            Constants.SpeciesCategories.NotAppropriate.ShortHand
        };
        public static readonly Dictionary<string, string> AllCriterias = new Dictionary<string, string>
        {
            {"A", "populasjonsreduksjon"},
            {"B", "lite areal"},
            {"C", "liten populasjon"},
            {"D", "svært liten populasjon eller forekomst"}
        };

        public static readonly Dictionary<string, string> AllEuropeanPopulationPercentages = new Dictionary<string, string>
        {
            {Constants.EuropeanPopulationPercentages.EuropeanPopLt5, "< 5 %"},
            {Constants.EuropeanPopulationPercentages.EuropeanPopRange5To25, "5 - 25 %"},
            {Constants.EuropeanPopulationPercentages.EuropeanPopRange25To50, "25 - 50 %"},
            {Constants.EuropeanPopulationPercentages.EuropeanPopGt50, "> 50 %"}
        };

        public static readonly Dictionary<string, string> AllRegions = new Dictionary<string, string>
        {
            {Regions.Ag, "Agder"},
            {Regions.In, "Innlandet"},
            {Regions.VT, "Vestfold og Telemark"},
            {Regions.MR, "Møre og Romsdal"},
            {Regions.No, "Nordland"},
            {Regions.Ro, "Rogaland"},
            {Regions.TF, "Troms og Finnmark"},
            {Regions.Tr, "Trøndelag"},
            {Regions.Ve, "Vestland"},
            {Regions.VO, "Viken og Oslo"},
            {Regions.Ha, "Havområder"}
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

        public class Regions
        {
            public const string Ag = "Ag";
            public const string In = "In";
            public const string VT = "VT";
            public const string MR = "MR";
            public const string No = "No";
            public const string Ro = "Ro";
            public const string TF = "TF";
            public const string Tr = "Tr";
            public const string Ve = "Ve";
            public const string VO = "VO";
            public const string Ha = "Ha";
            public const string MoreRomsdal = "Møre og Romsdal";
            public const string VestAgder = "Vest-Agder";
            public const string AustAgder = "Aust-Agder";
            public const string Oppland = "Oppland";
            public const string Hedmark = "Hedmark";
            public const string Vestfold = "Vestfold";
            public const string Telemark = "Telemark";
            public const string Nordland = "Nordland";
            public const string Rogaland = "Rogaland";
            public const string Troms = "Troms";
            public const string Finnmark = "Finnmark";
            public const string Trondelag = "Trøndelag";
            public const string SognFjordane = "Sogn og Fjordane";
            public const string Hordaland = "Hordaland";
            public const string OsloAkershus = "Oslo og Akershus";
            public const string Buskerud = "Buskerud";
            public const string Ostfold = "Østfold";
            public const string Nordsjoen = "Nordsjøen";
            public const string Norskehavet = "Norskehavet";
            public const string Gronlandshavet = "Grønlandshavet";
            public const string Polhavet = "Polhavet";
            public const string Barentshavet = "Barentshavet";
        }

        public class Filename
        {
            public const string Species2021 = "species-2021.json";

            // filnavn for modeller lagret som "RL2019"
            public const string Species2021Temp = "species-2021-temp.json";

            public const string Species2015 = "species-2015.json";

            public const string Species2006 = "species-2006.json";

            public const string SpeciesExpertCommitteeMembers = "species-experts.csv";
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
            public const string ResetAllFilters = "Nullstill filtre";
            public const string SearchChangedCategory = "Vis arter med endret kategori fra 2015";
            public const string SearchChooseArea = "Vurderingsområde";
            public const string SearchChooseCategory = "Kategori";
            public const string SearchChooseCriteria = "Kriterier";
            public const string SearchChooseSpeciesGroup = "Artsgruppe";
            public const string SearchFilterSpecies = "Søk art/slekt";
        }

    }

    public static class FilterViewHelpers
    {
        public static class Filters
        {
            public static string[] AssessmentAreas = new string[] {"Norge", "Svalbard"};
        }
    }
}