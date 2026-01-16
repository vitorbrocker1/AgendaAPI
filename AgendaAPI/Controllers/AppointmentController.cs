using AgendaAPI.Dto.Appointment;
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

        [HttpPost("CreateAppointment")]
        public async Task<ActionResult<ResponseModel<List<AppointmentModel>>>> CreateAppointment(
            AppointmentCreationDto appointmentCreationDto)
        {
            var appointment = await _appointmentService.CreateAppointment(appointmentCreationDto);
            return Ok(appointment);
        }

        [HttpGet("ListAllAppointment")]
        public async Task<ActionResult<ResponseModel<List<AppointmentModel>>>> ListAllAppointment()
        {
            var appointments = await _appointmentService.ListAllAppointment();
            return Ok(appointments);
        }

        [HttpGet("ListAppointmentById/{AppointmentId}")]
        public async Task<ActionResult<ResponseModel<List<AppointmentModel>>>> ListAppointmentById(int AppointmentId)
        {
            var appointments = await _appointmentService.ListAppointmentById(AppointmentId);
            return Ok(appointments);
        }


        [HttpGet("ListAppointmentByIdUser/{AppointmentId}")]
        public async Task<ActionResult<ResponseModel<AppointmentModel>>> ListAppointmentByIdUser(int AppointmentId)
        {
            var appointment = await _appointmentService.ListAppointmentByIdUser(AppointmentId);
            return Ok(appointment);
        }


        [HttpPut("UpdateAppointment")]
        public async Task<ActionResult<ResponseModel<List<AppointmentModel>>>> UpdateAppointment(
            AppointmentUpdateDto appointmentUpdateDto)
        {
            var appointment = await _appointmentService.UpdateAppointment(appointmentUpdateDto);
            return Ok(appointment);
        }

        [HttpDelete("DeleteAppointment/{AppointmentId}")]
        public async Task<ActionResult<ResponseModel<List<AppointmentModel>>>> DeleteAppointment()
        {
            var appointment = await _appointmentService.DeleteAppointment();
            return Ok(appointment);
        }



    }
}
