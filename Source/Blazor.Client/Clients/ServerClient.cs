using Smitenight.Domain.Models.Contracts.Common;
using Smitenight.Domain.Models.Enums.StatusCodes;
using System.Net.Http.Json;

namespace Smitenight.Presentation.Blazor.Client.Clients
{
    public abstract class ServerClient(HttpClient httpClient,
        string baseUrl)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly string _baseUrl = baseUrl;

        protected async Task<ServerResponseDto> GetAsync(string url, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ServerResponseDto>(_baseUrl + url, cancellationToken);
                return response ?? new ServerResponseDto(StatusCodeEnum.DeserializationEndedInNull);
            }
            catch (Exception)
            {
                return new ServerResponseDto(StatusCodeEnum.ExceptionDuringSendingRequest);
            }
        }

        protected async Task<ServerResponseDto<TResponse>> GetAsync<TResponse>(string url, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ServerResponseDto<TResponse>>(_baseUrl + url, cancellationToken);
                return response ?? new ServerResponseDto<TResponse>(StatusCodeEnum.DeserializationEndedInNull);
            }
            catch (Exception)
            {
                return new ServerResponseDto<TResponse>(StatusCodeEnum.ExceptionDuringSendingRequest);
            }
        }

        protected async Task<ServerResponseDto> PostAsync<TRequest>(string url, TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_baseUrl + url, request, cancellationToken);
                try
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<ServerResponseDto>(cancellationToken: cancellationToken);
                    return responseBody ?? new ServerResponseDto(StatusCodeEnum.DeserializationEndedInNull);
                }
                catch (Exception)
                {
                    return new ServerResponseDto(StatusCodeEnum.ExceptionDuringDeserialization);
                }
            }
            catch (Exception)
            {
                return new ServerResponseDto(StatusCodeEnum.ExceptionDuringSendingRequest);
            }
        }

        protected async Task<ServerResponseDto<TResponse>> PostAsync<TRequest, TResponse>(string url, TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync(_baseUrl + url, request, cancellationToken);
                try
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<ServerResponseDto<TResponse>>(cancellationToken: cancellationToken);
                    return responseBody ?? new ServerResponseDto<TResponse>(StatusCodeEnum.DeserializationEndedInNull);
                }
                catch (Exception)
                {
                    return new ServerResponseDto<TResponse>(StatusCodeEnum.ExceptionDuringDeserialization);
                }
            }
            catch (Exception)
            {
                return new ServerResponseDto<TResponse>(StatusCodeEnum.ExceptionDuringSendingRequest);
            }
        }
    }
}
