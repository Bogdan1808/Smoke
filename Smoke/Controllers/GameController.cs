using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Smoke.DTO.Games;
using Smoke.Models;
using Smoke.Utils.Mappings;
using Smoke.DTO;
using Smoke.Interfaces;
using Smoke.Utils.Helpers;
using Smoke.Utils.Specifications;

namespace Smoke.Controllers
{
    public class GameController : BaseApiController
    {
        private readonly IGenericRepository<Game> _gamesRepo;
        private readonly IGenericRepository<Genre> _genresRepo;
        private readonly IMapper _mapper;

        public GameController(IGenericRepository<Game> gamesRepo, IGenericRepository<Genre> genresRepo, IMapper mapper)
        {
            _gamesRepo = gamesRepo;
            _genresRepo = genresRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<GameToReturnDto>>> GetAllGames([FromQuery]GameSpecParams gameParams)
        {
            var spec = new GamesWithGenresSpecification(gameParams);
            var countSpec = new GameWithFiltersForCountSpecification(gameParams);
            var totalItems = await _gamesRepo.CountAsync(countSpec);
            var games = await _gamesRepo.ListAsync(spec);
            var data = _mapper
                .Map<IReadOnlyList<Game>, IReadOnlyList<GameToReturnDto>>(games);
            
            return Ok(new Pagination<GameToReturnDto>(gameParams.PageIndex, gameParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GameToReturnDto>> GetGame(int id)
        {
            var spec = new GamesWithGenresSpecification(id);
            
            var game = await _gamesRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Game, GameToReturnDto>(game);
        }

        [HttpGet("genres")]
        public async Task<IReadOnlyList<Genre>> GetGenres()
        {
            return await _genresRepo.ListAllAsync();
        }
        
        [HttpPost]
        public async Task<ActionResult<GameToReturnDto>> AddGame(GameToCreateDto gameToCreateDto)
        {
            var game = _mapper.Map<GameToCreateDto, Game>(gameToCreateDto);
            
            _gamesRepo.Add(game);
            await _gamesRepo.SaveChangesAsync();

            var gameToReturn = _mapper.Map<Game, GameToReturnDto>(game);

            return CreatedAtAction(nameof(GetGame), new { id = gameToReturn.Id }, gameToReturn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGame(int id, GameToUpdateDto gameToUpdateDto)
        {
            var game = await _gamesRepo.GetByIdAsync(id);
            if (game == null) return NotFound();

            _mapper.Map(gameToUpdateDto, game);

            _gamesRepo.Update(game);
            await _gamesRepo.SaveChangesAsync();

            return Ok("Game updated successfully!");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGame(int id)
        {
            var game = await _gamesRepo.GetByIdAsync(id);
            if (game == null) return NotFound();

            _gamesRepo.Delete(game);
            await _gamesRepo.SaveChangesAsync();

            return Ok("Game deleted successfully!");
        }
    }
}
