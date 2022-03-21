using PerfilTicNetProduct.DTOs;
using PerfilTicNetProduct.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfiltTicNetProduct.Presenters
{
    public class DeleteProductPresenter : IDeleteProductOutputPort, IPresenter<DeleteProductOutputPortDTO>
    {
        public DeleteProductOutputPortDTO Content { get; private set; }

        public Task Handle(DeleteProductOutputPortDTO product)
        {
            Content = product;
            return Task.CompletedTask;
        }
    }
}
