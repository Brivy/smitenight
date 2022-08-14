using System.Net.Http.Json;
using SmitenightApp.Domain.Contracts.Common;
using SmitenightApp.Domain.Enums.StatusCodes;

namespace SmitenightApp.Client.Clients
{
    public abstract class ServerClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        protected ServerClient(HttpClient httpClient,
            string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }

        protected async Task<ServerResponseDto> GetAsync(string url, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.GetAsync(_baseUrl + url, cancellationToken);
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

        protected async Task<ServerResponseDto<TResponse>> GetAsync<TResponse>(string url, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _httpClient.GetAsync(_baseUrl + url, cancellationToken);
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
