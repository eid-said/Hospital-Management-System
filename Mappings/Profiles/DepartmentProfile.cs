using AutoMapper;
using Hospital_Management_System.Models;
using Hospital_Management_System.ViewModels.Department;

namespace Hospital_Management_System.Mappings.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentResponseDto>();
            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<DepartmentUpdateDto, Department>();
        }
    }
}
