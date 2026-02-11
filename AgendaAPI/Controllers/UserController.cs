using AgendaAPI.Dto.User;
using AgendaAPI.Models;
using AgendaAPI.Service.User;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> CreateUser(UserCreationDto userCreationDto)
        {
            var users = await _userServices.CreateUser(userCreationDto);
            return Ok(users);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> ListAllUser()
        {
            var user = await _userServices.ListAllUser();
            return Ok(user);
        }

        [HttpGet("{UserId}")]
        public async Task<ActionResult<ResponseModel<UserModel>>> ListUserById(int UserId)
        {
            var user = await _userServices.ListUserById(UserId);
            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var user = await _userServices.UpdateUser(userUpdateDto);
            return Ok(user);
        }

        [HttpDelete("{UserId}")]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> DeleteUser(int UserId)
        {
            var user = await _userServices.DeleteUser(UserId);
            return Ok(user);
        }
    }
}
