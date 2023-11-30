using Domain.Ports;

namespace Domain.Services;

public class AuthenticationService : IAuthenticationService
{
    public bool ValidateUserCredentials(string username, string password)
    {
        return true;
    }
}