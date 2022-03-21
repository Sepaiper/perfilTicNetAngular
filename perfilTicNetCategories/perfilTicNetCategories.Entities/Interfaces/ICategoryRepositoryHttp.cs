using perfilTicNetCategories.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Entities.Interfaces
{
    public interface ICategoryRepositoryHttp
    {
        Task<bool> SearchProduct(Category category);
    }
}
