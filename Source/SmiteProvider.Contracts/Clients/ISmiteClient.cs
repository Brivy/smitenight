using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.GodClient;
using Smitenight.Providers.SmiteProvider.Contracts.Models.ItemClient;
using Smitenight.Providers.SmiteProvider.Contracts.Models.LeagueClient;
using Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;
using Smitenight.Providers.SmiteProvider.Contracts.Models.OtherClient;
using Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;
using Smitenight.Providers.SmiteProvider.Contracts.Models.RetrievePlayerClient;
using Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;
using Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient;

namespace Smitenight.Providers.SmiteProvider.Contracts.Clients;

public interface ISmiteClient
{
    Task<IEnumerable<DataUsedDto>> GetDataUsedAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<DemoDetailsDto>> GetDemoDetailsAsync(int matchId, CancellationToken cancellationToken = default);
    Task<IEnumerable<EsportProLeagueDto>> GetEsportProLeagueAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<FriendDto>> GetFriendsAsync(string playerId, CancellationToken cancellationToken = default);
    Task<IEnumerable<GodAltAbilityDto>> GetGodAltAbilitiesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<GodLeaderboardDto>> GetGodLeaderboardAsync(int godId, GameModeQueue gameModeQueue, CancellationToken cancellationToken = default);
    Task<IEnumerable<GodRankDto>> GetGodRanksAsync(string playerId, CancellationToken cancellationToken = default);
    Task<IEnumerable<GodRecommendedItemDto>> GetGodRecommendedItemsAsync(int godId, LanguageCode languageCode, CancellationToken cancellationToken = default);
    Task<IEnumerable<GodDto>> GetGodsAsync(LanguageCode languageCode, CancellationToken cancellationToken = default);
    Task<IEnumerable<GodSkinDto>> GetGodSkinsAsync(int godId, LanguageCode languageCode, CancellationToken cancellationToken = default);
    Task<IEnumerable<HirezServerStatusDto>> GetHirezServerStatusAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<ItemDto>> GetItemsAsync(LanguageCode languageCode, CancellationToken cancellationToken = default);
    Task<IEnumerable<LeagueLeaderboardDto>> GetLeagueLeaderboardAsync(GameModeQueue gameModeQueue, LeagueTier leagueTier, int round, CancellationToken cancellationToken = default);
    Task<IEnumerable<LeagueSeasonDto>> GetLeagueSeasonsAsync(GameModeQueue gameModeQueue, CancellationToken cancellationToken = default);
    Task<IEnumerable<MatchDetailsDto>> GetMatchDetailsAsync(int matchId, CancellationToken cancellationToken = default);
    Task<IEnumerable<MatchDetailsDto>> GetMatchDetailsBatchAsync(List<int> matchIds, CancellationToken cancellationToken = default);
    Task<IEnumerable<MatchHistoryDto>> GetMatchHistoryAsync(string playerId, CancellationToken cancellationToken = default);
    Task<IEnumerable<MatchIdsByQueueDto>> GetMatchIdsByQueueAsync(GameModeQueue gameModeQueue, int matchIdDate, int matchIdHour, CancellationToken cancellationToken = default);
    Task<IEnumerable<MatchPlayerDetailsDto>> GetMatchPlayerDetailsAsync(int matchId, CancellationToken cancellationToken = default);
    Task<IEnumerable<MotdDto>> GetMotdAsync(CancellationToken cancellationToken = default);
    Task<PatchInfoDto> GetPatchInfoAsync(CancellationToken cancellationToken = default);
    Task<PlayerAchievementDto> GetPlayerAchievementsAsync(int playerId, CancellationToken cancellationToken = default);
    Task<IEnumerable<PlayerDto>> GetPlayerAsync(string playerId, PortalType portalType, CancellationToken cancellationToken = default);
    Task<IEnumerable<PlayerIdDto>> GetPlayerIdByGamerTagAsync(PortalType portalType, string gamerTag, CancellationToken cancellationToken = default);
    Task<IEnumerable<PlayerIdDto>> GetPlayerIdByPlayerNameAsync(string playerName, CancellationToken cancellationToken = default);
    Task<IEnumerable<PlayerIdDto>> GetPlayerIdByPortalUserAsync(PortalType portalType, string portalUserId, CancellationToken cancellationToken = default);
    Task<IEnumerable<PlayerStatusDto>> GetPlayerStatusAsync(string playerId, CancellationToken cancellationToken = default);
    Task<IEnumerable<PlayerDto>> GetPlayerWithoutPortalAsync(string playerName, CancellationToken cancellationToken = default);
    Task<IEnumerable<QueueStatsDto>> GetQueueStatsAsync(string playerId, GameModeQueue gameModeQueue, CancellationToken cancellationToken = default);
    Task<IEnumerable<TeamDetailsDto>> GetTeamDetailsAsync(int clanId, CancellationToken cancellationToken = default);
    Task<IEnumerable<TeamPlayerDto>> GetTeamPlayersAsync(int clanId, CancellationToken cancellationToken = default);
    Task<IEnumerable<TopMatchDto>> GetTopMatchesAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<SearchPlayerDto>> SearchPlayersAsync(string playerId, CancellationToken cancellationToken = default);
    Task<IEnumerable<SearchTeamsDto>> SearchTeamsAsync(string teamName, CancellationToken cancellationToken = default);
    Task TestSmiteSessionAsync(CancellationToken cancellationToken = default);
}
