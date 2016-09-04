using InvSys.Companies.Core.Models;
using InvSys.Companies.State.EntityFramework.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InvSys.Companies.State.EntityFramework
{
    public class CompaniesContext : DbContext
    {
        private readonly IConfigurationRoot _config;

        public CompaniesContext() { }

        public CompaniesContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Subsector> Subsectors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (_config != null)
            {
                optionsBuilder.UseSqlServer(_config["ConnectionStrings:CompaniesContextConnection"]);
            }
            else
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Companies;Integrated Security=SSPI;integrated security=true;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(CompanyConfiguration.CompanyModelBuilder);
            modelBuilder.Entity<CompanyTranslation>(CompanyConfiguration.CompanyTranslationModelBuilder);
            modelBuilder.Entity<Industry>(IndustryConfiguration.IndustryModelBuilder);
            modelBuilder.Entity<IndustryTranslation>(IndustryConfiguration.IndustryTranslationModelBuilder);
            modelBuilder.Entity<Sector>(SectorConfiguration.SectorModelBuilder);
            modelBuilder.Entity<SectorTranslation>(SectorConfiguration.SectorTranslationModelBuilder);
            modelBuilder.Entity<Subsector>(SubsectorConfiguration.SubsectorModelBuilder);
            modelBuilder.Entity<SubsectorTranslation>(SubsectorConfiguration.SubsectorTranslationModelBuilder);
        }
    }
}
