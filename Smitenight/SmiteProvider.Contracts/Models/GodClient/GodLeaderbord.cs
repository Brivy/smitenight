﻿namespace Smitenight.Domain.Models.Clients.GodClient
{
    public record class GodLeaderbord(
        string GodId,
        string Losses,
        string PlayerId,
        string PlayerName,
        string PlayerRanking,
        string Rank,
        object RetMsg,
        string Wins);
}