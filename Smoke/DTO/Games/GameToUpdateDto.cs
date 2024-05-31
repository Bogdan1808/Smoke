namespace Smoke.DTO.Games;

public class GameToUpdateDto
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
    public string Genre { get; set; }
    public double Price { get; set; }
    public double Rating { get; set; }
}