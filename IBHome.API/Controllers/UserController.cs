using IBHome.API.Data;
using IBHome.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IBHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok( await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async  Task<IActionResult> GetUserById(Guid id)
        {
            return Ok(await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        [HttpPost()]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
              await  _context.Users.AddAsync(user);
              await  _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateUser([FromBody] User user,Guid id)
        {
            var userfromDb =await _context.Users.FindAsync(id);
            if (userfromDb != null)
            {
                _context.Users.Update(user);
               await _context.SaveChangesAsync();
                return Ok("User Updated");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> DeleteUserById(Guid id)
        {
            var userfromDb=await _context.Users.FindAsync(id);   
            if (userfromDb != null)
            {
                _context.Remove(id);
              await  _context.SaveChangesAsync();

                return Ok("User deleted");

            }
            else
            {
                return NotFound();
            }
            
          
        }



    }
}
