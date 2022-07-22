using Smitenight.Abstractions.Application.Services.Maintenance;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests;

namespace Smitenight.Application.Services.Maintenance
{
    public class MaintainSmitenight : IMaintainSmitenight
    {
        private readonly ISystemSmiteClient _systemSmiteClient;
        private readonly IMaintainItemsService _maintainItemsService;

        public MaintainSmitenight(ISystemSmiteClient systemSmiteClient,
            IMaintainItemsService maintainItemsService)
        {
            _systemSmiteClient = systemSmiteClient;
            _maintainItemsService = maintainItemsService;
        }

        /// <summary>
        /// Maintain the static data from the SMITE API
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task MaintainAsync(CancellationToken cancellationToken = default)
        {
            var sessionRequest = new CreateSmiteSessionRequest();
            var sessionResponse = await _systemSmiteClient.CreateSmiteSessionAsync(sessionRequest, cancellationToken);
            if (sessionResponse?.Response == null)
            {
                return;
            }

            await _maintainItemsService.MaintainAsync(sessionResponse.Response.SessionId, cancellationToken);
        }
    }
}
