using System;
using System.Collections.Generic;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Contracts.Services
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();
        Role GetById(Guid id);
        Role Add(Role entity);
        Role Update(Role entity);
        Role Delete(Role entity);
    }
}