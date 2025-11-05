//using AutoMapper;
//using Hospital_Management_System.Models;
//using Hospital_Management_System.ViewModels.Appointment;
//using Hospital_Management_System.ViewModels.Billing;

//using Hospital_Management_System.ViewModels.Department;
//using Hospital_Management_System.ViewModels.Doctor;
//using Hospital_Management_System.ViewModels.Patient;

//namespace Hospital_Management_System.Mappings
//{
//    public class MappingProfile : Profile
//    {
//        public MappingProfile()
//        {
//            // Department
//            CreateMap<Department, DepartmentResponseDto>();
//            CreateMap<DepartmentCreateDto, Department>();
//            CreateMap<DepartmentUpdateDto, Department>();

//            // Doctor
//            CreateMap<Doctor, DoctorResponseDto>()
//                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.Name));

//            CreateMap<DoctorCreateDto, Doctor>();
//            CreateMap<DoctorUpdateDto, Doctor>();

//            // Patient
//            CreateMap<Patient, PatientResponseDto>()
//                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name));

//            CreateMap<PatientCreateDto, Patient>();
//            CreateMap<PatientUpdateDto, Patient>();

//            // Appointment
//            CreateMap<Appointment, AppointmentResponseDto>()
//                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.Name))
//                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name));

//            CreateMap<AppointmentCreateDto, Appointment>();
//            CreateMap<AppointmentUpdateDto, Appointment>();

//            // Billing
//            CreateMap<Billing, BillingResponseDto>()
//                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Appointment.Patient.Name))
//                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Appointment.Doctor.Name))
//                .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => src.Appointment.Date));

//            CreateMap<BillingCreateDto, Billing>();
//            CreateMap<BillingUpdateDto, Billing>();
//        }
//    }
//}
