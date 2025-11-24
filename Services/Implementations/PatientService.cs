using AutoMapper;
using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Services.Interfaces;
using Hospital_Management_System.ViewModels.Patient;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PatientService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PatientResponseDto>> GetAllAsync()
        {
            var patients = await _context.Patients
                .Include(p => p.Doctor)
                .ToListAsync();

            return _mapper.Map<List<PatientResponseDto>>(patients);
        }

        public async Task<PatientResponseDto?> GetByIdAsync(int id)
        {
            var patient = await _context.Patients
                .Include(p => p.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);

            return _mapper.Map<PatientResponseDto?>(patient);
        }

        public async Task<PatientResponseDto> CreateAsync(PatientCreateDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);

            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();

            return _mapper.Map<PatientResponseDto>(patient);
        }

        public async Task<bool> UpdateAsync(int id, PatientUpdateDto dto)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return false;

            _mapper.Map(dto, patient);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient == null) return false;

            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
