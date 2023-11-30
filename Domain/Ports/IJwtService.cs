namespace Domain.Ports;

public interface IJwtService
{
    string GenerateToken(string userId);
}