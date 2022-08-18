using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmitenightApp.Persistence.Migrations
{
    public partial class Initial_migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttackSpeed = table.Column<float>(type: "real", nullable: false),
                    AttackSpeedPerLevel = table.Column<float>(type: "real", nullable: false),
                    AutoBanned = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cons = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GodCardUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GodIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hp5PerLevel = table.Column<float>(type: "real", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    HealthPerFive = table.Column<int>(type: "int", nullable: false),
                    HealthPerLevel = table.Column<int>(type: "int", nullable: false),
                    LatestGod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mp5PerLevel = table.Column<float>(type: "real", nullable: false),
                    MagicProtection = table.Column<int>(type: "int", nullable: false),
                    MagicProtectionPerLevel = table.Column<float>(type: "real", nullable: false),
                    MagicalPower = table.Column<int>(type: "int", nullable: false),
                    MagicalPowerPerLevel = table.Column<float>(type: "real", nullable: false),
                    Mana = table.Column<int>(type: "int", nullable: false),
                    ManaPerFive = table.Column<float>(type: "real", nullable: false),
                    ManaPerLevel = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnFreeRotation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pantheon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhysicalPower = table.Column<int>(type: "int", nullable: false),
                    PhysicalPowerPerLevel = table.Column<float>(type: "real", nullable: false),
                    PhysicalProtection = table.Column<int>(type: "int", nullable: false),
                    PhysicalProtectionPerLevel = table.Column<float>(type: "real", nullable: false),
                    Pros = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RootItemId = table.Column<int>(type: "int", nullable: false),
                    ChildItemId = table.Column<int>(type: "int", nullable: true),
                    ActiveFlag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Glyph = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemTier = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RestrictedRoles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondaryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartingItem = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Items_ChildItemId",
                        column: x => x.ChildItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Items_RootItemId",
                        column: x => x.RootItemId,
                        principalTable: "Items",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodId = table.Column<int>(type: "int", nullable: false),
                    Cooldown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Gods_GodId",
                        column: x => x.GodId,
                        principalTable: "Gods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasicAttackDescriptions",
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
                    table.PrimaryKey("PK_BasicAttackDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasicAttackDescriptions_Gods_GodId",
                        column: x => x.GodId,
                        principalTable: "Gods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDescriptions_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbilityRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityRanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbilityRanks_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbilityTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbilityTags_Abilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Abilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abilities_GodId",
                table: "Abilities",
                column: "GodId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityRanks_AbilityId",
                table: "AbilityRanks",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityTags_AbilityId",
                table: "AbilityTags",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_BasicAttackDescriptions_GodId",
                table: "BasicAttackDescriptions",
                column: "GodId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDescriptions_ItemId",
                table: "ItemDescriptions",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ChildItemId",
                table: "Items",
                column: "ChildItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_RootItemId",
                table: "Items",
                column: "RootItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityRanks");

            migrationBuilder.DropTable(
                name: "AbilityTags");

            migrationBuilder.DropTable(
                name: "BasicAttackDescriptions");

            migrationBuilder.DropTable(
                name: "ItemDescriptions");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Gods");
        }
    }
}
