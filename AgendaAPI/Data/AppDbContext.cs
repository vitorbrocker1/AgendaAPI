using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<AgendaAPI.Models.User> Users { get; set; }
        public DbSet<AgendaAPI.Models.Appointment> Appointments { get; set; }
    }
}
