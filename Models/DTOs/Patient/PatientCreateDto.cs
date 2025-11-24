namespace Hospital_Management_System.ViewModels.Patient
{
    public class PatientCreateDto
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public int? DoctorId { get; set; }
    }
}
