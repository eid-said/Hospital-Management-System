using AutoMapper;
using Hospital_Management_System.Models;
using Hospital_Management_System.ViewModels.Patient;

namespace Hospital_Management_System.Mappings.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientResponseDto>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName));

            CreateMap<PatientCreateDto, Patient>();
            CreateMap<PatientUpdateDto, Patient>();
        }
    }
}
