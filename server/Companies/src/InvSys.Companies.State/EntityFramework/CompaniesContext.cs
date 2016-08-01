using InvSys.Companies.Core.Model;
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

            //optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Companies;Integrated Security=SSPI;integrated security=true;MultipleActiveResultSets=True;");
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:CompaniesContextConnection"]);
        }
    }
}
