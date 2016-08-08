using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InvSys.Companies.State.EntityFramework;

namespace InvSys.Companies.State.EntityFramework.Migrations
{
    [DbContext(typeof(CompaniesContext))]
    [Migration("20160808145647_EFConfiguration")]
    partial class EFConfiguration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvSys.Companies.Core.Model.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 100);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasAlternateKey("Symbol");

                    b.HasIndex("Symbol")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Model.CompanyTranslation", b =>
                {
                    b.Property<Guid>("CompanyId");

                    b.Property<string>("Culture");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 3000);

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("CompanyId", "Culture");

                    b.HasIndex("CompanyId");

                    b.ToTable("CompanyTranslations");
                });

            modelBuilder.Entity("InvSys.Companies.Core.Model.CompanyTranslation", b =>
                {
                    b.HasOne("InvSys.Companies.Core.Model.Company", "Company")
                        .WithMany("Translations")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
