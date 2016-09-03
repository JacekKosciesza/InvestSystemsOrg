using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InvSys.Portfolios.State.EntityFramework;

namespace InvSys.Portfolios.State.EntityFramework.Migrations
{
    [DbContext(typeof(PortfoliosContext))]
    partial class PortfoliosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvSys.Portfolios.Core.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyId");

                    b.Property<string>("CompanySymbol");

                    b.Property<Guid>("PortfolioId");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("InvSys.Portfolios.Core.Models.Portfolio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("InvSys.Portfolios.Core.Models.PortfolioTranslation", b =>
                {
                    b.Property<Guid>("PortfolioId");

                    b.Property<string>("Culture");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 3000);

                    b.Property<string>("Name");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("PortfolioId", "Culture");

                    b.HasIndex("PortfolioId");

                    b.ToTable("PortfolioTranslations");
                });

            modelBuilder.Entity("InvSys.Portfolios.Core.Models.Item", b =>
                {
                    b.HasOne("InvSys.Portfolios.Core.Models.Portfolio", "Portfolio")
                        .WithMany("Items")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InvSys.Portfolios.Core.Models.PortfolioTranslation", b =>
                {
                    b.HasOne("InvSys.Portfolios.Core.Models.Portfolio", "Portfolio")
                        .WithMany("Translations")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
