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
    [Route("api/[controller]")]
    [ApiController]
    public class CreateProductController
    {
        readonly ICreateProductInputPort InputPort;
        readonly ICreateProductOutputPort OutputPort;

        public CreateProductController(ICreateProductInputPort inputPort, ICreateProductOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPost]
        public async Task<ProductOutPutDTO> CreateProduct(ProductInputDTO product)
        {
            try
            {
                await InputPort.Handle(product);
                return ((IPresenter<ProductOutPutDTO>)OutputPort).Content;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
