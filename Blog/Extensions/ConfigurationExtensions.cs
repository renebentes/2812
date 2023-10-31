namespace Blog.Extensions;

public static class ConfigurationExtensions
{
    public static void LoadConfiguration(this IConfiguration configuration)
    {
        Configuration.ApiKey = configuration.GetValue<string>(nameof(Configuration.ApiKey)) ?? string.Empty;
        Configuration.ApiKeyName = configuration.GetValue<string>(nameof(Configuration.ApiKeyName)) ?? string.Empty;
        Configuration.JwtKey = configuration.GetValue<string>(nameof(Configuration.JwtKey)) ?? string.Empty;
        Configuration.DefaultConnection = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

        var smtpConfiguration = new SmtpConfiguration();
        configuration.GetSection(nameof(Configuration.SmtpConfiguration)).Bind(smtpConfiguration);
    }
}
