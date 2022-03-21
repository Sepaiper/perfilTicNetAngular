using Microsoft.EntityFrameworkCore;
using perfilTicNetCategories.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetCategories.Repository.DataContext
{
    public class PerfilTicNetCategoriesContext : DbContext
    {
        public PerfilTicNetCategoriesContext(DbContextOptions<PerfilTicNetCategoriesContext> options): base(options) { }
        public DbSet<Category> Categories { get; set; }
    }
}
