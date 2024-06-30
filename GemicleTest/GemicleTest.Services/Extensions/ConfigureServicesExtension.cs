using GemicleTest.Services.Contracts;
using GemicleTest.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GemicleTest.Services.Extensions
{
    public static class ConfigureServicesExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<ICampaignService, CampaignService>();

            return services;
        }
    }
}
