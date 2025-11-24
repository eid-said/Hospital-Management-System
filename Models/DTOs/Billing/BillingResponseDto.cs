public class BillingResponseDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public string PatientFullName { get; set; }
    public string DoctorFullName { get; set; }
    public DateTime AppointmentDate { get; set; }
}
