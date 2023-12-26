using Microsoft.Extensions.Options;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Exceptions;
using Smitenight.Providers.SmiteProvider.Contracts.Models.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Constants;
using Smitenight.Providers.SmiteProvider.HiRez.Exceptions;
using Smitenight.Providers.SmiteProvider.HiRez.Models.SystemClient;
using Smitenight.Providers.SmiteProvider.HiRez.Secrets;
using Smitenight.Providers.SmiteProvider.HiRez.Services;
using Smitenight.Utilities.Time.Common.Constants;
using Smitenight.Utilities.Mapper.Services;
using System.Net.Http.Json;
using System.Text.Json;

namespace Smitenight.Providers.SmiteProvider.HiRez.Clients;

internal class SmiteSessionClient(
    HttpClient httpClient,
    ISmiteHashService smiteHashService,
    IMapperService mapperService,
    IOptions<SmiteClientSecrets> smiteClientSecrets,
    TimeProvider timeProvider) : ISmiteSessionClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ISmiteHashService _smiteHashService = smiteHashService;
    private readonly IMapperService _mapperService = mapperService;
    private readonly TimeProvider _timeProvider = timeProvider;
    private readonly SmiteClientSecrets _smiteClientSecrets = smiteClientSecrets.Value;

    public async Task<CreateSmiteSessionDto> CreateSmiteSessionAsync(CancellationToken cancellationToken = default)
    {
        string utcDateString = _timeProvider.GetUtcNow().ToString(DateTimeFormat.SessionIdFormat);
        string signature = _smiteHashService.GenerateSmiteHash(MethodNameConstants.CreateSessionMethod, utcDateString);
        string url = $"{MethodNameConstants.CreateSessionMethod}Json/{_smiteClientSecrets.DeveloperId}/{signature}/{utcDateString}";

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = await _httpClient.SendAsync(request, cancellationToken);
            CreateSmiteSession result = await response.Content.ReadFromJsonAsync<CreateSmiteSession>(cancellationToken: cancellationToken) ?? throw new SmiteClientInvalidResponseException("The HTTP content is empty or empty");
            return _mapperService.Map<CreateSmiteSession, CreateSmiteSessionDto>(result);
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
