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
            Console.WriteLine("test");
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            { 
                Console.WriteLine(user);
                return Ok(ex.Message);
            }
        }

    }


}
