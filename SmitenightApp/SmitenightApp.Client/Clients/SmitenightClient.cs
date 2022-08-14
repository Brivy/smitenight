using SmitenightApp.Client.Interfaces;
using SmitenightApp.Domain.Constants.Endpoints;
using SmitenightApp.Domain.Contracts.Common;
using SmitenightApp.Domain.Contracts.Smitenights;

namespace SmitenightApp.Client.Clients
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
