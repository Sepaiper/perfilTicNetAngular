using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using perfilTicNetProducts.Entities.Interfaces;
using PerfilTicNetProducts.Repository.DataContext;
using PerfilTicNetProducts.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProducts.Repository
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            services.AddDbContext<PerfiltTicNetProductContext>(options => options.UseSqlServer(configuration.GetConnectionString("PerfilTicNetProducts")));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
