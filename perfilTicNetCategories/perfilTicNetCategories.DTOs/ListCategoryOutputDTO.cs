using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.DTOs
{
    public class ListCategoryOutputDTO
    {
        public int Count { get; init; }
        public IEnumerable<ListCategoryChildrenOuputDTO> ListCategories { get; init; }
    }
}
