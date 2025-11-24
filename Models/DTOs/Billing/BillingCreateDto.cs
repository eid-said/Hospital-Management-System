namespace Hospital_Management_System.Models.DTOs.Billing
{
    public class BillingCreateDto
    {
        public decimal Amount { get; set; }
        public int PatientId { get; set; }
        public int AppointmentId { get; set; }
    }
}
