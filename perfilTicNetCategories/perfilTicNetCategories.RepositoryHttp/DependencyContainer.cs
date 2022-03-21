using Microsoft.Extensions.DependencyInjection;
using perfilTicNetCategories.Entities.Interfaces;
using perfilTicNetCategories.RepositoryHttp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.RepositoryHttp
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositoriesHttp(
          this IServiceCollection services)
        {
            services.AddScoped<ICategoryRepositoryHttp, CategoryRepositoryHttp>();

            return services;
        }
    }
}
