using AgendaAPI.Dto.Appointment;
using AgendaAPI.Dto.AppointmentResponseDto;
using AgendaAPI.Models;
using AgendaAPI.Service.Appointment;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{
    [Route("api/appointments")]
    [ApiController]
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentInterface)
        {
            _appointmentService = appointmentInterface;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<List<AppointmentModel>>>> CreateAppointment(
            AppointmentCreationDto appointmentCreationDto)
        {
            var appointment = await _appointmentService.CreateAppointment(appointmentCreationDto);
            return Ok(appointment);
        }

        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<AppointmentModel>>>> ListAllAppointment()
        {
            var appointments = await _appointmentService.ListAllAppointment();
            return Ok(appointments);
        }

        [HttpGet("{AppointmentId}")]
        public async Task<ActionResult<ResponseModel<List<AppointmentModel>>>> ListAppointmentById(int AppointmentId)
        {
            var appointments = await _appointmentService.ListAppointmentById(AppointmentId);
            return Ok(appointments);
        }

        [HttpGet("/api/users/{userId}/appointments")]
        public async Task<ActionResult<ResponseModel<List<AppointmentModel>>>> ListAppointmentByIdUser(int userId)
        {
            var response = await _appointmentService.ListAppointmentByIdUser(userId);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel<AppointmentResponseDto>>> UpdateAppointment(
            [FromBody] AppointmentUpdateDto dto)
        {
            var response = await _appointmentService.UpdateAppointment(dto);
            return Ok(response);
        }

        [HttpDelete("{appointmentId}")]
        public async Task<ActionResult<ResponseModel<List<AppointmentModel>>>> DeleteAppointment(int appointmentId)
        {
            var response = await _appointmentService.DeleteAppointment(appointmentId);
            return Ok(response);
        }
    }
}
