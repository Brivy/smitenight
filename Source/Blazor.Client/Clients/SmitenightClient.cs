using Smitenight.Domain.Models.Contracts.Common;
using Smitenight.Domain.Models.Contracts.Smitenights;
using Smitenight.Presentation.Blazor.Client.Constants.Endpoints;
using Smitenight.Presentation.Blazor.Client.Interfaces;

namespace Smitenight.Presentation.Blazor.Client.Clients
{
    public class SmitenightClient : ServerClient, ISmitenightClient
    {
        public SmitenightClient(HttpClient httpClient) : base(httpClient, SmitenightEndpoints.BaseUrl)
        {
        }

        public async Task<ServerResponseDto<SmitenightDto>> StartSmitenightAsync(SmitenightProcessDto requestDto, CancellationToken cancellationToken = default)
        {
            var result = await PostAsync<SmitenightProcessDto, SmitenightDto>(SmitenightEndpoints.StartSmitenight, requestDto, cancellationToken);
            return result;
        }

        public async Task<ServerResponseDto<SmitenightDto>> EndSmitenightAsync(SmitenightProcessDto requestDto, CancellationToken cancellationToken = default)
        {
            var result = await PostAsync<SmitenightProcessDto, SmitenightDto>(SmitenightEndpoints.EndSmitenight, requestDto, cancellationToken);
            return result;
        }
    }
}
