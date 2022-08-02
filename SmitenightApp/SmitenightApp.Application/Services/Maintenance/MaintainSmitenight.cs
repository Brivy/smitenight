using SmitenightApp.Abstractions.Application.Services.Maintenance;

namespace SmitenightApp.Application.Services.Maintenance
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
