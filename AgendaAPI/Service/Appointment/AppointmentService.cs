using AgendaAPI.Data;
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

        public Task<ResponseModel<AppointmentModel>> CreateAppointment(AppointmentModel appointment)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<AppointmentModel>>> GetAllAppointment()
        {
            ResponseModel<List<AppointmentModel>> response = new ResponseModel<List<AppointmentModel>>();
            try
            {
                var appointments = await _context.Appointments.ToListAsync();   

                response.Data = appointments;
                response.Message = "Appointments retrieved successfully.";
                return response;

            }
            catch(Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
                return response;
            }
        }

        public Task<ResponseModel<AppointmentModel>> GetAppointmentById(int AppointmentId)
        {
            /*ResponseModel<AppointmentModel> response = new ResponseModel<AppointmentModel>();
            try
            {

            }
            catch (Exception ex)
            {

            } */
            throw new NotImplementedException();
        } 

        public Task<ResponseModel<UserModel>> GetUserById(int UserId)
        {
            throw new NotImplementedException();
        }
    }
}
