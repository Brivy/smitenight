using SmitenightApp.Domain.Clients.SmiteClient.Responses.GodResponses;
using SmitenightApp.Domain.Models.Gods;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IGodBuilderService
{
    God Build(GodsResponse god, List<GodSkinsResponse> godSkins);
}