using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InvSys.Companies.State.EntityFramework.Migrations
{
    public partial class Classification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Source = table.Column<string>(maxLength: 300, nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Logo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Default = table.Column<string>(nullable: true),
                    Logomark = table.Column<string>(nullable: true),
                    Logotype = table.Column<string>(nullable: true),
                    Square = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IndustryTranslations",
                columns: table => new
                {
                    IndustryId = table.Column<Guid>(nullable: false),
                    Culture = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 3000, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndustryTranslations", x => new { x.IndustryId, x.Culture });
                    table.ForeignKey(
                        name: "FK_IndustryTranslations_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IndustryId = table.Column<Guid>(nullable: false),
                    Source = table.Column<string>(maxLength: 300, nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sectors_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SectorTranslations",
                columns: table => new
                {
                    SectorId = table.Column<Guid>(nullable: false),
                    Culture = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 3000, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorTranslations", x => new { x.SectorId, x.Culture });
                    table.ForeignKey(
                        name: "FK_SectorTranslations_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subsectors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SectorId = table.Column<Guid>(nullable: false),
                    Source = table.Column<string>(maxLength: 300, nullable: false),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subsectors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subsectors_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubsectorTranslations",
                columns: table => new
                {
                    SubsectorId = table.Column<Guid>(nullable: false),
                    Culture = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 3000, nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Timestamp = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubsectorTranslations", x => new { x.SubsectorId, x.Culture });
                    table.ForeignKey(
                        name: "FK_SubsectorTranslations_Subsectors_SubsectorId",
                        column: x => x.SubsectorId,
                        principalTable: "Subsectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CompanyTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "CompanyTranslations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Exchange",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "IndustryId",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogoId",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SectorId",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SubsectorId",
                table: "Companies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_IndustryId",
                table: "Companies",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_LogoId",
                table: "Companies",
                column: "LogoId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_SectorId",
                table: "Companies",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_SubsectorId",
                table: "Companies",
                column: "SubsectorId");

            migrationBuilder.CreateIndex(
                name: "IX_IndustryTranslations_IndustryId",
                table: "IndustryTranslations",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_Sectors_IndustryId",
                table: "Sectors",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_SectorTranslations_SectorId",
                table: "SectorTranslations",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Subsectors_SectorId",
                table: "Subsectors",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubsectorTranslations_SubsectorId",
                table: "SubsectorTranslations",
                column: "SubsectorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Industries_IndustryId",
                table: "Companies",
                column: "IndustryId",
                principalTable: "Industries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Logo_LogoId",
                table: "Companies",
                column: "LogoId",
                principalTable: "Logo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Sectors_SectorId",
                table: "Companies",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Subsectors_SubsectorId",
                table: "Companies",
                column: "SubsectorId",
                principalTable: "Subsectors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Industries_IndustryId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Logo_LogoId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Sectors_SectorId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Subsectors_SubsectorId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_IndustryId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_LogoId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_SectorId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_SubsectorId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "CompanyTranslations");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "CompanyTranslations");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Exchange",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "IndustryId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "LogoId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "SubsectorId",
                table: "Companies");

            migrationBuilder.DropTable(
                name: "IndustryTranslations");

            migrationBuilder.DropTable(
                name: "Logo");

            migrationBuilder.DropTable(
                name: "SectorTranslations");

            migrationBuilder.DropTable(
                name: "SubsectorTranslations");

            migrationBuilder.DropTable(
                name: "Subsectors");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "Industries");
        }
    }
}
