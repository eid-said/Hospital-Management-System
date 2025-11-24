using AutoMapper;
using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Hospital_Management_System.ViewModels.Department;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Services.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentResponseDto>> GetAllAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return _mapper.Map<IEnumerable<DepartmentResponseDto>>(departments);
        }

        public async Task<DepartmentResponseDto?> GetByIdAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            return _mapper.Map<DepartmentResponseDto>(dept);
        }

        public async Task<DepartmentResponseDto> CreateAsync(DepartmentCreateDto dto)
        {
            var entity = _mapper.Map<Department>(dto);
            _context.Departments.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<DepartmentResponseDto>(entity);
        }

        public async Task<bool> UpdateAsync(int id, DepartmentUpdateDto dto)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return false;

            _mapper.Map(dto, dept);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var dept = await _context.Departments.FindAsync(id);
            if (dept == null) return false;

            _context.Departments.Remove(dept);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
