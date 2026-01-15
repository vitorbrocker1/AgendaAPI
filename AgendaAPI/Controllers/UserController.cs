using AgendaAPI.Dto.User;
using AgendaAPI.Models;
using AgendaAPI.Service.Appointment;
using AgendaAPI.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> CreateUser(UserCreationDto userCreationDto)
        {
            var Users = await _userServices.CreateUser(userCreationDto);
            return Ok(Users);
        }

        [HttpGet("ListAllUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> ListAllUser()
        {

            var user = await _userServices.ListAllUser();
            return Ok(user);
        }

        [HttpGet("ListUserById/{UserId}")]
        public async Task<ActionResult<ResponseModel<UserModel>>> ListUserById(int UserId)
        {
            
            var user = await _userServices.ListUserById(UserId);
            return Ok(user);
        }

        [HttpPut("UpdateUser")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> UpdateUser(UserUpdateDto userUpdateDto)
        {

            var user = await _userServices.UpdateUser(userUpdateDto);
            return Ok(user);
        }

        [HttpDelete("DeleteUser/{UserId}")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> DeleteUser(int UserId)
        {

            var user = await _userServices.DeleteUser(UserId);
            return Ok(user);
        }
    }
}

