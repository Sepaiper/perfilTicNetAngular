using PerfilTicNetProduct.DTOs;
using PerfilTicNetProduct.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfiltTicNetProduct.Presenters
{
    public class UpdateProductPresenter : IUpdateProductOutputPort, IPresenter<ProductOutPutDTO>
    {
        public ProductOutPutDTO Content { get; private set; }

        public Task Handle(ProductOutPutDTO product)
        {
            Content = product;
            return Task.CompletedTask;
        }
    }
}
