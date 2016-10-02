using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvSys.RuleOne.State.EntityFramework.Migrations
{
    public partial class FiveMoats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Moats");

            migrationBuilder.CreateTable(
                name: "FiveMoats",
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
                    table.PrimaryKey("PK_FiveMoats", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FiveMoats");

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
        }
    }
}
