using AutoMapper;
using Smoke.DTO.Games;
using Smoke.Models;
using Smoke.Utils.Helpers;

namespace Smoke.Utils.Mappings
{
    public class GameExtensions : Profile
    {
        public GameExtensions()
        {
            CreateMap<Game, GameToReturnDto>()
                .ForMember(d => d.Genre, o => o.MapFrom(s => s.Genre.Name))
                .ForMember(d => d.ImageUrl, o => o.MapFrom<GameUrlResolver>());

            CreateMap<GameToCreateDto, Game>()
                .ForMember(d => d.Genre, o => o.MapFrom<GenreDataTypeResolver>());

            CreateMap<GameToUpdateDto, Game>()
                .ForMember(d => d.Genre, o => o.MapFrom<GenreDataTypeResolver>());
        }
    }
}