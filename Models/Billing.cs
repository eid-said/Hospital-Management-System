using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Billing
    {
        public int Id { get; set; }

        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Relation to Patient
        public int PatientId { get; set; }
        public Patient Patient { get; set; } = null!;
    }
}
