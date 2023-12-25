using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Smitenight.Persistence.Data.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmiteId = table.Column<int>(type: "int", nullable: false),
                    RootActiveId = table.Column<int>(type: "int", nullable: true),
                    ChildActiveId = table.Column<int>(type: "int", nullable: true),
                    Checksum = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Actives_Actives_RootActiveId",
                        column: x => x.RootActiveId,
                        principalTable: "Actives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Consumables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmiteId = table.Column<int>(type: "int", nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SecondaryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmiteId = table.Column<int>(type: "int", nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BasicAttackChecksum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AttackSpeed = table.Column<float>(type: "real", nullable: false),
                    AttackSpeedPerLevel = table.Column<float>(type: "real", nullable: false),
                    AutoBanned = table.Column<bool>(type: "bit", nullable: false),
                    GodCardUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GodIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hp5PerLevel = table.Column<float>(type: "real", nullable: false),
                    Health = table.Column<int>(type: "int", nullable: false),
                    HealthPerFive = table.Column<int>(type: "int", nullable: false),
                    HealthPerLevel = table.Column<int>(type: "int", nullable: false),
                    LatestGod = table.Column<bool>(type: "bit", nullable: false),
                    Lore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mp5PerLevel = table.Column<float>(type: "real", nullable: false),
                    MagicProtection = table.Column<float>(type: "real", nullable: false),
                    MagicProtectionPerLevel = table.Column<float>(type: "real", nullable: false),
                    MagicalPower = table.Column<int>(type: "int", nullable: false),
                    MagicalPowerPerLevel = table.Column<float>(type: "real", nullable: false),
                    Mana = table.Column<int>(type: "int", nullable: false),
                    ManaPerFive = table.Column<float>(type: "real", nullable: false),
                    ManaPerLevel = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnFreeRotation = table.Column<bool>(type: "bit", nullable: false),
                    Pantheon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhysicalPower = table.Column<int>(type: "int", nullable: false),
                    PhysicalPowerPerLevel = table.Column<float>(type: "real", nullable: false),
                    PhysicalProtection = table.Column<float>(type: "real", nullable: false),
                    PhysicalProtectionPerLevel = table.Column<float>(type: "real", nullable: false),
                    Pros = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Speed = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
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
                    SmiteId = table.Column<int>(type: "int", nullable: false),
                    RootItemId = table.Column<int>(type: "int", nullable: false),
                    ChildItemId = table.Column<int>(type: "int", nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Glyph = table.Column<bool>(type: "bit", nullable: false),
                    ItemTier = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RestrictedRoles = table.Column<int>(type: "int", nullable: false),
                    SecondaryDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingItem = table.Column<bool>(type: "bit", nullable: false),
                    ItemIconUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Items_ChildItemId",
                        column: x => x.ChildItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Items_RootItemId",
                        column: x => x.RootItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    TeamOneScore = table.Column<int>(type: "int", nullable: true),
                    TeamTwoScore = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerNameAttempts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Attempts = table.Column<int>(type: "int", nullable: false),
                    FirstTimeUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastTimeUsed = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextAttemptPossibleAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerNameAttempts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SmiteId = table.Column<int>(type: "int", nullable: true),
                    LastSynchronizedMatchId = table.Column<int>(type: "int", nullable: true),
                    SmitePortalUserId = table.Column<long>(type: "bigint", nullable: true),
                    HirezGamerTag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HirezPlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    MasteryLevel = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PortalType = table.Column<int>(type: "int", nullable: true),
                    PrivacyEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Abilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodId = table.Column<int>(type: "int", nullable: false),
                    SmiteId = table.Column<int>(type: "int", nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cooldown = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbilityType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Abilities_Gods_GodId",
                        column: x => x.GodId,
                        principalTable: "Gods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BasicAttacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodId = table.Column<int>(type: "int", nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(max)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "GodSkins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GodId = table.Column<int>(type: "int", nullable: false),
                    SmiteId = table.Column<int>(type: "int", nullable: false),
                    SecondarySmiteId = table.Column<int>(type: "int", nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GodBans_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Smitenights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smitenights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smitenights_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbilityRanks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbilityTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbilityId = table.Column<int>(type: "int", nullable: false),
                    Checksum = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                        onDelete: ReferentialAction.Restrict);
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
                    PlayerId = table.Column<int>(type: "int", nullable: true),
                    TeamId = table.Column<int>(type: "int", nullable: true),
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
                        name: "FK_MatchDetails_GodSkins_GodSkinId",
                        column: x => x.GodSkinId,
                        principalTable: "GodSkins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchDetails_Gods_GodId",
                        column: x => x.GodId,
                        principalTable: "Gods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchDetails_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchDetails_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SmitenightMatches",
                columns: table => new
                {
                    SmitenightId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    MatchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmitenightMatches", x => x.SmitenightId);
                    table.ForeignKey(
                        name: "FK_SmitenightMatches_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SmitenightMatches_Smitenights_SmitenightId",
                        column: x => x.SmitenightId,
                        principalTable: "Smitenights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivePurchases_MatchDetails_MatchDetailId",
                        column: x => x.MatchDetailId,
                        principalTable: "MatchDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemPurchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    MatchDetailId = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPurchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPurchases_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemPurchases_MatchDetails_MatchDetailId",
                        column: x => x.MatchDetailId,
                        principalTable: "MatchDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "IX_BasicAttacks_GodId",
                table: "BasicAttacks",
                column: "GodId");

            migrationBuilder.CreateIndex(
                name: "IX_GodBans_GodId",
                table: "GodBans",
                column: "GodId");

            migrationBuilder.CreateIndex(
                name: "IX_GodBans_MatchId",
                table: "GodBans",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_GodSkins_GodId",
                table: "GodSkins",
                column: "GodId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDescriptions_ItemId",
                table: "ItemDescriptions",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPurchases_ItemId",
                table: "ItemPurchases",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPurchases_MatchDetailId",
                table: "ItemPurchases",
                column: "MatchDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ChildItemId",
                table: "Items",
                column: "ChildItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_RootItemId",
                table: "Items",
                column: "RootItemId");

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
                name: "IX_SmitenightMatches_MatchId",
                table: "SmitenightMatches",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Smitenights_PlayerId",
                table: "Smitenights",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityRanks");

            migrationBuilder.DropTable(
                name: "AbilityTags");

            migrationBuilder.DropTable(
                name: "ActivePurchases");

            migrationBuilder.DropTable(
                name: "BasicAttacks");

            migrationBuilder.DropTable(
                name: "Consumables");

            migrationBuilder.DropTable(
                name: "GodBans");

            migrationBuilder.DropTable(
                name: "ItemDescriptions");

            migrationBuilder.DropTable(
                name: "ItemPurchases");

            migrationBuilder.DropTable(
                name: "PlayerNameAttempts");

            migrationBuilder.DropTable(
                name: "SmitenightMatches");

            migrationBuilder.DropTable(
                name: "Abilities");

            migrationBuilder.DropTable(
                name: "Actives");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "MatchDetails");

            migrationBuilder.DropTable(
                name: "Smitenights");

            migrationBuilder.DropTable(
                name: "GodSkins");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Gods");
        }
    }
}
