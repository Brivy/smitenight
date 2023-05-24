//using Microsoft.EntityFrameworkCore;
//using Smitenight.Application.Blazor.Business.Contracts.Services.Common;
//using Smitenight.Application.Blazor.Business.Contracts.Services.Players;
//using Smitenight.Domain.Models.Models.Players;
//using Smitenight.Persistence.Data.EntityFramework;

//namespace Smitenight.Application.Blazor.Business.Services.Players
//{
//    public class PlayerNameAttemptService : IPlayerNameAttemptService
//    {
//        private readonly SmitenightDbContext _dbContext;
//        private readonly IClock _clock;

//        public PlayerNameAttemptService(SmitenightDbContext dbContext,
//            IClock clock)
//        {
//            _dbContext = dbContext;
//            _clock = clock;
//        }

//        public async Task RegisterNotFoundPlayerNameAsync(string playerName, CancellationToken cancellationToken = default)
//        {
//            var alreadyUsedPlayerName = await _dbContext.PlayerNameAttempts.SingleOrDefaultAsync(x => x.PlayerName == playerName, cancellationToken);
//            if (alreadyUsedPlayerName != null)
//            {
//                alreadyUsedPlayerName.Attempts += 1;
//                alreadyUsedPlayerName.LastTimeUsed = _clock.Now();
//                alreadyUsedPlayerName.NextAttemptPossibleAt = _clock.Now().AddHours(1);
//                _dbContext.PlayerNameAttempts.Update(alreadyUsedPlayerName);
//            }
//            else
//            {
//                alreadyUsedPlayerName = new PlayerNameAttempt
//                {
//                    Attempts = 1,
//                    PlayerName = playerName,
//                    NextAttemptPossibleAt = _clock.Now().AddHours(1),
//                    FirstTimeUsed = _clock.Now(),
//                    LastTimeUsed = _clock.Now()
//                };
//                _dbContext.PlayerNameAttempts.Add(alreadyUsedPlayerName);
//            }

//            await _dbContext.SaveChangesAsync(cancellationToken);
//        }

//        public async Task<bool> PlayerNameAlreadyTriedAsync(string playerName, CancellationToken cancellationToken = default)
//        {
//            var alreadyUsedPlayerName = await _dbContext.PlayerNameAttempts.SingleOrDefaultAsync(x => x.PlayerName == playerName, cancellationToken);
//            if (alreadyUsedPlayerName == null || alreadyUsedPlayerName.NextAttemptPossibleAt <= _clock.Now())
//            {
//                return false;
//            }

//            alreadyUsedPlayerName.LastTimeUsed = _clock.Now();
//            alreadyUsedPlayerName.Attempts += 1;
//            _dbContext.PlayerNameAttempts.Update(alreadyUsedPlayerName);
//            await _dbContext.SaveChangesAsync(cancellationToken);

//            return true;
//        }
//    }
//}
