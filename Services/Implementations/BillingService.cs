using AutoMapper;
using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Models.DTOs.Billing;
using Hospital_Management_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services.Implementations
{
    public class BillingService : IBillingService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BillingService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BillingResponseDto>> GetAllAsync()
        {
            var bills = await _context.Billings
                .Include(b => b.Appointment).ThenInclude(a => a.Patient)
                .Include(b => b.Appointment).ThenInclude(a => a.Doctor)
                .ToListAsync();

            return _mapper.Map<IEnumerable<BillingResponseDto>>(bills);
        }

        public async Task<BillingResponseDto?> GetByIdAsync(int id)
        {
            var bill = await _context.Billings
                .Include(b => b.Appointment).ThenInclude(a => a.Patient)
                .Include(b => b.Appointment).ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(x => x.Id == id);

            return bill == null ? null : _mapper.Map<BillingResponseDto>(bill);
        }

        public async Task<BillingResponseDto> CreateAsync(BillingCreateDto dto)
        {
            var bill = _mapper.Map<Billing>(dto);

            _context.Billings.Add(bill);
            await _context.SaveChangesAsync();

            return _mapper.Map<BillingResponseDto>(bill);
        }

        public async Task<BillingResponseDto?> UpdateAsync(int id, BillingUpdateDto dto)
        {
            var bill = await _context.Billings.FindAsync(id);
            if (bill == null) return null;

            bill.Amount = dto.Amount;
            await _context.SaveChangesAsync();

            return _mapper.Map<BillingResponseDto>(bill);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bill = await _context.Billings.FindAsync(id);
            if (bill == null) return false;

            _context.Billings.Remove(bill);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
