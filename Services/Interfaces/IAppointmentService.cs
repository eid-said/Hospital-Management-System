using Hospital_Management_System.ViewModels.Appointment;

namespace Hospital_Management_System.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<AppointmentResponseDto>> GetAllAsync();
        Task<AppointmentResponseDto?> GetByIdAsync(int id);
        Task<AppointmentResponseDto> CreateAsync(AppointmentCreateDto model);
        Task<bool> UpdateAsync(int id, AppointmentUpdateDto model);
        Task<bool> DeleteAsync(int id);
    }
}
