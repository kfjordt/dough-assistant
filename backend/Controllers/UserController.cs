using BudgetBffBackend.Contexts;
using BudgetBffBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BudgetBffBackend.Controllers
{
    [Route("api/users")]
    [ApiController]

    public class UserController : Controller
    {

        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult AddUser([FromBody] User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUserByEmail([FromQuery] string email)
        {
            try
            {
                // Use the 'email' parameter to fetch the user by email
                var user = _context.Users.FirstOrDefault(u => u.GoogleEmail == email);

                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return NotFound("User not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }


}
