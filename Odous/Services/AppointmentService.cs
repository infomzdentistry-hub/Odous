using Microsoft.EntityFrameworkCore;
using Odous.Models;
using Odous.Data;

namespace Odous.Services
{
    public class AppointmentService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public AppointmentService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            using var context = _dbFactory.CreateDbContext();
            return await context.Appointments.ToListAsync();
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            using var context = _dbFactory.CreateDbContext();
            context.Appointments.Add(appointment);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            using var context = _dbFactory.CreateDbContext();
            var appointment = await context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                context.Appointments.Remove(appointment);
                await context.SaveChangesAsync();
            }
        }
    }
}