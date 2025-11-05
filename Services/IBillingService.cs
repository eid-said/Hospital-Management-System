using Hospital_Management_System.Models;

namespace Hospital_Management_System.Services
{
    public interface IBillingService
    {
        Task<IEnumerable<Billing>> GetAllAsync();
        Task<Billing?> GetByIdAsync(int id);
        Task<Billing> CreateAsync(Billing billing);
        Task<Billing> UpdateAsync(Billing billing);
        Task<bool> DeleteAsync(int id);
    }
}
