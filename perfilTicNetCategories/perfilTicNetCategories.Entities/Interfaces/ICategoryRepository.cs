using perfilTicNetCategories.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Entities.Interfaces
{
    public interface ICategoryRepository
    {
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        Task<bool> SearchProducts(Category category);
        void ReadCategory(Category category);
        void DeleteCategory(Category category);
        void GetAll(ListCategory list);
        void GetAllWPagination(ListCategory list);
        void GetChildren(ListCategory list);
    }
}
