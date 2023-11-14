using Domain.Enums;
using Domain.Tests;

namespace Application.UseCases.Doctor.Queries.GetDoctor;

public record DoctorDto(Guid id,string firstName, string secondName, string lastName, string secondLastName,
    TypeDocument documentType, string documentNumber, string email, long phone, string address, DateTime birthdate, string specialization);