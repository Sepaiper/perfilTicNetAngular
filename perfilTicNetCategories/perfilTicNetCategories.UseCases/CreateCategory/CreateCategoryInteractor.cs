using perfilTicNetCategories.DTOs;
using perfilTicNetCategories.Entities.Interfaces;
using perfilTicNetCategories.Entities.POCOs;
using perfilTicNetCategories.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.UseCases.CreateCategory
{
    public class CreateCategoryInteractor : ICreateCategoryInputPort
    {
        readonly ICategoryRepository Repository;
        readonly ICategoryRepositoryHttp RepositoryHttp;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateCategoryOutputPort OutputPort;

        public CreateCategoryInteractor(ICategoryRepository repository, ICategoryRepositoryHttp repositoryHttp, IUnitOfWork unitOfWork, ICreateCategoryOutputPort outputPort) =>
            (Repository, RepositoryHttp, UnitOfWork, OutputPort) = (repository, repositoryHttp, unitOfWork, outputPort);

        public async Task Handle(CategoryInputDTO category)
        {
            try
            {
                Category NewCategory = new()
                {
                    Name = category.Name,
                    Imagen = category.Images,
                    IdCategory = category.IdCategory
                };
                if (NewCategory.IdCategory > 0)
                {
                    Category NewCategoryFather = new()
                    {
                        Id = category.IdCategory
                    };
                    Repository.ReadCategory(NewCategoryFather);
                    if(NewCategoryFather.Name == null) throw new Exception("La categoría padre no existe");
                    if (await RepositoryHttp.SearchProduct(NewCategory)) throw new Exception("No se puede crear la categoría porque la padre ya tiene productos");
                }
                Repository.CreateCategory(NewCategory);
                await UnitOfWork.SaveChanges();
                await OutputPort.Handle(new CategoryOutputDTO
                {
                    Id = NewCategory.Id,
                    Name = NewCategory.Name,
                    Images = NewCategory.Imagen,
                    IdCategory = category.IdCategory
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
