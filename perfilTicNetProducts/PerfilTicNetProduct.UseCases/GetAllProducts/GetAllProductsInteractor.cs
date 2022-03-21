using PerfilTicNetProduct.DTOs;
using PerfilTicNetProduct.UseCasesPorts;
using perfilTicNetProducts.Entities.Interfaces;
using perfilTicNetProducts.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProduct.UseCases.GetAllProducts
{
    public class GetAllProductsInteractor : IGetAllProductsInputPort
    {
        readonly IProductRepository Repository;
        readonly IGetAllProductsOutputPort OutputPort;

        public GetAllProductsInteractor(IProductRepository repository, IGetAllProductsOutputPort outputPort) => (Repository, OutputPort) = (repository, outputPort);

        public Task Handle(ListProductInputDTO list)
        {
            try
            {
                ListProduct newList = new()
                {
                    PerPage = list.PerPage,
                    Page = list.Page
                };
                Repository.GetAll(newList);
                ListProductOutputPortDTO products = new()
                {
                    Count = newList.Count,
                    ListProducts = newList.ListProducts.Select(p =>
                    new SimpleProductDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Weight = p.Weight,
                        Category = p.Category
                    })
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
