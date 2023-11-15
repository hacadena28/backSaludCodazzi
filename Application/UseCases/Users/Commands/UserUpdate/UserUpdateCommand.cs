using Application.UseCases.Users.Queries.GetUser;

namespace Application.UseCases.Users.Commands.UserUpdate
{
    public record UserUpdateCommand(Guid Id, string Password) : IRequest<EmptyUserDto>;
}