// AppointmentService.cs
using AgendaAPI.Data;
using AgendaAPI.Dto.Appointment;
using AgendaAPI.Dto.AppointmentResponseDto;
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

        public async Task<ResponseModel<List<AppointmentResponseDto>>> ListAppointmentByIdUser(int userId)
        {
            var response = new ResponseModel<List<AppointmentResponseDto>>();

            try
            {
                var appointments = await _context.Appointments
                    .Where(a => a.User.UserId == userId)
                    .Select(a => new AppointmentResponseDto(
                        a.AppointmentId,
                        a.Title,
                        a.Description,
                        a.Date,
                        a.User.UserId
                    ))
                    .ToListAsync();

                if (!appointments.Any())
                {
                    response.Message = "Nenhum appointment encontrado para este usuário.";
                    response.Success = false;
                    return response;
                }

                response.Data = appointments;
                response.Message = "Appointments localizados com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }


        public async Task<ResponseModel<List<AppointmentResponseDto>>> CreateAppointment(AppointmentCreationDto appointmentCreationDto)
        {
            var response = new ResponseModel<List<AppointmentResponseDto>>();

            try
            {
                var user = await _context.Users
                    .FirstOrDefaultAsync(u => u.UserId == appointmentCreationDto.User.UserId);

                if (user == null)
                {
                    response.Message = "User not found.";
                    response.Success = false;
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

                response.Data = new List<AppointmentResponseDto>
        {
            new(
                appointment.AppointmentId,
                appointment.Title,
                appointment.Description,
                appointment.Date,
                user.UserId
            )
        };

                response.Message = "Appointment created successfully.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }


        public async Task<ResponseModel<AppointmentResponseDto>> UpdateAppointment(
    AppointmentUpdateDto dto)
        {
            var response = new ResponseModel<AppointmentResponseDto>();

            try
            {
                var appointment = await _context.Appointments
                    .Include(a => a.User)
                    .FirstOrDefaultAsync(a => a.AppointmentId == dto.AppointmentId);

                if (appointment == null)
                {
                    response.Message = "Agendamento não encontrado.";
                    response.Success = false;
                    return response;
                }

                // 🔒 Garante que não troca o vínculo
                if (appointment.User.UserId != dto.User.UserId)
                {
                    response.Message = "Não é permitido alterar o usuário do agendamento.";
                    response.Success = false;
                    return response;
                }

                appointment.Title = dto.Title;
                appointment.Description = dto.Description;
                appointment.Date = dto.Date;

                await _context.SaveChangesAsync();

                response.Data = new AppointmentResponseDto(
                    appointment.AppointmentId,
                    appointment.Title,
                    appointment.Description,
                    appointment.Date,
                    appointment.User.UserId
                );

                response.Message = "Agendamento atualizado com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }


        public async Task<ResponseModel<List<AppointmentModel>>> DeleteAppointment(int appointmentId)
        {
            var response = new ResponseModel<List<AppointmentModel>>();

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

                _context.Appointments.Remove(appointment);
                await _context.SaveChangesAsync();

                response.Data = await _context.Appointments.ToListAsync();
                response.Message = "Appointment deleted successfully.";
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



    