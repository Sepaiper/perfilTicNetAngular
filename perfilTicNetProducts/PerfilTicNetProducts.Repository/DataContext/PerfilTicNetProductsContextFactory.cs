using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProducts.Repository.DataContext
{
    class PerfilTicNetProductsContextFactory : IDesignTimeDbContextFactory<PerfiltTicNetProductContext>
    {
        public PerfiltTicNetProductContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<PerfiltTicNetProductContext>();
            OptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;database=PerfilTicNetProducts");
            return new PerfiltTicNetProductContext(OptionsBuilder.Options);
        }
    }
}
