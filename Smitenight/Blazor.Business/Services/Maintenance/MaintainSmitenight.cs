using Smitenight.Application.Blazor.Business.Contracts.Services.Maintenance;
using Smitenight.Providers.SmiteProvider.Contracts.Clients;
using Smitenight.Providers.SmiteProvider.Contracts.Enums;

namespace Smitenight.Application.Blazor.Business.Services.Maintenance
{
    public class MaintainSmitenight : IMaintainSmitenight
    {
        private readonly IMaintainItemsService _maintainItemsService;
        private readonly IMaintainGodsService _maintainGodsService;
        private readonly IGodSmiteClient _godSmiteClient;

        public MaintainSmitenight(
            IMaintainItemsService maintainItemsService,
            IMaintainGodsService maintainGodsService,
            IGodSmiteClient godSmiteClient)
        {
            _maintainItemsService = maintainItemsService;
            _maintainGodsService = maintainGodsService;
            _godSmiteClient = godSmiteClient;
        }

        public async Task MaintainAsync(CancellationToken cancellationToken = default)
        {
            await _godsService.MaintainAsync(cancellationToken);
            await _maintainItemsService.MaintainAsync(cancellationToken);
        }

        public async Task MaintainGodsAsync(CancellationToken cancellationToken = default)
        {
            var gods = await _godSmiteClient.GetGodsAsync(LanguageCodeEnum.English, cancellationToken);
            if (cancellationToken.IsCancellationRequested) return;

            try
            {
                foreach (var god in gods)
                {
                    var createdGodId = await _maintainGodsService.CreateGodAsync(god, cancellationToken);
                    await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails1, cancellationToken);
                    await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails2, cancellationToken);
                    await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails3, cancellationToken);
                    await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails4, cancellationToken);
                    await _maintainGodsService.CreateAbility(createdGodId, god.AbilityDetails5, cancellationToken);
                    await _maintainGodsService.CreateBasicAttackDescriptionsAsync(createdGodId, god.BasicAttack.ItemDescription.MenuItems, cancellationToken);

                    var godSkins = await _godSmiteClient.GetGodSkinsAsync(god.Id, LanguageCodeEnum.English, cancellationToken);
                    await _maintainGodsService.CreateGodSkinsAsync(createdGodId, godSkins, cancellationToken);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
