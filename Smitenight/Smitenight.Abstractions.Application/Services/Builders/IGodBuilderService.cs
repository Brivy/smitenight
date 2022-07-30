using Smitenight.Domain.Clients.SmiteClient.Responses.GodResponses;
using Smitenight.Domain.Models.Gods;

namespace Smitenight.Abstractions.Application.Services.Builders;

public interface IGodBuilderService
{
    God Build(GodsResponse god, List<GodSkinsResponse> godSkins);
}