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
    [Route("api/[controller]/{Page}/{PerPage}/{IdCategory}")]
    [ApiController]
    public class GetAllCategoryController
    {
        readonly IGetAllCategoriesInputPort InputPort;
        readonly IGetAllCategoriesOutputPort OutputPort;

        public GetAllCategoryController(IGetAllCategoriesInputPort inputPort, IGetAllCategoriesOutputPort outputPort) => (InputPort, OutputPort) = (inputPort, outputPort);

        [HttpGet]
        public async Task<ListCategoryOutputDTO> CreateCategory(int Page, int PerPage, int IdCategory)
        {
            try
            {
                await InputPort.Handle(new ListCateoryInputDTO
                {
                    Page = Page,
                    PerPage = PerPage,
                    IdCategory = IdCategory
                });
                return ((IPresenter<ListCategoryOutputDTO>)OutputPort).Content;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
