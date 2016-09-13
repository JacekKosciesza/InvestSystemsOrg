using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InvSys.Companies.State.EntityFramework;

namespace InvSys.Companies.State.EntityFramework.Migrations
{
    [DbContext(typeof(CompaniesContext))]
    [Migration("20160913071239_Inital")]
    partial class Inital
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

                    b.Property<string>("Country");

                    b.Property<string>("Email");

                    b.Property<string>("Exchange");

                    b.Property<string>("Fax");

                    b.Property<DateTime?>("IPODate");

                    b.Property<string>("Logo");

                    b.Property<string>("MarketValue");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Phone");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.CompanyTranslation", b =>
                {
                    b.Property<Guid>("CompanyId");

                    b.Property<string>("Culture");

                    b.Property<string>("Address");

                    b.Property<string>("Description")
                        .HasAnnotation("MaxLength", 3000);

                    b.Property<string>("Industry");

                    b.Property<string>("Sector");

                    b.Property<string>("Subsector");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Website");

                    b.HasKey("CompanyId", "Culture");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyTranslations");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.Officer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompanyId");

                    b.Property<string>("Name");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Officer");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.Website", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("CompanyId");

                    b.Property<int>("Type");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Website");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.CompanyTranslation", b =>
                {
                    b.HasOne("InvSys.Companies.Core.Models.Company", "Company")
                        .WithMany("Translations")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.Officer", b =>
                {
                    b.HasOne("InvSys.Companies.Core.Models.Company")
                        .WithMany("Officers")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Models.Website", b =>
                {
                    b.HasOne("InvSys.Companies.Core.Models.Company")
                        .WithMany("Websites")
                        .HasForeignKey("CompanyId");
                });
        }
    }
}
