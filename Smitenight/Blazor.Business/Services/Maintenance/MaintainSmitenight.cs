using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;

namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public class MaintainSmitenight : IMaintainSmitenight
    {
        private readonly IMaintainItemsService _maintainItemsService;
        private readonly IMaintainGodsService _godsService;

        public MaintainSmitenight(IMaintainItemsService maintainItemsService,
            IMaintainGodsService godsService)
        {
            _maintainItemsService = maintainItemsService;
            _godsService = godsService;
        }

        public async Task MaintainAsync(CancellationToken cancellationToken = default)
        {
            await _godsService.MaintainAsync(cancellationToken);
            await _maintainItemsService.MaintainAsync(cancellationToken);
        }
    }
}
