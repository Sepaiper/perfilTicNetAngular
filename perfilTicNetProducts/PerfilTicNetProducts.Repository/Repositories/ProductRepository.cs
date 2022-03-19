using perfilTicNetProducts.Entities.Interfaces;
using perfilTicNetProducts.Entities.POCOs;
using PerfilTicNetProducts.Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProducts.Repository.Repositories
{
    public class ProductRepository : IProductRepository
    {

        readonly PerfiltTicNetProductContext Context;
        public ProductRepository(PerfiltTicNetProductContext context) => Context = context;

        public void CreateProduct(Product product)
        {
            Context.Add(product);
        }


        public Product ReadProduct(int idProduct)
        {
            return Context.Products.Find(idProduct);
        }

        public Product UpdateProduct(Product product)
        {
            var productTemporal = Context.Products.Find(product.Id);
            productTemporal.Name = product.Name;
            productTemporal.Description = product.Description;
            productTemporal.Weight = product.Weight;
            productTemporal.Category = product.Category;
            productTemporal.ImageOne = product.ImageOne;
            productTemporal.ImageTwo = product.ImageTwo;
            productTemporal.ImageThree = product.ImageThree;
            return productTemporal;
        }

        public void DeleteProduct(int idProduct)
        {
            var product = Context.Products.Find(idProduct);
            Context.Products.Remove(product);
        }

        public IEnumerable<Product> GetAll(int page, int perPage)
        {
            //TODO: Pendiente devolver el count
            return Context.Products.OrderBy(d => d.Name).Skip((perPage * page) - perPage).Take(perPage).ToList();
        }
    }
}
