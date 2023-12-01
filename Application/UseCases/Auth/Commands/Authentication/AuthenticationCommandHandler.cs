using Application.UseCases.Auth.Queries;
using Domain.Services;

namespace Application.UseCases.Auth.Commands.Authentication;

public class AuthenticationCommandHandler : IRequestHandler<AuthenticationCommand, AuthenticationDto>
{
    private readonly AuthenticationService _authenticationService;

    public AuthenticationCommandHandler(UserService userService, AuthenticationService authenticationService)
    {
        _authenticationService =
            authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
    }

    public async Task<AuthenticationDto> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
    {
        var user =
            await _authenticationService.ValidateUserCredentials(request.DocumentNumber.Trim(), request.Password);
        return new AuthenticationDto(
            user.Id, user.Person.DocumentNumber, user.Role
        );
    }
}