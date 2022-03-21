using perfilTicNetCategories.DTOs;
using perfilTicNetCategories.Entities.Interfaces;
using perfilTicNetCategories.Entities.POCOs;
using perfilTicNetCategories.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.UseCases.GetAllCategories
{
    public class GetAllCategoriesInteractor : IGetAllCategoriesInputPort
    {
        readonly ICategoryRepository Repository;
        readonly IGetAllCategoriesOutputPort OutputPort;
        public GetAllCategoriesInteractor(ICategoryRepository repository, IGetAllCategoriesOutputPort outputPort) => (Repository, OutputPort) = (repository, outputPort);
        public Task Handle(ListCateoryInputDTO list)
        {
            try
            {
                ListCategory NewList = new()
                {
                    PerPage = list.PerPage,
                    Page = list.Page,
                    IdCategory = list.IdCategory
                };
                Repository.GetAll(NewList);
                List<ListCategoryChildren> NewListCategoriesChildren = new();
                foreach (Category LC in NewList.ListCategories)
                {
                    List<Category> NewListCategories = new();
                    NewListCategoriesChildren.Add(new ListCategoryChildren
                    {
                        Id = LC.Id,
                        Name = LC.Name,
                        IdCategory = LC.IdCategory,
                        Imagen = LC.Imagen,
                        ListCategoriesChildren = SearchChildren(LC.Id, NewListCategories)
                    });
                }
                IEnumerable<ListCategoryChildren> ReturnList = NewListCategoriesChildren;
                NewList.ListCategoriesChildren = ReturnList;

                List<ListCategoryChildrenOuputDTO> NewListCategoriesOutput = new();
                if (NewList.ListCategoriesChildren != null)
                {
                    foreach (ListCategoryChildren item in NewList.ListCategoriesChildren)
                    {
                        List<ListCategoryChildrenOuputDTO> NewListCategoriesOutputTemporal = new();
                        NewListCategoriesOutput.Add(new ListCategoryChildrenOuputDTO
                        {
                            Id = item.Id,
                            Name = item.Name,
                            IdCategory = item.IdCategory,
                            Images = item.Imagen,
                            ListCategories = ConvertCategoryOutPut(NewListCategoriesOutputTemporal, item)
                        });
                    }
                }
                IEnumerable<ListCategoryChildrenOuputDTO> returnList = NewListCategoriesOutput;
                ListCategoryOutputDTO Categories = new()
                {
                    Count = NewList.Count,
                    ListCategories = returnList
                };
                OutputPort.Handle(Categories);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private IEnumerable<Category> SearchChildren(int IdCategory, List<Category> NewListCategories)
        {
            ListCategory NewList = new()
            {
                IdCategory = IdCategory
            };
            Repository.GetAllWPagination(NewList);
            foreach (Category LC in NewList.ListCategories)
            {
                List<Category> NewListCategoriesTemporal = new();
                NewListCategories.Add(new ListCategoryChildren
                {
                    Id = LC.Id,
                    Name = LC.Name,
                    IdCategory = LC.IdCategory,
                    Imagen = LC.Imagen,
                    ListCategoriesChildren = SearchChildren(LC.Id, NewListCategoriesTemporal)
                });
            }
            return NewListCategories;
        }

        private IEnumerable<ListCategoryChildrenOuputDTO> ConvertCategoryOutPut(List<ListCategoryChildrenOuputDTO> NewListCategoriesOutput, ListCategoryChildren NewListChildren)
        {
            foreach (ListCategoryChildren item in NewListChildren.ListCategoriesChildren)
            {
                List<ListCategoryChildrenOuputDTO> NewListCategoriesOutputTemporal = new();
                NewListCategoriesOutput.Add(new ListCategoryChildrenOuputDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                    IdCategory = item.IdCategory,
                    Images = item.Imagen,
                    ListCategories = ConvertCategoryOutPut(NewListCategoriesOutputTemporal, item)
                });
            }
            return NewListCategoriesOutput;
        }
    }
}
