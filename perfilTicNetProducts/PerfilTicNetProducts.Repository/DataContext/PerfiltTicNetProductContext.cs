using Microsoft.EntityFrameworkCore;
using perfilTicNetProducts.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfilTicNetProducts.Repository.DataContext
{
    public class PerfiltTicNetProductContext : DbContext
    {
        public PerfiltTicNetProductContext(DbContextOptions<PerfiltTicNetProductContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
