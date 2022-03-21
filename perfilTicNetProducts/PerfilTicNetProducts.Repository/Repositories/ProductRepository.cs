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
            try
            {
                Context.Add(product);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public void ReadProduct(Product product)
        {
            try
            {
                Product productTemporal = Context.Products.Find(product.Id);
                if (productTemporal != null)
                {
                    product.Name = productTemporal.Name;
                    product.Description = productTemporal.Description;
                    product.Weight = productTemporal.Weight;
                    product.Price = productTemporal.Price;
                    product.Category = productTemporal.Category;
                    product.ImageOne = productTemporal.ImageOne;
                    product.ImageTwo = productTemporal.ImageTwo;
                    product.ImageThree = productTemporal.ImageThree;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void UpdateProduct(Product product)
        {
            try
            {
                var productTemporal = Context.Products.Find(product.Id);
                if (productTemporal != null)
                {
                    productTemporal.Name = product.Name;
                    productTemporal.Description = product.Description;
                    productTemporal.Weight = product.Weight;
                    productTemporal.Category = product.Category;
                    productTemporal.ImageOne = product.ImageOne;
                    productTemporal.ImageTwo = product.ImageTwo;
                    productTemporal.ImageThree = product.ImageThree;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteProduct(Product product)
        {
            try
            {
                var productRemove = Context.Products.Find(product.Id);
                if (productRemove != null)
                {
                    Context.Products.Remove(productRemove);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void GetAll(ListProduct listProduct)
        {
            try
            {
                listProduct.Count = Context.Products.ToList().Count;
                listProduct.ListProducts =  Context.Products.OrderBy(d => d.Name).Skip((listProduct.PerPage * listProduct.Page) - listProduct.PerPage).Take(listProduct.PerPage).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void GetProductsBCategory(ListProductBCategory list)
        {
            try
            {
                list.Count = Context.Products.Where(p => p.Category == list.Id).Count();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
