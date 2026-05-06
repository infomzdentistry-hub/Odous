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

        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Appointment> Appointments { get; set; } = null!;
        public DbSet<TreatmentPlan> TreatmentPlans { get; set; } = null!;
        public DbSet<TreatmentPlanItem> TreatmentPlanItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(e => e.ContactNo).HasMaxLength(20);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Address).HasMaxLength(200);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.PatientName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.ServiceType).HasMaxLength(50);
                entity.Property(e => e.Dentist).HasMaxLength(100);
                entity.Property(e => e.Status).HasMaxLength(20);
            });

            modelBuilder.Entity<TreatmentPlanItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ToothNumbers).HasMaxLength(200);
                entity.Property(e => e.Procedure).HasMaxLength(50);
                entity.Property(e => e.ProcedureVariant).HasMaxLength(50);
                entity.Property(e => e.PricePerUnit).HasColumnType("decimal(10,2)");
                entity.Property(e => e.NumberOfTeeth);
                entity.Property(e => e.BasePrice).HasColumnType("decimal(10,2)");
                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(5,2)");
                entity.Ignore(e => e.FinalPrice); // Don't store computed property
            });

            modelBuilder.Entity<TreatmentPlanItem>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ToothNumbers).HasMaxLength(200);
                entity.Property(e => e.Procedure).HasMaxLength(50);
                entity.Property(e => e.ProcedureVariant).HasMaxLength(50);
                entity.Property(e => e.PricePerUnit).HasColumnType("decimal(10,2)");
                entity.Property(e => e.NumberOfTeeth);
                entity.Property(e => e.BasePrice).HasColumnType("decimal(10,2)");
                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(5,2)");
                entity.Ignore(e => e.FinalPrice);
            });
        }
    }
}