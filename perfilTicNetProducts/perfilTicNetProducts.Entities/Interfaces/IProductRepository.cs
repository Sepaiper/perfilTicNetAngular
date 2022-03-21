using perfilTicNetProducts.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetProducts.Entities.Interfaces
{
    public interface IProductRepository
    {
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void ReadProduct(Product product);
        void DeleteProduct(Product product);
        void GetAll(ListProduct list);
        void GetProductsBCategory(ListProductBCategory list);
    }
}
