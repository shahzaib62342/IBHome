using IBHome.API.Data;
using IBHome.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

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
        public async Task<IActionResult> GetAllUserTypes()
        {
            return Ok(await _context.UserTypes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task< IActionResult>GetUserTypeById(Guid id)
        {
            return Ok(await _context.UserTypes.Where(x => x.Id == id).FirstOrDefaultAsync());
        }

        [HttpPost()]
        public async Task<IActionResult> CreateUserType([FromBody] UserType usertype)
        {
           await _context.UserTypes.AddAsync(usertype);
          await  _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateUserType([FromBody] UserType usertype, Guid id)
        {
            var userfromDb =await _context.UserTypes.FindAsync(id);
            if (userfromDb != null)
            {
                _context.UserTypes.Update(usertype);
              await  _context.SaveChangesAsync();
                return Ok("UserType Updated");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async  Task<IActionResult> DeleteUserById(Guid id)
        {
            var usertypefromDb =await _context.UserTypes.FindAsync(id);
            if (usertypefromDb != null)
            {
                _context.Remove(id);
              await  _context.SaveChangesAsync();

                return Ok("Usertype deleted");

            }
            else
            {
                return NotFound();
            }


        }



    }
}
