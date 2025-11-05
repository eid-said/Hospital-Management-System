namespace Hospital_Management_System.ViewModels.Appointment
{
    public class AppointmentResponseDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime Date { get; set; }
    }
}
