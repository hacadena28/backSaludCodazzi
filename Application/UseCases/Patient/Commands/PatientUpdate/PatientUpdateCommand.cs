using Application.UseCases.Patient.Queries.GetPatient;
using Domain.Enums;
using Domain.Tests;
using MediatR;

namespace Application.UseCases.Patient.Commands.PatientUpdate
{
    public record PatientUpdateCommand(Guid Id, string firstName, string secondName, string lastName, string secondLastName, TypeDocument documentType, string documentNumber, string email, long phone, string address, DateTime birthdate) : IRequest<PatientDto>;
}