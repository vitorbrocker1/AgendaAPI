using AgendaAPI.Models;
using AgendaAPI.Service.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentInterface)
        {
            _appointmentService = appointmentInterface;
        }

        [HttpGet("GetAllAppointments")]

        public async Task<ActionResult<ResponseModel<List<AppointmentModel>>>> GetAllAppointments()
        {
            var appointment = await _appointmentService.GetAllAppointment();
            return Ok(appointment);
        }
        
       
           
        }
}
