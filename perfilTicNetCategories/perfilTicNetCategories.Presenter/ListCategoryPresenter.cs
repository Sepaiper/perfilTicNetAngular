using perfilTicNetCategories.DTOs;
using perfilTicNetCategories.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Presenter
{
    public class ListCategoryPresenter : IGetAllCategoriesOutputPort, IPresenter<ListCategoryOutputDTO>
    {
        public ListCategoryOutputDTO Content { get; private set; }

        public Task Handle(ListCategoryOutputDTO categories)
        {
            Content = categories;
            return Task.CompletedTask;
        }
    }
}
