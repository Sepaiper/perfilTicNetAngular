using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.DTOs
{
    public class ListCategoryChildrenOuputDTO : CategoryOutputDTO
    {
        public IEnumerable<ListCategoryChildrenOuputDTO> ListCategories { get; init; }
    }
}
