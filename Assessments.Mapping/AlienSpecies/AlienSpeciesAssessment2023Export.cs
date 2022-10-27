using System.ComponentModel;

namespace Assessments.Mapping.AlienSpecies
{
    public class AlienSpeciesAssessment2023Export
    {
        [DisplayName("Id for vurderingen")]
        [Description("Id for 2023 vurderingen")]
        public int Id { get; set; }

        [DisplayName("Ekspertgruppe")]
        [Description("Ekspertgruppen bak 2023-vurderingen")]
        public string ExpertGroup { get; set; }

        [DisplayName("Vitenskapelig navn")]
        [Description("Gyldig vitenskapelig navn i henhold til Artsnavnebasen")]
        public string ScientificName { get; set; }

        [DisplayName("Fremmedartsstatus")]
        [Description("Om arten er selvstendig reproduserende, en dørstokkart, regionalt fremmed osv.")]
        public string AlienSpeciesCategory { get; set; }

        [DisplayName("Etableringsklasse")]
        [Description("Angir etableringsklassen arten har i Norge i dag. Går fra laveste kategori (A) Arten forekommer ikke Norge til høyeste kategori (E) Arten har etter introduksjonen selv spredd seg til og etablert [2.2.] seg i minst ti ytterligere forekomster i norsk natur")]
        public string EstablishmentCategory { get; set; }

        [DisplayName("Risikokategori")]
        [Description("Endelig kategori i 2023 etter GEIAAS kategorier and kriterier")]
        public string Category { get; set; }

        [DisplayName("Utslagsgivende kriterier")]
        [Description("Utslagsgivende kriterier i 2023 etter GEIAAS metoden")]
        public string Criteria { get; set; }

        [DisplayName("Skår Invasjonspotensial")]
        [Description("...")]
        public int? ScoreInvationPotential { get; set; }

        [DisplayName("Skår Økologisk Effekt")]
        [Description("...")]
        public int? ScoreEcologicalEffect { get; set; }
    }
}
