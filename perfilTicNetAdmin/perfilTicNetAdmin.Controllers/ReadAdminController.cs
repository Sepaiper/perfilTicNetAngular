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
    public class ReadAdminController
    {
        readonly IReadAdminInputPort InputPort;
        readonly IReadAdminOutputPort OutputPort;

        public ReadAdminController(IReadAdminInputPort inputPort, IReadAdminOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPost]
        public async Task<ReadAdminOutputDTO> ReadAdmin(ReadAdminInputDTO admin)
        {
            try
            {
                await InputPort.Handle(admin);
                return ((IPresenter<ReadAdminOutputDTO>)OutputPort).Content;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
