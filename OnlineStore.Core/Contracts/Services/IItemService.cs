using System;
using System.Collections.Generic;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Contracts.Services
{
    public interface IItemService
    {
        IEnumerable<Item> GetAll();
        Item GetById(Guid id);
        Item Add(Item entity);
        Item Update(Item entity);
        Item Delete(Item entity);
    }
}