using PerfilTicNetProduct.DTOs;
using PerfilTicNetProduct.UseCasesPorts;
using perfilTicNetProducts.Entities.Interfaces;
using perfilTicNetProducts.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProduct.UseCases.DeleteProduct
{
    public class DeleteProductInteractor : IDeleteProductInputPort
    {
        readonly IProductRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IDeleteProductOutputPort OutputPort;

        public DeleteProductInteractor(IProductRepository repository, IUnitOfWork unitOfWork, IDeleteProductOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = (repository, unitOfWork, outputPort);

        public async Task Handle(DeleteProductInputDTO deleteProduct)
        {
            try
            {
                Product NewProduct = new()
                {
                    Id = deleteProduct.Id
                };
                Repository.DeleteProduct(NewProduct);
                await UnitOfWork.SaveChanges();
                await OutputPort.Handle(new DeleteProductOutputPortDTO
                {
                    Id = NewProduct.Id
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
