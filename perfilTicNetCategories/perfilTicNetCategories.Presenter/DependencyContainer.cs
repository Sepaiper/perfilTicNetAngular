using Microsoft.Extensions.DependencyInjection;
using perfilTicNetCategories.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Presenter
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(
            this IServiceCollection services)
        {
            services.AddScoped<ICreateCategoryOutputPort, CreateCategoryPresenter>();
            services.AddScoped<IDeleteCategoryOutputPort, DeleteCategoryPresenter>();
            services.AddScoped<IGetAllCategoriesOutputPort, ListCategoryPresenter>();
            services.AddScoped<IReadCategoryOutputPort, ReadCategoryPresenter>();
            services.AddScoped<IUpdateCategoryOutputPort, UpdateCategoryPresenter>();

            return services;
        }
    }
}
