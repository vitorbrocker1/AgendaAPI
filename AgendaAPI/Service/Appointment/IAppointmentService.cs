
using AgendaAPI.Dto.Appointment;
using AgendaAPI.Models;

namespace AgendaAPI.Service.Appointment
{
    public interface IAppointmentService
    {
        Task<ResponseModel<List<AppointmentModel>>> ListAllAppointment();

        Task<ResponseModel<AppointmentModel>> ListAppointmentById(int appointmentId);

        Task<ResponseModel<UserModel>> ListAppointmentByIdUser(int appointmentId);

        Task<ResponseModel<List<AppointmentModel>>> CreateAppointment(AppointmentCreationDto appointmentCreationDto);

        Task<ResponseModel<List<AppointmentModel>>> UpdateAppointment(AppointmentUpdateDto appointmentUpdateDto);

        Task<ResponseModel<List<AppointmentModel>>> DeleteAppointment();
    }
}
