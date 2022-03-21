using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Entities.POCOs
{
    public class ListCategory
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int IdCategory { get; set; }
        public int Count { get; set; }
        public IEnumerable<Category> ListCategories { get; set; }
        public IEnumerable<ListCategoryChildren> ListCategoriesChildren { get; set; }
    }
}
