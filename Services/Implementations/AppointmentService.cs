using AutoMapper;
using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Services.Interfaces;
using Hospital_Management_System.ViewModels.Appointment;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET ALL
        public async Task<List<AppointmentResponseDto>> GetAllAsync()
        {
            var data = await _context.Appointments
                        .Include(x => x.Patient)
                        .Include(x => x.Doctor)
                        .ToListAsync();

            return _mapper.Map<List<AppointmentResponseDto>>(data);
        }

        // GET BY ID
        public async Task<AppointmentResponseDto?> GetByIdAsync(int id)
        {
            var item = await _context.Appointments
                        .Include(x => x.Patient)
                        .Include(x => x.Doctor)
                        .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<AppointmentResponseDto>(item);
        }

        // CREATE
        public async Task<AppointmentResponseDto> CreateAsync(AppointmentCreateDto model)
        {
            var item = _mapper.Map<Appointment>(model);

            _context.Appointments.Add(item);
            await _context.SaveChangesAsync();

            // Load Patient + Doctor to map response
            await _context.Entry(item).Reference(x => x.Patient).LoadAsync();
            await _context.Entry(item).Reference(x => x.Doctor).LoadAsync();

            return _mapper.Map<AppointmentResponseDto>(item);
        }

        // UPDATE
        public async Task<bool> UpdateAsync(int id, AppointmentUpdateDto model)
        {
            var item = await _context.Appointments.FindAsync(id);
            if (item == null) return false;

            _mapper.Map(model, item);
            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _context.Appointments.FindAsync(id);
            if (item == null) return false;

            _context.Appointments.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
