using Hospital_Management_System.Models.DTOs.Dashboard;

namespace Hospital_Management_System.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardStatsDto> GetStatsAsync();
    }
}
