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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //if (!optionsBuilder.IsConfigured)
            //{
                optionsBuilder.UseSqlServer(_config != null
                    ? _config["ConnectionStrings:CompaniesContextConnection"]
                    : "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Companies;Integrated Security=SSPI;integrated security=true;MultipleActiveResultSets=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(CompanyConfiguration.CompanyModelBuilder);
            modelBuilder.Entity<CompanyTranslation>(CompanyConfiguration.CompanyTranslationModelBuilder);
        }
    }
}
