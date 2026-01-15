using System.ComponentModel.DataAnnotations;

namespace AgendaAPI.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public ICollection<AppointmentModel> Appointments { get; set; }
            = new List<AppointmentModel>();
    }
}
