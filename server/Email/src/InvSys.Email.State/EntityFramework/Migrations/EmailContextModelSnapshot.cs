using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InvSys.Email.State.EntityFramework;

namespace InvSys.Email.State.EntityFramework.Migrations
{
    [DbContext(typeof(EmailContext))]
    partial class EmailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvSys.Email.Core.Models.Template", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("InvSys.Email.Core.Models.TemplateTranslation", b =>
                {
                    b.Property<Guid>("TemplateId");

                    b.Property<string>("Culture");

                    b.Property<string>("Body");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 3000);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 200);

                    b.HasKey("TemplateId", "Culture");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateTranslations");
                });

            modelBuilder.Entity("InvSys.Email.Core.Models.TemplateTranslation", b =>
                {
                    b.HasOne("InvSys.Email.Core.Models.Template", "Template")
                        .WithMany("Translations")
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
