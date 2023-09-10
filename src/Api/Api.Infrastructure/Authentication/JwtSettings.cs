namespace Api.Infrastructure.Authentication;

public class JwtSettings
{
    public static string SectionName => nameof(JwtSettings);
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public int ExpirationInDays { get; set; }
    public string SecretKey { get; set; } = string.Empty;
}
