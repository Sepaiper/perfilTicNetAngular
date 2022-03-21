using perfilTicNetAdmin.Entities.Interfaces;
using perfilTicNetAdmin.Entities.POCOs;
using perfilTicNetAdmin.Repository.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.Repository.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        readonly PerfilTicNetAdminContext Context;
        public AdminRepository(PerfilTicNetAdminContext context) => Context = context;

        public void CreateAdmin(Admin admin)
        {
            try
            {
                Context.Add(admin);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void ReadAdmin(Admin admin)
        {
            try
            {
                Admin AdminTemporal = Context.Admins.Where(a => a.Email == admin.Email && a.Password == admin.Password).FirstOrDefault();
                if (AdminTemporal != null)
                {
                    admin.Name = AdminTemporal.Name;
                    admin.Id = AdminTemporal.Id;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
