using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Repository.DataContext
{
    class PerfilTicNetCategoriesContextFactory : IDesignTimeDbContextFactory<PerfilTicNetCategoriesContext>
    {
        public PerfilTicNetCategoriesContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<PerfilTicNetCategoriesContext>();
            OptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=PerfilTicNetCategories");
            return new PerfilTicNetCategoriesContext(OptionsBuilder.Options);
        }
    }
}
