using CarService.BL.Interfaces;
using CarService.BL.Services;
using CarService.DL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CarService.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection
            AddBusinessLayer(this IServiceCollection services)
        {
            // Register data layer services here
            services.AddSingleton<ICarCrudService,CarCrudService>();
            services.AddSingleton<ICustomerCrudService, CustomerCrudService>();

            return services;
        }
    }
}
