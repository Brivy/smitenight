using Smitenight.Abstractions.Application.Services.Maintenance;
using Smitenight.Abstractions.Application.Services.System;

namespace Smitenight.Application.Services.Maintenance
{
    public class MaintainSmitenight : IMaintainSmitenight
    {
        private readonly ISmiteSessionService _smiteSessionService;
        private readonly IMaintainItemsService _maintainItemsService;
        private readonly IMaintainGodsService _godsService;

        public MaintainSmitenight(ISmiteSessionService smiteSessionService,
            IMaintainItemsService maintainItemsService,
            IMaintainGodsService godsService)
        {
            _smiteSessionService = smiteSessionService;
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
            var sessionId = await _smiteSessionService.GetSessionIdAsync(cancellationToken);
            if (sessionId == null)
            {
                return;
            }

            await _godsService.MaintainAsync(sessionId, cancellationToken);
            await _maintainItemsService.MaintainAsync(sessionId, cancellationToken);
        }
    }
}
