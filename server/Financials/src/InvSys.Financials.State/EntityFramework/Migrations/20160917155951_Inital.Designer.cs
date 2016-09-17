using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InvSys.Financials.State.EntityFramework;

namespace InvSys.Financials.State.EntityFramework.Migrations
{
    [DbContext(typeof(FinancialsContext))]
    [Migration("20160917155951_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvSys.Financials.Core.Models.BalanceSheet", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyId");

                    b.Property<string>("CompanySymbol");

                    b.Property<decimal>("Debt");

                    b.Property<decimal>("Equity");

                    b.Property<DateTime>("Year");

                    b.HasKey("Id");

                    b.ToTable("BalanceSheets");
                });

            modelBuilder.Entity("InvSys.Financials.Core.Models.CashFlow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyId");

                    b.Property<string>("CompanySymbol");

                    b.Property<decimal>("Dividends");

                    b.Property<decimal>("FreeCashFlow");

                    b.Property<DateTime>("Year");

                    b.HasKey("Id");

                    b.ToTable("CashFlows");
                });

            modelBuilder.Entity("InvSys.Financials.Core.Models.IncomeStatement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyId");

                    b.Property<string>("CompanySymbol");

                    b.Property<double>("EPS");

                    b.Property<decimal>("Revenue");

                    b.Property<DateTime>("Year");

                    b.HasKey("Id");

                    b.ToTable("IncomeStatements");
                });

            modelBuilder.Entity("InvSys.Financials.Core.Models.RatioCalculation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("CompanyId");

                    b.Property<string>("CompanySymbol");

                    b.Property<double>("ReturnOnCapital");

                    b.Property<DateTime>("Year");

                    b.HasKey("Id");

                    b.ToTable("RatioCalculations");
                });
        }
    }
}
