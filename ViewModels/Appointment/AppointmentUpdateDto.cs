namespace Hospital_Management_System.ViewModels.Appointment
{
    public class AppointmentUpdateDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime Date { get; set; }
    }
}
