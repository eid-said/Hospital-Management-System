using Hospital_Management_System.Models.DTOs.Billing;

namespace Hospital_Management_System.Services.Interfaces
{
    public interface IBillingService
    {
        Task<IEnumerable<BillingResponseDto>> GetAllAsync();
        Task<BillingResponseDto?> GetByIdAsync(int id);
        Task<BillingResponseDto> CreateAsync(BillingCreateDto dto);
        Task<BillingResponseDto?> UpdateAsync(int id, BillingUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
