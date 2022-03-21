using perfilTicNetCategories.DTOs;
using perfilTicNetCategories.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Presenter
{
    public class CreateCategoryPresenter : ICreateCategoryOutputPort, IPresenter<CategoryOutputDTO>
    {
        public CategoryOutputDTO Content { get; private set; }

        public Task Handle(CategoryOutputDTO category)
        {
            Content = category;
            return Task.CompletedTask;
        }
    }
}
