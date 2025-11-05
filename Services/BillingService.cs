using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services
{
    public class BillingService : IBillingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Billing> _billingRepo;

        public BillingService(ApplicationDbContext context, IRepository<Billing> billingRepo)
        {
            _context = context;
            _billingRepo = billingRepo;
        }

        public async Task<IEnumerable<Billing>> GetAllAsync()
        {
            return await _context.Billings
                .Include(b => b.Patient)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Billing?> GetByIdAsync(int id)
        {
            return _billingRepo.GetByIdAsync(id);
        }

        public Task<Billing> CreateAsync(Billing billing)
        {
            return _billingRepo.AddAsync(billing);
        }

        public Task<Billing> UpdateAsync(Billing billing)
        {
            return _billingRepo.UpdateAsync(billing);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _billingRepo.DeleteAsync(id);
        }
    }
}
