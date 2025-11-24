using Hospital_Management_System.ViewModels.Doctor;

namespace Hospital_Management_System.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorResponseDto>> GetAllAsync();
        Task<DoctorResponseDto?> GetByIdAsync(int id);
        Task<DoctorResponseDto> CreateAsync(DoctorCreateDto dto);
        Task<bool> UpdateAsync(int id, DoctorUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
