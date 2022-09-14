using Microsoft.EntityFrameworkCore;
using SmitenightApp.Abstractions.Application.Services.Builders;
using SmitenightApp.Abstractions.Application.Services.Maintenance;
using SmitenightApp.Abstractions.Infrastructure.SmiteClient;
using SmitenightApp.Domain.Clients.SmiteClient.Requests.GodRequests;
using SmitenightApp.Domain.Clients.SmiteClient.Responses.GodResponses;
using SmitenightApp.Domain.Enums.SmiteClient;
using SmitenightApp.Persistence;

namespace SmitenightApp.Application.Services.Maintenance
{
    public class MaintainGodsService : IMaintainGodsService
    {
        private readonly IGodBuilderService _godBuilderService;
        private readonly IGodSmiteClient _godSmiteClient;
        private readonly SmitenightDbContext _dbContext;

        public MaintainGodsService(
            IGodBuilderService godBuilderService,
            IGodSmiteClient godSmiteClient,
            SmitenightDbContext dbContext)
        {
            _godBuilderService = godBuilderService;
            _godSmiteClient = godSmiteClient;
            _dbContext = dbContext;
        }

        public async Task MaintainAsync(CancellationToken cancellationToken = default)
        {
            var godsResponse = await _godSmiteClient.GetGodsAsync(LanguageCodeEnum.English, cancellationToken);
            if (godsResponse?.Response == null)
            {
                return;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                foreach (var god in godsResponse.Response)
                {
                    var godSkinsResponse = await _godSmiteClient.GetGodSkinsAsync(god.Id, LanguageCodeEnum.English, cancellationToken);
                    var godSkins = godSkinsResponse?.Response ?? new List<GodSkinsResponse>();

                    await ProcessGodAsync(god, godSkins, cancellationToken);
                }

                await _dbContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #region Processing

        private async Task ProcessGodAsync(GodsResponse god, List<GodSkinsResponse> godSkins, CancellationToken cancellationToken = default)
        {
            var godEntity = _godBuilderService.Build(god, godSkins);
            var existingGodEntity = await _dbContext.Gods.AsNoTracking()
                .Include(x => x.Abilities)
                .Include(x => x.GodSkins)
                .SingleOrDefaultAsync(x => x.SmiteId == god.Id, cancellationToken);

            if (existingGodEntity == null)
            {
                _dbContext.Gods.Add(godEntity);
            }
            else
            {
                var abilityIds = existingGodEntity.Abilities.Select(x => x.Id).ToList();
                _dbContext.BasicAttackDescriptions.RemoveRange(await _dbContext.BasicAttackDescriptions.Where(x => x.GodId == existingGodEntity.Id).ToListAsync(cancellationToken));
                _dbContext.AbilityRanks.RemoveRange(await _dbContext.AbilityRanks.Where(x => abilityIds.Contains(x.AbilityId)).ToListAsync(cancellationToken));
                _dbContext.AbilityTags.RemoveRange(await _dbContext.AbilityTags.Where(x => abilityIds.Contains(x.AbilityId)).ToListAsync(cancellationToken));

                godEntity.Id = existingGodEntity.Id;
                godEntity.Abilities.ForEach(ability =>
                {
                    ability.Id = existingGodEntity.Abilities.Single(x => x.AbilityType == ability.AbilityType).Id;
                });

                // Possible to have a new skin that doesn't have both the Ids in the existing God entity
                godEntity.GodSkins.ForEach(godSkin =>
                {
                    godSkin.Id = existingGodEntity.GodSkins.SingleOrDefault(x => x.SmiteId == godSkin.SmiteId && x.SecondarySmiteId == godSkin.SecondarySmiteId)?.Id ?? 0;
                });

                _dbContext.Gods.Update(godEntity);
            }
        }

        #endregion
    }
}
