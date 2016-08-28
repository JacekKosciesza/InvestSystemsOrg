using InvSys.Email.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;

namespace InvSys.Email.State.EntityFramework
{
    public class EmailContext : DbContext
    {
        private readonly IConfigurationRoot _config;

        public EmailContext() { }

        public EmailContext(IConfigurationRoot config, DbContextOptions options)
            : base(options)
        {
            _config = config;
        }

        public DbSet<Template> Templates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Email;Integrated Security=SSPI;integrated security=true;MultipleActiveResultSets=True;");
            //optionsBuilder.UseSqlServer("Data Source=EPPLKATW0006\\SQLEXPRESS;Initial Catalog=Email;User Id=sa;Password=TODO;MultipleActiveResultSets =True;");
            //optionsBuilder.UseSqlServer(_config["ConnectionStrings:EmailContextConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Template>(ConfigureTemplate);
            modelBuilder.Entity<TemplateTranslation>(ConfigureTemplateTranslation);

        }

        private static void ConfigureTemplate(EntityTypeBuilder<Template> builder)
        {
            builder.HasMany(c => c.Translations).WithOne(t => t.Template).HasForeignKey(t => t.TemplateId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasAlternateKey(c => c.Name);
            builder.HasIndex(c => c.Name).IsUnique();
            builder.Property(c => c.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
        }

        private static void ConfigureTemplateTranslation(EntityTypeBuilder<TemplateTranslation> builder)
        {
            builder.ToTable("TemplateTranslations");
            builder.HasKey(t => new { t.TemplateId, t.Culture });
            builder.Property(c => c.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            builder.Property(c => c.Description).IsRequired().HasMaxLength(3000);
            builder.Property(c => c.Title).IsRequired().HasMaxLength(200);
        }
    }
}
