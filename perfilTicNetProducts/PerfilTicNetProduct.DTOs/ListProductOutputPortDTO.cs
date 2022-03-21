using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProduct.DTOs
{
    public class ListProductOutputPortDTO
    {
        public int Count { get; init; }
        public IEnumerable<SimpleProductDTO> ListProducts { get; init; }
    }
}
