using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.AspNetCore.Server.HttpSys;

namespace Smoke.Models;

public class BasketItem
{
    public int Id { get; set; }
    public string GameName { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string ImageUrl { get; set; }
    public string Genre { get; set; }
}