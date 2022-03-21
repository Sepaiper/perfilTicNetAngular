using perfilTicNetAdmin.DTOs;
using perfilTicNetAdmin.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.Presenters
{
    public class ReadAdminPresenter : IReadAdminOutputPort, IPresenter<ReadAdminOutputDTO>
    {
        public ReadAdminOutputDTO Content { get; private set; }

        public Task Handle(ReadAdminOutputDTO admin)
        {
            Content = admin;
            return Task.CompletedTask;
        }
    }
}
