using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smoke.Data;
using Smoke.DTO.Games;
using Smoke.Models;
using Smoke.Utils.Mappings;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smoke.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly DataContext _context;

        public GameController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> AddGame(AddGameRequest newGame)
        {
            var existingGame = await _context.Games.FirstOrDefaultAsync(g => g.Title.ToLower() == newGame.Title.ToLower());
            if (existingGame != null)
            {
                return BadRequest("Game title already exists.");
            }

            var game = newGame.ToGame();
            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return Ok();
        }



        [HttpGet("{title}")]
        public async Task<ActionResult<Game>> GetGame(string title)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Title == title);
            if (game == null)
            {
                return NotFound("Game not found.");
            }
            return Ok(game);
        }


        [HttpPut("{title}")]
        public async Task<IActionResult> UpdateGame(string title, Game updatedGame)
        {
            var existingGame = await _context.Games.FirstOrDefaultAsync(g => g.Title == title);
            if (existingGame == null)
            {
                return NotFound("Game not found.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingGame.Description = updatedGame.Description;
            existingGame.ImageUrl = updatedGame.ImageUrl;
            existingGame.Publisher = updatedGame.Publisher;
            existingGame.Genre = updatedGame.Genre;
            existingGame.Rating = updatedGame.Rating;
            existingGame.Price = updatedGame.Price;

            _context.Entry(existingGame).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{title}")]
        public async Task<IActionResult> DeleteGame(string title)
        {
            var game = await _context.Games.FirstOrDefaultAsync(g => g.Title == title);
            if (game == null)
            {
                return NotFound("Game not found.");
            }

            _context.Games.Remove(game);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
