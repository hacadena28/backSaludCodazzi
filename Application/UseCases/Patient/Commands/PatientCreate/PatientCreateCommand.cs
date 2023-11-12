using Application.UseCases.Patient.Queries.GetPatient;
using Domain.Entities;
using Domain.Enums;
using Domain.Tests;

namespace Application.UseCases.Patient.Commands.PatientCreate;

public record PatientCreateCommand2(
    string firstName, string secondName, string lastName, string secondLastName, TypeDocument documentType,
    string documentNumber, string email, string phone, string address, DateTime birthdate, Domain.Entities.Eps eps
) : IRequest<PatientDtoEmpty>;