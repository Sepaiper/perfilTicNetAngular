using Microsoft.AspNetCore.Mvc;
using PerfilTicNetProduct.DTOs;
using PerfilTicNetProduct.UseCasesPorts;
using PerfiltTicNetProduct.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProduct.Controllers
{
    [Route("api/[controller]/{id}")]
    [ApiController]
    public class DeleteProductController
    {
        readonly IDeleteProductInputPort InputPort;
        readonly IDeleteProductOutputPort OutputPort;

        public DeleteProductController(IDeleteProductInputPort inputPort, IDeleteProductOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpDelete]
        public async Task<DeleteProductOutputPortDTO> DeleteProduct(int id)
        {
            try
            {
                DeleteProductInputDTO Product = new()
                {
                    Id = id
                };
                await InputPort.Handle(Product);
                return ((IPresenter<DeleteProductOutputPortDTO>)OutputPort).Content;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
