using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvSys.Companies.State.EntityFramework.Migrations
{
    public partial class SymbolNotUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Companies_Symbol",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Symbol",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Companies_Symbol",
                table: "Companies",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Symbol",
                table: "Companies",
                column: "Symbol",
                unique: true);
        }
    }
}
