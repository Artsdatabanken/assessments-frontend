using Assessments.Transformation.Database.Rodliste2020.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessments.Transformation.Database.Rodliste2020
{
    public class Rodliste2020Context : DbContext
    {
        public Rodliste2020Context() { }

        public Rodliste2020Context(DbContextOptions<Rodliste2020Context> options)
            : base(options) { }

        public virtual DbSet<Assessment> Assessments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // database stored locally
                optionsBuilder.UseSqlServer("Server=.;Database=Rodliste2020;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.HasIndex(e => e.Expertgroup, "IX_Assessments_Expertgroup");

                entity.HasIndex(e => e.Category, "NonClusteredIndex-20200316-102610");

                entity.Property(e => e.AssessmentContext)
                    .HasMaxLength(10)
                    .HasComputedColumnSql("(CONVERT([nvarchar](10),json_value([Doc],'$.VurderingsContext')))", false);

                entity.Property(e => e.AssessmentYear).HasComputedColumnSql("(CONVERT([int],json_value([Doc],'$.\"Vurderingsår\"')))", false);

                entity.Property(e => e.Category)
                    .HasMaxLength(5)
                    .HasComputedColumnSql("(CONVERT([nvarchar](5),json_value([Doc],'$.Kategori')))", false);

                entity.Property(e => e.CategoryLastRedList)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([Doc],'$.KategoriFraForrigeListe')))", false);

                entity.Property(e => e.Criteria)
                    .HasMaxLength(50)
                    .HasComputedColumnSql("(CONVERT([nvarchar](50),json_value([Doc],'$.Kriterier')))", false);

                entity.Property(e => e.Doc).IsRequired();

                entity.Property(e => e.EvaluationStatus)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([Doc],'$.EvaluationStatus')))", false);

                entity.Property(e => e.Expertgroup)
                    .HasMaxLength(150)
                    .HasComputedColumnSql("(CONVERT([nvarchar](150),json_value([Doc],'$.Ekspertgruppe')))", false);

                entity.Property(e => e.IsDeleted).HasComputedColumnSql("(CONVERT([bit],case when json_value([Doc],'$.Slettet')='true' then (1) else (0) end))", false);

                entity.Property(e => e.LastUpdatedAt).HasComputedColumnSql("(CONVERT([datetime2],json_value([Doc],'$.LastUpdatedOn'),(112)))", false);

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([Doc],'$.LastUpdatedBy')))", false);

                entity.Property(e => e.LockedForEditAt).HasComputedColumnSql("(CONVERT([datetime2],json_value([Doc],'$.LockedForEditAt'),(112)))", false);

                entity.Property(e => e.LockedForEditByUser)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([Doc],'$.LockedForEditByUser')))", false);

                entity.Property(e => e.NatureTypes)
                    .HasMaxLength(500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](500),json_value([Doc],'$.NaturtypeHovedenhet')))", false);

                entity.Property(e => e.PopularName)
                    .HasMaxLength(300)
                    .HasComputedColumnSql("(CONVERT([nvarchar](300),json_value([Doc],'$.PopularName')))", false);

                entity.Property(e => e.RedListAssessedSpecies)
                    .HasMaxLength(100)
                    .HasComputedColumnSql("(CONVERT([nvarchar](100),json_value([Doc],'$.RodlisteVurdertArt')))", false);

                entity.Property(e => e.ScientificName)
                    .HasMaxLength(601)
                    .HasComputedColumnSql("(CONVERT([nvarchar](300),json_value([Doc],'$.VurdertVitenskapeligNavn'))+isnull(' '+CONVERT([nvarchar](300),json_value([Doc],'$.VurdertVitenskapeligNavnAutor')),''))", false);

                entity.Property(e => e.ScientificNameId).HasComputedColumnSql("(CONVERT([int],json_value([Doc],'$.VurdertVitenskapeligNavnId')))", false);

                entity.Property(e => e.TaxonHierarcy)
                    .HasMaxLength(1500)
                    .HasComputedColumnSql("(CONVERT([nvarchar](1500),json_value([Doc],'$.VurdertVitenskapeligNavnHierarki')))", false);
            });
        }
    }
}
