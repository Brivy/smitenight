using Smitenight.Domain.Models.Clients.MatchClient;
using Smitenight.Domain.Models.Models.Matches;

namespace Smitenight.Application.Blazor.Business.Contracts.Services.Builders;

public interface IMatchDetailBuilderService
{
    MatchDetail Build(MatchDetailsResponse matchDetailsResponse);
}