using System;
using System.Collections.Generic;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Contracts.Services
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(Guid id);
        Customer Add(Customer entity);
        Customer Update(Customer entity);
        Customer Delete(Customer entity);
    }
}