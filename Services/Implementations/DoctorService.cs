using AutoMapper;
using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Services.Interfaces;
using Hospital_Management_System.ViewModels.Doctor;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services.Implementations
{
    public class DoctorService : IDoctorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DoctorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DoctorResponseDto>> GetAllAsync()
        {
            var doctors = await _context.Doctors
                .Include(d => d.Department)
                .ToListAsync();

            return _mapper.Map<IEnumerable<DoctorResponseDto>>(doctors);
        }

        public async Task<DoctorResponseDto?> GetByIdAsync(int id)
        {
            var doctor = await _context.Doctors
                .Include(d => d.Department)
                .FirstOrDefaultAsync(d => d.Id == id);

            return doctor == null ? null : _mapper.Map<DoctorResponseDto>(doctor);
        }

        public async Task<DoctorResponseDto> CreateAsync(DoctorCreateDto dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return _mapper.Map<DoctorResponseDto>(doctor);
        }

        public async Task<bool> UpdateAsync(int id, DoctorUpdateDto dto)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return false;

            _mapper.Map(dto, doctor);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor == null) return false;

            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
