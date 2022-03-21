using perfilTicNetCategories.DTOs;
using perfilTicNetCategories.Entities.Interfaces;
using perfilTicNetCategories.Entities.POCOs;
using perfilTicNetCategories.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.UseCases.DeleteCategory
{
    public class DeleteCategoryInteractor : IDeleteCategoryInputPort
    {
        readonly ICategoryRepository Repository;
        readonly ICategoryRepositoryHttp RepositoryHttp;
        readonly IUnitOfWork UnitOfWork;
        readonly IDeleteCategoryOutputPort OutputPort;
        public DeleteCategoryInteractor(ICategoryRepository repository, ICategoryRepositoryHttp repositoryHttp, IUnitOfWork unitOfWork, IDeleteCategoryOutputPort outputPort) =>
            (Repository, RepositoryHttp, UnitOfWork, OutputPort) = (repository, repositoryHttp, unitOfWork, outputPort);
        public async Task Handle(DeleteCategoryInputDTO deleteCategory)
        {
            try
            {
                Category NewCategory = new()
                {
                    Id = deleteCategory.Id,
                    IdCategory = deleteCategory.Id
                };
                Repository.DeleteCategory(NewCategory);
                if (await RepositoryHttp.SearchProduct(NewCategory)) throw new Exception("No es posible eliminar la categoría, porque tiene productos asociados");
                await UnitOfWork.SaveChanges();
                await OutputPort.Handle(new DeleteCategoryOutputDTO
                {
                    Id = NewCategory.Id
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
