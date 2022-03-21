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
    public class DeleteCategoryController
    {
        readonly IDeleteCategoryInputPort InputPort;
        readonly IDeleteCategoryOutputPort OutputPort;
        public DeleteCategoryController(IDeleteCategoryInputPort inputPort, IDeleteCategoryOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpDelete]
        public async Task<DeleteCategoryOutputDTO> DeleteCategory(int id)
        {
            try
            {
                DeleteCategoryInputDTO Category = new()
                {
                    Id = id
                };
                await InputPort.Handle(Category);
                return ((IPresenter<DeleteCategoryOutputDTO>)OutputPort).Content;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
