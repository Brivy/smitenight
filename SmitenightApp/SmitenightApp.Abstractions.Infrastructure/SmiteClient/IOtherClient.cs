using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.OtherResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IOtherClient
{
    Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(
        CancellationToken cancellationToken = default);

    Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(
        CancellationToken cancellationToken = default);
}