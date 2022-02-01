using System;
using System.Collections.Generic;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Contracts.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();
        Order GetById(Guid id);
        Order Add(Order entity);
        Order Update(Order entity);
        Order Delete(Order entity);
    }
}