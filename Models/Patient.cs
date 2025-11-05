namespace Hospital_Management_System.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // Navigation
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<Billing> Bills { get; set; }
        public int? DoctorId { get; set; }
        public Doctor? Doctor { get; set; }

    }
}
