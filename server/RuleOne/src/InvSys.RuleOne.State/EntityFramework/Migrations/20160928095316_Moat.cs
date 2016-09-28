using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InvSys.RuleOne.State.EntityFramework.Migrations
{
    public partial class Moat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Moats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Brand = table.Column<bool>(nullable: false),
                    CompanySymbol = table.Column<string>(nullable: true),
                    Price = table.Column<bool>(nullable: false),
                    Secret = table.Column<bool>(nullable: false),
                    Switching = table.Column<bool>(nullable: false),
                    Toll = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EMA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanySymbol = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    EMA = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PriceAverage = table.Column<decimal>(nullable: false),
                    PriceSum = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EMA", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MACD",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanySymbol = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    EMA12Day = table.Column<decimal>(nullable: false),
                    EMA26Day = table.Column<decimal>(nullable: false),
                    Histogram = table.Column<decimal>(nullable: false),
                    MACD = table.Column<decimal>(nullable: false),
                    MACDAverage = table.Column<decimal>(nullable: false),
                    MACDSum = table.Column<decimal>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PriceAverage = table.Column<decimal>(nullable: false),
                    PriceSum = table.Column<decimal>(nullable: false),
                    Signal = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MACD", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stochastic",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Close = table.Column<decimal>(nullable: false),
                    CompanySymbol = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    High = table.Column<decimal>(nullable: false),
                    HighestHigh = table.Column<decimal>(nullable: false),
                    Low = table.Column<decimal>(nullable: false),
                    LowestLow = table.Column<decimal>(nullable: false),
                    Open = table.Column<decimal>(nullable: false),
                    PercentD = table.Column<decimal>(nullable: false),
                    PercentK = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stochastic", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moats");

            migrationBuilder.DropTable(
                name: "EMA");

            migrationBuilder.DropTable(
                name: "MACD");

            migrationBuilder.DropTable(
                name: "Stochastic");
        }
    }
}
