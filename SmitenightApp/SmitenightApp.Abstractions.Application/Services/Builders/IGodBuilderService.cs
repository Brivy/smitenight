using SmitenightApp.Domain.Clients.GodClient;
using SmitenightApp.Domain.Models.Gods;

namespace SmitenightApp.Abstractions.Application.Services.Builders;

public interface IGodBuilderService
{
    God Build(GodsResponse godResponse, List<GodSkinsResponse> godSkinsResponse);
}