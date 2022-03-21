using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Entities.POCOs
{
    public class ListCategoryChildren : Category
    {
        public IEnumerable<Category> ListCategoriesChildren { get; set; }

    }
}
