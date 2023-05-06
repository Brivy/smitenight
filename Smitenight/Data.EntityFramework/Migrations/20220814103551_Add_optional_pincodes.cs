using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmitenightApp.Persistence.Migrations
{
    public partial class Add_optional_pincodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PinCode",
                table: "Smitenights",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PinCode",
                table: "Smitenights");
        }
    }
}
