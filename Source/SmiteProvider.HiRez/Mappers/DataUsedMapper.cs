using Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Models.SystemClient;
using Smitenight.Utilities.Mapper.Models;

namespace Smitenight.Providers.SmiteProvider.HiRez.Mappers;

public class DataUsedMapper : Mapper<DataUsed, DataUsedDto>
{
    public override DataUsedDto Map(DataUsed input)
    {
        return new DataUsedDto
        {
            ActiveSessions = input.ActiveSessions,
            ConcurrentSessions = input.ConcurrentSessions,
            RequestLimitDaily = input.RequestLimitDaily,
            SessionCap = input.SessionCap,
            SessionTimeLimit = input.SessionTimeLimit,
            TotalRequestsToday = input.TotalRequestsToday,
            TotalSessionsToday = input.TotalSessionsToday,
            RetMsg = input.RetMsg ?? string.Empty,
        };
    }
}
