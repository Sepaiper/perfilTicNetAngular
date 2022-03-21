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
    public class CreateCategoryController
    {
        readonly ICreateCategoryInputPort InputPort;
        readonly ICreateCategoryOutputPort OutputPort;
        public CreateCategoryController(ICreateCategoryInputPort inputPort, ICreateCategoryOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpPost]
        public async Task<CategoryOutputDTO> CreateProduct(CategoryInputDTO category)
        {
            try
            {
                await InputPort.Handle(category);
                return ((IPresenter<CategoryOutputDTO>)OutputPort).Content;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
