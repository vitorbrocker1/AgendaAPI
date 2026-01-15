using AgendaAPI.Dto.User;
using AgendaAPI.Models;

namespace AgendaAPI.Service.User
{
    public interface IUserServices
    {
        public Task<ResponseModel<List<UserModel>>> CreateUser(UserCreationDto userCreationDto);

        public Task<ResponseModel<List<UserModel>>> ListAllUser();

        public Task<ResponseModel<UserModel>> ListUserById(int UserId);

        public Task<ResponseModel<List<UserModel>>> UpdateUser(UserUpdateDto userUpdateDto);

        public Task<ResponseModel<List<UserModel>>> DeleteUser(int UserId);
    }
}
