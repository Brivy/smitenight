//using Microsoft.EntityFrameworkCore;
//using Smitenight.Application.Blazor.Business.Contracts.Services.Builders;
//using Smitenight.Domain.Models.Clients.MatchClient;
//using Smitenight.Persistence.Data.Contracts.Enums;
//using Smitenight.Persistence.Data.EntityFramework;
//using Smitenight.Persistence.Data.EntityFramework.Entities;
//using Smitenight.Providers.SmiteProvider.Contracts.Constants;

//namespace Smitenight.Application.Blazor.Business.Services.Builders
//{
//    public class GodBanBuilderService : IGodBanBuilderService
//    {
//        private readonly SmitenightDbContext _dbContext;

//        public GodBanBuilderService(SmitenightDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        public async Task<List<GodBan>> BuildAsync(MatchDetailsResponse matchDetailsResponse, CancellationToken cancellationToken = default)
//        {
//            var godBans = new List<GodBan>();
//            var godBanIdList = new List<int>
//            {
//                matchDetailsResponse.Ban1Id,
//                matchDetailsResponse.Ban2Id,
//                matchDetailsResponse.Ban3Id,
//                matchDetailsResponse.Ban4Id,
//                matchDetailsResponse.Ban5Id,
//                matchDetailsResponse.Ban6Id,
//                matchDetailsResponse.Ban7Id,
//                matchDetailsResponse.Ban8Id,
//                matchDetailsResponse.Ban9Id,
//                matchDetailsResponse.Ban10Id,
//                matchDetailsResponse.Ban11Id,
//                matchDetailsResponse.Ban12Id
//            };

//            godBanIdList.RemoveAll(x => x == SmiteConstants.EmptyResponse);
//            if (!godBanIdList.Any())
//            {
//                return godBans;
//            }

//            var gods = await _dbContext.Gods.AsNoTracking().Where(x => godBanIdList.Contains(x.SmiteId)).ToListAsync(cancellationToken);
//            if (matchDetailsResponse.Ban1Id != SmiteConstants.EmptyResponse)
//            {
//                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban1Id)?.Id ?? MatchConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.FirstBan });
//            }
//            if (matchDetailsResponse.Ban2Id != SmiteConstants.EmptyResponse)
//            {
//                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban2Id)?.Id ?? MatchConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.SecondBan });
//            }
//            if (matchDetailsResponse.Ban3Id != SmiteConstants.EmptyResponse)
//            {
//                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban3Id)?.Id ?? MatchConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.ThirdBan });
//            }
//            if (matchDetailsResponse.Ban4Id != SmiteConstants.EmptyResponse)
//            {
//                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban4Id)?.Id ?? MatchConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.FourthBan });
//            }
//            if (matchDetailsResponse.Ban5Id != SmiteConstants.EmptyResponse)
//            {
//                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban5Id)?.Id ?? MatchConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.FifthBan });
//            }
//            if (matchDetailsResponse.Ban6Id != SmiteConstants.EmptyResponse)
//            {
//                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban6Id)?.Id ?? MatchConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.SixthBan });
//            }
//            if (matchDetailsResponse.Ban7Id != SmiteConstants.EmptyResponse)
//            {
//                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban7Id)?.Id ?? MatchConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.SeventhBan });
//            }
//            if (matchDetailsResponse.Ban8Id != SmiteConstants.EmptyResponse)
//            {
//                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban8Id)?.Id ?? MatchConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.EightBan });
//            }
//            if (matchDetailsResponse.Ban9Id != SmiteConstants.EmptyResponse)
//            {
//                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban9Id)?.Id ?? MatchConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.NinthBan });
//            }
//            if (matchDetailsResponse.Ban10Id != SmiteConstants.EmptyResponse)
//            {
//                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban10Id)?.Id ?? MatchConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.TenthBan });
//            }
//            if (matchDetailsResponse.Ban11Id != SmiteConstants.EmptyResponse)
//            {
//                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban11Id)?.Id ?? MatchConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.EleventhBan });
//            }
//            if (matchDetailsResponse.Ban12Id != SmiteConstants.EmptyResponse)
//            {
//                godBans.Add(new GodBan { GodId = gods.SingleOrDefault(x => x.SmiteId == matchDetailsResponse.Ban12Id)?.Id ?? MatchConstants.DefaultGodId, GodBanOrder = GodBanOrderEnum.TwelfthBan });
//            }

//            return godBans;
//        }
//    }
//}
