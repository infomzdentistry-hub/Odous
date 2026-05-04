namespace Odous.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public int PatientMR { get; set; }      // Unique sequence number
        public string Name { get; set; } = "";
        public string Gender { get; set; } = "";
        public int Age { get; set; }
        public string ContactNo { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime? LastVisit { get; set; }
        public string Notes { get; set; } = "";
        public string Status { get; set; } = "Active";
    }
}