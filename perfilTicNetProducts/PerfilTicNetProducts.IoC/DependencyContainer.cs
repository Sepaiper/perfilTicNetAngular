using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PerfilTicNetProduct.UseCases;
using perfilTicNetProducts.RepositoryHttp;
using PerfilTicNetProducts.Repository;
using PerfiltTicNetProduct.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProducts.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPerfilTicNetProductsDependencies(
            this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddRepositoriesHttp();
            services.AddUseCasesServices();
            services.AddPresenters();

            return services;
        }

    }
}
