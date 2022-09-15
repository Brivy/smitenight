using Microsoft.EntityFrameworkCore;
using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Domain.Clients.MatchClient;
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

        public async Task<List<GodBan>> BuildAsync(MatchDetailsResponse matchDetailsResponse, CancellationToken cancellationToken = default)
        {
            var godBans = new List<GodBan>();
            var godBanIdList = new List<int>
            {
                matchDetailsResponse.Ban1Id, 
                matchDetailsResponse.Ban2Id, 
                matchDetailsResponse.Ban3Id, 
                matchDetailsResponse.Ban4Id, 
                matchDetailsResponse.Ban5Id, 
                matchDetailsResponse.Ban6Id, 
                matchDetailsResponse.Ban7Id, 
                matchDetailsResponse.Ban8Id, 
                matchDetailsResponse.Ban9Id, 
                matchDetailsResponse.Ban10Id, 
                matchDetailsResponse.Ban11Id, 
                matchDetailsResponse.Ban12Id
            };

            godBanIdList.RemoveAll(x => x == ResponseConstants.EmptyResponse);
            if (!godBanIdList.Any())
            {
                return godBans;
            }
            
            var gods = await _dbContext.Gods.AsNoTracking().Where(x => godBanIdList.Contains(x.SmiteId)).ToListAsync(cancellationToken);
            if (matchDetailsResponse.Ban1Id != ResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban1Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.FirstBan });
            }
            if (matchDetailsResponse.Ban2Id != ResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban2Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.SecondBan });
            }
            if (matchDetailsResponse.Ban3Id != ResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban3Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.ThirdBan });
            }
            if (matchDetailsResponse.Ban4Id != ResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban4Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.FourthBan });
            }
            if (matchDetailsResponse.Ban5Id != ResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban5Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.FifthBan });
            }
            if (matchDetailsResponse.Ban6Id != ResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban6Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.SixthBan });
            }
            if (matchDetailsResponse.Ban7Id != ResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban7Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.SeventhBan });
            }
            if (matchDetailsResponse.Ban8Id != ResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban8Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.EightBan });
            }
            if (matchDetailsResponse.Ban9Id != ResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban9Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.NinthBan });
            }
            if (matchDetailsResponse.Ban10Id != ResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban10Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.TenthBan });
            }
            if (matchDetailsResponse.Ban11Id != ResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban11Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.EleventhBan });
            }
            if (matchDetailsResponse.Ban12Id != ResponseConstants.EmptyResponse)
            {
                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban12Id)?.Id ?? MatchResponseConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.TwelfthBan });
            }

            return godBans;
        }
    }
}
