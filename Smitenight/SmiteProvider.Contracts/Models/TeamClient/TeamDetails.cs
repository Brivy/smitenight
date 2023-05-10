﻿namespace Smitenight.Domain.Models.Clients.TeamClient
{
    public record class TeamDetails
    (
        string? AvatarUrl,
        string? Founder,
        string? FounderId,
        int Losses,
        string? Name,
        int Players,
        int Rating,
        string? Tag,
        int TeamId,
        int Wins,
        string? RetMsg
    );
}