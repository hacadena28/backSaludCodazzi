using Domain.Enums;

namespace Application.UseCases.Users.Commands.UserCreateDoctor;

public record DoctorCreateCommand(
    string FirstName, string SecondName, string LastName, string SecondLastName, TypeDocument DocumentType,
    string DocumentNumber, string Email, string Phone, string Address, DateTime Birthdate, string Specialization
);

public record UserCreateDoctorCommand(string Password, DoctorCreateCommand Doctor) : IRequest<Unit>;