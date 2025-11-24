using Hospital_Management_System.ViewModels.Department;

namespace Hospital_Management_System.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentResponseDto>> GetAllAsync();
        Task<DepartmentResponseDto?> GetByIdAsync(int id);
        Task<DepartmentResponseDto> CreateAsync(DepartmentCreateDto dto);
        Task<bool> UpdateAsync(int id, DepartmentUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
