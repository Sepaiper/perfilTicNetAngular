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
    [Route("api/[controller]/{Page}/{PerPage}")]
    [ApiController]
    public class GetAllProductController
    {
        readonly IGetAllProductsInputPort InputPort;
        readonly IGetAllProductsOutputPort OutputPort;

        public GetAllProductController(IGetAllProductsInputPort inputPort, IGetAllProductsOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet]
        public async Task<ListProductOutputPortDTO> CreateProduct(int Page, int PerPage)
        {
            try
            {
                await InputPort.Handle(new ListProductInputDTO
                {
                    Page = Page,
                    PerPage = PerPage
                });
                return ((IPresenter<ListProductOutputPortDTO>)OutputPort).Content;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
