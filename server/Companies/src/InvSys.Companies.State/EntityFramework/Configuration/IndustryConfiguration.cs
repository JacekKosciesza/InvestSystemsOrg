using InvSys.Companies.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvSys.Companies.State.EntityFramework.Configuration
{
    public static class IndustryConfiguration
    {
        public static void IndustryModelBuilder(EntityTypeBuilder<Industry> builder)
        {
            builder.HasMany(c => c.Translations).WithOne(t => t.Industry).HasForeignKey(t => t.IndustryId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Sectors).WithOne(t => t.Industry).HasForeignKey(t => t.IndustryId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Property(c => c.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            builder.Property(c => c.Source).HasMaxLength(300);
        }

        public static void IndustryTranslationModelBuilder(EntityTypeBuilder<IndustryTranslation> builder)
        {
            builder.ToTable("IndustryTranslations");
            builder.HasKey(t => new { t.IndustryId, t.Culture });
            builder.Property(c => c.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            builder.Property(c => c.Description).HasMaxLength(3000);
        }
    }
}
