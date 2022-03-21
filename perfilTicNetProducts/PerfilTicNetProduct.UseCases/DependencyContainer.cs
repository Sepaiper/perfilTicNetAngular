using Microsoft.Extensions.DependencyInjection;
using PerfilTicNetProduct.UseCases.CreateProduct;
using PerfilTicNetProduct.UseCases.DeleteProduct;
using PerfilTicNetProduct.UseCases.GetAllProducts;
using PerfilTicNetProduct.UseCases.GetProductBCategory;
using PerfilTicNetProduct.UseCases.ReadProduct;
using PerfilTicNetProduct.UseCases.UpdateProduct;
using PerfilTicNetProduct.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProduct.UseCases
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddUseCasesServices(
            this IServiceCollection services)
        {
            services.AddTransient<ICreateProductInputPort, CreateProductInteractor>();
            services.AddTransient<IGetAllProductsInputPort, GetAllProductsInteractor>();
            services.AddTransient<IGetAllProductBCategoryInputPort, GetAllProductBCategoryInteractor>();
            services.AddTransient<IReadProductInputPort, ReadProductInteractor>();
            services.AddTransient<IUpdateProductInputPort, UpdateProductInteractor>();
            services.AddTransient<IDeleteProductInputPort, DeleteProductInteractor>();

            return services;
        }
    }
}
