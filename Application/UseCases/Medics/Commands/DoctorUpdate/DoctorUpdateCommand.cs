using Application.UseCases.Medics.Queries.GetDoctor;
using Domain.Enums;

namespace Application.UseCases.Medics.Commands.DoctorUpdate
{
    public record DoctorUpdateCommand(Guid Id, string firstName, string secondName, string lastName,
        string secondLastName, TypeDocument documentType, string documentNumber, string email, string phone,
        string address, DateTime birthdate,string specialization) : IRequest<DoctorDto>;
}