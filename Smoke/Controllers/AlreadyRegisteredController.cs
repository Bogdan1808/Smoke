using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smoke.Data;

namespace Smoke.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlreadyRegisteredController : ControllerBase
    {
        private readonly DataContext _context;

        public AlreadyRegisteredController(DataContext context)
        {
            _context = context;
        }


        //TODO : de schimbat CheckUserExists pt login fara register

        [HttpGet("exists")]
        public async Task<ActionResult<bool>> CheckUserExists(string UserName, string Password)
        {
            var userExists = await _context.Users.AnyAsync(u => u.UserName == UserName && u.Password == Password);

            if (userExists)
            {
                return Ok("User has been foud");
            }
            else return BadRequest("User or password may be invalid. If not registered, please register.");
        }
        
    }
}
