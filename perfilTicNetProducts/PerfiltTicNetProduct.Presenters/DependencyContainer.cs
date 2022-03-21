using Microsoft.Extensions.DependencyInjection;
using PerfilTicNetProduct.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfiltTicNetProduct.Presenters
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPresenters(
            this IServiceCollection services)
        {
            services.AddScoped<ICreateProductOutputPort, CreateProductPresenter>();
            services.AddScoped<IDeleteProductOutputPort, DeleteProductPresenter>();
            services.AddScoped<IGetAllProductsOutputPort, ListProductPresenter>();
            services.AddScoped<IGetAllProductBCategoryOutputPort, GetAllProductsBCategoryPresenter>();
            services.AddScoped<IReadProductOutputPort, ReadProductPresenter>();
            services.AddScoped<IUpdateProductOutputPort, UpdateProductPresenter>();

            return services;
        }
    }
}
