using InvSys.RuleOne.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InvSys.RuleOne.State.EntityFramework
{
    public class RuleOneContext : DbContext
    {
        private readonly IConfigurationRoot _config;

        public RuleOneContext() { }

        public RuleOneContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
        }

        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            //if (!optionsBuilder.IsConfigured)
            //{
                optionsBuilder.UseSqlServer(_config != null
                    ? _config["ConnectionStrings:CompaniesContextConnection"]
                    : "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RuleOne;Integrated Security=SSPI;integrated security=true;MultipleActiveResultSets=True;");
            //}
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
