using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetProducts.Entities.POCOs
{
    public class ListProduct
    {
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int Count { get; set; }
        public IEnumerable<Product> ListProducts { get; set; }
    }
}
