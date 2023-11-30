using Domain.Enums;

namespace Application.UseCases.Users.Commands.UserCreateAdmin;

public record AdminCreateCommand(
    string FirstName, string SecondName, string LastName, string SecondLastName, TypeDocument DocumentType,
    string DocumentNumber, string Email, string Phone, string Address, DateTime Birthdate
);

public record UserCreateAdminCommand(string Password, AdminCreateCommand Admin) : IRequest<Unit>;