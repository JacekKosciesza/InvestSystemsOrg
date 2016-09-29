using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InvSys.RuleOne.State.EntityFramework;

namespace InvSys.RuleOne.State.EntityFramework.Migrations
{
    [DbContext(typeof(RuleOneContext))]
    [Migration("20160929073348_Management")]
    partial class Management
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvSys.RuleOne.Core.Models.Management.Leader", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<string>("CompanySymbol");

                    b.Property<bool>("IsLevelFiveLeader");

                    b.Property<string>("Name");

                    b.Property<string>("Position");

                    b.HasKey("Id");

                    b.ToTable("Leaders");
                });

            modelBuilder.Entity("InvSys.RuleOne.Core.Models.Management.LeadershipExample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<bool>("IsPositive");

                    b.Property<Guid?>("LeaderId");

                    b.Property<string>("Reference");

                    b.HasKey("Id");

                    b.HasIndex("LeaderId");

                    b.ToTable("LeadershipExample");
                });

            modelBuilder.Entity("InvSys.RuleOne.Core.Models.Moat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Brand");

                    b.Property<string>("CompanySymbol");

                    b.Property<bool>("Price");

                    b.Property<bool>("Secret");

                    b.Property<bool>("Switching");

                    b.Property<bool>("Toll");

                    b.HasKey("Id");

                    b.ToTable("Moats");
                });

            modelBuilder.Entity("InvSys.RuleOne.Core.Models.Rating", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanySymbol");

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsWonderful");

                    b.HasKey("Id");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("InvSys.RuleOne.Core.Models.ThreeTools.EMAData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanySymbol");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("EMA");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("PriceAverage");

                    b.Property<decimal>("PriceSum");

                    b.HasKey("Id");

                    b.ToTable("EMA");
                });

            modelBuilder.Entity("InvSys.RuleOne.Core.Models.ThreeTools.MACDData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CompanySymbol");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("EMA12Day");

                    b.Property<decimal>("EMA26Day");

                    b.Property<decimal>("Histogram");

                    b.Property<decimal>("MACD");

                    b.Property<decimal>("MACDAverage");

                    b.Property<decimal>("MACDSum");

                    b.Property<decimal>("Price");

                    b.Property<decimal>("PriceAverage");

                    b.Property<decimal>("PriceSum");

                    b.Property<decimal>("Signal");

                    b.HasKey("Id");

                    b.ToTable("MACD");
                });

            modelBuilder.Entity("InvSys.RuleOne.Core.Models.ThreeTools.StochasticData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Close");

                    b.Property<string>("CompanySymbol");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("High");

                    b.Property<decimal>("HighestHigh");

                    b.Property<decimal>("Low");

                    b.Property<decimal>("LowestLow");

                    b.Property<decimal>("Open");

                    b.Property<decimal>("PercentD");

                    b.Property<decimal>("PercentK");

                    b.HasKey("Id");

                    b.ToTable("Stochastic");
                });

            modelBuilder.Entity("InvSys.RuleOne.Core.Models.Management.LeadershipExample", b =>
                {
                    b.HasOne("InvSys.RuleOne.Core.Models.Management.Leader")
                        .WithMany("LeadershipExamples")
                        .HasForeignKey("LeaderId");
                });
        }
    }
}
