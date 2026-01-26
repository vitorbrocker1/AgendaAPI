using AgendaAPI.Dto.Vinculo;
using AgendaAPI.Models;

namespace AgendaAPI.Dto.Appointment
{
    public class AppointmentUpdateDto
    {
        public int AppointmentId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public UserVinculo User { get; set; }
    }
}
