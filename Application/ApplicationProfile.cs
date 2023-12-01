using Application.UseCases.Admins.Queries.GetAdmin;
using Application.UseCases.Appointments.Queries.GetAppointments;
using Application.UseCases.Epses.Queries.GetEps;
using Application.UseCases.Epses.Queries.GetEpsNormal;
using Application.UseCases.MedicalHistorys.Queries.GetMedicalHistory;
using Application.UseCases.Medics.Queries.GetDoctor;
using Application.UseCases.Medics.Queries.GetEpsNormal;
using Application.UseCases.Patients.Queries.GetPatient;
using Application.UseCases.Users.Queries.GetPaginationUser;
using Domain.Entities;

namespace Application;

public class ApplicationProfile : Profile
{
    public ApplicationProfile()
    {
        CreateMap<Appointment, AppointmentDto>().ReverseMap();
        CreateMap<MedicalHistory, MedicalHistoryDto>().ReverseMap();
        CreateMap<Doctor, DoctorDto>().ReverseMap();
        CreateMap<Admin, AdminDto>().ReverseMap();
        CreateMap<Eps, EpsDto>().ReverseMap();
        CreateMap<Patient, PatientDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Eps, EpsNormalDto>().ReverseMap();
        CreateMap<Doctor, DoctorNormalDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName + " " + src.SecondLastName));
    }
}