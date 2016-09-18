using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvSys.Financials.State.EntityFramework.Migrations
{
    public partial class Nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Revenue",
                table: "Data",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "ROIC",
                table: "Data",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Equity",
                table: "Data",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "EPS",
                table: "Data",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Dividends",
                table: "Data",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Debt",
                table: "Data",
                nullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cash",
                table: "Data",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Revenue",
                table: "Data",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "ROIC",
                table: "Data",
                nullable: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Equity",
                table: "Data",
                nullable: false);

            migrationBuilder.AlterColumn<double>(
                name: "EPS",
                table: "Data",
                nullable: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Dividends",
                table: "Data",
                nullable: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Debt",
                table: "Data",
                nullable: false);

            migrationBuilder.AlterColumn<decimal>(
                name: "Cash",
                table: "Data",
                nullable: false);
        }
    }
}
