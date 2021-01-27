using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Web.Interfaces;

namespace Web.Extensions
{
    public static class ApiClientExtensions
    {
         public static void AddApiClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRefitClient<IClientApi>()
               .ConfigureHttpClient(
                   c => c.BaseAddress = new Uri(configuration["UrlChurrasApi"]));
        }
    }
}