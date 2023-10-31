namespace Blog.Configurations;

public static class Configuration
{
    public static string ApiKey { get; set; } = string.Empty;

    public static string ApiKeyName { get; set; } = string.Empty;

    public static string DefaultConnection { get; set; } = string.Empty;

    public static string JwtKey { get; set; } = string.Empty;

    public static SmtpConfiguration SmtpConfiguration { get; set; } = new();
}
