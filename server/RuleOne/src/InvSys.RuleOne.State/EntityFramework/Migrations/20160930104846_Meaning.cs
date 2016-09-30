using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvSys.RuleOne.State.EntityFramework.Migrations
{
    public partial class Meaning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meanings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanySymbol = table.Column<string>(nullable: true),
                    Money = table.Column<bool>(nullable: false),
                    Passion = table.Column<bool>(nullable: false),
                    Talent = table.Column<bool>(nullable: false),
                    Understand = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Whole = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meanings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meanings");
        }
    }
}
