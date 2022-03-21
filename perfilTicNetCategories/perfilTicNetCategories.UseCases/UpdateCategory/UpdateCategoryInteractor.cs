using perfilTicNetCategories.DTOs;
using perfilTicNetCategories.Entities.Interfaces;
using perfilTicNetCategories.Entities.POCOs;
using perfilTicNetCategories.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.UseCases.UpdateCategory
{
    public class UpdateCategoryInteractor : IUpdateCategoryInputPort
    {
        readonly ICategoryRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IUpdateCategoryOutputPort OutputPort;

        public UpdateCategoryInteractor(ICategoryRepository repository, IUnitOfWork unitOfWork, IUpdateCategoryOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = (repository, unitOfWork, outputPort);

        public async Task Handle(UpdateCategoryInputDTO category)
        {
            try
            {
                Category NewCategory = new()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Imagen = category.Images,
                };
                Repository.UpdateCategory(NewCategory);
                await UnitOfWork.SaveChanges();
                await OutputPort.Handle(new CategoryOutputDTO
                {
                    Id = NewCategory.Id,
                    Name = NewCategory.Name,
                    Images = NewCategory.Imagen,
                    IdCategory = NewCategory.IdCategory,
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
