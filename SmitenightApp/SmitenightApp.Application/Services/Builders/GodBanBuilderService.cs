using Microsoft.EntityFrameworkCore;
using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.MatchResponses;
using SmitenightApp.Domain.Constants.SmiteClient.Responses;
using SmitenightApp.Domain.Enums.Gods;
using SmitenightApp.Domain.Models.Gods;
using SmitenightApp.Persistence;

namespace SmitenightApp.Application.Services.Builders
{
    public class GodBanBuilderService : IGodBanBuilderService
    {
        private readonly SmitenightDbContext _dbContext;

        public GodBanBuilderService(SmitenightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<GodBan>> BuildAsync(MatchDetailsResponse matchDetails, CancellationToken cancellationToken = default)
        {
            var godBans = new List<GodBan>();
            var godBanIdList = new List<int>
            {
                matchDetails.Ban1Id, 
                matchDetails.Ban2Id, 
                matchDetails.Ban3Id, 
                matchDetails.Ban4Id, 
                matchDetails.Ban5Id, 
                matchDetails.Ban6Id, 
                matchDetails.Ban7Id, 
                matchDetails.Ban8Id, 
                matchDetails.Ban9Id, 
                matchDetails.Ban10Id, 
                matchDetails.Ban11Id, 
                matchDetails.Ban12Id
            };

            godBanIdList.RemoveAll(x => x == MatchResponseConstants.EmptyResponse);
            if (!godBanIdList.Any())
            {
                return godBans;
            }
            
            var gods = await _dbContext.Gods.AsNoTracking().Where(x => godBanIdList.Contains(x.SmiteId)).ToListAsync(cancellationToken);
            if (matchDetails.Ban1Id != MatchResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban1Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.FirstBan });
            }
            if (matchDetails.Ban2Id != MatchResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban2Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.SecondBan });
            }
            if (matchDetails.Ban3Id != MatchResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban3Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.ThirdBan });
            }
            if (matchDetails.Ban4Id != MatchResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban4Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.FourthBan });
            }
            if (matchDetails.Ban5Id != MatchResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban5Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.FifthBan });
            }
            if (matchDetails.Ban6Id != MatchResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban6Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.SixthBan });
            }
            if (matchDetails.Ban7Id != MatchResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban7Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.SeventhBan });
            }
            if (matchDetails.Ban8Id != MatchResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban8Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.EightBan });
            }
            if (matchDetails.Ban9Id != MatchResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban9Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.NinthBan });
            }
            if (matchDetails.Ban10Id != MatchResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban10Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.TenthBan });
            }
            if (matchDetails.Ban11Id != MatchResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban11Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.EleventhBan });
            }
            if (matchDetails.Ban12Id != MatchResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetails.Ban12Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.TwelfthBan });
            }

            return godBans;
        }
    }
}
