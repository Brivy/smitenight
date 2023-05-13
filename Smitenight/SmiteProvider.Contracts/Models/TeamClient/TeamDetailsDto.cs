﻿namespace Smitenight.Providers.SmiteProvider.Contracts.Models.TeamClient
{
    public record class TeamDetailsDto
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