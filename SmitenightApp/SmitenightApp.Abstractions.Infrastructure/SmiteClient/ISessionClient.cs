using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.SystemResponses;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface ISessionClient
{
    Task<SmiteClientResponse<CreateSmiteSessionResponse>?> CreateSmiteSessionAsync(CancellationToken cancellationToken);
}