using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvSys.Companies.State.EntityFramework.Migrations
{
    public partial class Translations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Companies");

            migrationBuilder.CreateTable(
                name: "CompanyTranslation",
                columns: table => new
                {
                    CompanyId = table.Column<Guid>(nullable: false),
                    Culture = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyTranslation", x => new { x.CompanyId, x.Culture });
                    table.ForeignKey(
                        name: "FK_CompanyTranslation_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyTranslation_CompanyId",
                table: "CompanyTranslation",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyTranslation");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Companies",
                nullable: true);
        }
    }
}
