using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.Repository.DataContext
{
    class PerfilTicNetAdminContextFactory : IDesignTimeDbContextFactory<PerfilTicNetAdminContext>
    {
        public PerfilTicNetAdminContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<PerfilTicNetAdminContext>();
            OptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=PerfilTicNetAdmins");
            return new PerfilTicNetAdminContext(OptionsBuilder.Options);
        }
    }
}
