using Application.UseCases.Patients.Queries.GetPatient;
using Domain.Enums;

namespace Application.UseCases.Patients.Commands.PatientUpdate
{
    public record PatientUpdateCommand(Guid Id, string firstName, string secondName, string lastName,
        string secondLastName, TypeDocument documentType, string documentNumber, string email, string phone,
        string address, DateTime birthdate, Domain.Entities.Eps eps) : IRequest<PatientDto>;
}