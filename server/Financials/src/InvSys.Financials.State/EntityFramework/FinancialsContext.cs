using InvSys.Financials.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InvSys.Financials.State.EntityFramework
{
    public class FinancialsContext : DbContext
    {
        private readonly IConfigurationRoot _config;

        public FinancialsContext() { }

        public FinancialsContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
        }

        public DbSet<BalanceSheet> BalanceSheets { get; set; }
        public DbSet<CashFlow> CashFlows { get; set; }
        public DbSet<IncomeStatement> IncomeStatements { get; set; }
        public DbSet<RatioCalculation> RatioCalculations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Financials;Integrated Security=SSPI;integrated security=true;MultipleActiveResultSets=True;");
            //optionsBuilder.UseSqlServer("Data Source=EPPLKATW0006\\SQLEXPRESS;Initial Catalog=Financials;User Id=sa;Password=TODO;MultipleActiveResultSets =True;");
            //optionsBuilder.UseSqlServer(_config["ConnectionStrings:WatchlistsContextConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
