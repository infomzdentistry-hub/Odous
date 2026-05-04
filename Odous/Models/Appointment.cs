namespace Odous.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = "";
        public DateTime AppointmentDate { get; set; } = DateTime.Now;
        public string Reason { get; set; } = "";
        public string Status { get; set; } = "Scheduled";
    }
}