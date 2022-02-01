using System;
using System.Collections.Generic;

namespace OnlineStore.Core.Contracts.Repositories
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
    }
}