using System;
using System.Collections.Generic;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Contracts.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        User Add(User entity);
        User Update(User entity);
        User Delete(User entity);
    }
}