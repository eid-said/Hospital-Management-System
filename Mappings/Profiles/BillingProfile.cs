using AutoMapper;
using Hospital_Management_System.Models;

public class BillingProfile : Profile
{
    public BillingProfile()
    {
        CreateMap<Billing, BillingResponseDto>()
            .ForMember(dest => dest.PatientFullName, opt => opt.MapFrom(src => src.Appointment.Patient.FullName))
            .ForMember(dest => dest.DoctorFullName, opt => opt.MapFrom(src => src.Appointment.Doctor.FullName))
            .ForMember(dest => dest.AppointmentDate, opt => opt.MapFrom(src => src.Appointment.Date));
    }
}
