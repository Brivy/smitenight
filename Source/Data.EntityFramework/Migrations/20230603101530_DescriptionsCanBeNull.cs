using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smitenight.Persistence.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class DescriptionsCanBeNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Latest",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Latest",
                table: "GodSkins",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Latest",
                table: "Gods",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Consumables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Latest",
                table: "Consumables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Actives",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SecondaryDescription",
                table: "Actives",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Latest",
                table: "Actives",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Latest",
                table: "Abilities",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latest",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Latest",
                table: "GodSkins");

            migrationBuilder.DropColumn(
                name: "Latest",
                table: "Gods");

            migrationBuilder.DropColumn(
                name: "Latest",
                table: "Consumables");

            migrationBuilder.DropColumn(
                name: "Latest",
                table: "Actives");

            migrationBuilder.DropColumn(
                name: "Latest",
                table: "Abilities");

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Consumables",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ShortDescription",
                table: "Actives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SecondaryDescription",
                table: "Actives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
