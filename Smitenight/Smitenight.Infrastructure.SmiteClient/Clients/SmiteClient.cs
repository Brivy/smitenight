using System.Net;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Smitenight.Domain.Clients.SmiteClient.Requests;
using Smitenight.Domain.Constants.Common;
using Smitenight.Domain.Secrets;
using Smitenight.Infrastructure.SmiteClient.Contracts;
using Smitenight.Infrastructure.SmiteClient.Secrets;
using Smitenight.Infrastructure.SmiteClient.Settings;

namespace Smitenight.Infrastructure.SmiteClient.Clients
{
    public abstract class SmiteClient
    {
        private readonly HttpClient _httpClient;
        private readonly SmiteClientSecrets _smiteClientSecrets;
        private readonly SmiteClientSettings _smiteClientSettings;

        protected readonly IMapper Mapper;

        protected SmiteClient(HttpClient httpClient,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper)
        {
            _httpClient = httpClient;
            _smiteClientSettings = smiteClientSettings.Value;
            _smiteClientSecrets = smiteClientSecrets.Value;
            Mapper = mapper;
        }

        protected async Task<SmiteClientResponseDto> GetAsync<TRequest>(TRequest smiteRequest, CancellationToken cancellationToken)
            where TRequest : SmiteClientRequest
        {
            try
            {
                var url = ConstructUrl(smiteRequest);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await _httpClient.SendAsync(request, cancellationToken);
                return new SmiteClientResponseDto(response.StatusCode, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                return new SmiteClientResponseDto(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        protected async Task<SmiteClientResponseDto<TResponse>> GetAsync<TRequest, TResponse>(TRequest smiteRequest, CancellationToken cancellationToken)
            where TRequest : SmiteClientRequest
            where TResponse : class
        {
            try
            {
                var url = ConstructUrl(smiteRequest);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await _httpClient.SendAsync(request, cancellationToken);

                try
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<TResponse>(cancellationToken: cancellationToken);
                    return new SmiteClientResponseDto<TResponse>(response.StatusCode, response.ReasonPhrase, responseBody);
                }
                catch (Exception)
                {
                    return new SmiteClientResponseDto<TResponse>(response.StatusCode, response.ReasonPhrase, default);
                }
            }
            catch (Exception ex)
            {
                return new SmiteClientResponseDto<TResponse>(HttpStatusCode.InternalServerError, ex.Message, default);
            }
        }

        protected async Task<SmiteClientListResponseDto<TResponse>> GetListAsync<TRequest, TResponse>(TRequest smiteRequest, CancellationToken cancellationToken)
            where TRequest : SmiteClientRequest
            where TResponse : class
        {
            try
            {
                var url = ConstructUrl(smiteRequest);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                using var response = await _httpClient.SendAsync(request, cancellationToken);

                try
                {
                    var responseBody = await response.Content.ReadFromJsonAsync<List<TResponse>>(cancellationToken: cancellationToken);
                    return new SmiteClientListResponseDto<TResponse>(response.StatusCode, response.ReasonPhrase, responseBody);
                }
                catch (Exception)
                {
                    return new SmiteClientListResponseDto<TResponse>(response.StatusCode, response.ReasonPhrase, default);
                }
            }
            catch (Exception ex)
            {
                return new SmiteClientListResponseDto<TResponse>(HttpStatusCode.InternalServerError, ex.Message, default);
            }
        }

        #region Private functionality

        private string ConstructUrl(SmiteClientRequest smiteRequest)
        {
            var smiteUrl = _smiteClientSettings.Url;
            if (smiteUrl == null)
            {
                throw new NullReferenceException("Smite URL is not defined in the settings");
            }

            var baseUrlPath = ConstructBaseUrlPath(smiteRequest);
            return $"{smiteUrl}{baseUrlPath}{smiteRequest.GetUrlPath()}";
        }

        /// <summary>
        /// Constructs the base of the url path string needed for each request
        /// </summary>
        /// <returns></returns>
        private string ConstructBaseUrlPath(SmiteClientRequest smiteRequest)
        {
            var utcDateString = GetCurrentUtcDate();
            var baseUrlPath = new StringBuilder($"{smiteRequest.MethodName}Json/");
            if (_smiteClientSecrets.DeveloperId != 0)
            {
                baseUrlPath.Append($"{_smiteClientSecrets.DeveloperId}/");
            }

            if (_smiteClientSecrets.DeveloperId != 0 && !string.IsNullOrWhiteSpace(_smiteClientSecrets.AuthenticationKey))
            {
                var signature = GenerateMd5Hash(smiteRequest, utcDateString);
                baseUrlPath.Append($"{signature}/");
            }

            if (!string.IsNullOrWhiteSpace(smiteRequest.SessionId))
            {
                baseUrlPath.Append($"{smiteRequest.SessionId}/");
            }

            if (!string.IsNullOrWhiteSpace(utcDateString))
            {
                baseUrlPath.Append($"{utcDateString}/");
            }

            // Remove the last slash
            baseUrlPath.Length--;
            return baseUrlPath.ToString();
        }

        /// <summary>
        /// Creates a MD5 hash from the method we are calling and our credentials
        /// This is needed for each request to Smite (except Ping)
        /// </summary>
        /// <returns></returns>
        private string GenerateMd5Hash(SmiteClientRequest smiteRequest, string utcDateString)
        {
            var credentials = $"{_smiteClientSecrets.DeveloperId}{smiteRequest.MethodName}{_smiteClientSecrets.AuthenticationKey}{utcDateString}";

            using var md5 = MD5.Create();
            var bytes = md5.ComputeHash(Encoding.ASCII.GetBytes(credentials));
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b.ToString("x2").ToLower());
            }

            return sb.ToString();
        }

        /// <summary>
        /// Converts the current UTC date to a string in the <see cref="DateTimeFormats.SessionIdFormat"/> format
        /// </summary>
        /// <returns></returns>
        private static string GetCurrentUtcDate() =>
            DateTime.UtcNow.ToString(DateTimeFormats.SessionIdFormat);

        #endregion
    }
}
