using Microsoft.Extensions.DependencyInjection;
using perfilTicNetAdmin.UseCases.CreateAdmin;
using perfilTicNetAdmin.UseCases.ReadAdmin;
using perfilTicNetAdmin.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
        {
            services.AddTransient<ICreateAdminInputPort, CreateAdminInteractor>();
            services.AddTransient<IReadAdminInputPort, ReadAdminInteractor>();

            return services;
        }
    }
}
