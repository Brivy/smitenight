using Smitenight.Providers.SmiteProvider.Contracts.Exceptions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients
{
    public abstract class SmiteClient
    {
        private readonly HttpClient _httpClient;

        protected SmiteClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        protected async Task PingAsync(string url, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(request, cancellationToken);
            if (response.StatusCode != HttpStatusCode.OK) throw new SmiteClientPingFailedException($"Ping returned invalid status code: {response.StatusCode}");
        }

        protected async Task<TResponse> GetAsync<TResponse>(string url, CancellationToken cancellationToken = default)
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
