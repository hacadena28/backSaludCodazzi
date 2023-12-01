using Application.UseCases.Auth.Queries;
using Domain.Enums;

namespace Application.UseCases.Auth.Commands.Authentication;

public record AuthenticationCommand(
    string DocumentNumber, string Password,Role Role
) : IRequest<AuthenticationDto>;