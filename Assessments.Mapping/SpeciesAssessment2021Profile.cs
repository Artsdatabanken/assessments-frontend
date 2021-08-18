using Assessments.Mapping.Models.Source.Species;
using Assessments.Mapping.Models.Species;
using AutoMapper;

namespace Assessments.Mapping
{
    public class SpeciesAssessment2021Profile : Profile
    {
        public SpeciesAssessment2021Profile()
        {
            CreateMap<Rodliste2019.MinMaxProbable, SpeciesAssessment2021MinMaxProbable>();
            CreateMap<Rodliste2019.MinMaxProbableIntervall, SpeciesAssessment2021MinMaxProbableIntervall>();
            CreateMap<Rodliste2019.Reference, SpeciesAssessment2021Reference>();

            CreateMap<Rodliste2019.Fylkesforekomst, SpeciesAssessment2021RegionOccurrence>().ForMember(dest => dest.Fylke, opt => opt.MapFrom(src => ResolveRegion(src.Fylke)));

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

                .ForPath(dest => dest.B1.Quantile, opt => opt.MapFrom(src => src.B1BeregnetAreal))
                .ForPath(dest => dest.B1.Statistics, opt => opt.MapFrom(src => src.B1IntervallUtbredelsesområde))
                .ForPath(dest => dest.B1.PreliminaryCategory, opt => opt.MapFrom(src => src.B1UtbredelsesområdeKode))

                .ForPath(dest => dest.B2.Quantile, opt => opt.MapFrom(src => src.B2BeregnetAreal))
                .ForPath(dest => dest.B2.PreliminaryCategory, opt => opt.MapFrom(src => src.B2ForekomstarealKode))
                .ForPath(dest => dest.B2.Statistics, opt => opt.MapFrom(src => src.B2IntervallForekomstareal))

                .ForMember(dest => dest.BaiSevereFragmentation, opt => opt.MapFrom(src => src.BA1KraftigFragmenteringKode))

                .ForPath(dest => dest.BAii.PreliminaryCategory, opt => opt.MapFrom(src => src.BA2FåLokaliteterKode))
                .ForPath(dest => dest.BAii.Quantile, opt => opt.MapFrom(src => src.BA2FåLokaliteterProdukt))
                .ForPath(dest => dest.BAii.Statistics, opt => opt.MapFrom(src => src.BaIntervallAntallLokaliteter))

                .ForMember(dest => dest.BbContinuingDecline, opt => opt.MapFrom(src => src.BBPågåendeArealreduksjonKode))
                .ForMember(dest => dest.ExtremeFluctuations, opt => opt.MapFrom(src => src.BCEksterneFluktuasjonerKode))
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
                .ForPath(dest => dest.C.CPopulasjonsstørrelse, opt => opt.MapFrom(src => src.CPopulasjonsstørrelse))
                .ForPath(dest => dest.C.Statistics, opt => opt.MapFrom(src => src.CPopulasjonsstørrelseAntatt))
                .ForPath(dest => dest.C.PreliminaryCategory, opt => opt.MapFrom(src => src.CPopulasjonsstørrelseKode))
                .ForPath(dest => dest.C.IndividualsPerLocation, opt => opt.MapFrom(src => src.CReproductionDefinitionPerLocation))
                .ForPath(dest => dest.C.IndividualsPerSubstrateUnit, opt => opt.MapFrom(src => src.CReproductionDefinitionPerTree))
                .ForPath(dest => dest.C.IndividualsPerAreaValue, opt => opt.MapFrom(src => src.CReproductionDefinitionTemplate))
                .ForPath(dest => dest.C.IndividualsPerAreaUnit, opt => opt.MapFrom(src => src.CReproductionDefinitionTemplateScale))
                .ForPath(dest => dest.C.SubstrateUnitsPerLocation, opt => opt.MapFrom(src => src.CSubstratenheter))

                .ForMember(dest => dest.D1PreliminaryCategory, opt => opt.MapFrom(src => src.D1FåReproduserendeIndividKode))
                .ForMember(dest => dest.D2PreliminaryCategory, opt => opt.MapFrom(src => src.D2MegetBegrensetForekomstarealKode))
                .ForMember(dest => dest.ExpertCommittee, opt => opt.MapFrom(src => src.Ekspertgruppe))
                .ForMember(dest => dest.EPreliminaryCategory, opt => opt.MapFrom(src => src.EKvantitativUtryddingsmodellKode))
                


                

                .ForMember(dest => dest.GenerationLength, opt => opt.MapFrom(src => src.Generasjonslengde))
                .ForMember(dest => dest.ExpertStatement, opt => opt.MapFrom(src => src.Kriteriedokumentasjon.Trim()))

                .ForMember(dest => dest.CriteriaSummarized, opt => opt.MapFrom(src => src.Kriterier))

                .ForMember(dest => dest.RationaleNotEvaluated, opt => opt.MapFrom(src => src.KunnskapsStatusNE))
                .ForMember(dest => dest.PercentageEuropeanPopulation, opt => opt.MapFrom(src => src.MaxAndelAvEuropeiskBestand))
                .ForMember(dest => dest.PercentageGlobalPopulation, opt => opt.MapFrom(src => src.MaxAndelAvGlobalBestand))
                .ForMember(dest => dest.MainHabitat, opt => opt.MapFrom(src => src.NaturtypeHovedenhet))

                .ForMember(dest => dest.RedlistAssessmentClassification, opt => opt.MapFrom(src => src.OverordnetKlassifiseringGruppeKode))
                .ForMember(dest => dest.PopularName, opt => opt.MapFrom(src => src.PopularName))

                .ForMember(dest => dest.References, opt => opt.MapFrom(src => src.Referanser))

                .ForMember(dest => dest.EvaluationJustification, opt => opt.MapFrom(src => src.RodlisteVurdertArt))
                .ForMember(dest => dest.YearPreviousAssessment, opt => opt.MapFrom(src => src.SistVurdertAr))

                .ForMember(dest => dest.TaxonomicHistory, opt => opt.MapFrom(src => src.TaxonomicHistory))

                .ForMember(dest => dest.TaxonRank, opt => opt.MapFrom(src => src.TaxonRank))

                // TODO .ForMember(dest => dest.TilførselFraNaboland, opt => opt.MapFrom(src => src.TilførselFraNaboland))

                .ForMember(dest => dest.PresumedExtinct, opt => opt.MapFrom(src => src.TroligUtdodd))
                .ForMember(dest => dest.RationaleRE, opt => opt.MapFrom(src => src.UtdoddINorgeRE))

                // TODO .ForMember(dest => dest.UtdøingSterktPåvirket, opt => opt.MapFrom(src => src.UtdøingSterktPåvirket))

                .ForMember(dest => dest.AssessmentArea, opt => opt.MapFrom(src => src.VurderingsContext))
                .ForMember(dest => dest.AssessmentYear, opt => opt.MapFrom(src => src.Vurderingsår))

                .ForMember(dest => dest.ScientificName, opt => opt.MapFrom(src => src.VurdertVitenskapeligNavn))
                .ForMember(dest => dest.ScientificNameAuthor, opt => opt.MapFrom(src => src.VurdertVitenskapeligNavnAutor))

                // TODO .ForMember(dest => dest.VurdertVitenskapeligNavnHierarki, opt => opt.MapFrom(src => src.VurdertVitenskapeligNavnHierarki))

                .ForMember(dest => dest.ScientificNameId, opt => opt.MapFrom(src => src.VurdertVitenskapeligNavnId))

                // TODO .ForMember(dest => dest.ÅrsakTilEndringAvKategori, opt => opt.MapFrom(src => src.ÅrsakTilEndringAvKategori))
                // TODO .ForMember(dest => dest.ÅrsakTilNedgraderingAvKategori, opt => opt.MapFrom(src => src.ÅrsakTilNedgraderingAvKategori))

                // .ForAllOtherMembers(opts => opts.Ignore())
                ;
        }

        private static string ResolveRegion(string fylke)
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
    }
}