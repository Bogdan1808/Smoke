using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smoke.Data;
using Smoke.DTO.Users;
using Smoke.Models;
using Smoke.Utils.Mappings;

namespace Smoke.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult> AddNewUser(UserRegisterRequest user)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
            if (existingUser != null)
            {
                return BadRequest("Email is already in use.");
            }

            var newUser = user.ToUser();
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete("{UserName}/{Password}")]
        public async Task<IActionResult> DeleteUser(string UserName, string Password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == UserName && u.Password == Password);

            if (user == null)
            {   
                return NotFound("User not found!");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
