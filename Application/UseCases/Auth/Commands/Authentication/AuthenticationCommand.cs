using Application.UseCases.Auth.Queries;

namespace Application.UseCases.Auth.Commands.Authentication;

public record AuthenticationCommand(
    string DocumentNumber, string Password
) : IRequest<AuthenticationDto>;