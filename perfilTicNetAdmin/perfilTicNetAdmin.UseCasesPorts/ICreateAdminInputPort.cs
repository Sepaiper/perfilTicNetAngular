using perfilTicNetAdmin.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.UseCasesPorts
{
    public interface ICreateAdminInputPort
    {
        Task Handle(AdminInputDTO admin);
    }
}
