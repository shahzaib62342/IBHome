

using IBHome.DataAccess.Infrastructure.IRepository;
using IBHome.DataAccess.Infrastructure.Repository;
using IBHome.Models;
using Microsoft.AspNetCore.Mvc;

namespace IBHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private  IUnitOfWork _unitofwork;
        public UserController(IUnitOfWork  unitofwork) 
        {
            _unitofwork= unitofwork;
        }

        [HttpGet]
        public  IActionResult GetAllUsers()
        {
           
            return Ok(_unitofwork.User.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var user=_unitofwork.User.GetById(x=>x.Id==id);
            return Ok(user);
        }

        [HttpPost()]
        public  IActionResult CreateUser([FromBody] User user)
        {
            _unitofwork.User.Add(user);
            _unitofwork.Save();

            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut()]
        public  IActionResult UpdateUser([FromBody] User user,Guid id)
        {
            var userfromDb = _unitofwork.User.GetById(x=>x.Id==id);
            if (userfromDb != null)
            {
                 _unitofwork.User.Update(user);
                _unitofwork.Save();
                return Ok("User Updated");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public   IActionResult DeleteUserById(Guid id)
        {
            var userfromDb= _unitofwork.User.GetById(x=>x.Id== id);
            if (userfromDb != null)
            {
                _unitofwork.User.Delete(userfromDb);
                _unitofwork.Save();

                return Ok("User deleted");

            }
            else
            {
                return NotFound();
            }
            
          
        }



    }
}
