using Microsoft.Extensions.DependencyInjection;
using perfilTicNetAdmin.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(
           this IServiceCollection services)
        {
            services.AddScoped<ICreateOutputPort, CreateAdminPresenter>();
            services.AddScoped<IReadAdminOutputPort, ReadAdminPresenter>();

            return services;
        }
    }
}
