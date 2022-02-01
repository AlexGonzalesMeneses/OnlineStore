using System;
using System.Collections.Generic;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Contracts.Services
{
    public interface ISaleService
    {
        IEnumerable<Sale> GetAll();
        Sale GetById(Guid id);
        Sale Add(Sale entity);
        Sale Update(Sale entity);
        Sale Delete(Sale entity);
    }
}