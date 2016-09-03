using InvSys.Portfolios.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace InvSys.Portfolios.State.EntityFramework
{
    public class PortfoliosContext : DbContext
    {
        private readonly IConfigurationRoot _config;

        public PortfoliosContext() { }

        public PortfoliosContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
        }

        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Item> Items { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Portfolios;Integrated Security=SSPI;integrated security=true;MultipleActiveResultSets=True;");
            //optionsBuilder.UseSqlServer("Data Source=EPPLKATW0006\\SQLEXPRESS;Initial Catalog=Portfolios;User Id=sa;Password=TODO;MultipleActiveResultSets =True;");
            //optionsBuilder.UseSqlServer(_config["ConnectionStrings:PortfoliosContextConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Portfolio>(ConfigurePortfolio);
            modelBuilder.Entity<PortfolioTranslation>(ConfigurePortfolioTranslation);
            modelBuilder.Entity<Item>(ConfigureItem);
        }

        private static void ConfigurePortfolio(EntityTypeBuilder<Portfolio> builder)
        {
            builder.HasMany(c => c.Translations).WithOne(t => t.Portfolio).HasForeignKey(t => t.PortfolioId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Property(c => c.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            builder.HasMany(c => c.Items).WithOne(t => t.Portfolio).HasForeignKey(t => t.PortfolioId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
        }

        private static void ConfigurePortfolioTranslation(EntityTypeBuilder<PortfolioTranslation> builder)
        {
            builder.ToTable("PortfolioTranslations");
            builder.HasKey(t => new { t.PortfolioId, t.Culture });
            builder.Property(c => c.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            builder.Property(c => c.Description).IsRequired().HasMaxLength(3000);
        }

        private static void ConfigureItem(EntityTypeBuilder<Item> builder)
        {
        }
    }
}
