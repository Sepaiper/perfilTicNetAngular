using Microsoft.EntityFrameworkCore;
using perfilTicNetAdmin.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.Repository.DataContext
{
    public class PerfilTicNetAdminContext : DbContext
    {
        public PerfilTicNetAdminContext(DbContextOptions<PerfilTicNetAdminContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }
    }
}
