namespace Application.UseCases.Users.Commands.UserDelete;

public record UserDeleteCommand(Guid Id) : IRequest;