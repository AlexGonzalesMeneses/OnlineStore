using System;
using System.Collections.Generic;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Contracts.Services
{
    public interface IUserRoleService
    {
        IEnumerable<UserRole> GetAll();
        UserRole GetById(Guid id);
        UserRole Add(UserRole entity);
        UserRole Update(UserRole entity);
        UserRole Delete(UserRole entity);
    }
}