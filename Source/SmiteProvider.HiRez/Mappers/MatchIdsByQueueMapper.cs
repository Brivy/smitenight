﻿using Smitenight.Providers.SmiteProvider.Contracts.Models.MatchClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.MatchClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

internal class MatchIdsByQueueMapper : Mapper<MatchIdsByQueue, MatchIdsByQueueDto>
{
    public override MatchIdsByQueueDto Map(MatchIdsByQueue input)
    {
        return new MatchIdsByQueueDto
        {
            ActiveFlag = input.ActiveFlag ?? string.Empty,
            Match = input.Match ?? string.Empty,
            RetMsg = input.RetMsg ?? string.Empty,
        };
    }
}
