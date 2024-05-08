using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    [HttpGet]
    [Route("data")]
    public IActionResult GetData()
    {
        // Implement logic to retrieve data from the backend
        return Ok(new { message = "Data from backend" });
    }

    // Add more actions for other API endpoints
}