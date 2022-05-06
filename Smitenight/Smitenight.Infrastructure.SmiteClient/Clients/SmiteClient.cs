using System.Net;
using System.Net.Http.Json;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Domain.Clients.SmiteClient.Requests;
using Smitenight.Domain.Clients.SmiteClient.Responses;
using Smitenight.Infrastructure.SmiteClient.Contracts;
using Smitenight.Infrastructure.SmiteClient.Settings;

namespace Smitenight.Infrastructure.SmiteClient.Clients
{
    public class SmiteClient
    {
        private readonly HttpClient _httpClient;
        private readonly SmiteClientSettings _smiteClientSettings;

        protected readonly IMapper Mapper;

        public SmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IMapper mapper)
        {
            _httpClient = httpClient;
            _smiteClientSettings = smiteClientSettings.Value;
            Mapper = mapper;
        }

        protected async Task<SmiteClientResponseDto> GetAsync(string url, CancellationToken cancellationToken)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await _httpClient.SendAsync(request, cancellationToken);
                return new SmiteClientResponseDto(response.StatusCode, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                return new SmiteClientResponseDto(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        protected async Task<SmiteClientResponseDto<TResponseType>> GetAsync<TResponseType>(string url, CancellationToken cancellationToken)
            where TResponseType : class
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await _httpClient.SendAsync(request, cancellationToken);

                try
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<TResponseType>(cancellationToken: cancellationToken);
                    return new SmiteClientResponseDto<TResponseType>(response.StatusCode, response.ReasonPhrase, responseBody);
                }
                catch (Exception)
                {
                    return new SmiteClientResponseDto<TResponseType>(response.StatusCode, response.ReasonPhrase, default);
                }
            }
            catch (Exception ex)
            {
                return new SmiteClientResponseDto<TResponseType>(HttpStatusCode.InternalServerError, ex.Message, default);
            }
        }

        protected async Task<SmiteClientListResponseDto<TResponseType>> GetListAsync<TResponseType>(string url, CancellationToken cancellationToken)
            where TResponseType : class
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await _httpClient.SendAsync(request, cancellationToken);

                try
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<List<TResponseType>>(cancellationToken: cancellationToken);
                    return new SmiteClientListResponseDto<TResponseType>(response.StatusCode, response.ReasonPhrase, responseBody);
                }
                catch (Exception)
                {
                    return new SmiteClientListResponseDto<TResponseType>(response.StatusCode, response.ReasonPhrase, default);
                }
            }
            catch (Exception ex)
            {
                return new SmiteClientListResponseDto<TResponseType>(HttpStatusCode.InternalServerError, ex.Message, default);
            }
        }

        protected string? ConstructUrl(SmiteClientRequest smiteClientRequest, params string[] urlPaths)
        {
            var baseUrl = ConstructBaseUrl(smiteClientRequest);
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                return null;
            }

            var sb = new StringBuilder(baseUrl);
            foreach (var urlPath in urlPaths)
            {
                sb.Append($"{urlPath}/");
            }

            // Remove last slash
            sb.Length--;
            return sb.ToString();
        }

        private string ConstructBaseUrl(SmiteClientRequest smiteClientRequest)
        {
            var smiteUrl = _smiteClientSettings.Url;
            if (smiteUrl == null)
            {
                return string.Empty;
            }

            var baseUrl = $"{smiteUrl}{smiteClientRequest.MethodName}{smiteClientRequest.ResponseType}/";
            if (smiteClientRequest.DeveloperId.HasValue)
            {
                baseUrl += $"{smiteClientRequest.DeveloperId}/";
            }

            if (!string.IsNullOrWhiteSpace(smiteClientRequest.Signature))
            {
                baseUrl += $"{smiteClientRequest.Signature}/";
            }

            if (!string.IsNullOrWhiteSpace(smiteClientRequest.SessionId))
            {
                baseUrl += $"{smiteClientRequest.SessionId}/";
            }

            if (!string.IsNullOrWhiteSpace(smiteClientRequest.CurrentDate))
            {
                baseUrl += $"{smiteClientRequest.CurrentDate}/";
            }

            return baseUrl;
        }
    }
}
