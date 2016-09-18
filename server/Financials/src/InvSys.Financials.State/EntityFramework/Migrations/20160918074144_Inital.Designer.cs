using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InvSys.Financials.State.EntityFramework;

namespace InvSys.Financials.State.EntityFramework.Migrations
{
    [DbContext(typeof(FinancialsContext))]
    [Migration("20160918074144_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvSys.Financials.Core.Models.FinancialData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cash");

                    b.Property<string>("CompanySymbol");

                    b.Property<string>("Currency");

                    b.Property<decimal>("Debt");

                    b.Property<decimal>("Dividends");

                    b.Property<double>("EPS");

                    b.Property<decimal>("Equity");

                    b.Property<double>("ROIC");

                    b.Property<decimal>("Revenue");

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.ToTable("Data");
                });
        }
    }
}
