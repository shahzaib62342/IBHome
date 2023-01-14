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
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}")]
        public User GetUserById(Guid id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        [HttpPost()]
        public void CreateUser([FromBody] User user)
        {
                _context.Users.Add(user);
                _context.SaveChanges();
        }

        [HttpPut()]
        public void CreateUser([FromBody] User user,Guid id)
        {
            var userfromDb = _context.Users.Find(id);
            if (userfromDb != null)
            {
                _context.Users.Update(user);
                _context.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void DeleteUserById(Guid id)
        {
            var userfromDb= _context.Users.Find(id);   
            if (userfromDb != null)
            {
                _context.Remove(id);
            }
            _context.SaveChanges();
          
        }



    }
}
