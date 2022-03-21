using perfilTicNetCategories.DTOs;
using perfilTicNetCategories.Entities.Interfaces;
using perfilTicNetCategories.Entities.POCOs;
using perfilTicNetCategories.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.UseCases.ReadCategory
{
    public class ReadCategoryInteractor : IReadCategoryInputPort
    {
        readonly ICategoryRepository Repository;
        readonly IReadCategoryOutputPort OutputPort;
        public ReadCategoryInteractor(ICategoryRepository repository, IReadCategoryOutputPort outputPort) => (Repository, OutputPort) = (repository, outputPort);
        public Task Handle(ReadCategoryInputDTO readCategoryDto)
        {
            try
            {
                Category NewCategory = new()
                {
                    Id = readCategoryDto.Id
                };
                Repository.ReadCategory(NewCategory);
                return OutputPort.Handle(new CategoryOutputDTO
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
