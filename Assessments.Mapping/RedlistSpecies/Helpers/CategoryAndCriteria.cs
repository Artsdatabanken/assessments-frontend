using System;

namespace Assessments.Mapping.RedlistSpecies.Helpers
{
    public class CategoryAndCriteria
    {
        public CategoryAndCriteria()
        {
            Kategori = "";
            Allebruktekriterier = "";
            Kriterie = "";
        }
        public CategoryAndCriteria(string kategori, string allebruktekriterier) : this(kategori, allebruktekriterier, allebruktekriterier) { }

        public CategoryAndCriteria(string kategori, string allebruktekriterier, string kriterie)
        {
            string kat = kategori.Substring(0, Math.Min(kategori.Length, 2));
            string allekrit = string.IsNullOrEmpty(kriterie) ? "" : allebruktekriterier ?? "";
            string uts = string.IsNullOrEmpty(kriterie) ? allekrit : kriterie;

            Kategori = kategori;
            Allebruktekriterier = allekrit;
            Kriterie = uts;
        }
        public string Kategori { get; set; } = "";
        public string Allebruktekriterier { get; private set; } = "";
        public string Kriterie { get; set; } = "";
        public string KategoriEndretFra { get; internal set; }
    }
}