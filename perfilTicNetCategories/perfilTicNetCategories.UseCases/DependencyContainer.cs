using Microsoft.Extensions.DependencyInjection;
using perfilTicNetCategories.UseCases.CreateCategory;
using perfilTicNetCategories.UseCases.DeleteCategory;
using perfilTicNetCategories.UseCases.GetAllCategories;
using perfilTicNetCategories.UseCases.ReadCategory;
using perfilTicNetCategories.UseCases.UpdateCategory;
using perfilTicNetCategories.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(
           this IServiceCollection services)
        {
            services.AddTransient<ICreateCategoryInputPort, CreateCategoryInteractor>();
            services.AddTransient<IGetAllCategoriesInputPort, GetAllCategoriesInteractor>();
            services.AddTransient<IReadCategoryInputPort, ReadCategoryInteractor>();
            services.AddTransient<IUpdateCategoryInputPort, UpdateCategoryInteractor>();
            services.AddTransient<IDeleteCategoryInputPort, DeleteCategoryInteractor>();

            return services;
        }
    }
}
