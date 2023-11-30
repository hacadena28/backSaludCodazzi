using Domain.Enums;

namespace Application.UseCases.Admins.Queries.GetAdmin;

public record AdminDto(Guid Id, string FirstName, string SecondName, string LastName, string SecondLastName,
    TypeDocument DocumentType, string DocumentNumber, string Email, long Phone, string Address, DateTime Birthdate);