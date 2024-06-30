using GemicleTest.CSV.DataAccess.DataAccess;
using GemicleTest.CSV.DataAccess.DataAccess.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace GemicleTest.CSV.DataAccess.Extensions
{
    public static class AddCSVDataAccessExtension
    {
        public static IServiceCollection AddCSVDataAccess(this IServiceCollection services, string filePath)
        {
            services.Configure<CsvConnectionOptions>(o => o.FilePath = filePath);
            services.AddScoped<ICustomerDao, CustomerDao>();
            services.AddScoped<ICampaignDao, CampaignDao>();

            return services;
        }
    }
}
