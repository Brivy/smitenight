using Smitenight.Domain.Models.Clients.GodClient;
using Smitenight.Domain.Models.Models.Gods;

namespace Smitenight.Application.Blazor.Business.Contracts.Services.Builders;

public interface IGodBuilderService
{
    God Build(GodsResponse godResponse, List<GodSkinsResponse> godSkinsResponse);
}