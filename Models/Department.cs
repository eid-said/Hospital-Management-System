namespace Hospital_Management_System.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation
        public ICollection<Doctor> Doctors { get; set; }
    }
}
