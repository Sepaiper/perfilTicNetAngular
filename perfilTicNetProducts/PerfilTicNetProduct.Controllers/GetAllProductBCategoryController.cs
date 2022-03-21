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
    [Route("api/[controller]/{IdCategory}")]
    [ApiController]
    public class GetAllProductBCategoryController
    {
        readonly IGetAllProductBCategoryInputPort InputPort;
        readonly IGetAllProductBCategoryOutputPort OutputPort;
        public GetAllProductBCategoryController(IGetAllProductBCategoryInputPort inputPort, IGetAllProductBCategoryOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet]
        public async Task<ListProductsBCategoryOutpuDTO> ListProductBCategory(int IdCategory)
        {
            try
            {
                await InputPort.Handle(new ListProductsBCategoryInputDTO
                {
                   Category = IdCategory
                });
                return ((IPresenter<ListProductsBCategoryOutpuDTO>)OutputPort).Content;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
