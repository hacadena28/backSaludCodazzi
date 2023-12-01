using System.Security.Authentication;
using Application.Common.Exceptions;
using Application.UseCases.Auth.Queries;
using Domain.Services;

namespace Application.UseCases.Auth.Commands.Authentication;

public class AuthenticationCommandHandler : IRequestHandler<AuthenticationCommand, AuthenticationDto>
{
    private readonly UserService _userService;
    private readonly AuthenticationService _authenticationService;
    private readonly JwtService _jwtService;

    public AuthenticationCommandHandler(UserService userService, JwtService jwtService,
        AuthenticationService authenticationService)
    {
        _jwtService = jwtService ?? throw new ArgumentNullException(nameof(jwtService));
        _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        _authenticationService =
            authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
    }

    public async Task<AuthenticationDto> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
    {
        var searchedUser =
            await _authenticationService.ValidateUserCredentials(request.DocumentNumber.Trim(), request.Password,
                request.Role);

        if (searchedUser == null)
        {
            throw new AuthenticationException(Domain.Messages.NotAuthorized);
        }
        
        

        var tokenGenerated = await _jwtService.GenerateToken(searchedUser);

        var Auth = new AuthenticationDto(
            searchedUser.Id, searchedUser.Person.DocumentNumber, tokenGenerated, searchedUser.Role
        );
        return Auth;
    }
}