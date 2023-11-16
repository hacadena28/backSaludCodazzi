using Application.UseCases.Appointment.Queries.GetAppointment;
using Application.UseCases.Doctor.Queries.GetDoctor;
using Application.UseCases.Eps.Queries.GetEps;
using Application.UseCases.Patient.Queries.GetPatient;
using Application.UseCases.Users.Commands.UserCreateDoctor;
using Application.UseCases.Users.Commands.UserCreatePatient;
using Application.UseCases.Users.Commands.UserDeleteDoctor;
using Application.UseCases.Users.Commands.UserDeletePatient;
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
            
            CreateMap<DoctorCreateCommand, Doctor>().ReverseMap();
            
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UserCreateDoctorCommand, User>().ReverseMap();
            CreateMap<UserDeleteDoctorCommand, User>().ReverseMap();
            CreateMap<UserCreatePatientCommand, User>().ReverseMap();
            CreateMap<UserDeletePatientCommand, User>().ReverseMap();
        }
    }
}