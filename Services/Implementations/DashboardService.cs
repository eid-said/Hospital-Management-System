using AutoMapper;
using Hospital_Management_System.Data;
using Hospital_Management_System.Models.DTOs.Dashboard;

using Hospital_Management_System.Services.Interfaces;
using Hospital_Management_System.ViewModels.Appointment;
using Hospital_Management_System.ViewModels.Patient;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DashboardService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DashboardStatsDto> GetStatsAsync()
        {
            var stats = new DashboardStatsDto
            {
                TotalPatients = await _context.Patients.CountAsync(),
                TotalDoctors = await _context.Doctors.CountAsync(),
                TotalAppointments = await _context.Appointments.CountAsync(),
                TotalBillings = await _context.Billings.CountAsync(),
                TotalRevenue = await _context.Billings.SumAsync(b => b.Amount)
            };

            // Latest records
            var latestPatients = await _context.Patients
                .OrderByDescending(p => p.Id)
                .Take(5)
                .ToListAsync();

            var latestAppointments = await _context.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .OrderByDescending(a => a.Date)
                .Take(5)
                .ToListAsync();

            var latestBillings = await _context.Billings
                .Include(b => b.Appointment)
                .ThenInclude(a => a.Patient)
                .Include(b => b.Appointment)
                .ThenInclude(a => a.Doctor)
                .OrderByDescending(b => b.CreatedAt)
                .Take(5)
                .ToListAsync();

            stats.RecentPatients = _mapper.Map<List<PatientResponseDto>>(latestPatients);
            stats.RecentAppointments = _mapper.Map<List<AppointmentResponseDto>>(latestAppointments);
            stats.RecentBillings = _mapper.Map<List<BillingResponseDto>>(latestBillings);

            return stats;
        }
    }
}
