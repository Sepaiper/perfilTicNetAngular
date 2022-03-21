using perfilTicNetCategories.Entities.Interfaces;
using perfilTicNetCategories.Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly PerfilTicNetCategoriesContext Context;
        public UnitOfWork(PerfilTicNetCategoriesContext context) => Context = context;
        public Task<int> SaveChanges()
        {
            return Context.SaveChangesAsync();
        }
    }
}
