using Application.UseCases.Appointment.Queries.GetAppointment;
using Application.UseCases.Epses.Queries.GetEps;
using Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;
using Application.UseCases.Medics.Queries.GetDoctor;
using Application.UseCases.Patients.Queries.GetPatient;
using Application.UseCases.Users.Queries.GetUser;
using Domain.Entities;

namespace Application;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<MedicalHistory, MedicalHistoryDto>().ReverseMap();
        CreateMap<Doctor, DoctorDto>().ReverseMap();
        CreateMap<Eps, EpsDto>().ReverseMap();
        CreateMap<Patient, PatientDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}