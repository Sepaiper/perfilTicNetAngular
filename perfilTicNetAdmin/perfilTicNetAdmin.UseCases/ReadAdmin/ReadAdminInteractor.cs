using perfilTicNetAdmin.DTOs;
using perfilTicNetAdmin.Entities.Interfaces;
using perfilTicNetAdmin.Entities.POCOs;
using perfilTicNetAdmin.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.UseCases.ReadAdmin
{
    public class ReadAdminInteractor : IReadAdminInputPort
    {
        readonly IAdminRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly IReadAdminOutputPort OutputPort;
        public ReadAdminInteractor(IAdminRepository repository, IUnitOfWork unitOfWork, IReadAdminOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = (repository, unitOfWork, outputPort);
        public Task Handle(ReadAdminInputDTO admin)
        {
            try
            {
                Admin NewAdmin = new()
                {
                    Email = admin.Email,
                    Password = admin.Password
                };
                Repository.ReadAdmin(NewAdmin);
                return OutputPort.Handle(new ReadAdminOutputDTO
                {
                    Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
