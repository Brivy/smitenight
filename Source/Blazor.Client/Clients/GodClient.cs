﻿using Smitenight.Domain.Models.Contracts.Common;
using Smitenight.Domain.Models.Contracts.Gods;
using Smitenight.Presentation.Blazor.Client.Constants.Endpoints;
using Smitenight.Presentation.Blazor.Client.Interfaces;

namespace Smitenight.Presentation.Blazor.Client.Clients
{
    public class GodClient(HttpClient httpClient) : ServerClient(httpClient, GodEndpoints.BaseUrl), IGodClient
    {

        public async Task<ServerResponseDto<List<GodSkinDto>>> ListHomeLoadingSkinsAsync(CancellationToken cancellationToken = default)
        {
            var result = await GetAsync<List<GodSkinDto>>(GodEndpoints.ListHomeLoadingSkins, cancellationToken);
            return result;
        }
    }
}
