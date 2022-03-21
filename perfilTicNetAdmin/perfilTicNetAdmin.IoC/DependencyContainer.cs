using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using perfilTicNetAdmin.Presenters;
using perfilTicNetAdmin.Repository;
using perfilTicNetAdmin.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPerfilTicNetAdminsDependencies(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddUseCasesServices();
            services.AddPresenters();

            return services;
        }

    }
}
