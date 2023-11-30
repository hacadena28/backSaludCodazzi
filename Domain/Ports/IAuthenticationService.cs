namespace Domain.Ports;

public interface IAuthenticationService
{
    bool ValidateUserCredentials(string username, string password);
}