using InvSys.Companies.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InvSys.Companies.State.EntityFramework.Configuration
{
    public static class SubsectorConfiguration
    {
        public static void SubsectorModelBuilder(EntityTypeBuilder<Subsector> builder)
        {
            builder.HasMany(c => c.Translations).WithOne(t => t.Subsector).HasForeignKey(t => t.SubsectorId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.Property(c => c.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            builder.Property(c => c.Source).HasMaxLength(300);
        }

        public static void SubsectorTranslationModelBuilder(EntityTypeBuilder<SubsectorTranslation> builder)
        {
            builder.ToTable("SubsectorTranslations");
            builder.HasKey(t => new { t.SubsectorId, t.Culture });
            builder.Property(c => c.Timestamp).ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
            builder.Property(c => c.Description).HasMaxLength(3000);
        }
    }
}
