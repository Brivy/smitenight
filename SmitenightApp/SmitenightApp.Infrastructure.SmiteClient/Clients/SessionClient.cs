﻿using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.SystemRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.SystemResponses;
using SmitenightApp.Infrastructure.SmiteClient.Contracts.SystemResponses;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public class SessionClient : SmiteClient, ISessionClient
    {
        public SessionClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper) : base(httpClient, smiteClientSettings, smiteClientSecrets, mapper)
        {
        }

        public async Task<SmiteClientResponse<CreateSmiteSessionResponse>?> CreateSmiteSessionAsync(
            CreateSmiteSessionRequest request, CancellationToken cancellationToken)
        {
            var result = await GetAsync<CreateSmiteSessionRequest, CreateSmiteSessionResponseDto>(request, cancellationToken);
            return Mapper.Map<SmiteClientResponse<CreateSmiteSessionResponse>>(result);
        }
    }
}
