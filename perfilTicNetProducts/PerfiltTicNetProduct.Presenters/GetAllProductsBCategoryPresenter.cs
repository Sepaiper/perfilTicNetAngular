using PerfilTicNetProduct.DTOs;
using PerfilTicNetProduct.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfiltTicNetProduct.Presenters
{
    public class GetAllProductsBCategoryPresenter : IGetAllProductBCategoryOutputPort, IPresenter<ListProductsBCategoryOutpuDTO>
    {
        public ListProductsBCategoryOutpuDTO Content { get; private set; }

        public Task Handle(ListProductsBCategoryOutpuDTO listProduct)
        {
            Content = listProduct;
            return Task.CompletedTask;
        }
    }
}
