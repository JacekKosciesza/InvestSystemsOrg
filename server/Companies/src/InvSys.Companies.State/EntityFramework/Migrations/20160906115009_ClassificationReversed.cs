using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvSys.Companies.State.EntityFramework.Migrations
{
    public partial class ClassificationReversed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sectors_Industries_IndustryId",
                table: "Sectors");

            migrationBuilder.DropIndex(
                name: "IX_Sectors_IndustryId",
                table: "Sectors");

            migrationBuilder.DropColumn(
                name: "IndustryId",
                table: "Sectors");

            migrationBuilder.AddColumn<Guid>(
                name: "SubsectorId",
                table: "Industries",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Industries_SubsectorId",
                table: "Industries",
                column: "SubsectorId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CompanyTranslations",
                maxLength: 3000,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Industries_Subsectors_SubsectorId",
                table: "Industries",
                column: "SubsectorId",
                principalTable: "Subsectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Industries_Subsectors_SubsectorId",
                table: "Industries");

            migrationBuilder.DropIndex(
                name: "IX_Industries_SubsectorId",
                table: "Industries");

            migrationBuilder.DropColumn(
                name: "SubsectorId",
                table: "Industries");

            migrationBuilder.AddColumn<Guid>(
                name: "IndustryId",
                table: "Sectors",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_IndustryId",
                table: "Sectors",
                column: "IndustryId");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CompanyTranslations",
                maxLength: 3000,
                nullable: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Sectors_Industries_IndustryId",
                table: "Sectors",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
