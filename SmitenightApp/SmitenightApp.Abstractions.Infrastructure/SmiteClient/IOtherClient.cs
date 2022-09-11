using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.OtherResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface IOtherClient
{
    Task<SmiteClientListResponse<EsportProLeagueResponse>?> GetEsportProLeagueAsync(
        string sessionId, CancellationToken cancellationToken);

    Task<SmiteClientListResponse<MotdResponse>?> GetMotdAsync(
        string sessionId, CancellationToken cancellationToken);
}