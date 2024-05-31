using AutoMapper;
using Smoke.Data;
using Smoke.DTO.Games;
using Smoke.Models;

namespace Smoke.Utils.Helpers
{
    public class GenreDataTypeResolver : IValueResolver<GameToCreateDto, Game, Genre>, IValueResolver<GameToUpdateDto, Game, Genre>
    {
        private readonly DataContext _context;

        public GenreDataTypeResolver(DataContext context)
        {
            _context = context;
        }

        public Genre Resolve(GameToCreateDto source, Game destination, Genre destMember, ResolutionContext context)
        {
            return _context.Genres.FirstOrDefault(g => g.Name == source.Genre);
        }
        
        public Genre Resolve(GameToUpdateDto source, Game destination, Genre destMember, ResolutionContext context)
        {
            return _context.Genres.FirstOrDefault(g => g.Name == source.Genre);
        }
    }
}
