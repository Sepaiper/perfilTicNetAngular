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
    public class ReadProductController
    {
        readonly IReadProductInputPort InputPort;
        readonly IReadProductOutputPort OutputPort;

        public ReadProductController(IReadProductInputPort inputPort, IReadProductOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet]
        public async Task<ProductOutPutDTO> ReadProduct(int id)
        {
            try
            {
                ReadProductInputDTO Product = new()
                {
                    Id = id
                };
                await InputPort.Handle(Product);
                return ((IPresenter<ProductOutPutDTO>)OutputPort).Content;
            } catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
