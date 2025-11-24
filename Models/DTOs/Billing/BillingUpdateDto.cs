namespace Hospital_Management_System.Models.DTOs.Billing
{
    public class BillingUpdateDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int AppointmentId { get; set; }
    }
}
