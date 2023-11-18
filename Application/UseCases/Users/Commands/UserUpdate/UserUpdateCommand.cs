namespace Application.UseCases.Users.Commands.UserUpdate
{
    public record UserUpdateCommand(Guid Id, string Password) : IRequest;
}