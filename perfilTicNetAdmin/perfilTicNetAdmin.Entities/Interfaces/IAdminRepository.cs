using perfilTicNetAdmin.Entities.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.Entities.Interfaces
{
    public interface IAdminRepository
    {
        void CreateAdmin(Admin admin);
        void ReadAdmin(Admin admin);
    }
}
