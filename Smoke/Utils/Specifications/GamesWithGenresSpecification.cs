using Smoke.Models;

namespace Smoke.Utils.Specifications;

public class GamesWithGenresSpecification : BaseSpecification<Game>
{
    public GamesWithGenresSpecification(GameSpecParams gameParams)
        : base(x => 
                (string.IsNullOrEmpty(gameParams.Search) || x.Title.ToLower().Contains(gameParams.Search)) && 
                (!gameParams.GenreId.HasValue || x.GenreId == gameParams.GenreId)
        )
    {
        AddInclude(x => x.Genre);
        AddOrderBy(x => x.Title);
        ApplyPaging(gameParams.PageSize * (gameParams.PageIndex - 1), gameParams.PageSize);

        if (!string.IsNullOrEmpty(gameParams.Sort))
        {
            switch (gameParams.Sort)
            {
                case "priceAsc": AddOrderBy(p => p.Price);
                    break;
                case "priceDesc": AddOrderByDescending(p => p.Price);
                    break;
                default:
                    AddOrderBy(t => t.Title);
                    break;
            }
        }
    }
    
    public GamesWithGenresSpecification(int id) : base(x => x.Id == id)
    {
        AddInclude(x => x.Genre);
    }
}