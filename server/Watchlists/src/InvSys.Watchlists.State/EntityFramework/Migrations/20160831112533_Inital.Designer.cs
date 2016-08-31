using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InvSys.Watchlists.State.EntityFramework;

namespace InvSys.Watchlists.State.EntityFramework.Migrations
{
    [DbContext(typeof(WatchlistsContext))]
    [Migration("20160831112533_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvSys.Watchlists.Core.Models.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyId");

                    b.Property<string>("CompanySymbol");

                    b.Property<Guid>("WatchlistId");

                    b.HasKey("Id");

                    b.HasIndex("WatchlistId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("InvSys.Watchlists.Core.Models.Watchlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid>("UserId");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Watchlists");
                });

            modelBuilder.Entity("InvSys.Watchlists.Core.Models.WatchlistTranslation", b =>
                {
                    b.Property<Guid>("WatchlistId");

                    b.Property<string>("Culture");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 3000);

                    b.Property<string>("Name");

                    b.Property<byte[]>("Timestamp")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("WatchlistId", "Culture");

                    b.HasIndex("WatchlistId");

                    b.ToTable("WatchlistTranslations");
                });

            modelBuilder.Entity("InvSys.Watchlists.Core.Models.Item", b =>
                {
                    b.HasOne("InvSys.Watchlists.Core.Models.Watchlist", "Watchlist")
                        .WithMany("Items")
                        .HasForeignKey("WatchlistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InvSys.Watchlists.Core.Models.WatchlistTranslation", b =>
                {
                    b.HasOne("InvSys.Watchlists.Core.Models.Watchlist", "Watchlist")
                        .WithMany("Translations")
                        .HasForeignKey("WatchlistId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
