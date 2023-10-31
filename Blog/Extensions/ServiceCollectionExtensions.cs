namespace Blog.Extensions;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<BlogDataContext>(options => options.UseSqlServer(Configuration.DefaultConnection));

        return services;
    }
}
