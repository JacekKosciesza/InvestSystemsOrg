using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InvSys.Financials.State.EntityFramework.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Data",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cash = table.Column<decimal>(nullable: false),
                    CompanySymbol = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true),
                    Debt = table.Column<decimal>(nullable: false),
                    Dividends = table.Column<decimal>(nullable: false),
                    EPS = table.Column<double>(nullable: false),
                    Equity = table.Column<decimal>(nullable: false),
                    ROIC = table.Column<double>(nullable: false),
                    Revenue = table.Column<decimal>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Data", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Data");
        }
    }
}
