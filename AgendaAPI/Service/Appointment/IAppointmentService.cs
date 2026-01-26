using AgendaAPI.Dto.Appointment;
using AgendaAPI.Dto.AppointmentResponseDto;
using AgendaAPI.Models;

namespace AgendaAPI.Service.Appointment
{
    public interface IAppointmentService
    {
        Task<ResponseModel<List<AppointmentModel>>> ListAllAppointment();

        Task<ResponseModel<AppointmentModel>> ListAppointmentById(int appointmentId);

        Task<ResponseModel<List<AppointmentResponseDto>>> ListAppointmentByIdUser(int userId);

        Task<ResponseModel<List<AppointmentResponseDto>>> CreateAppointment(
            AppointmentCreationDto appointmentCreationDto);

        Task<ResponseModel<AppointmentResponseDto>> UpdateAppointment(AppointmentUpdateDto dto);

        Task<ResponseModel<List<AppointmentModel>>> DeleteAppointment(int appointmentId);

    }
}
