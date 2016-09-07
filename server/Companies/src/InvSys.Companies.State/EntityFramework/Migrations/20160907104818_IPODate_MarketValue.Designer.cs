using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InvSys.Companies.State.EntityFramework;

namespace InvSys.Companies.State.EntityFramework.Migrations
{
    [DbContext(typeof(CompaniesContext))]
    [Migration("20160907104818_IPODate_MarketValue")]
    partial class IPODate_MarketValue
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvSys.Companies.Core.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("Exchange");

                    b.Property<string>("Fax");

                    b.Property<DateTime?>("IPODate");

                    b.Property<Guid?>("IndustryId");

                    b.Property<int?>("LogoId");

                    b.Property<string>("MarketValue");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Phone");

                    b.Property<Guid?>("SectorId");

                    b.Property<Guid?>("SubsectorId");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("IndustryId");

                    b.HasIndex("LogoId");

                    b.HasIndex("SectorId");

                    b.HasIndex("SubsectorId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.CompanyTranslation", b =>
                {
                    b.Property<Guid>("CompanyId");

                    b.Property<string>("Culture");

                    b.Property<string>("Address");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 3000);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Website");

                    b.HasKey("CompanyId", "Culture");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyTranslations");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.Industry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Source")
                        .HasAnnotation("MaxLength", 300);

                    b.Property<Guid>("SubsectorId");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("SubsectorId");

                    b.ToTable("Industries");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.IndustryTranslation", b =>
                {
                    b.Property<Guid>("IndustryId");

                    b.Property<string>("Culture");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 3000);

                    b.Property<string>("Name");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("IndustryId", "Culture");

                    b.HasIndex("IndustryId");

                    b.ToTable("IndustryTranslations");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.Logo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Default");

                    b.Property<string>("Logomark");

                    b.Property<string>("Logotype");

                    b.Property<string>("Square");

                    b.HasKey("Id");

                    b.ToTable("Logo");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.Sector", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Source")
                        .HasAnnotation("MaxLength", 300);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.SectorTranslation", b =>
                {
                    b.Property<Guid>("SectorId");

                    b.Property<string>("Culture");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 3000);

                    b.Property<string>("Name");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("SectorId", "Culture");

                    b.HasIndex("SectorId");

                    b.ToTable("SectorTranslations");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.Subsector", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("SectorId");

                    b.Property<string>("Source")
                        .HasAnnotation("MaxLength", 300);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.ToTable("Subsectors");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.SubsectorTranslation", b =>
                {
                    b.Property<Guid>("SubsectorId");

                    b.Property<string>("Culture");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 3000);

                    b.Property<string>("Name");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("SubsectorId", "Culture");

                    b.HasIndex("SubsectorId");

                    b.ToTable("SubsectorTranslations");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.Company", b =>
                {
                    b.HasOne("InvSys.Companies.Core.Models.Industry", "Industry")
                        .WithMany()
                        .HasForeignKey("IndustryId");

                    b.HasOne("InvSys.Companies.Core.Models.Logo", "Logo")
                        .WithMany()
                        .HasForeignKey("LogoId");

                    b.HasOne("InvSys.Companies.Core.Models.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId");

                    b.HasOne("InvSys.Companies.Core.Models.Subsector", "Subsector")
                        .WithMany()
                        .HasForeignKey("SubsectorId");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.CompanyTranslation", b =>
                {
                    b.HasOne("InvSys.Companies.Core.Models.Company", "Company")
                        .WithMany("Translations")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.Industry", b =>
                {
                    b.HasOne("InvSys.Companies.Core.Models.Subsector", "Subsector")
                        .WithMany("Industries")
                        .HasForeignKey("SubsectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.IndustryTranslation", b =>
                {
                    b.HasOne("InvSys.Companies.Core.Models.Industry", "Industry")
                        .WithMany("Translations")
                        .HasForeignKey("IndustryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.SectorTranslation", b =>
                {
                    b.HasOne("InvSys.Companies.Core.Models.Sector", "Sector")
                        .WithMany("Translations")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.Subsector", b =>
                {
                    b.HasOne("InvSys.Companies.Core.Models.Sector", "Sector")
                        .WithMany("Subsectors")
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.SubsectorTranslation", b =>
                {
                    b.HasOne("InvSys.Companies.Core.Models.Subsector", "Subsector")
                        .WithMany("Translations")
                        .HasForeignKey("SubsectorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
