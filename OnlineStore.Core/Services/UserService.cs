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
    public class UserService  : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public User Add(User entity)
        {
            return unitOfWork.UserRepository.Add(entity);
        }

        public User Delete(User entity)
        {
            return unitOfWork.UserRepository.Delete(entity);
        }

        public IEnumerable<User> GetAll()
        {
            return unitOfWork.UserRepository.GetAll();
        }

        public User GetById(Guid id)
        {
            return unitOfWork.UserRepository.GetById(id);
        }

        public User Update(User entity)
        {
            return unitOfWork.UserRepository.Update(entity);
        }
    }
}
