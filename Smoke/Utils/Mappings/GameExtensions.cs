using Smoke.DTO.Games;
using Smoke.Models;
using System.Runtime.CompilerServices;

namespace Smoke.Utils.Mappings;

public static class GameExtensions
{
    public static Game ToGame(this AddGameRequest request)
    {
        return new Game
        {
            Title = request.Title,
            Description = request.Description,
            ImageUrl = request.ImageUrl,
            Publisher = request.Publisher,
            Genre = request.Genre,
            Price = request.Price,
            Rating = 0
        };
    }
}
