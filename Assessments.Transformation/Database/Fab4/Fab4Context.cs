using Assessments.Transformation.Database.Fab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessments.Transformation.Database.Fab4
{
    public class Fab4Context : DbContext
    {
        public Fab4Context() {}

        public Fab4Context(DbContextOptions<Fab4Context> options) : base(options) {}

        public virtual DbSet<Assessment> Assessments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // database stored locally
                optionsBuilder.UseSqlServer("Server=.;Database=fab4;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.HasIndex(e => e.ChangedAt, "IX_Assessments_ChangedAt");

                entity.HasIndex(e => e.Expertgroup, "IX_Assessments_Expertgroup");

                entity.HasIndex(e => e.LastUpdatedByUserId, "IX_Assessments_LastUpdatedByUserId");

                entity.HasIndex(e => e.LockedForEditByUserId, "IX_Assessments_LockedForEditByUserId");

                entity.Property(e => e.Doc).IsRequired();

                entity.Property(e => e.Expertgroup)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasComputedColumnSql("(isnull(CONVERT([nvarchar](150),json_value([Doc],'$.ExpertGroup')),'mangler'))", false);

                entity.Property(e => e.IsDeleted).HasComputedColumnSql("(CONVERT([bit],case when json_value([Doc],'$.IsDeleted')='true' then (1) else (0) end))", false);
            });

        }
    }
}
