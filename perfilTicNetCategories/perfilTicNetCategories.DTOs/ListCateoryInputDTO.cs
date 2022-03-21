using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.DTOs
{
    public class ListCateoryInputDTO
    {
        public int Page { get; init; }
        public int PerPage { get; init; }
        public int IdCategory { get; init; }
    }
}
