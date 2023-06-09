using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudyBuddy.Application.Auth;
using StudyBuddy.Domain.Users;
using StudyBuddy.Shared.Domain.Interfaces;

namespace StudyBuddy.Infrastructure.Auth;

public class JwtProvider : IJwtProvider
{
    private readonly IClock _clock;
    private readonly IConfiguration _configuration;

    public JwtProvider(
        IClock clock,
        IConfiguration configuration)
    {
        _clock = clock;
        _configuration = configuration;
    }

    public string Create(User user)
    {
        JwtSettings jwtSettings = new JwtSettings();
        _configuration.GetSection("Jwt").Bind(jwtSettings);
        
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecurityKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        Claim[] claims =
        {
            new Claim("userId", user.Id.ToString()),
            new Claim("email", user.Email.Value),
            new Claim("firstname", user.Firstname.Value),
            new Claim("lastname", user.Lastname.Value)
        };

        var tokenExpirationTime = _clock.Current().AddMinutes(jwtSettings.TokenExpirationInMinutes);

        var token = new JwtSecurityToken(
            jwtSettings.Issuer,
            jwtSettings.Audience,
            claims,
            null,
            tokenExpirationTime,
            signingCredentials);

        var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }
}