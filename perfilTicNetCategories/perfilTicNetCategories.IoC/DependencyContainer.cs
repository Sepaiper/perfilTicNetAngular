using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using perfilTicNetCategories.Presenter;
using perfilTicNetCategories.Repository;
using perfilTicNetCategories.RepositoryHttp;
using perfilTicNetCategories.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPerfilTicNetCategoriesDependencies(
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
