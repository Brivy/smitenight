using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmitenightApp.Persistence.Migrations
{
    public partial class Added_GodSkins : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GodSkins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodId = table.Column<int>(type: "int", nullable: false),
                    SmiteId = table.Column<int>(type: "int", nullable: false),
                    SecondarySmiteId = table.Column<int>(type: "int", nullable: false),
                    GodSkinUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obtainability = table.Column<int>(type: "int", nullable: false),
                    PriceFavor = table.Column<int>(type: "int", nullable: false),
                    PriceGems = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GodSkins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GodSkins_Gods_GodId",
                        column: x => x.GodId,
                        principalTable: "Gods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GodSkins_GodId",
                table: "GodSkins",
                column: "GodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GodSkins");
        }
    }
}
