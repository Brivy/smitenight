using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smitenight.Persistence.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class RemappingBasicAttacks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasicAttacks");

            migrationBuilder.DropColumn(
                name: "BasicAttackChecksum",
                table: "Gods");

            migrationBuilder.CreateTable(
                name: "GodBasicAttacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GodBasicAttacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GodBasicAttacks_Gods_GodId",
                        column: x => x.GodId,
                        principalTable: "Gods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GodBasicAttacks_GodId",
                table: "GodBasicAttacks",
                column: "GodId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GodBasicAttacks");

            migrationBuilder.AddColumn<string>(
                name: "BasicAttackChecksum",
                table: "Gods",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "BasicAttacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasicAttacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicAttacks_Gods_GodId",
                        column: x => x.GodId,
                        principalTable: "Gods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasicAttacks_GodId",
                table: "BasicAttacks",
                column: "GodId");
        }
    }
}
