using PerfilTicNetProduct.DTOs;
using PerfilTicNetProduct.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfiltTicNetProduct.Presenters
{
    public class ListProductPresenter : IGetAllProductsOutputPort, IPresenter<ListProductOutputPortDTO>
    {
        public ListProductOutputPortDTO Content { get; private set; }

        public Task Handle(ListProductOutputPortDTO products)
        {
            Content = products;
            return Task.CompletedTask;
        }
    }
}
