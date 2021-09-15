using Assessments.Mapping.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using Assessments.Mapping.Models.Source.Species;
using Assessments.Mapping.Models.Species;
using AutoMapper;

namespace Assessments.Mapping
{
    public class SpeciesAssessment2021Profile : Profile
    {
        public SpeciesAssessment2021Profile()
        {
            CreateMap<Rodliste2019.Pavirkningsfaktor, SpeciesAssessment2021ImpactFactor>()
                .ForMember(dest => dest.Severity, opt => opt.MapFrom(src => src.Alvorlighetsgrad))
                .ForMember(dest => dest.PopulationScope, opt => opt.MapFrom(src => src.Omfang))
                .ForMember(dest => dest.TimeScope, opt => opt.MapFrom(src => src.Tidspunkt))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .AfterMap(CorrectImpactFactors);

            CreateMap<Rodliste2019.TrackInfo, SpeciesAssessment2021TrackInfo>();
            CreateMap<Rodliste2019.MinMaxProbable, SpeciesAssessment2021MinMaxProbable>();
            CreateMap<Rodliste2019.MinMaxProbableIntervall, SpeciesAssessment2021MinMaxProbableIntervall>();
            CreateMap<Rodliste2019.Reference, SpeciesAssessment2021Reference>();

            CreateMap<Rodliste2019.Fylkesforekomst, SpeciesAssessment2021RegionOccurrence>()
                .ForMember(dest => dest.Fylke, opt => opt.MapFrom(src => SpeciesAssessment2021ProfileHelper.ResolveRegion(src.Fylke)));

            CreateMap<Rodliste2019.TaxonHistory, SpeciesAssessment2021TaxonHistory>()
                .ForMember(dest => dest.ExpertCommittee, opt => opt.MapFrom(src => src.Ekspertgruppe))
                .ForMember(dest => dest.ScientificName, opt => opt.MapFrom(src => src.VitenskapeligNavn))
                .ForMember(dest => dest.AuthorCitation, opt => opt.MapFrom(src => src.VitenskapeligNavnAutor))
                .ForMember(dest => dest.TaxonomicHierarchy, opt => opt.MapFrom(src => src.VitenskapeligNavnHierarki))
                .ForMember(dest => dest.ScientificNameId, opt => opt.MapFrom(src => src.VitenskapeligNavnId));

            CreateMap<Rodliste2019, SpeciesAssessment2021>()
                
                .ForMember(dest => dest.RegionOccurrences, opt => opt.MapFrom(src => src.Fylkesforekomster))

                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))

                .ForPath(dest => dest.A1.ReductionBasedOn, opt => opt.MapFrom(src => src.A1EndringBasertpåKode))
                .ForPath(dest => dest.A1.PreliminaryCategory, opt => opt.MapFrom(src => src.A1OpphørtOgReversibel))
                .ForPath(dest => dest.A1.QuantifiedReduction, opt => opt.MapFrom(src => src.A1OpphørtOgReversibelAntatt))

                .ForPath(dest => dest.A2.ReductionBasedOn, opt => opt.MapFrom(src => src.A2EndringBasertpåKode))
                .ForPath(dest => dest.A2.PreliminaryCategory, opt => opt.MapFrom(src => src.A2Forutgående10År))
                .ForPath(dest => dest.A2.QuantifiedReduction, opt => opt.MapFrom(src => src.A2Forutgående10ÅrAntatt))

                .ForPath(dest => dest.A3.ReductionBasedOn, opt => opt.MapFrom(src => src.A3EndringBasertpåKode))
                .ForPath(dest => dest.A3.PreliminaryCategory, opt => opt.MapFrom(src => src.A3Kommende10År))
                .ForPath(dest => dest.A3.QuantifiedReduction, opt => opt.MapFrom(src => src.A3Kommende10ÅrAntatt))

                .ForPath(dest => dest.A4.ReductionBasedOn, opt => opt.MapFrom(src => src.A4EndringBasertpåKode))
                .ForPath(dest => dest.A4.PreliminaryCategory, opt => opt.MapFrom(src => src.A4Intervall10År))
                .ForPath(dest => dest.A4.QuantifiedReduction, opt => opt.MapFrom(src => src.A4Intervall10ÅrAntatt))

                .ForMember(dest => dest.ProportionOfMaxPopulation, opt => opt.MapFrom(src => src.AndelNåværendeBestand))

                .ForPath(dest => dest.B1.Statistics, opt => opt.MapFrom(src => src.B1IntervallUtbredelsesområde))
                .ForPath(dest => dest.B1.PreliminaryCategory, opt => opt.MapFrom(src => src.B1UtbredelsesområdeKode))

                .ForPath(dest => dest.B2.PreliminaryCategory, opt => opt.MapFrom(src => src.B2ForekomstarealKode))
                .ForPath(dest => dest.B2.Statistics, opt => opt.MapFrom(src => src.B2IntervallForekomstareal))

                .ForMember(dest => dest.BaiSevereFragmentation, opt => opt.MapFrom(src => src.BA1KraftigFragmenteringKode))

                .ForPath(dest => dest.BAii.PreliminaryCategory, opt => opt.MapFrom(src => src.BA2FåLokaliteterKode))
                .ForPath(dest => dest.BAii.Statistics, opt => opt.MapFrom(src => src.BaIntervallAntallLokaliteter))

                .ForMember(dest => dest.BBOptions, opt => opt.MapFrom(src => src.BBPågåendeArealreduksjonKode))
                .ForMember(dest => dest.BCOptions, opt => opt.MapFrom(src => src.BCEksterneFluktuasjonerKode))
                .ForMember(dest => dest.RationaleNotApplicable, opt => opt.MapFrom(src => src.BegrensetForekomstNA))

                .ForPath(dest => dest.C1.Statistics, opt => opt.MapFrom(src => src.C1PågåendePopulasjonsreduksjonAntatt))
                .ForPath(dest => dest.C1.ThresholdValue, opt => opt.MapFrom(src => src.C1PågåendePopulasjonsreduksjonKode))

                .ForPath(dest => dest.C2Ai.Statistics, opt => opt.MapFrom(src => src.C2A1PågåendePopulasjonsreduksjonAntatt))
                .ForPath(dest => dest.C2Ai.ThresholdValue, opt => opt.MapFrom(src => src.C2A1PågåendePopulasjonsreduksjonKode))

                .ForPath(dest => dest.C2Aii.ThresholdValue, opt => opt.MapFrom(src => src.C2A2PågåendePopulasjonsreduksjonKode))
                .ForPath(dest => dest.C2Aii.PercentageOneSubpop, opt => opt.MapFrom(src => src.C2A2ReproduksjonsdyktigeIndivid))
                .ForPath(dest => dest.C2Aii.TruthValue, opt => opt.MapFrom(src => src.C2A2SannhetsverdiKode))

                .ForMember(dest => dest.C2bExtremeFluctuations, opt => opt.MapFrom(src => src.C2BPågåendePopulasjonsreduksjonKode))

                .ForPath(dest => dest.C.GenetsPerLocation, opt => opt.MapFrom(src => src.CAntallGeneter))
                .ForPath(dest => dest.C.RametsPerGenet, opt => opt.MapFrom(src => src.CAntallRameter))
                .ForPath(dest => dest.C.KnownPopulationSize, opt => opt.MapFrom(src => src.CKjentPopulasjonsstørrelse))
                .ForPath(dest => dest.C.NumberOfLocations, opt => opt.MapFrom(src => src.CNumberOfLocations))
                .ForPath(dest => dest.C.IndirectEstimate, opt => opt.MapFrom(src => src.CPopulasjonsstørrelse))
                .ForPath(dest => dest.C.Statistics, opt => opt.MapFrom(src => src.CPopulasjonsstørrelseAntatt))
                .ForPath(dest => dest.C.PreliminaryCategory, opt => opt.MapFrom(src => src.CPopulasjonsstørrelseKode))
                .ForPath(dest => dest.C.IndividualsPerLocation, opt => opt.MapFrom(src => src.CReproductionDefinitionPerLocation))
                .ForPath(dest => dest.C.IndividualsPerSubstrateUnit, opt => opt.MapFrom(src => src.CReproductionDefinitionPerTree))
                .ForPath(dest => dest.C.IndividualsPerAreaValue, opt => opt.MapFrom(src => src.CReproductionDefinitionTemplate))
                .ForPath(dest => dest.C.IndividualsPerAreaUnit, opt => opt.MapFrom(src => src.CReproductionDefinitionTemplateScale))
                .ForPath(dest => dest.C.SubstrateUnitsPerLocation, opt => opt.MapFrom(src => src.CSubstratenheter))

                .ForMember(dest => dest.D1PreliminaryCategory, opt => opt.MapFrom(src => src.D1FåReproduserendeIndividKode))
                .ForMember(dest => dest.D2PreliminaryCategory, opt => opt.MapFrom(src => src.D2MegetBegrensetForekomstarealKode))
                
                .ForMember(dest => dest.ExpertCommittee, opt => opt.MapFrom(src => SpeciesAssessment2021ProfileHelper.RemoveAssessmentArea(src.Ekspertgruppe)))
                .ForMember(dest => dest.SpeciesGroup, opt => opt.MapFrom(src => SpeciesAssessment2021ProfileHelper.ResolveSpeciesGroupName(src)))
                
                .ForMember(dest => dest.EPreliminaryCategory, opt => opt.MapFrom(src => src.EKvantitativUtryddingsmodellKode))
                
                .ForMember(dest => dest.GenerationLength, opt => opt.MapFrom(src => src.Generasjonslengde))
                
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Kategori))
                .ForMember(destination => destination.Category, opt => opt.NullSubstitute(string.Empty))

                .ForMember(dest => dest.CategoryAdjustedFrom, opt => opt.MapFrom(src => src.KategoriEndretFra))
                .ForMember(dest => dest.CategoryAdjustedTo, opt => opt.MapFrom(src => src.KategoriEndretTil))

                .ForMember(dest => dest.ExpertStatement, opt => opt.MapFrom(src => HtmlCleaner.MakeHtmlSafe(src.Kriteriedokumentasjon, true)))

                .ForMember(dest => dest.CriteriaSummarized, opt => opt.MapFrom(src => src.Kriterier))

                .ForMember(dest => dest.RationaleNotEvaluated, opt => opt.MapFrom(src => src.KunnskapsStatusNE))
                .ForMember(dest => dest.PercentageEuropeanPopulation, opt => opt.MapFrom(src => src.MaxAndelAvEuropeiskBestand))
                .ForMember(dest => dest.PercentageGlobalPopulation, opt => opt.MapFrom(src => src.MaxAndelAvGlobalBestand))
                .ForMember(dest => dest.MainHabitat, opt => opt.MapFrom(src => src.NaturtypeHovedenhet))

                .ForMember(dest => dest.AssessmentInitialClassification, opt => opt.MapFrom(src => src.OverordnetKlassifiseringGruppeKode))
                
                .ForMember(dest => dest.PopularName, opt => opt.MapFrom(src => src.PopularName))
                .ForMember(destination => destination.PopularName, opt => opt.NullSubstitute(string.Empty))
                
                .ForMember(dest => dest.ImpactFactors, opt => opt.MapFrom(src => src.Påvirkningsfaktorer.OrderBy(x=>x.Id)))

                .ForMember(dest => dest.References, opt => opt.MapFrom(src => src.Referanser))

                .ForMember(dest => dest.EvaluationJustification, opt => opt.MapFrom(src => src.RodlisteVurdertArt))
                .ForMember(dest => dest.YearPreviousAssessment, opt => opt.MapFrom(src => src.SistVurdertAr))

                .ForMember(dest => dest.TaxonomicHistory, opt => opt.MapFrom(src => src.TaxonomicHistory))

                .ForMember(dest => dest.TaxonRank, opt => opt.MapFrom(src => src.TaxonRank))

                .ForMember(dest => dest.PresumedExtinct, opt => opt.MapFrom(src => src.TroligUtdodd))
                .ForMember(dest => dest.RationaleRegionallyExtinct, opt => opt.MapFrom(src => src.UtdoddINorgeRE))

                .ForMember(dest => dest.ExtinctionRiskAffected, opt => opt.MapFrom(src => src.UtdøingSterktPåvirket))

                .ForMember(dest => dest.AssessmentArea, opt => opt.MapFrom(src => src.VurderingsContext))
                .ForMember(dest => dest.AssessmentYear, opt => opt.MapFrom(src => src.Vurderingsår))

                .ForMember(dest => dest.ScientificName, opt => opt.MapFrom(src => src.VurdertVitenskapeligNavn))
                .ForMember(dest => dest.ScientificNameAuthor, opt => opt.MapFrom(src => src.VurdertVitenskapeligNavnAutor))

                .ForMember(dest => dest.VurdertVitenskapeligNavnHierarki, opt => opt.MapFrom(src => src.VurdertVitenskapeligNavnHierarki))

                .ForMember(dest => dest.ScientificNameId, opt => opt.MapFrom(src => src.VurdertVitenskapeligNavnId))

                .ForMember(dest => dest.ReasonCategoryChange, opt => opt.MapFrom(src => src.ÅrsakTilEndringAvKategori))
                .ForMember(dest => dest.ÅrsakTilNedgraderingAvKategori, opt => opt.MapFrom(src => src.ÅrsakTilNedgraderingAvKategori))
                .AfterMap((src, dest) =>
                {
                    if (dest.Category == "LCº")
                    {
                        dest.CriteriaSummarized = string.Empty;
                    }
                });
        }

        #region CorrectImpactFactors

        private static Dictionary<string, string> _replaceTextDictionary = new()
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
        private static Dictionary<string, string> _replaceIdDictionary = new()
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

        private static Dictionary<string, Tuple<string, string, string>> mapImpactfactor2010Dictionary =
            new Dictionary<string, Tuple<string, string, string>>
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
                },
            };

        private static Dictionary<string, Tuple<string, string>> fixImpactfactor2010Dictionary =
            new Dictionary<string, Tuple<string, string>>
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

        private static string _uttakAvDødVedStåendeGaddOgLiggendeLæger = "Uttak av død ved (stående gadd og liggende læger)";
        private static void CorrectImpactFactors(Rodliste2019.Pavirkningsfaktor src, SpeciesAssessment2021ImpactFactor dest)
        {
            var pOverordnetTittel = src.OverordnetTittel;
            var pBeskrivelse = src.Beskrivelse;
            var pId = src.Id;

            // map old 2010 factors to correct id and text
            foreach (var item in mapImpactfactor2010Dictionary.Where(item => item.Key == pId.Trim() + pBeskrivelse.Trim()))
            {
                //Console.WriteLine(assessment.VurdertVitenskapeligNavn);
                pBeskrivelse = item.Value.Item2;
                pId = item.Value.Item1;
                pOverordnetTittel = item.Value.Item3;
            }

            // fix som old texts 
            foreach (var item in fixImpactfactor2010Dictionary.Where(item => item.Key == pId.Trim()))
            {
                //Console.WriteLine(assessment.VurdertVitenskapeligNavn);
                if (pBeskrivelse != item.Value.Item1)
                {
                    pBeskrivelse = item.Value.Item1;
                }

                //pId = item.Value.Item1;
                if (pOverordnetTittel == item.Value.Item2)
                {
                    pOverordnetTittel = item.Value.Item2;
                }
            }

            foreach (var item in _replaceTextDictionary.Where(item =>
                pOverordnetTittel.IndexOf(item.Key, StringComparison.InvariantCulture) > -1))
            {
                pOverordnetTittel = pOverordnetTittel.Replace(item.Key, item.Value, StringComparison.InvariantCulture);
            }

            foreach (var item in _replaceTextDictionary.Where(item =>
                pBeskrivelse.IndexOf(item.Key, StringComparison.InvariantCulture) > -1))
            {
                pBeskrivelse = pBeskrivelse.Replace(item.Key, item.Value, StringComparison.InvariantCulture);
            }

            foreach (var item in _replaceIdDictionary.Where(item => pId == item.Key))
            {
                pId = item.Value;
            }

            var level = dest.Id.Split(".", StringSplitOptions.RemoveEmptyEntries).Length;

            if (pId == "1.1.2.1.4." || pId == "1.2.4.1.")
            {
                // fjern alternativ med * og " brukt i disse
                pBeskrivelse = _uttakAvDødVedStåendeGaddOgLiggendeLæger;
            }

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

        #endregion
    }
}