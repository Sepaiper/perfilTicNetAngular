using Microsoft.Extensions.DependencyInjection;
using perfilTicNetProducts.Entities.Interfaces;
using perfilTicNetProducts.RepositoryHttp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetProducts.RepositoryHttp
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositoriesHttp(
            this IServiceCollection services)
        {
            services.AddScoped<IProductRepositoryHttp, ProductRepositoryHttp>();

            return services;
        }

    }
}
