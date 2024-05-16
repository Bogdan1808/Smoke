namespace Smoke.Models.OrderAggregates;

public class OrderItem
{
    public int Id { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public GameItemOrder ItemOrder { get; set; }
}
