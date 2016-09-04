using InvSys.Companies.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvSys.Companies.State.EntityFramework.Configuration
{
    public static class SectorConfiguration
    {
        public static void SectorModelBuilder(EntityTypeBuilder<Sector> builder)
        {
            builder.HasMany(c => c.Translations).WithOne(t => t.Sector).HasForeignKey(t => t.SectorId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Subsectors).WithOne(t => t.Sector).HasForeignKey(t => t.SectorId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Property(c => c.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            builder.Property(c => c.Source).IsRequired().HasMaxLength(300);
        }

        public static void SectorTranslationModelBuilder(EntityTypeBuilder<SectorTranslation> builder)
        {
            builder.ToTable("SectorTranslations");
            builder.HasKey(t => new { t.SectorId, t.Culture });
            builder.Property(c => c.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            builder.Property(c => c.Description).IsRequired().HasMaxLength(3000);
        }
    }
}
