using Smitenight.Providers.SmiteProvider.Contracts.Enums;
using Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Models.PlayerClient;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients;

public partial class SmiteClient
{
    public async Task<IEnumerable<FriendDto>> GetFriendsAsync(string playerId, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.FriendsMethod, urlPath, cancellationToken);
        IEnumerable<Friend> result = await GetAsync<IEnumerable<Friend>>(url, cancellationToken);
        return _mapperService.MapAll<Friend, FriendDto>(result);
    }

    public async Task<IEnumerable<GodRankDto>> GetGodRanksAsync(string playerId, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.GodRanksMethod, urlPath, cancellationToken);
        IEnumerable<GodRank> result = await GetAsync<IEnumerable<GodRank>>(url, cancellationToken);
        return _mapperService.MapAll<GodRank, GodRankDto>(result);
    }

    public async Task<PlayerAchievementDto> GetPlayerAchievementsAsync(int playerId, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerAchievementsMethod, urlPath, cancellationToken);
        PlayerAchievement result = await GetAsync<PlayerAchievement>(url, cancellationToken);
        return _mapperService.Map<PlayerAchievement, PlayerAchievementDto>(result);
    }

    public async Task<IEnumerable<PlayerStatusDto>> GetPlayerStatusAsync(string playerId, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.PlayerStatusMethod, urlPath, cancellationToken);
        IEnumerable<PlayerStatus> result = await GetAsync<IEnumerable<PlayerStatus>>(url, cancellationToken);
        return _mapperService.MapAll<PlayerStatus, PlayerStatusDto>(result);
    }

    public async Task<IEnumerable<MatchHistoryDto>> GetMatchHistoryAsync(string playerId, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.MatchHistoryMethod, urlPath, cancellationToken);
        IEnumerable<MatchHistory> result = await GetAsync<IEnumerable<MatchHistory>>(url, cancellationToken);
        return _mapperService.MapAll<MatchHistory, MatchHistoryDto>(result);
    }

    public async Task<IEnumerable<QueueStatsDto>> GetQueueStatsAsync(string playerId, GameModeQueue gameModeQueue, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(playerId, (int)gameModeQueue);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.QueueStatsMethod, urlPath, cancellationToken);
        IEnumerable<QueueStats> result = await GetAsync<IEnumerable<QueueStats>>(url, cancellationToken);
        return _mapperService.MapAll<QueueStats, QueueStatsDto>(result);
    }

    public async Task<IEnumerable<SearchPlayerDto>> SearchPlayersAsync(string playerId, CancellationToken cancellationToken = default)
    {
        string urlPath = _smiteClientUrlService.ConstructUrlPath(playerId);
        string url = await _smiteClientUrlService.ConstructUrlAsync(MethodNameConstants.SearchPlayersMethod, urlPath, cancellationToken);
        IEnumerable<SearchPlayer> result = await GetAsync<IEnumerable<SearchPlayer>>(url, cancellationToken);
        return _mapperService.MapAll<SearchPlayer, SearchPlayerDto>(result);
    }
}
