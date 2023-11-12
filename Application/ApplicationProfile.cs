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
            CreateMap<Eps, EpsDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Patient, PatientDto>().ReverseMap();
        }
    }
}