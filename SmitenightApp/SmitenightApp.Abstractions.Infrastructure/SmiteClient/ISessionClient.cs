using SmitenightApp.Domain.Clients.SmiteClient;
using SmitenightApp.Domain.Clients.SystemClient;

namespace SmitenightApp.Abstractions.Infrastructure.SmiteClient;

public interface ISessionClient
{
    Task<SmiteClientResponse<CreateSmiteSessionResponse>?> CreateSmiteSessionAsync(CancellationToken cancellationToken = default);
}