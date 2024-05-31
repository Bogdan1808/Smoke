using AutoMapper;
using Smoke.DTO.Games;
using Smoke.Models;

namespace Smoke.Utils.Helpers;

public class GameUrlResolver : IValueResolver<Game, GameToReturnDto, string>
{
    private readonly IConfiguration _config;

    public GameUrlResolver(IConfiguration config)
    {
        _config = config;
    }
    public string Resolve(Game source, GameToReturnDto destination, string destMember, ResolutionContext context)
    {
        if (!string.IsNullOrEmpty(source.ImageUrl))
        {
            return _config["ApiUrl"] + source.ImageUrl;
        }

        return null;
    }
}