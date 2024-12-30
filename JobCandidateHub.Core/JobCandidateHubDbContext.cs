using JobCandidateHub.Core.EntityConfiguration;
using JobCandidateHub.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace JobCandidateHub.Core
{
    public class JobCandidateHubDbContext : DbContext
    {
        IConfiguration Configuration { get; }
        public JobCandidateHubDbContext(DbContextOptions<JobCandidateHubDbContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }
        public DbSet<Candidate> Candidate { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(Configuration.GetConnectionString("Default"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateConfig());
            modelBuilder.Entity<Candidate>().HasIndex(x => x.Email).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
