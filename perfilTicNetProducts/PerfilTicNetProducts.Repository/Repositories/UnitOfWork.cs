using perfilTicNetProducts.Entities.Interfaces;
using PerfilTicNetProducts.Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProducts.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly PerfiltTicNetProductContext Context;

        public UnitOfWork(PerfiltTicNetProductContext context) => Context = context;

        public Task<int> SaveChanges()
        {
            return Context.SaveChangesAsync();
        }
    }
}
