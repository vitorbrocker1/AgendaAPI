using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaAPI.Models
{
    public class AppointmentModel
    {
        [Key]
        public int AppointmentId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        // FK explícita (BOA PRÁTICA)
        public int UserId { get; set; }

        public UserModel User { get; set; }
    }
}
