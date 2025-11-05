using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Patient> _patientRepo;

        public PatientService(ApplicationDbContext context, IRepository<Patient> patientRepo)
        {
            _context = context;
            _patientRepo = patientRepo;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients
                .Include(p => p.Doctor)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Patient?> GetByIdAsync(int id)
        {
            return _patientRepo.GetByIdAsync(id);
        }

        public Task<Patient> CreateAsync(Patient patient)
        {
            return _patientRepo.AddAsync(patient);
        }

        public Task<Patient> UpdateAsync(Patient patient)
        {
            return _patientRepo.UpdateAsync(patient);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _patientRepo.DeleteAsync(id);
        }
    }
}
