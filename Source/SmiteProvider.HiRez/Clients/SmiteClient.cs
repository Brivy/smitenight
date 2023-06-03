using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Exceptions;
using Smitenight.Providers.SmiteProvider.HiRez.Exceptions;
using Smitenight.Providers.SmiteProvider.HiRez.Services;
using Smitenight.Utilities.Mapper.Services;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public partial class SmiteClient : ISmiteClient
    {
        private readonly HttpClient _httpClient;
        private readonly ISmiteClientUrlService _smiteClientUrlService;
        private readonly IMapperService _mapperService;

        public SmiteClient(
            HttpClient httpClient,
            ISmiteClientUrlService smiteClientUrlService,
            IMapperService mapperService)
        {
            _httpClient = httpClient;
            _smiteClientUrlService = smiteClientUrlService;
            _mapperService = mapperService;
        }

        private async Task PingAsync(string url, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(request, cancellationToken);
            if (response.StatusCode != HttpStatusCode.OK) throw new SmiteClientPingFailedException($"Ping returned invalid status code: {response.StatusCode}");
        }

        private async Task<TResponse> GetAsync<TResponse>(string url, CancellationToken cancellationToken = default)
            where TResponse : class
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await _httpClient.SendAsync(request, cancellationToken);
                return await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken) ?? throw new SmiteClientInvalidResponseException("The HTTP content is empty or empty");
            }
            catch (SmiteClientInvalidResponseException ex)
            {
                throw new SmiteClientRequestException($"The response was invalid: {ex.Message}");
            }
            catch (JsonException ex)
            {
                throw new SmiteClientRequestException($"Could not deserialize response body: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new SmiteClientRequestException($"The request ended in an exception: {ex.Message}");
            }
        }
    }
}
