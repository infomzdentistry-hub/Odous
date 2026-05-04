using Microsoft.EntityFrameworkCore;
using Odous.Models;
using Odous.Data;

namespace Odous.Services
{
    public class PatientService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public PatientService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            using var context = _dbFactory.CreateDbContext();
            return await context.Patients.ToListAsync();
        }

        public async Task AddPatientAsync(Patient patient)
        {
            using var context = _dbFactory.CreateDbContext();
            context.Patients.Add(patient);
            await context.SaveChangesAsync();
        }

        public async Task DeletePatientAsync(int id)
        {
            using var context = _dbFactory.CreateDbContext();
            var patient = await context.Patients.FindAsync(id);
            if (patient != null)
            {
                context.Patients.Remove(patient);
                await context.SaveChangesAsync();
            }
        }
    }
}