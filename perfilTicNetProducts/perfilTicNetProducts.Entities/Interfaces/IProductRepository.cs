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
        Product UpdateProduct(Product product);
        Product ReadProduct(int idProduct);
        void DeleteProduct(int idProduct);
        IEnumerable<Product> GetAll(int page, int perPage);
    }
}
