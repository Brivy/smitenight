﻿using System.Text.Json.Serialization;

namespace Smitenight.Providers.SmiteProvider.HiRez.Models.TeamClient;

public record class TeamPlayer
{
    [JsonPropertyName("AccountLevel")] public int AccountLevel { get; init; }
    [JsonPropertyName("JoinedDatetime")] public string? JoinedDatetime { get; init; }
    [JsonPropertyName("LastLoginDatetime")] public string? LastLoginDatetime { get; init; }
    [JsonPropertyName("Name")] public string? Name { get; init; }
    [JsonPropertyName("PlayerId")] public string? PlayerId { get; init; }
    [JsonPropertyName("ret_msg")] public string? RetMsg { get; init; }
}
