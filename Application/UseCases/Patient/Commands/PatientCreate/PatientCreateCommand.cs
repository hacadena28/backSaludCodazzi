using Application.UseCases.Patient.Queries.GetPatient;
using Domain.Entities;
using Domain.Enums;
using Domain.Tests;

namespace Application.UseCases.Patient.Commands.PatientCreate;

public record PatientCreateCommand(
    string firstName, string secondName, string lastName, string secondLastName, TypeDocument documentType,
    string documentNumber, string email, long phone, string address, DateTime birthdate
) : IRequest<PatientDtoEmpty>;