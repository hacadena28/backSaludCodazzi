using Application.UseCases.Users.Queries.GetUser;

namespace Application.UseCases.Users.Commands.UserDeletePatient;

public record UserDeletePatientCommand(Guid Id, Guid PersonId) : IRequest<EmptyUserDto>;