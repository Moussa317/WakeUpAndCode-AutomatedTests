using Microsoft.Extensions.DependencyInjection;

namespace ReadingLog.Data
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IReviewDataService, ReviewDataService>();

            return services;
        }

    }
}
