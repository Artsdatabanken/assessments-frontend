using System.ComponentModel;

namespace Assessments.Mapping.AlienSpecies
{
    public class AlienSpeciesAssessment2023Export
    {
        [DisplayName("Id for vurderingen")]
        [Description("Id for 2023 vurderingen")]
        public int Id { get; set; }

        [DisplayName("Ekspertkomité")]
        [Description("Ekspertgruppen bak 2023-vurderingen")]
        public string ExpertGroup { get; set; }

        [DisplayName("Taksonomisk sti")]
        [Description("Taksonomisk sti for arten")]
        public string TaxonHierarcy { get; set; }

        [DisplayName("Vitenskapelig navn id")]
        [Description("Gyldig vitenskapelig navn id ved vurderingstidspunkt, i henhold til Artsnavnebase")]
        public int ScientificNameId { get; set; }

        [DisplayName("Vitenskapelig navn")]
        [Description("Gyldig vitenskapelig navn i henhold til Artsnavnebase")]
        public string ScientificName { get; set; }

        [DisplayName("Autor")]
        [Description("Autor for gyldig vitenskapelig navn i henhold til Artsnavnebase")]
        public string ScientificNameAuthor { get; set; }

        [DisplayName("Populærnavn")]
        [Description("Prioritert norsk populærnavn i henhold til Artsnavnebase")]
        public string VernacularName { get; set; }

        [DisplayName("Fremmedartsstatus")]
        [Description("Om arten er selvstendig reproduserende, en dørstokkart, regionalt fremmed osv.")]
        public string AlienSpeciesCategory { get; set; }

        [DisplayName("Etableringsklasse")]
        [Description("Angir etableringsklassen arten har i Norge i dag. Går fra laveste kategori (A) Arten forekommer ikke Norge til høyeste kategori (E) Arten har etter introduksjonen selv spredd seg til og etablert [2.2.] seg i minst ti ytterligere forekomster i norsk natur")]
        public string EstablishmentCategory { get; set; }

        [DisplayName("Risikokategori 2023")]
        [Description("Endelig kategori i 2023 etter GEIAAS kategorier and kriterier")]
        public string Category { get; set; }

        [DisplayName("Utslagsgivende kriterier 2023")]
        [Description("Utslagsgivende kriterier i 2023 etter GEIAAS metoden")]
        public string Criteria { get; set; }

        [DisplayName("Skår Invasjonspotensial")]
        [Description("Artens delkategori (1-4) på invasjonsaksen i risikomatrisen. Denne bestemmes av artens invasjonspotensial.")]
        public int? ScoreInvationPotential { get; set; }

        [DisplayName("Skår Økologisk effekt")]
        [Description("Artens delkategori (1-4) på effektaksen i risikomatrisen. Denne bestemmes av artens økologiske effekt")]
        public int? ScoreEcologicalEffect { get; set; }
    }
}
