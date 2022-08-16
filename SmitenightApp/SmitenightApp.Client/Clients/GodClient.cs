using SmitenightApp.Client.Constants.Endpoints;
using SmitenightApp.Client.Interfaces;
using SmitenightApp.Domain.Contracts.Common;
using SmitenightApp.Domain.Contracts.Gods;

namespace SmitenightApp.Client.Clients
{
    public class GodClient : ServerClient, IGodClient
    {
        public GodClient(HttpClient httpClient) : base(httpClient, GodEndpoints.BaseUrl)
        {
        }

        public async Task<ServerResponseDto<List<GodSkinDto>>> ListHomeLoadingSkinsAsync(CancellationToken cancellationToken = default)
        {
            var result = await GetAsync<List<GodSkinDto>>(GodEndpoints.ListHomeLoadingSkins, cancellationToken);
            return result;
        }
    }
}
