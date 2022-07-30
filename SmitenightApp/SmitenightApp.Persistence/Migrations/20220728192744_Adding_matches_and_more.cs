using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmitenightApp.Persistence.Migrations
{
    public partial class Adding_matches_and_more : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Items",
                newName: "Enabled");

            migrationBuilder.CreateTable(
                name: "Actives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmiteId = table.Column<int>(type: "int", nullable: false),
                    RootActiveId = table.Column<int>(type: "int", nullable: false),
                    ChildActiveId = table.Column<int>(type: "int", nullable: true),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ItemTier = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SecondaryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Actives_Actives_ChildActiveId",
                        column: x => x.ChildActiveId,
                        principalTable: "Actives",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Actives_Actives_RootActiveId",
                        column: x => x.RootActiveId,
                        principalTable: "Actives",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmiteId = table.Column<int>(type: "int", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SecondaryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmiteId = table.Column<int>(type: "int", nullable: false),
                    GameMap = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameModeQueue = table.Column<int>(type: "int", nullable: false),
                    MatchDuration = table.Column<int>(type: "int", nullable: false),
                    TeamOneScore = table.Column<int>(type: "int", nullable: false),
                    TeamTwoScore = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmiteId = table.Column<int>(type: "int", nullable: false),
                    SmitePortalUserId = table.Column<int>(type: "int", nullable: true),
                    HirezPlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    MasteryLevel = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortalType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmiteId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConsumableDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumableId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumableDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumableDescriptions_Consumables_ConsumableId",
                        column: x => x.ConsumableId,
                        principalTable: "Consumables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GodBans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    GodBanOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GodBans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GodBans_Gods_GodId",
                        column: x => x.GodId,
                        principalTable: "Gods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GodBans_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatchDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodId = table.Column<int>(type: "int", nullable: false),
                    GodSkinId = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false),
                    DamageDone = table.Column<int>(type: "int", nullable: false),
                    DamageDoneInHand = table.Column<int>(type: "int", nullable: false),
                    DamageDoneMagical = table.Column<int>(type: "int", nullable: false),
                    DamageDonePhysical = table.Column<int>(type: "int", nullable: false),
                    DamageDoneToBots = table.Column<int>(type: "int", nullable: false),
                    DamageDoneToStructures = table.Column<int>(type: "int", nullable: false),
                    DamageTaken = table.Column<int>(type: "int", nullable: false),
                    DamageTakenMagical = table.Column<int>(type: "int", nullable: false),
                    DamageTakenPhysical = table.Column<int>(type: "int", nullable: false),
                    DamageMitigated = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    Deaths = table.Column<int>(type: "int", nullable: false),
                    FirstBlood = table.Column<int>(type: "int", nullable: false),
                    SingleKills = table.Column<int>(type: "int", nullable: false),
                    DoubleKills = table.Column<int>(type: "int", nullable: false),
                    TripleKills = table.Column<int>(type: "int", nullable: false),
                    QuadraKills = table.Column<int>(type: "int", nullable: false),
                    PentaKills = table.Column<int>(type: "int", nullable: false),
                    HighestMultiKill = table.Column<int>(type: "int", nullable: false),
                    KillingSpree = table.Column<int>(type: "int", nullable: false),
                    BotKills = table.Column<int>(type: "int", nullable: false),
                    PlayerKills = table.Column<int>(type: "int", nullable: false),
                    FireGiantKills = table.Column<int>(type: "int", nullable: false),
                    GoldFuryKills = table.Column<int>(type: "int", nullable: false),
                    PhoenixKills = table.Column<int>(type: "int", nullable: false),
                    SiegeJuggernautKills = table.Column<int>(type: "int", nullable: false),
                    TowerKills = table.Column<int>(type: "int", nullable: false),
                    WildJuggernautKills = table.Column<int>(type: "int", nullable: false),
                    ObjectiveAssists = table.Column<int>(type: "int", nullable: false),
                    DistanceTraveled = table.Column<int>(type: "int", nullable: false),
                    GodRole = table.Column<int>(type: "int", nullable: false),
                    GoldEarned = table.Column<int>(type: "int", nullable: false),
                    GoldEarnedPerMinute = table.Column<int>(type: "int", nullable: false),
                    HealingDone = table.Column<int>(type: "int", nullable: false),
                    HealingDoneToBots = table.Column<int>(type: "int", nullable: false),
                    HealingDoneToSelf = table.Column<int>(type: "int", nullable: false),
                    LevelReached = table.Column<int>(type: "int", nullable: false),
                    MatchTeam = table.Column<int>(type: "int", nullable: false),
                    Surrendered = table.Column<bool>(type: "bit", nullable: false),
                    TotalTimeDead = table.Column<int>(type: "int", nullable: false),
                    WardsPlaced = table.Column<int>(type: "int", nullable: false),
                    Winner = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchDetails_Gods_GodId",
                        column: x => x.GodId,
                        principalTable: "Gods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchDetails_GodSkins_GodSkinId",
                        column: x => x.GodSkinId,
                        principalTable: "GodSkins",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchDetails_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchDetails_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MatchDetails_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActivePurchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActiveId = table.Column<int>(type: "int", nullable: false),
                    MatchDetailId = table.Column<int>(type: "int", nullable: false),
                    ActivePurchaseOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivePurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivePurchases_Actives_ActiveId",
                        column: x => x.ActiveId,
                        principalTable: "Actives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivePurchases_MatchDetails_MatchDetailId",
                        column: x => x.MatchDetailId,
                        principalTable: "MatchDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPurchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    MatchDetailId = table.Column<int>(type: "int", nullable: false),
                    ItemPurchaseOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPurchases_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPurchases_MatchDetails_MatchDetailId",
                        column: x => x.MatchDetailId,
                        principalTable: "MatchDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivePurchases_ActiveId",
                table: "ActivePurchases",
                column: "ActiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivePurchases_MatchDetailId",
                table: "ActivePurchases",
                column: "MatchDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Actives_ChildActiveId",
                table: "Actives",
                column: "ChildActiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Actives_RootActiveId",
                table: "Actives",
                column: "RootActiveId");

            migrationBuilder.CreateIndex(
                name: "IX_ConsumableDescriptions_ConsumableId",
                table: "ConsumableDescriptions",
                column: "ConsumableId");

            migrationBuilder.CreateIndex(
                name: "IX_GodBans_GodId",
                table: "GodBans",
                column: "GodId");

            migrationBuilder.CreateIndex(
                name: "IX_GodBans_MatchId",
                table: "GodBans",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPurchases_ItemId",
                table: "ItemPurchases",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPurchases_MatchDetailId",
                table: "ItemPurchases",
                column: "MatchDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchDetails_GodId",
                table: "MatchDetails",
                column: "GodId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchDetails_GodSkinId",
                table: "MatchDetails",
                column: "GodSkinId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchDetails_MatchId",
                table: "MatchDetails",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchDetails_PlayerId",
                table: "MatchDetails",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchDetails_TeamId",
                table: "MatchDetails",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivePurchases");

            migrationBuilder.DropTable(
                name: "ConsumableDescriptions");

            migrationBuilder.DropTable(
                name: "GodBans");

            migrationBuilder.DropTable(
                name: "ItemPurchases");

            migrationBuilder.DropTable(
                name: "Actives");

            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "MatchDetails");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.RenameColumn(
                name: "Enabled",
                table: "Items",
                newName: "Active");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
