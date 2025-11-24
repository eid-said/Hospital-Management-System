namespace Hospital_Management_System.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string? Notes { get; set; }

        // Relations
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; } = null!;
        public ICollection<Billing> Billings { get; set; }

    }
}
