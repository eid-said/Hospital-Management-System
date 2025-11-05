using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Hospital_Management_System.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Doctor> _doctorRepo;

        public DoctorService(ApplicationDbContext context, IRepository<Doctor> doctorRepo)
        {
            _context = context;
            _doctorRepo = doctorRepo;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            //return await _doctorRepo.GetAllAsync();
            return await _context.Doctors
                .Include(d => d.Department)
                .ToListAsync();
        }

        public Task<Doctor> GetByIdAsync(int id)
        {
            return _doctorRepo.GetByIdAsync(id);
        }

        public Task<Doctor> CreateAsync(Doctor doctor)
        {
            return _doctorRepo.AddAsync(doctor);
        }

        public Task<Doctor> UpdateAsync(Doctor doctor)
        {
            return _doctorRepo.UpdateAsync(doctor);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _doctorRepo.DeleteAsync(id);
        }
    }
}
