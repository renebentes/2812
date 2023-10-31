namespace Blog.Extensions;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder builder)
    {
        builder.UseSwagger();
        builder.UseSwaggerUI();

        return builder;
    }
}
