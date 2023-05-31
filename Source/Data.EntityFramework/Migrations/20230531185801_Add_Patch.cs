using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smitenight.Persistence.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Add_Patch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatchId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatchId",
                table: "GodSkins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatchId",
                table: "Gods",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatchId",
                table: "Consumables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatchId",
                table: "Actives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatchId",
                table: "Abilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Patches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patches", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_PatchId",
                table: "Items",
                column: "PatchId");

            migrationBuilder.CreateIndex(
                name: "IX_GodSkins_PatchId",
                table: "GodSkins",
                column: "PatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Gods_PatchId",
                table: "Gods",
                column: "PatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumables_PatchId",
                table: "Consumables",
                column: "PatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Actives_PatchId",
                table: "Actives",
                column: "PatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_PatchId",
                table: "Abilities",
                column: "PatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abilities_Patches_PatchId",
                table: "Abilities",
                column: "PatchId",
                principalTable: "Patches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Actives_Patches_PatchId",
                table: "Actives",
                column: "PatchId",
                principalTable: "Patches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Consumables_Patches_PatchId",
                table: "Consumables",
                column: "PatchId",
                principalTable: "Patches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Gods_Patches_PatchId",
                table: "Gods",
                column: "PatchId",
                principalTable: "Patches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GodSkins_Patches_PatchId",
                table: "GodSkins",
                column: "PatchId",
                principalTable: "Patches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Patches_PatchId",
                table: "Items",
                column: "PatchId",
                principalTable: "Patches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abilities_Patches_PatchId",
                table: "Abilities");

            migrationBuilder.DropForeignKey(
                name: "FK_Actives_Patches_PatchId",
                table: "Actives");

            migrationBuilder.DropForeignKey(
                name: "FK_Consumables_Patches_PatchId",
                table: "Consumables");

            migrationBuilder.DropForeignKey(
                name: "FK_Gods_Patches_PatchId",
                table: "Gods");

            migrationBuilder.DropForeignKey(
                name: "FK_GodSkins_Patches_PatchId",
                table: "GodSkins");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Patches_PatchId",
                table: "Items");

            migrationBuilder.DropTable(
                name: "Patches");

            migrationBuilder.DropIndex(
                name: "IX_Items_PatchId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_GodSkins_PatchId",
                table: "GodSkins");

            migrationBuilder.DropIndex(
                name: "IX_Gods_PatchId",
                table: "Gods");

            migrationBuilder.DropIndex(
                name: "IX_Consumables_PatchId",
                table: "Consumables");

            migrationBuilder.DropIndex(
                name: "IX_Actives_PatchId",
                table: "Actives");

            migrationBuilder.DropIndex(
                name: "IX_Abilities_PatchId",
                table: "Abilities");

            migrationBuilder.DropColumn(
                name: "PatchId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "PatchId",
                table: "GodSkins");

            migrationBuilder.DropColumn(
                name: "PatchId",
                table: "Gods");

            migrationBuilder.DropColumn(
                name: "PatchId",
                table: "Consumables");

            migrationBuilder.DropColumn(
                name: "PatchId",
                table: "Actives");

            migrationBuilder.DropColumn(
                name: "PatchId",
                table: "Abilities");
        }
    }
}
