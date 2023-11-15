using Application.UseCases.Appointment.Queries.GetAppointment;
using Application.UseCases.Doctor.Queries.GetDoctor;
using Application.UseCases.Eps.Queries.GetEps;
using Application.UseCases.Patient.Queries.GetPatient;
using Application.UseCases.Users.Queries.GetUser;
using Domain.Entities;

namespace Application
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<Eps, EpsDto>().ReverseMap();
            CreateMap<EpsDto, Eps>().ReverseMap();
            // CreateMap<MedicalHistory, MedicalHistoryDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}