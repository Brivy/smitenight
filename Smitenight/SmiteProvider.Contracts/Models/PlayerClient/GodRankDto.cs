﻿namespace Smitenight.Providers.SmiteProvider.Contracts.Models.PlayerClient
{
    public record class GodRankDto
    (
        int Assists,
        int Deaths,
        int Kills,
        int Losses,
        int MinionKills,
        int Rank,
        int Wins,
        int Worshippers,
        string God,
        string GodId,
        string PlayerId,
        object RetMsg
    );
}
