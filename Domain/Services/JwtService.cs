using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entities;
using Domain.Ports;
using Domain.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace Domain.Services;

public class JwtService
{
    private readonly JWTSettings _jwtSettings;

    public JwtService(IOptions<JWTSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }


    public async Task<string> GenerateToken(User user)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("Uid", user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Sub, user.Person.FirstName),
            new Claim(JwtRegisteredClaimNames.Sub, user.Person.LastName),
            new Claim(JwtRegisteredClaimNames.Email, user.Person.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var singningCredential = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: new DateTime().AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: singningCredential
        );
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}