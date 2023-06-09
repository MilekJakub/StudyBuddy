namespace StudyBuddy.Infrastructure.Auth;

public class JwtSettings
{
    public JwtSettings()
    {
        Issuer = string.Empty;
        Audience = string.Empty;
        SecurityKey = string.Empty;
    }

    public string Issuer { get; set; }
    public string Audience { get; set; }
    public string SecurityKey { get; set; }
    public int TokenExpirationInMinutes { get; set; }
}