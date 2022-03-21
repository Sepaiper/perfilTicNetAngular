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
    public class UpdateProductController
    {
        readonly IUpdateProductInputPort InputPort;
        readonly IUpdateProductOutputPort OutputPort;

        public UpdateProductController(IUpdateProductInputPort inputPort, IUpdateProductOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPut]
        public async Task<ProductOutPutDTO> UpdateProduct(UpdateProductInputDTO product)
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
