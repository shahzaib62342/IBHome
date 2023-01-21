
using IBHome.DataAccess.Data;
using IBHome.DataAccess.Infrastructure.IRepository;
using IBHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IBHome.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;
        public UserTypeController(IUnitOfWork unitofwork)
        {
           _unitofwork= unitofwork;
        }

        [HttpGet]
        public  IActionResult GetAllUserTypes()
        {
            return Ok( _unitofwork.UserType.GetAll());
        }

        [HttpGet("{id}")]
        public  IActionResult GetUserTypeById(Guid id)
        {
            return Ok(_unitofwork.UserType.GetById(x=>x.Id==id));
        }

        [HttpPost()]
        public IActionResult CreateUserType([FromBody] UserType usertype)
        {
            _unitofwork.UserType.Add(usertype);
            _unitofwork.Save();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut()]
        public IActionResult UpdateUserType([FromBody] UserType usertype, Guid id)
        {
            var userfromDb = _unitofwork.UserType.GetById(x=>x.Id==id);
            if (userfromDb != null)
            {
                _unitofwork.UserType.Update(usertype);
              _unitofwork.Save();
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
            var usertypefromDb = _unitofwork.UserType.GetById(x => x.Id == id);
            if (usertypefromDb != null)
            {
                _unitofwork.UserType.Delete(usertypefromDb);
                _unitofwork.Save();
                return Ok("Usertype deleted");

            }
            else
            {
                return NotFound();
            }


        }



    }
}
