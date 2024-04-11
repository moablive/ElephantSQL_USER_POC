//Microsoft
using Microsoft.AspNetCore.Mvc;

//Project
using ElephantSQL.db;
using ElephantSQL.Models;
using Microsoft.EntityFrameworkCore;

namespace ElephantSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<userMODEL>>> GetUsers()
        {
            // Retrieve all users from the database
            return await _context.Users.ToListAsync();
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<userMODEL>> PostUser(userMODEL user)
        {
            // Add a new user to the database
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            // Return the newly created user
            return CreatedAtAction(nameof(GetUser), new { id = user.id }, user);
        }


        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<userMODEL>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }
    }
}