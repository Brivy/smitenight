using System.Net;
using System.Net.Http.Json;
using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Infrastructure.SmiteClient.Contracts;
using Smitenight.Infrastructure.SmiteClient.Settings;

namespace Smitenight.Infrastructure.SmiteClient.Clients
{
    public abstract class SmiteClient
    {
        private readonly HttpClient _httpClient;
        private readonly SmiteClientSettings _smiteClientSettings;

        protected readonly IMapper Mapper;

        protected SmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IMapper mapper)
        {
            _httpClient = httpClient;
            _smiteClientSettings = smiteClientSettings.Value;
            Mapper = mapper;
        }

        protected async Task<SmiteClientResponseDto> GetAsync(string urlPath, CancellationToken cancellationToken)
        {
            try
            {
                var url = ConstructUrl(urlPath);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await _httpClient.SendAsync(request, cancellationToken);
                return new SmiteClientResponseDto(response.StatusCode, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                return new SmiteClientResponseDto(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        protected async Task<SmiteClientResponseDto<TResponseType>> GetAsync<TResponseType>(string urlPath, CancellationToken cancellationToken)
            where TResponseType : class
        {
            try
            {
                var url = ConstructUrl(urlPath);
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

        protected async Task<SmiteClientListResponseDto<TResponseType>> GetListAsync<TResponseType>(string urlPath, CancellationToken cancellationToken)
            where TResponseType : class
        {
            try
            {
                var url = ConstructUrl(urlPath);
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

        private string? ConstructUrl(string urlPath)
        {
            var smiteUrl = _smiteClientSettings.Url;
            if (smiteUrl == null)
            {
                throw new NullReferenceException("Smite URL is not defined in the settings");
            }

            return $"{smiteUrl}{urlPath}";
        }
    }
}
