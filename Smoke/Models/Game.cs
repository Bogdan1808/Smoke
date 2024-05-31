namespace Smoke.Models
{
    public class Game : BaseEntity    
    { 
        public required string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Publisher { get; set; } = string.Empty;
        public Genre Genre { get; set; }
        public int? GenreId { get; set; }
        public double Rating { get; set; }
        public double Price { get; set; }
    }
}

