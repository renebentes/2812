namespace Blog.Extensions;

internal static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder builder)
    {
        builder.UseSwagger();
        builder.UseSwaggerUI();

        return builder;
    }
}
