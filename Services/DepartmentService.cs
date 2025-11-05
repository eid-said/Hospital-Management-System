using Hospital_Management_System.Models;
using Hospital_Management_System.Repositories;

namespace Hospital_Management_System.Services
{
    public class DepartmentService : IDepartmentService
    {

        private readonly IRepository<Department> _departmentRepo;

        public DepartmentService(IRepository<Department> departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public Task<IEnumerable<Department>> GetAllDepartmentsAsync() =>
            _departmentRepo.GetAllAsync();

        public Task<Department> GetDepartmentByIdAsync(int id) =>
            _departmentRepo.GetByIdAsync(id);

        public Task<Department> CreateDepartmentAsync(Department department) =>
            _departmentRepo.AddAsync(department);

        public Task<Department> UpdateDepartmentAsync(Department department) =>
            _departmentRepo.UpdateAsync(department);

        public Task<bool> DeleteDepartmentAsync(int id) =>
            _departmentRepo.DeleteAsync(id);
    }
}
