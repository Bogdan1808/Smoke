using Microsoft.EntityFrameworkCore;
using Smoke.Interfaces;
using Smoke.Models;

namespace Smoke.Data.Repositories;

public class GameRepository : IGameRepository
{
    private readonly DataContext _context;

    public GameRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<Game?> GetGameByIdAsync(int id)
    {
        return await _context.Games
            .Include(g => g.Genre)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IReadOnlyList<Game>> GetGamesAsync()
    {
        return await _context.Games
            .Include(g => g.Genre)
            .ToListAsync();
    }

    public async Task AddGameAsync(Game game)
    {
        await _context.Games.AddAsync(game);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGameAsync(Game game)
    {
        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateGameAsync(Game existingGame, Game updatedGame)
    {
        existingGame.Title = updatedGame.Title;
        existingGame.Description = updatedGame.Description;
        existingGame.ImageUrl = updatedGame.ImageUrl;
        existingGame.Publisher = updatedGame.Publisher;
        existingGame.Genre = updatedGame.Genre;
        existingGame.Rating = updatedGame.Rating;
        existingGame.Price = updatedGame.Price;

        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<Genre>> GetGenresAsync()
    {
        return await _context.Genres.ToListAsync();
    }
}