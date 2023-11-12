using Application.UseCases.Users.Queries.GetUser;
using Domain.Enums;

namespace Application.UseCases.Users.Commands.UserCreate;

public record PatientCreateCommand(
    string FirstName, string SecondName, string LastName, string SecondLastName, TypeDocument DocumentType,
    string DocumentNumber, string Email, string Phone, string Address, DateTime Birthdate,Domain.Entities.Eps Eps
);

public record UserCreateCommand(string Password, Role Role, PatientCreateCommand Person) : IRequest<UserDtoEmpty>;