using perfilTicNetAdmin.DTOs;
using perfilTicNetAdmin.Entities.Interfaces;
using perfilTicNetAdmin.Entities.POCOs;
using perfilTicNetAdmin.UseCasesPorts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace perfilTicNetAdmin.UseCases.CreateAdmin
{
    public class CreateAdminInteractor : ICreateAdminInputPort
    {
        readonly IAdminRepository Repository;
        readonly IUnitOfWork UnitOfWork;
        readonly ICreateOutputPort OutputPort;
        public CreateAdminInteractor(IAdminRepository repository, IUnitOfWork unitOfWork, ICreateOutputPort outputPort) =>
            (Repository, UnitOfWork, OutputPort) = (repository, unitOfWork, outputPort);
        public async Task Handle(AdminInputDTO admin)
        {
            try
            {
                Admin NewAdmin = new()
                {
                    Name = admin.Name,
                    Email = admin.Email,
                    Password = admin.Password,
                };
                Repository.CreateAdmin(NewAdmin);
                await UnitOfWork.SaveChanges();
                await OutputPort.Handle(new AdminOutputDTO
                {
                    Id = NewAdmin.Id
                });
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
