using Microsoft.AspNetCore.Mvc;
using perfilTicNetAdmin.DTOs;
using perfilTicNetAdmin.Presenters;
using perfilTicNetAdmin.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateAdminController
    {
        readonly ICreateAdminInputPort InputPort;
        readonly ICreateOutputPort OutputPort;

        public CreateAdminController(ICreateAdminInputPort inputPort, ICreateOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPost]
        public async Task<AdminOutputDTO> CreateProduct(AdminInputDTO product)
        {
            try
            {
                await InputPort.Handle(product);
                return ((IPresenter<AdminOutputDTO>)OutputPort).Content;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
