using OnlineStore.Core.Contracts.Repositories;
using OnlineStore.Core.Contracts.Services;
using OnlineStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserRoleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public UserRole Add(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public UserRole Delete(UserRole entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRole> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserRole GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public UserRole Update(UserRole entity)
        {
            throw new NotImplementedException();
        }
    }
}
