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
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateCategoryController
    {
        readonly IUpdateCategoryInputPort InputPort;
        readonly IUpdateCategoryOutputPort OutputPort;

        public UpdateCategoryController(IUpdateCategoryInputPort inputPort, IUpdateCategoryOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPut]
        public async Task<CategoryOutputDTO> UpdateCategory(UpdateCategoryInputDTO Category)
        {
            try
            {
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
