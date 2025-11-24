namespace Hospital_Management_System.ViewModels.Appointment
{
    public class AppointmentCreateDto
    {
        public DateTime Date { get; set; }
        public string? Notes { get; set; }

        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }
}
