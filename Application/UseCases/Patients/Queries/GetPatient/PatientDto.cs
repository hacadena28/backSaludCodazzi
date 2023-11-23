using Domain.Enums;

namespace Application.UseCases.Patients.Queries.GetPatient;

public record PatientDto(Guid Id, string FirstName, string SecondName, string LastName, string SecondLastName,
    TypeDocument DocumentType, string DocumentNumber, string Email, long Phone, string Address, DateTime Birthdate);