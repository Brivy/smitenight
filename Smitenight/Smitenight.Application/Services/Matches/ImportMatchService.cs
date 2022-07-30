using Microsoft.EntityFrameworkCore;
using Smitenight.Abstractions.Application.Services.Matches;
using Smitenight.Abstractions.Application.Services.System;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.MatchRequests;
using Smitenight.Domain.Clients.SmiteClient.Responses.MatchResponses;
using Smitenight.Domain.Constants.SmiteClient.Responses;
using Smitenight.Domain.Enums.Gods;
using Smitenight.Domain.Enums.Items;
using Smitenight.Domain.Enums.Matches;
using Smitenight.Domain.Enums.SmiteClient;
using Smitenight.Domain.Extensions;
using Smitenight.Domain.Models.Gods;
using Smitenight.Domain.Models.Items;
using Smitenight.Domain.Models.Matches;
using Smitenight.Domain.Models.Players;
using Smitenight.Persistence;

namespace Smitenight.Application.Services.Matches
{
    public class ImportMatchService : IImportMatchService
    {
        private readonly ISmiteSessionService _smiteSessionService;
        private readonly IMatchInfoClient _matchInfoClient;
        private readonly SmitenightDbContext _dbContext;

        public ImportMatchService(
            ISmiteSessionService smiteSessionService,
            IMatchInfoClient matchInfoClient,
            SmitenightDbContext dbContext)
        {
            _smiteSessionService = smiteSessionService;
            _matchInfoClient = matchInfoClient;
            _dbContext = dbContext;
        }

        public async Task ImportAsync(int smiteMatchId, CancellationToken cancellationToken = default)
        {
            var matchAlreadyExists = await _dbContext.Matches.AnyAsync(x => x.SmiteId == smiteMatchId, cancellationToken);
            if (matchAlreadyExists)
            {
                return;
            }

            var sessionId = await _smiteSessionService.GetSessionIdAsync(cancellationToken);
            if (string.IsNullOrEmpty(sessionId))
            {
                return;
            }

            var matchDetailsRequest = new MatchDetailsRequest(sessionId, smiteMatchId);
            var matchDetailsResponse = await _matchInfoClient.GetMatchDetailsAsync(matchDetailsRequest, cancellationToken);
            if (matchDetailsResponse?.Response?.Any() != true)
            {
                return;
            }

            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                var singleMatchDetails = matchDetailsResponse.Response.First();
                var matchEntity = BuildMatchEntity(singleMatchDetails);

                // Attach god bans
                var godBanIdList = new List<int> { singleMatchDetails.Ban1Id, singleMatchDetails.Ban2Id, singleMatchDetails.Ban3Id, singleMatchDetails.Ban4Id, singleMatchDetails.Ban5Id, singleMatchDetails.Ban6Id, singleMatchDetails.Ban7Id, singleMatchDetails.Ban8Id, singleMatchDetails.Ban9Id, singleMatchDetails.Ban10Id, singleMatchDetails.Ban11Id, singleMatchDetails.Ban12Id };
                godBanIdList.RemoveAll(x => x == 0);
                var gods = await _dbContext.Gods.AsNoTracking().Where(x => godBanIdList.Contains(x.SmiteId)).ToListAsync(cancellationToken);
                var godBans = BuildGodBanEntities(singleMatchDetails, gods);
                if (godBans.Any())
                {
                    matchEntity.GodBans = godBans;
                }

                foreach (var matchDetails in matchDetailsResponse.Response)
                {
                    var matchDetailsEntity = BuildMatchDetailEntity(matchDetails);

                    // Attach the given god
                    var god = await _dbContext.Gods.AsNoTracking().Include(x => x.GodSkins).SingleOrDefaultAsync(x => x.SmiteId == matchDetails.GodId, cancellationToken);
                    matchDetailsEntity.GodId = god?.Id ?? 1;
                    matchDetailsEntity.GodSkinId = god?.GodSkins.SingleOrDefault(x => x.SmiteId == matchDetails.SkinId || x.SecondarySmiteId == matchDetails.SkinId)?.Id ?? 1;

                    // Attach purchased active entities
                    var activeIdList = new List<int> { matchDetails.ActiveId1, matchDetails.ActiveId2 };
                    activeIdList.RemoveAll(x => x == 0);
                    var actives = await _dbContext.Actives.AsNoTracking().Where(x => activeIdList.Contains(x.SmiteId)).ToListAsync(cancellationToken);
                    matchDetailsEntity.ActivePurchases = BuildActivePurchaseEntities(matchDetails, actives);

                    // Attach purchased item entities
                    var itemIdList = new List<int> { matchDetails.ItemId1, matchDetails.ItemId2, matchDetails.ItemId3, matchDetails.ItemId4, matchDetails.ItemId5, matchDetails.ItemId6 };
                    itemIdList.RemoveAll(x => x == 0);
                    var items = await _dbContext.Items.AsNoTracking().Where(x => itemIdList.Contains(x.SmiteId)).ToListAsync(cancellationToken);
                    matchDetailsEntity.ItemPurchases = BuildItemPurchaseEntities(matchDetails, items);

                    // Attach player (and update if already exists)
                    if (matchDetails.PlayerId == "0")
                    {
                        var existingPlayer = await _dbContext.Players.AsNoTracking().SingleOrDefaultAsync(x => x.Level == matchDetails.AccountLevel && x.MasteryLevel == matchDetails.MasteryLevel, cancellationToken);
                        if (existingPlayer == null)
                        {
                            var player = BuildAnonymousPlayerEntity(matchDetails);
                            matchDetailsEntity.Player = player;
                        }
                        else
                        {
                            matchDetailsEntity.PlayerId = existingPlayer.Id;
                        }
                    }
                    else
                    {
                        var parsedPlayerId = int.Parse(matchDetails.PlayerId);
                        var existingPlayer = await _dbContext.Players.AsNoTracking().SingleOrDefaultAsync(x => x.SmiteId == parsedPlayerId, cancellationToken);
                        if (existingPlayer == null)
                        {
                            var player = BuildPlayerEntity(matchDetails);
                            matchDetailsEntity.Player = player;
                        }
                        else if (existingPlayer.LastSynchronizedMatchId < matchDetails.Match)
                        {
                            Player player;
                            var attachedEntity = _dbContext.ChangeTracker.Entries<Player>().SingleOrDefault(x => x.Entity.Id == existingPlayer.Id);
                            if (attachedEntity != null)
                            {
                                player = attachedEntity.Entity;
                                UpdatePlayerEntity(player, matchDetails);
                            }
                            else
                            {
                                player = BuildPlayerEntity(matchDetails);
                            }
                            
                            player.Id = existingPlayer.Id;
                            matchDetailsEntity.PlayerId = existingPlayer.Id;
                            matchDetailsEntity.Player = player;
                            _dbContext.Players.Update(player);
                        }
                        else
                        {
                            matchDetailsEntity.PlayerId = existingPlayer.Id;
                        }
                    }

                    matchEntity.MatchDetails.Add(matchDetailsEntity);
                }

                _dbContext.Matches.Add(matchEntity);
                await _dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #region Builders

        private Match BuildMatchEntity(MatchDetailsResponse matchDetails)
        {
            var matchEntity = new Match
            {
                GameMap = matchDetails.MapGame,
                GameModeQueue = (GameModeQueueIdEnum)matchDetails.MatchQueueId,
                MatchDuration = matchDetails.MatchDuration,
                Name = matchDetails.Name,
                Region = matchDetails.Region,
                SmiteId = matchDetails.Match,
                StartDate = DateTime.Parse(matchDetails.EntryDatetime)
            };

            // If one of them is not zero, we have some kind of match with points
            if (matchDetails.Team1Score != 0 || matchDetails.Team2Score != 0)
            {
                matchEntity.TeamOneScore = matchDetails.Team1Score;
                matchEntity.TeamTwoScore = matchDetails.Team2Score;
            }

            return matchEntity;
        }

        private MatchDetail BuildMatchDetailEntity(MatchDetailsResponse matchDetails)
        {
            return new MatchDetail
            {
                Assists = matchDetails.Assists,
                BotKills = matchDetails.KillsBot,
                DamageDone = matchDetails.DamagePlayer,
                DamageDoneInHand = matchDetails.DamageDoneInHand,
                DamageDoneMagical = matchDetails.DamageDoneMagical,
                DamageDonePhysical = matchDetails.DamageDonePhysical,
                DamageDoneToBots = matchDetails.DamageBot,
                DamageDoneToStructures = matchDetails.StructureDamage,
                DamageMitigated = matchDetails.DamageMitigated,
                DamageTaken = matchDetails.DamageTaken,
                DamageTakenMagical = matchDetails.DamageTakenMagical,
                DamageTakenPhysical = matchDetails.DamageTakenPhysical,
                Deaths = matchDetails.Deaths,
                DistanceTraveled = matchDetails.DistanceTraveled,
                DoubleKills = matchDetails.KillsDouble,
                FireGiantKills = matchDetails.KillsFireGiant,
                FirstBlood = matchDetails.KillsFirstBlood,
                GodRole = ConvertToGodRoleEnum(matchDetails.Role),
                GoldEarned = matchDetails.GoldEarned,
                GoldEarnedPerMinute = matchDetails.GoldPerMinute,
                GoldFuryKills = matchDetails.KillsGoldFury,
                HealingDone = matchDetails.Healing,
                HealingDoneToBots = matchDetails.HealingBot,
                HealingDoneToSelf = matchDetails.HealingPlayerSelf,
                HighestMultiKill = matchDetails.MultiKillMax,
                KillingSpree = matchDetails.KillingSpree,
                LevelReached = matchDetails.FinalMatchLevel,
                MatchTeam = ConvertToMatchTeamEnum(matchDetails.TaskForce),
                ObjectiveAssists = matchDetails.ObjectiveAssists,
                PartyId = matchDetails.PartyId,
                PentaKills = matchDetails.KillsPenta,
                PhoenixKills = matchDetails.KillsPhoenix,
                PlayerKills = matchDetails.KillsPlayer,
                QuadraKills = matchDetails.KillsQuadra,
                SiegeJuggernautKills = matchDetails.KillsSiegeJuggernaut,
                SingleKills = matchDetails.KillsSingle,
                Surrendered = matchDetails.Surrendered.ConvertToBool(),
                TeamId = matchDetails.TeamId != 0 ? matchDetails.TeamId : null,
                TotalTimeDead = matchDetails.TimeDeadSeconds,
                TowerKills = matchDetails.TowersDestroyed,
                TripleKills = matchDetails.KillsTriple,
                WardsPlaced = matchDetails.WardsPlaced,
                WildJuggernautKills = matchDetails.KillsWildJuggernaut,
                Winner = matchDetails.WinStatus == MatchResponseConstants.WinnerStatus
            };
        }

        private List<GodBan> BuildGodBanEntities(MatchDetailsResponse matchDetails, List<God> gods)
        {
            var godBans = new List<GodBan>();
            if (matchDetails.Ban1Id != 0)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban1Id)?.Id ?? 1, GodBanOrder = GodBanOrderEnum.FirstBan });
            }
            if (matchDetails.Ban2Id != 0)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban2Id)?.Id ?? 1, GodBanOrder = GodBanOrderEnum.SecondBan });
            }
            if (matchDetails.Ban3Id != 0)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban3Id)?.Id ?? 1, GodBanOrder = GodBanOrderEnum.ThirdBan });
            }
            if (matchDetails.Ban4Id != 0)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban4Id)?.Id ?? 1, GodBanOrder = GodBanOrderEnum.FourthBan });
            }
            if (matchDetails.Ban5Id != 0)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban5Id)?.Id ?? 1, GodBanOrder = GodBanOrderEnum.FifthBan });
            }
            if (matchDetails.Ban6Id != 0)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban6Id)?.Id ?? 1, GodBanOrder = GodBanOrderEnum.SixthBan });
            }
            if (matchDetails.Ban7Id != 0)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban7Id)?.Id ?? 1, GodBanOrder = GodBanOrderEnum.SeventhBan });
            }
            if (matchDetails.Ban8Id != 0)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban8Id)?.Id ?? 1, GodBanOrder = GodBanOrderEnum.EightBan });
            }
            if (matchDetails.Ban9Id != 0)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban9Id)?.Id ?? 1, GodBanOrder = GodBanOrderEnum.NinthBan });
            }
            if (matchDetails.Ban10Id != 0)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban10Id)?.Id ?? 1, GodBanOrder = GodBanOrderEnum.TenthBan });
            }
            if (matchDetails.Ban11Id != 0)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban11Id)?.Id ?? 1, GodBanOrder = GodBanOrderEnum.EleventhBan });
            }
            if (matchDetails.Ban12Id != 0)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban12Id)?.Id ?? 1, GodBanOrder = GodBanOrderEnum.TwelfthBan });
            }

            return godBans;
        }

        private List<ActivePurchase> BuildActivePurchaseEntities(MatchDetailsResponse matchDetails, List<Active> actives)
        {
            var activePurchases = new List<ActivePurchase>();
            if (matchDetails.ActiveId1 != 0)
            {
                activePurchases.Add(new ActivePurchase { ActiveId = actives.SingleOrDefault(x => x.SmiteId == matchDetails.ActiveId1)?.Id ?? 1, ActivePurchaseOrder = ActivePurchaseOrderEnum.FirstActive });
            }
            if (matchDetails.ActiveId2 != 0)
            {
                activePurchases.Add(new ActivePurchase { ActiveId = actives.SingleOrDefault(x => x.SmiteId == matchDetails.ActiveId2)?.Id ?? 1, ActivePurchaseOrder = ActivePurchaseOrderEnum.SecondActive });
            }

            return activePurchases;
        }

        private List<ItemPurchase> BuildItemPurchaseEntities(MatchDetailsResponse matchDetails, List<Item> items)
        {
            var itemPurchases = new List<ItemPurchase>();
            if (matchDetails.ItemId1 != 0)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetails.ItemId1)?.Id ?? 1, ItemPurchaseOrder = ItemPurchaseOrderEnum.FirstItem });
            }
            if (matchDetails.ItemId2 != 0)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetails.ItemId2)?.Id ?? 1, ItemPurchaseOrder = ItemPurchaseOrderEnum.SecondItem });
            }
            if (matchDetails.ItemId3 != 0)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetails.ItemId3)?.Id ?? 1, ItemPurchaseOrder = ItemPurchaseOrderEnum.ThirdItem });
            }
            if (matchDetails.ItemId4 != 0)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetails.ItemId4)?.Id ?? 1, ItemPurchaseOrder = ItemPurchaseOrderEnum.FourthItem });
            }
            if (matchDetails.ItemId5 != 0)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetails.ItemId5)?.Id ?? 1, ItemPurchaseOrder = ItemPurchaseOrderEnum.FifthItem });
            }
            if (matchDetails.ItemId6 != 0)
            {
                itemPurchases.Add(new ItemPurchase { ItemId = items.SingleOrDefault(x => x.SmiteId == matchDetails.ItemId6)?.Id ?? 1, ItemPurchaseOrder = ItemPurchaseOrderEnum.SixthItem });
            }

            return itemPurchases;
        }

        private Player BuildPlayerEntity(MatchDetailsResponse matchDetails)
        {
            return new Player
            {
                HirezGamerTag = matchDetails.HzGamerTag,
                HirezPlayerName = matchDetails.HzPlayerName,
                LastSynchronizedMatchId = matchDetails.Match,
                Level = matchDetails.AccountLevel,
                MasteryLevel = matchDetails.MasteryLevel,
                PlayerName = matchDetails.PlayerName,
                PortalType = (PortalTypeEnum)int.Parse(matchDetails.PlayerPortalId!),
                PrivacyEnabled = false,
                SmiteId = int.Parse(matchDetails.PlayerId),
                SmitePortalUserId = matchDetails.PlayerPortalUserId != null ? long.Parse(matchDetails.PlayerPortalUserId) : null
            };
        }

        private void UpdatePlayerEntity(Player player, MatchDetailsResponse matchDetails)
        {
            player.HirezGamerTag = matchDetails.HzGamerTag;
            player.HirezPlayerName = matchDetails.HzPlayerName;
            player.LastSynchronizedMatchId = matchDetails.Match;
            player.Level = matchDetails.AccountLevel;
            player.MasteryLevel = matchDetails.MasteryLevel;
            player.PlayerName = matchDetails.PlayerName;
            player.PortalType = (PortalTypeEnum) int.Parse(matchDetails.PlayerPortalId!);
            player.PrivacyEnabled = false;
            player.SmiteId = int.Parse(matchDetails.PlayerId);
            player.SmitePortalUserId = matchDetails.PlayerPortalUserId != null ? long.Parse(matchDetails.PlayerPortalUserId) : null;
        }

        private Player BuildAnonymousPlayerEntity(MatchDetailsResponse matchDetails)
        {
            return new Player
            {
                Level = matchDetails.AccountLevel,
                MasteryLevel = matchDetails.MasteryLevel,
                PrivacyEnabled = true,
            };
        }

        #endregion

        #region Converters

        /// <summary>
        /// Converts a god role string to <see cref="GodRoleEnum"/>
        /// </summary>
        /// <param name="godRoles"></param>
        /// <returns></returns>
        private GodRoleEnum ConvertToGodRoleEnum(string godRoles) => godRoles switch
        {
            GodResponseConstants.WarriorRole => GodRoleEnum.Warrior,
            GodResponseConstants.MageRole => GodRoleEnum.Mage,
            GodResponseConstants.HunterRole => GodRoleEnum.Hunter,
            GodResponseConstants.AssassinRole => GodRoleEnum.Assassin,
            GodResponseConstants.GuardianRole => GodRoleEnum.Guardian,
            _ => GodRoleEnum.Unknown
        };

        /// <summary>
        /// Converts a team id int to <see cref="MatchTeamEnum"/>
        /// </summary>
        /// <param name="matchTeamId"></param>
        /// <returns></returns>
        private MatchTeamEnum ConvertToMatchTeamEnum(int matchTeamId) => matchTeamId switch
        {
            MatchResponseConstants.MatchTeamOne => MatchTeamEnum.TeamOne,
            MatchResponseConstants.MatchTeamTwo => MatchTeamEnum.TeamTwo,
            _ => MatchTeamEnum.Unknown
        };

        #endregion
    }
}
