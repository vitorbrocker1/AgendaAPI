// AppointmentService.cs
using AgendaAPI.Data;
using AgendaAPI.Dto.Appointment;
using AgendaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Service.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<AppointmentModel>>> ListAllAppointment()
        {
            ResponseModel<List<AppointmentModel>> response = new ResponseModel<List<AppointmentModel>>();

            try
            {
                var appointments = await _context.Appointments.ToListAsync();
                response.Data = appointments;
                response.Message = "Appointments retrieved successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }

        public async Task<ResponseModel<AppointmentModel>> ListAppointmentById(int appointmentId)
        {
            ResponseModel<AppointmentModel> response = new ResponseModel<AppointmentModel>();

            try
            {
                var appointment = await _context.Appointments
                    .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);

                if (appointment == null)
                {
                    response.Message = "Appointment not found.";
                    response.Success = false;
                    return response;
                }

                response.Data = appointment;
                response.Message = "Appointment retrieved successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }

        public async Task<ResponseModel<UserModel>> ListAppointmentByIdUser(int appointmentId)
        {
            ResponseModel<UserModel> response = new ResponseModel<UserModel>();

            try
            {
                var appointment = await _context.Appointments
                    .Include(a => a.User)
                    .FirstOrDefaultAsync(a => a.AppointmentId == appointmentId);

                if (appointment == null)
                {
                    response.Message = "Nenhum registro localizado!";
                    response.Success = false;
                    return response;
                }

                response.Data = appointment.User;
                response.Message = "Usuário localizado!";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AppointmentModel>>> CreateAppointment(AppointmentCreationDto appointmentCreationDto)
        {
            ResponseModel<List<AppointmentModel>> response = new ResponseModel<List<AppointmentModel>>();

            try
            {
               var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserId == appointmentCreationDto.User.UserId);
                if (user == null)
                {
                    response.Message = "User not found.";
                    return response;
                }

                var appointment = new AppointmentModel
                {
                    Title = appointmentCreationDto.Title,
                    Description = appointmentCreationDto.Description,
                    Date = appointmentCreationDto.Date,
                    User = user
                }; 
                
                _context.Appointments.Add(appointment);
                await _context.SaveChangesAsync();

                response.Data = await _context.Appointments.Include(a => a.User).ToListAsync();
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AppointmentModel>>> UpdateAppointment(AppointmentUpdateDto appointmentUpdateDto)
        {
            ResponseModel<List<AppointmentModel>> response = new ResponseModel<List<AppointmentModel>>();

            try
            {
                var appointment = await _context.Appointments
                    .Include(u => u.User)
                    .FirstOrDefaultAsync(a => a.AppointmentId == appointmentUpdateDto.AppointmentId);

                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserId == appointmentUpdateDto.User.UserId);

                if (appointment == null)
                {
                    response.Message = "Appointment not found.";
                    return response;
                }
                if (user == null)
                {
                    response.Message = "User not found.";
                    return response;
                }

                appointment.Title = appointmentUpdateDto.Title;
                appointment.Description = appointmentUpdateDto.Description;
                appointment.Date = appointmentUpdateDto.Date;
                appointment.User = user;

                _context.Update(appointment);
                await _context.SaveChangesAsync();

                response.Data = await _context.Appointments.ToListAsync();
                return response;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AppointmentModel>>> DeleteAppointment()
        {
            ResponseModel<List<AppointmentModel>> response = new ResponseModel<List<AppointmentModel>>();

            try
            {
                var appointments = await _context.Appointments.ToListAsync();

                if (appointments == null)
                {
                    response.Message = "No appointments found.";
                    return response;
                }

                _context.Remove(appointments);
                await _context.SaveChangesAsync();

                response.Data = await _context.Appointments.ToListAsync();
                response.Message = "Appointments deleted successfully.";
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
