using System;

namespace Odous.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int AppointmentMR { get; set; }   // Unique appointment number
        public string PatientName { get; set; } = "";
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public TimeSpan StartTime { get; set; } = new TimeSpan(9, 0, 0);
        public TimeSpan EndTime { get; set; } = new TimeSpan(10, 0, 0);
        public string Reason { get; set; } = "";
        public string ServiceType { get; set; } = "";
        public string Dentist { get; set; } = "";
        public string Status { get; set; } = "Scheduled";
        public string Notes { get; set; } = "";
    }
}