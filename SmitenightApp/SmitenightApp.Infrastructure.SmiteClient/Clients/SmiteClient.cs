using System.Net;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using SmitenightApp.Abstractions.Infrastructure.System;
using SmitenightApp.Domain.Constants.Common;
using SmitenightApp.Infrastructure.SmiteClient.Contracts;
using SmitenightApp.Infrastructure.SmiteClient.Models;
using SmitenightApp.Infrastructure.SmiteClient.Secrets;
using SmitenightApp.Infrastructure.SmiteClient.Settings;

namespace SmitenightApp.Infrastructure.SmiteClient.Clients
{
    public abstract class SmiteClient
    {
        private readonly HttpClient _httpClient;
        private readonly ISmiteSessionService? _smiteSessionService;
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

        protected SmiteClient(HttpClient httpClient,
            ISmiteSessionService smiteSessionService,
            IOptions<SmiteClientSettings> smiteClientSettings,
            IOptions<SmiteClientSecrets> smiteClientSecrets,
            IMapper mapper)
        {
            _httpClient = httpClient;
            _smiteSessionService = smiteSessionService;
            _smiteClientSettings = smiteClientSettings.Value;
            _smiteClientSecrets = smiteClientSecrets.Value;
            Mapper = mapper;
        }

        protected async Task<SmiteClientResponseDto> GetAsync(SmiteClientRequest smiteClientRequest, CancellationToken cancellationToken)
        {
            try
            {
                var url = ConstructUrl(smiteClientRequest);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await _httpClient.SendAsync(request, cancellationToken);
                return new SmiteClientResponseDto(response.StatusCode, response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                return new SmiteClientResponseDto(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        protected async Task<SmiteClientResponseDto<TResponse>> GetAsync<TResponse>(SmiteClientRequest smiteClientRequest, CancellationToken cancellationToken)
            where TResponse : class
        {
            try
            {
                var url = ConstructUrl(smiteClientRequest);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await _httpClient.SendAsync(request, cancellationToken);

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

        protected async Task<SmiteClientListResponseDto<TResponse>> GetListAsync<TResponse>(SmiteClientRequest smiteClientRequest, CancellationToken cancellationToken)
            where TResponse : class
        {
            try
            {
                var url = ConstructUrl(smiteClientRequest);
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var response = await _httpClient.SendAsync(request, cancellationToken);

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

        protected string ConstructUrlPath(params object[] urlPaths)
        {
            if (!urlPaths.Any())
            {
                return string.Empty;
            }

            var sb = new StringBuilder("/");
            foreach (var urlPath in urlPaths)
            {
                sb.Append($"{urlPath.ToString()}/");
            }

            // Remove last slash
            sb.Length--;
            return sb.ToString();
        }

        #region Private functionality

        private string ConstructUrl(SmiteClientRequest smiteClientRequest)
        {
            var smiteUrl = _smiteClientSettings.Url;
            if (smiteUrl == null)
            {
                throw new NullReferenceException("Smite URL is not defined in the settings");
            }

            var baseUrlPath = ConstructBaseUrlPath(smiteClientRequest);
            return $"{smiteUrl}{baseUrlPath}{smiteClientRequest.UrlPath}";
        }

        /// <summary>
        /// Constructs the base of the url path string needed for each request
        /// </summary>
        /// <returns></returns>
        private string ConstructBaseUrlPath(SmiteClientRequest smiteClientRequest)
        {
            var utcDateString = GetCurrentUtcDate();
            var baseUrlPath = new StringBuilder($"{smiteClientRequest.MethodName}Json/");
            if (_smiteClientSecrets.DeveloperId != 0)
            {
                baseUrlPath.Append($"{_smiteClientSecrets.DeveloperId}/");
            }

            if (_smiteClientSecrets.DeveloperId != 0 && !string.IsNullOrWhiteSpace(_smiteClientSecrets.AuthenticationKey))
            {
                var signature = GenerateMd5Hash(smiteClientRequest, utcDateString);
                baseUrlPath.Append($"{signature}/");
            }

            if (!string.IsNullOrWhiteSpace(smiteClientRequest.SessionId))
            {
                baseUrlPath.Append($"{smiteClientRequest.SessionId}/");
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
