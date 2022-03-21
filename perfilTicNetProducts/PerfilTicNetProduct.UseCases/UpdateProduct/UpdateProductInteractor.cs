using PerfilTicNetProduct.DTOs;
using PerfilTicNetProduct.UseCasesPorts;
using perfilTicNetProducts.Entities.Interfaces;
using perfilTicNetProducts.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProduct.UseCases.UpdateProduct
{
    public class UpdateProductInteractor : IUpdateProductInputPort
    {
        readonly IProductRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpdateProductOutputPort OutputPort;

        public UpdateProductInteractor(IProductRepository repository, IUnitOfWork unitOfWork, IUpdateProductOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = (repository, unitOfWork, outputPort);

        public async Task Handle(ProductOutPutDTO product)
        {
            try
            {
                Product NewProduct = new()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Weight = product.Weight,
                    Category = product.Category,
                    ImageOne = product.ImageOne,
                    ImageTwo = product.ImageTwo,
                    ImageThree = product.ImageThree
                };
                Repository.UpdateProduct(NewProduct);
                await UnitOfWork.SaveChanges();
                await OutputPort.Handle(new UpdateProductInputDTO
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
