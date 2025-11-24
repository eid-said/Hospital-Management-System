
using Hospital_Management_System.ViewModels.Appointment;
using Hospital_Management_System.ViewModels.Patient;

namespace Hospital_Management_System.Models.DTOs.Dashboard
{
    public class DashboardStatsDto
    {
        public int TotalPatients { get; set; }
        public int TotalDoctors { get; set; }
        public int TotalAppointments { get; set; }
        public int TotalBillings { get; set; }
        public decimal TotalRevenue { get; set; }

        // Latest Records
        public List<PatientResponseDto> RecentPatients { get; set; } = new();
        public List<AppointmentResponseDto> RecentAppointments { get; set; } = new();
        public List<BillingResponseDto> RecentBillings { get; set; } = new();
    }
}
