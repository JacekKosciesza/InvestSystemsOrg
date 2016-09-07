using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvSys.Companies.State.EntityFramework.Migrations
{
    public partial class IPODate_MarketValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "IPODate",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MarketValue",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IPODate",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MarketValue",
                table: "Companies");
        }
    }
}
