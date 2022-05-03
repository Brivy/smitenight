using System.Net;
using System.Net.Http.Json;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Domain.Clients.SmiteClient.Requests;
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

        protected async Task<SmiteClientResponse> GetAsync(string url, CancellationToken cancellationToken)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await _httpClient.SendAsync(request, cancellationToken);
                return new SmiteClientResponse
                {
                    StatusCode = response.StatusCode,
                    ReasonPhrase = response.ReasonPhrase
                };
            }
            catch (Exception ex)
            {
                //TODO: Add logging here
                return new SmiteClientResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = ex.Message
                };
            }
        }

        protected async Task<TResponseType> GetAsync<TResponseType>(string url, CancellationToken cancellationToken)
            where TResponseType : SmiteClientResponse, new()
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await _httpClient.SendAsync(request, cancellationToken);
                
                try
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<TResponseType>(cancellationToken: cancellationToken);
                    if (responseBody == null)
                    {
                        return new TResponseType
                        {
                            ReasonPhrase = response.ReasonPhrase,
                            StatusCode = response.StatusCode
                        };
                    }
                    
                    responseBody.ReasonPhrase = response.ReasonPhrase;
                    responseBody.StatusCode = response.StatusCode;
                    return responseBody;
                }
                catch (Exception)
                {
                    //TODO: Add logging here
                    return new TResponseType
                    {
                        StatusCode = response.StatusCode,
                        ReasonPhrase = response.ReasonPhrase
                    };
                }
            }
            catch (Exception ex)
            {
                //TODO: Add logging here
                return new TResponseType
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = ex.Message
                };
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
