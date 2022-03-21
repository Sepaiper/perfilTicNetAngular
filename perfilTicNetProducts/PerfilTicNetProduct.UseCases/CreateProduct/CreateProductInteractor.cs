using PerfilTicNetProduct.DTOs;
using PerfilTicNetProduct.UseCasesPorts;
using perfilTicNetProducts.Entities.Interfaces;
using perfilTicNetProducts.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProduct.UseCases.CreateProduct
{
    public class CreateProductInteractor : ICreateProductInputPort
    {
        readonly IProductRepository Repository;
        readonly IProductRepositoryHttp RepositoryHttp;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateProductOutputPort OutputPort;

        public CreateProductInteractor(IProductRepository repository, IProductRepositoryHttp repositoryHttp, IUnitOfWork unitOfWork, ICreateProductOutputPort outputPort) =>
            (Repository, RepositoryHttp, UnitOfWork, OutputPort) = (repository, repositoryHttp, unitOfWork, outputPort);

        public async Task Handle(ProductInputDTO product)
        {
            try
            {
                Product NewProduct = new()
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Weight = product.Weight,
                    Category = product.Category,
                    ImageOne = product.ImageOne,
                    ImageTwo = product.ImageTwo,
                    ImageThree = product.ImageThree
                };
                if(!await RepositoryHttp.SearchCategory(NewProduct)) throw new Exception("La categoría no existe");
                Repository.CreateProduct(NewProduct);
                await UnitOfWork.SaveChanges();
                await OutputPort.Handle(new ProductOutPutDTO
                {
                    Id = NewProduct.Id,
                    Name = NewProduct.Name,
                    Description = NewProduct.Description,
                    Price = NewProduct.Price,
                    Weight = NewProduct.Weight,
                    Category = NewProduct.Category,
                    ImageOne = NewProduct.ImageOne,
                    ImageTwo = NewProduct.ImageTwo,
                    ImageThree = NewProduct.ImageThree
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
