using Smoke.Models;
using Smoke.Utils.Specifications;

namespace Smoke.Interfaces;

public interface IGameRepository
{
        Task<Game?> GetGameByIdAsync(int id);
        Task<IReadOnlyList<Game>> GetGamesAsync();
        Task AddGameAsync(Game game);
        Task DeleteGameAsync(Game game);
        Task UpdateGameAsync(Game existingGame, Game updatedGame);
        Task<IReadOnlyList<Genre>> GetGenresAsync();
}