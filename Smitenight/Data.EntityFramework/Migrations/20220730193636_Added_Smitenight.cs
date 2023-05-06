using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmitenightApp.Persistence.Migrations
{
    public partial class Added_Smitenight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Smitenights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smitenights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smitenights_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmitenightMatches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    SmitenightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmitenightMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SmitenightMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmitenightMatches_Smitenights_SmitenightId",
                        column: x => x.SmitenightId,
                        principalTable: "Smitenights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmitenightMatches_MatchId",
                table: "SmitenightMatches",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_SmitenightMatches_SmitenightId",
                table: "SmitenightMatches",
                column: "SmitenightId");

            migrationBuilder.CreateIndex(
                name: "IX_Smitenights_PlayerId",
                table: "Smitenights",
                column: "PlayerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmitenightMatches");

            migrationBuilder.DropTable(
                name: "Smitenights");
        }
    }
}
