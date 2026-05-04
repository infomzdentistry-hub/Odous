using System;

namespace Odous.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int AppointmentMR { get; set; }
        public string PatientName { get; set; } = "";
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public TimeOnly StartTime { get; set; } = new TimeOnly(9, 0);
        public TimeOnly EndTime { get; set; } = new TimeOnly(10, 0);
        public string Reason { get; set; } = "";
        public string ProcedureNotes { get; set; } = "";
        public string ServiceType { get; set; } = "";
        public string Dentist { get; set; } = "";
        public string Status { get; set; } = "Scheduled";
        public string Notes { get; set; } = "";
    }
}