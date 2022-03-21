using perfilTicNetCategories.Entities.Interfaces;
using perfilTicNetCategories.Entities.POCOs;
using perfilTicNetCategories.Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Repository.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        readonly PerfilTicNetCategoriesContext Context;
        public CategoryRepository(PerfilTicNetCategoriesContext context) => Context = context;

        public void CreateCategory(Category category)
        {
            try
            {
                Context.Add(category);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteCategory(Category category)
        {
            try
            {
                var categoryRemove = Context.Categories.Find(category.Id);
                if (categoryRemove != null)
                {
                    var categoriesChildren = Context.Categories.Where(sc => sc.IdCategory == categoryRemove.Id).FirstOrDefault();
                    if (categoriesChildren != null) throw new Exception("No es posible eliminar la categoría, porque tienes categorías hijas");
                    Context.Categories.Remove(categoryRemove);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void GetAll(ListCategory list)
        {
            try
            {
                list.Count = Context.Categories.Where(sc => sc.IdCategory == list.IdCategory).Count();
                list.ListCategories = Context.Categories.Where(sc => sc.IdCategory == list.IdCategory).OrderBy(d => d.Name).Skip((list.PerPage * list.Page) - list.PerPage).Take(list.PerPage).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void GetAllWPagination(ListCategory list)
        {
            try
            {
                list.Count = Context.Categories.Where(sc => sc.IdCategory == list.IdCategory).Count();
                list.ListCategories = Context.Categories.Where(sc => sc.IdCategory == list.IdCategory).OrderBy(d => d.Name).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void GetChildren(ListCategory list)
        {
            try
            {
                list.ListCategories = Context.Categories.Where(sc => sc.IdCategory == list.IdCategory).OrderBy(d => d.Name).ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void ReadCategory(Category category)
        {
            try
            {
                Category categoryTemporal = Context.Categories.Find(category.Id);
                if (categoryTemporal != null)
                {
                    category.Name = categoryTemporal.Name;
                    category.Imagen = categoryTemporal.Imagen;
                    category.IdCategory = categoryTemporal.IdCategory;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public async Task<bool> SearchProducts(Category category)
        {
            return true;
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                Category categoryTemporal = Context.Categories.Find(category.Id);
                if (categoryTemporal != null)
                {
                    categoryTemporal.Name = category.Name;
                    categoryTemporal.Imagen = category.Imagen;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
