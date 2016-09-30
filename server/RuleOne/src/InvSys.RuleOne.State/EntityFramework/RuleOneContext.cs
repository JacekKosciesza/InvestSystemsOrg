using InvSys.RuleOne.Core.Models;
using InvSys.RuleOne.Core.Models.Management;
using InvSys.RuleOne.Core.Models.ThreeTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InvSys.RuleOne.State.EntityFramework
{
    public class RuleOneContext : DbContext
    {
        private readonly IConfigurationRoot _config;

        public RuleOneContext() { }

        public RuleOneContext(IConfigurationRoot config, DbContextOptions options) // TODO: check DbContextOptions vs DbContextOptions<RuleOneContext>
            : base(options)
        {
            _config = config;
        }

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<EMAData> EMA { get; set; }
        public DbSet<MACDData> MACD { get; set; }
        public DbSet<StochasticData> Stochastic { get; set; }
        public DbSet<Moat> Moats { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Meaning> Meanings { get; set; }

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
