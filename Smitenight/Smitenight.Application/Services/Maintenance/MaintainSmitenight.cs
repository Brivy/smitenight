using Smitenight.Abstractions.Application.Services.Maintenance;
using Smitenight.Abstractions.Infrastructure.SmiteClient;
using Smitenight.Domain.Clients.SmiteClient.Requests.SystemRequests;

namespace Smitenight.Application.Services.Maintenance
{
    public class MaintainSmitenight : IMaintainSmitenight
    {
        private readonly ISystemSmiteClient _systemSmiteClient;
        private readonly IMaintainItemsService _maintainItemsService;
        private readonly IMaintainGodsService _godsService;

        public MaintainSmitenight(ISystemSmiteClient systemSmiteClient,
            IMaintainItemsService maintainItemsService,
            IMaintainGodsService godsService)
        {
            _systemSmiteClient = systemSmiteClient;
            _maintainItemsService = maintainItemsService;
            _godsService = godsService;
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

            await _godsService.MaintainAsync(sessionResponse.Response.SessionId, cancellationToken);
            //await _maintainItemsService.MaintainAsync(sessionResponse.Response.SessionId, cancellationToken);
        }
    }
}
