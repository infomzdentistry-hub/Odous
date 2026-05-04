namespace Odous.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime? LastVisit { get; set; }
        public string Notes { get; set; } = "";
    }
}