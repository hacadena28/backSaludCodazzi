using Application.UseCases.Users.Queries.GetUser;

namespace Application.UseCases.Users.Commands.UserDeleteDoctor;

public record UserDeleteDoctorCommand(Guid Id, Guid PersonId) : IRequest<EmptyUserDto>;