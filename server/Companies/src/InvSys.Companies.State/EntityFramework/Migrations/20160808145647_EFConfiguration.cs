using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvSys.Companies.State.EntityFramework.Migrations
{
    public partial class EFConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTranslation_Companies_CompanyId",
                table: "CompanyTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyTranslation",
                table: "CompanyTranslation");

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "CompanyTranslation",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Companies",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CompanyTranslation",
                maxLength: 3000,
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyTranslations",
                table: "CompanyTranslation",
                columns: new[] { "CompanyId", "Culture" });

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "Companies",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                maxLength: 100,
                nullable: false);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Companies_Symbol",
                table: "Companies",
                column: "Symbol");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Symbol",
                table: "Companies",
                column: "Symbol",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTranslations_Companies_CompanyId",
                table: "CompanyTranslation",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_CompanyTranslation_CompanyId",
                table: "CompanyTranslation",
                newName: "IX_CompanyTranslations_CompanyId");

            migrationBuilder.RenameTable(
                name: "CompanyTranslation",
                newName: "CompanyTranslations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyTranslations_Companies_CompanyId",
                table: "CompanyTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyTranslations",
                table: "CompanyTranslations");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Companies_Symbol",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_Symbol",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "CompanyTranslations");

            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "CompanyTranslations",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyTranslation",
                table: "CompanyTranslations",
                columns: new[] { "CompanyId", "Culture" });

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "Companies",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyTranslation_Companies_CompanyId",
                table: "CompanyTranslations",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.RenameIndex(
                name: "IX_CompanyTranslations_CompanyId",
                table: "CompanyTranslations",
                newName: "IX_CompanyTranslation_CompanyId");

            migrationBuilder.RenameTable(
                name: "CompanyTranslations",
                newName: "CompanyTranslation");
        }
    }
}
