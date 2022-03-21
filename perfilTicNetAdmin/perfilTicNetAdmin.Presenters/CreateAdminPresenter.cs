using perfilTicNetAdmin.DTOs;
using perfilTicNetAdmin.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.Presenters
{
    public class CreateAdminPresenter : ICreateOutputPort, IPresenter<AdminOutputDTO>
    {
        public AdminOutputDTO Content { get; private set; }

        public Task Handle(AdminOutputDTO admin)
        {
            Content = admin;
            return Task.CompletedTask;
        }
    }
}
