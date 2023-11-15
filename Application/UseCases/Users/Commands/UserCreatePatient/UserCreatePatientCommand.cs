using Application.UseCases.Eps.Queries.GetEps;
using Application.UseCases.Users.Queries.GetUser;
using Domain.Enums;

namespace Application.UseCases.Users.Commands.UserCreatePatient;



public record PatientCreateCommand(
    string FirstName, string SecondName, string LastName, string SecondLastName, TypeDocument DocumentType,
    string DocumentNumber, string Email, string Phone, string Address, DateTime Birthdate,EpsDto Eps
);

public record UserCreatePatientCommand(string Password, PatientCreateCommand Patient) : IRequest<EmptyUserDto>;