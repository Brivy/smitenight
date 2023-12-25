using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smitenight.Persistence.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class WhyThisChecksumThough : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checksum",
                table: "ItemDescriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Checksum",
                table: "ItemDescriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
