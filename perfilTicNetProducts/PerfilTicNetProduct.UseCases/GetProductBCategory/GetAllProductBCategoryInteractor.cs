using PerfilTicNetProduct.DTOs;
using PerfilTicNetProduct.UseCasesPorts;
using perfilTicNetProducts.Entities.Interfaces;
using perfilTicNetProducts.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProduct.UseCases.GetProductBCategory
{
    public class GetAllProductBCategoryInteractor : IGetAllProductBCategoryInputPort
    {
        readonly IProductRepository Repository;
        readonly IGetAllProductBCategoryOutputPort OutputPort;
        public GetAllProductBCategoryInteractor(IProductRepository repository, IGetAllProductBCategoryOutputPort outputPort) => (Repository, OutputPort) = (repository, outputPort);

        public Task Handle(ListProductsBCategoryInputDTO product)
        {
            try
            {
                ListProductBCategory newListProductBCategory = new()
                {
                    Id = product.Category
                };
                Repository.GetProductsBCategory(newListProductBCategory);
                ListProductsBCategoryOutpuDTO products = new()
                {
                    Count = newListProductBCategory.Count,
                };
                OutputPort.Handle(products);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
