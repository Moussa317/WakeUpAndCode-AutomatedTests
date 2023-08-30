using Microsoft.Extensions.DependencyInjection;

namespace ReadingLog.Services
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<IBookService, BookSerivce>();
            services.AddScoped<IIsbnWrapper, IsbnWrapper>();

            return services;
        }

    }
}
