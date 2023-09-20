using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using News.Infrastructure.Services.ClassificationServices;
using News.Infrastructure.Services.NewsServices;
using News.Infrastructure.Services.FileServices;
using News.Infrastructure.Services.LandingServices;

namespace News.Infrastructure.Services
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddConfig(
        this IServiceCollection services, IConfiguration config)
        {

            return services;
        }
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddTransient<IClassificationService, ClassificationService>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<ILandingService, LandingService>();
            //services.AddScoped<, >();



            return services;
        }
    }
}
