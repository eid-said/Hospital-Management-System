using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepository<Appointment> _appointmentRepo;

        public AppointmentService(ApplicationDbContext context, IRepository<Appointment> appointmentRepo)
        {
            _context = context;
            _appointmentRepo = appointmentRepo;
        }

        public async Task<IEnumerable<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .AsNoTracking()
                .ToListAsync();
        }

        public Task<Appointment?> GetByIdAsync(int id)
        {
            return _appointmentRepo.GetByIdAsync(id);
        }

        public Task<Appointment> CreateAsync(Appointment appointment)
        {
            return _appointmentRepo.AddAsync(appointment);
        }

        public Task<Appointment> UpdateAsync(Appointment appointment)
        {
            return _appointmentRepo.UpdateAsync(appointment);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return _appointmentRepo.DeleteAsync(id);
        }
    }
}
