using PerfilTicNetProduct.DTOs;
using PerfilTicNetProduct.UseCasesPorts;
using perfilTicNetProducts.Entities.Interfaces;
using perfilTicNetProducts.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProduct.UseCases.ReadProduct
{
    public class ReadProductInteractor : IReadProductInputPort
    {
        readonly IProductRepository Repository;
        readonly IReadProductOutputPort OutputPort;

        public ReadProductInteractor(IProductRepository repository, IReadProductOutputPort outputPort) => (Repository, OutputPort) = (repository, outputPort);

        public Task Handle(ReadProductInputDTO readProductDto)
        {
            try
            {
                Product NewProduct = new()
                {
                    Id = readProductDto.Id
                };
                Repository.ReadProduct(NewProduct);
                return OutputPort.Handle(new ProductOutPutDTO
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
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
