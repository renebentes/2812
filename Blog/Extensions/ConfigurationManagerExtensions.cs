namespace Blog.Extensions;

public static class ConfigurationManagerExtensions
{
    public static void LoadConfiguration(this ConfigurationManager configuration)
    {
        Configuration.ApiKey = configuration.GetValue<string>(nameof(Configuration.ApiKey)) ?? string.Empty;
        Configuration.ApiKeyName = configuration.GetValue<string>(nameof(Configuration.ApiKeyName)) ?? string.Empty;
        Configuration.JwtKey = configuration.GetValue<string>(nameof(Configuration.JwtKey)) ?? string.Empty;

        var smtpConfiguration = new SmtpConfiguration();
        configuration.GetSection(nameof(Configuration.SmtpConfiguration)).Bind(smtpConfiguration);
    }
}
