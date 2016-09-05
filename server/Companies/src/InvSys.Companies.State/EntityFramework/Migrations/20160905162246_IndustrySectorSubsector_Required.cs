using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvSys.Companies.State.EntityFramework.Migrations
{
    public partial class IndustrySectorSubsector_Required : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SubsectorTranslations",
                maxLength: 3000,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "Subsectors",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SectorTranslations",
                maxLength: 3000,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "Sectors",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "IndustryTranslations",
                maxLength: 3000,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "Industries",
                maxLength: 300,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SubsectorTranslations",
                maxLength: 3000,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "Subsectors",
                maxLength: 300,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "SectorTranslations",
                maxLength: 3000,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "Sectors",
                maxLength: 300,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "IndustryTranslations",
                maxLength: 3000,
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Source",
                table: "Industries",
                maxLength: 300,
                nullable: false);
        }
    }
}
