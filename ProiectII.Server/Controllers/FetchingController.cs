using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;

[ApiController]
[Route("[controller]")]
public class GamesController : ControllerBase
{
    private readonly IMongoDatabase _database;

    public GamesController(IMongoDatabase database)
    {
        _database = database;
    }

    [HttpGet]
    public IActionResult GetAllGames()
    {
        var collection = _database.GetCollection<BsonDocument>("Games");

        var games = collection.Find(new BsonDocument()).ToList();

        return Ok(games);
    }
}
