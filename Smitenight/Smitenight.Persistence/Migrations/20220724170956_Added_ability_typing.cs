using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smitenight.Persistence.Migrations
{
    public partial class Added_ability_typing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbilityType",
                table: "Abilities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbilityType",
                table: "Abilities");
        }
    }
}
