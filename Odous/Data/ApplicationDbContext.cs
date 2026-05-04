using Microsoft.EntityFrameworkCore;
using Odous.Models;

namespace Odous.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; } = default!;
        public DbSet<Appointment> Appointments { get; set; } = default!;
    }
}