using System.Reflection;
using Assessments.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Assessments.Data
{
    public class AssessmentsDbContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackAttachment> FeedbackAttachments { get; set; }

        public AssessmentsDbContext(DbContextOptions<AssessmentsDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}