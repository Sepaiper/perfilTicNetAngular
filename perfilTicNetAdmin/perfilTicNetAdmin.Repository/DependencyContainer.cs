using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using perfilTicNetAdmin.Entities.Interfaces;
using perfilTicNetAdmin.Repository.DataContext;
using perfilTicNetAdmin.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.Repository
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PerfilTicNetAdminContext>(options => options.UseSqlServer(configuration.GetConnectionString("PerfilTicNetAdmins")));
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
