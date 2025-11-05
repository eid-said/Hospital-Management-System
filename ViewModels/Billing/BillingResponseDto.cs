namespace Hospital_Management_System.ViewModels.Billing
{
    public class BillingResponseDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public decimal Amount { get; set; }
    }
}
