using perfilTicNetAdmin.Entities.Interfaces;
using perfilTicNetAdmin.Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly PerfilTicNetAdminContext Context;
        public UnitOfWork(PerfilTicNetAdminContext context) => Context = context;
        public Task<int> SaveChanges()
        {
            return Context.SaveChangesAsync();
        }
    }
}
