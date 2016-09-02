using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using InvSys.StockQuotes.State.EntityFramework;

namespace InvSys.StockQuotes.State.EntityFramework.Migrations
{
    [DbContext(typeof(StockQuotesContext))]
    [Migration("20160902123324_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InvSys.StockQuotes.Core.Models.HistoricalQuote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AdjClose");

                    b.Property<decimal>("Close");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("High");

                    b.Property<decimal>("Low");

                    b.Property<decimal>("Open");

                    b.Property<string>("Symbol");

                    b.Property<long>("Volume");

                    b.HasKey("Id");

                    b.ToTable("HistoricalQuotes");
                });
        }
    }
}
