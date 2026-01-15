using AgendaAPI.Models;

namespace AgendaAPI.Service.Appointment
{
    public interface IAppointmentService
    {

        public Task<ResponseModel<List<AppointmentModel>>> GetAllAppointment();

        public Task<ResponseModel<AppointmentModel>> GetAppointmentById(int AppointmentId);

        public Task<ResponseModel<AppointmentModel>> CreateAppointment(AppointmentModel appointment);

        public Task<ResponseModel<UserModel>> GetUserById(int UserId);



    }
}
