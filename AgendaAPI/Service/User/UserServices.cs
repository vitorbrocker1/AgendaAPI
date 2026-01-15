using AgendaAPI.Data;
using AgendaAPI.Dto.User;
using AgendaAPI.Models;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Service.User
{
    public class UserServices : IUserServices
    {
        private readonly AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<UserModel>>> CreateUser(UserCreationDto userCreationDto)
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();
            try
            {
                var user = new UserModel()
                {
                    Name = userCreationDto.Name,
                    Email = userCreationDto.Email
                };
                
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                response.Data = await _context.Users.ToListAsync();
                response.Message = "User created successfully.";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;    
            }
        }

        public async Task<ResponseModel<List<UserModel>>> ListAllUser()

        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();
            try
            {
                var users = await _context.Users.ToListAsync();
                response.Data = users;
                response.Message = "Users retrieved successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }

        public async Task<ResponseModel<UserModel>> ListUserById(int UserId)
        {
            ResponseModel<UserModel> response = new ResponseModel<UserModel>();

            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserId == UserId);

                if (user == null)
                {
                    response.Message = "User not found.";
                    response.Success = false;
                    return response;
                }

                response.Data = user;
                response.Message = "User retrieved successfully.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> UpdateUser(UserUpdateDto userUpdateDto)
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();
            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserId == userUpdateDto.UserId);

                if (user == null)
                {
                    response.Message = "User not found.";
                    return response;
                }

                user.Name = userUpdateDto.Name;
                user.Email = userUpdateDto.Email;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                response.Data = await _context.Users.ToListAsync();
                response.Message = "User updated successfully.";
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> DeleteUser(int UserId)
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();

            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserId == UserId);

                if (user == null)
                {
                    response.Message = "User not found.";
                    return response;
                }


                _context.Remove(user);
                await _context.SaveChangesAsync();

                response.Data = await _context.Users.ToListAsync();
                response.Message = "User deleted successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }
    }
}
