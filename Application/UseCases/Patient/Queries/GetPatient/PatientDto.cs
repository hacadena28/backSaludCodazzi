using Domain.Enums;
using Domain.Tests;

namespace Application.UseCases.Patient.Queries.GetPatient;

public record PatientDto(Guid id,string firstName, string secondName, string lastName, string secondLastName,
    TypeDocument documentType, string documentNumber, string email, long phone, string address, DateTime birthdate);