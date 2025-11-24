using Hospital_Management_System.ViewModels.Patient;

namespace Hospital_Management_System.Services.Interfaces
{
    public interface IPatientService
    {
        Task<List<PatientResponseDto>> GetAllAsync();
        Task<PatientResponseDto?> GetByIdAsync(int id);
        Task<PatientResponseDto> CreateAsync(PatientCreateDto dto);
        Task<bool> UpdateAsync(int id, PatientUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
