using perfilTicNetCategories.DTOs;
using perfilTicNetCategories.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Presenter
{
    public class DeleteCategoryPresenter : IDeleteCategoryOutputPort, IPresenter<DeleteCategoryOutputDTO>
    {
        public DeleteCategoryOutputDTO Content { get; private set; }

        public Task Handle(DeleteCategoryOutputDTO Category)
        {
            Content = Category;
            return Task.CompletedTask;
        }
    }
}
