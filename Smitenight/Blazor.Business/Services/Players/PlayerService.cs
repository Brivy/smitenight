using Microsoft.EntityFrameworkCore;
using Smitenight.Application.Blazor.Business.Contracts.Services.Players;
using Smitenight.Persistence.Data.EntityFramework;
using Smitenight.Persistence.Data.EntityFramework.Entities;

namespace Smitenight.Application.Blazor.Business.Services.Players
{
    public class PlayerService : IPlayerService
    {
        private readonly SmitenightDbContext _dbContext;

        public PlayerService(SmitenightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Player?> GetAlreadyExistingAsync(string playerName, CancellationToken cancellationToken = default)
        {
            var players = await _dbContext.Players.Where(x => x.HirezPlayerName == playerName).ToListAsync(cancellationToken);
            if (!players.Any())
            {
                return null;
            }

            // If there are more players with the same name, we don't know who this is and need to ask the SMITE API
            return players.Count == 1 ? players.Single() : null;
        }
    }
}
