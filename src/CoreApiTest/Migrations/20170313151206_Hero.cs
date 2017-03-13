using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CoreApiTest.Migrations
{
    public partial class Hero : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeroItems",
                columns: table => new
                {
                    HeroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsRetired = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroItems", x => x.HeroId);
                });

            migrationBuilder.CreateTable(
                name: "QuestItems",
                columns: table => new
                {
                    QuestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsCompleted = table.Column<bool>(nullable: false),
                    QuestOwnerId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestItems", x => x.QuestId);
                    table.ForeignKey(
                        name: "FK_QuestItems_HeroItems_QuestOwnerId",
                        column: x => x.QuestOwnerId,
                        principalTable: "HeroItems",
                        principalColumn: "HeroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestItems_QuestOwnerId",
                table: "QuestItems",
                column: "QuestOwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestItems");

            migrationBuilder.DropTable(
                name: "HeroItems");
        }
    }
}
