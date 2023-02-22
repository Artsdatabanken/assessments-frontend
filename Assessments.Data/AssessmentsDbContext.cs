using System.Reflection;
using Assessments.Data.Models;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assessments.Data
{
    public class AssessmentsDbContext : DbContext, IDataProtectionKeyContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<FeedbackAttachment> FeedbackAttachments { get; set; }

        public DbSet<EmailValidation> EmailValidations { get; set; }

        public DbSet<Log> Logs { get; set; }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

        public AssessmentsDbContext(DbContextOptions<AssessmentsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}