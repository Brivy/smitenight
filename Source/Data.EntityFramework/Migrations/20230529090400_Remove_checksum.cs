using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smitenight.Persistence.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Remove_checksum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Checksum",
                table: "BasicAttacks");

            migrationBuilder.DropColumn(
                name: "Checksum",
                table: "AbilityTags");

            migrationBuilder.DropColumn(
                name: "Checksum",
                table: "AbilityRanks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Checksum",
                table: "BasicAttacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Checksum",
                table: "AbilityTags",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Checksum",
                table: "AbilityRanks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
