using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using perfilTicNetCategories.Entities.Interfaces;
using perfilTicNetCategories.Repository.DataContext;
using perfilTicNetCategories.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Repository
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(
           this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<PerfilTicNetCategoriesContext>(options => options.UseSqlServer(configuration.GetConnectionString("PerfilTicNetCategories")));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
