using Microsoft.AspNetCore.Mvc;
using perfilTicNetCategories.DTOs;
using perfilTicNetCategories.Presenter;
using perfilTicNetCategories.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Controllers
{
    [Route("api/[controller]/{id}")]
    [ApiController]
    public class ReadCategoryController
    {
        readonly IReadCategoryInputPort InputPort;
        readonly IReadCategoryOutputPort OutputPort;

        public ReadCategoryController(IReadCategoryInputPort inputPort, IReadCategoryOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet]
        public async Task<CategoryOutputDTO> ReadCategory(int id)
        {
            try
            {
                ReadCategoryInputDTO Category = new()
                {
                    Id = id
                };
                await InputPort.Handle(Category);
                return ((IPresenter<CategoryOutputDTO>)OutputPort).Content;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
