using InvSys.StockQuotes.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace InvSys.StockQuotes.State.EntityFramework
{
    public class StockQuotesContext : DbContext
    {
        private readonly IConfigurationRoot _config;

        public StockQuotesContext() { }

        public StockQuotesContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
        }

        public DbSet<HistoricalQuote> HistoricalQuotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SockQuotes;Integrated Security=SSPI;integrated security=true;MultipleActiveResultSets=True;");
            //optionsBuilder.UseSqlServer("Data Source=EPPLKATW0006\\SQLEXPRESS;Initial Catalog=SockQuotes;User Id=sa;Password=TODO;MultipleActiveResultSets =True;");
            //optionsBuilder.UseSqlServer(_config["ConnectionStrings:SockQuotesContextConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistoricalQuote>(ConfigureHistoricalQuote);
        }

        private static void ConfigureHistoricalQuote(EntityTypeBuilder<HistoricalQuote> builder)
        {
        }
    }
}
