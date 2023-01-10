using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Assessments.Transformation.Database.Fab4.Models;
using System.Net.Mail;
using Attachment = Assessments.Transformation.Database.Fab4.Models.Attachment;

namespace Assessments.Transformation.Database.Fab4
{
    public partial class Fab4Context : DbContext
    {
        public Fab4Context()
        {
        }

        public Fab4Context(DbContextOptions<Fab4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Assessment> Assessments { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRoleInExpertGroup> UserRoleInExpertGroups { get; set; }

        public virtual DbSet<Models.Attachment> Attachments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Fab4;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

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

                entity.HasOne(d => d.LastUpdatedByUser)
                    .WithMany(p => p.AssessmentLastUpdatedByUsers)
                    .HasForeignKey(d => d.LastUpdatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.LockedForEditByUser)
                    .WithMany(p => p.AssessmentLockedForEditByUsers)
                    .HasForeignKey(d => d.LockedForEditByUserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Application).HasMaxLength(2000);

                entity.Property(e => e.DateCreated).HasDefaultValueSql("('2020-01-01T00:00:00.0000000')");

                entity.Property(e => e.DateLastActive).HasDefaultValueSql("('2020-01-01T00:00:00.0000000')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<UserRoleInExpertGroup>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ExpertGroupName });

                entity.ToTable("UserRoleInExpertGroup");

                entity.Property(e => e.ExpertGroupName).HasMaxLength(200);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoleInExpertGroups)
                    .HasForeignKey(d => d.UserId);
            });

            // attachemnts
            modelBuilder.Entity<Attachment>(e =>
            {
                e.HasKey(x => x.Id);
                e.HasOne(x => x.Assessment).WithMany(x => x.Attachments).OnDelete(DeleteBehavior.NoAction).IsRequired();
                e.Property(x => x.IsDeleted).IsRequired();
                e.Property(x => x.File).IsRequired();
                e.Property(x => x.Type).IsRequired().HasMaxLength(300);
                e.Property(x => x.Date).IsRequired();
                e.Property(x => x.FileName).IsRequired().HasMaxLength(1000);
                e.Property(x => x.Name).IsRequired().HasMaxLength(2000);
                e.HasOne(x => x.User).WithMany().OnDelete(DeleteBehavior.NoAction).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
