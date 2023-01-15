using IBHome.API.Data;
using IBHome.API.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IBHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllUserTypes()
        {
            return Ok(_context.UserTypes.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserTypeById(Guid id)
        {
            return Ok(_context.UserTypes.Where(x => x.Id == id).FirstOrDefault());
        }

        [HttpPost()]
        public IActionResult CreateUserType([FromBody] UserType usertype)
        {
            _context.UserTypes.Add(usertype);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut()]
        public IActionResult UpdateUserType([FromBody] UserType usertype, Guid id)
        {
            var userfromDb = _context.UserTypes.Find(id);
            if (userfromDb != null)
            {
                _context.UserTypes.Update(usertype);
                _context.SaveChanges();
                return Ok("UserType Updated");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserById(Guid id)
        {
            var usertypefromDb = _context.UserTypes.Find(id);
            if (usertypefromDb != null)
            {
                _context.Remove(id);
                _context.SaveChanges();

                return Ok("Usertype deleted");

            }
            else
            {
                return NotFound();
            }


        }



    }
}
