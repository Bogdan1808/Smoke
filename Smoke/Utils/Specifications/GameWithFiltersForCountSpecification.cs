using Smoke.Controllers;
using Smoke.Models;

namespace Smoke.Utils.Specifications;

public class GameWithFiltersForCountSpecification : BaseSpecification<Game>
{
    public GameWithFiltersForCountSpecification(GameSpecParams gameParams)
        : base(x => 
            (string.IsNullOrEmpty(gameParams.Search) || x.Title.ToLower().Contains(gameParams.Search)) && 
            (!gameParams.GenreId.HasValue || x.GenreId == gameParams.GenreId)
        )
    {
        
    }
}