using Hospital_Management_System.Models;

public class Billing
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public int AppointmentId { get; set; }
    public Appointment Appointment { get; set; }

   
}
