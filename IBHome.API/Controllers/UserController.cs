using IBHome.API.Data;
using IBHome.API.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllUsers()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            return Ok(_context.Users.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost()]
        public IActionResult CreateUser([FromBody] User user)
        {
                _context.Users.Add(user);
                _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut()]
        public IActionResult CreateUser([FromBody] User user,Guid id)
        {
            var userfromDb = _context.Users.Find(id);
            if (userfromDb != null)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return Ok("User Updated");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(Guid id)
        {
            var userfromDb= _context.Users.Find(id);   
            if (userfromDb != null)
            {
                _context.Remove(id);
                _context.SaveChanges();

                return Ok("User deleted");

            }
            else
            {
                return NotFound();
            }
            
          
        }



    }
}
