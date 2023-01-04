using Microsoft.EntityFrameworkCore;

namespace BookManagement.Infrastructure.EntityFramework
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterEntityFramework(this IServiceCollection services, string? connectionstring)
        {
            if(string.IsNullOrEmpty(connectionstring))
                throw new ArgumentNullException(nameof(connectionstring));

            services.AddDbContext<BooksDbContext>(options => options.UseNpgsql(connectionstring));
            return services;
        }
    }
}
