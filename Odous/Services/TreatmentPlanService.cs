using Microsoft.EntityFrameworkCore;
using Odous.Models;
using Odous.Data;

namespace Odous.Services
{
    public class TreatmentPlanService
    {
        private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;

        public TreatmentPlanService(IDbContextFactory<ApplicationDbContext> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<List<TreatmentPlan>> GetByPatientAsync(string patientName)
        {
            using var context = _dbFactory.CreateDbContext();
            return await context.TreatmentPlans
                .Include(t => t.Items)
                .Where(t => t.PatientName == patientName)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task<TreatmentPlan> SavePlanAsync(TreatmentPlan plan)
        {
            using var context = _dbFactory.CreateDbContext();
            
            if (plan.CreatedAt == default)
            {
                plan.CreatedAt = DateTime.UtcNow;
            }
            
            context.TreatmentPlans.Add(plan);
            await context.SaveChangesAsync();
            return plan;
        }

        public async Task DeletePlanAsync(int id)
        {
            using var context = _dbFactory.CreateDbContext();
            var plan = await context.TreatmentPlans.FindAsync(id);
            if (plan != null)
            {
                context.TreatmentPlans.Remove(plan);
                await context.SaveChangesAsync();
            }
        }
    }
}
