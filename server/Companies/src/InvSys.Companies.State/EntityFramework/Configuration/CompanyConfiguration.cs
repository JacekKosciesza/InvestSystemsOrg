using InvSys.Companies.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvSys.Companies.State.EntityFramework.Configuration
{
    public static class CompanyConfiguration
    {
        public static void CompanyModelBuilder(EntityTypeBuilder<Company> builder)
        {
            builder.HasMany(c => c.Translations).WithOne(t => t.Company).HasForeignKey(t => t.CompanyId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            //builder.HasAlternateKey(c => c.Symbol);
            //builder.HasIndex(c => c.Symbol).IsUnique();
            builder.Property(c => c.Symbol).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(100);
        }

        public static void CompanyTranslationModelBuilder(EntityTypeBuilder<CompanyTranslation> builder)
        {
            builder.ToTable("CompanyTranslations");
            builder.HasKey(t => new { t.CompanyId, t.Culture });
            builder.Property(c => c.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            builder.Property(c => c.Description).HasMaxLength(3000);
        }
    }
}
