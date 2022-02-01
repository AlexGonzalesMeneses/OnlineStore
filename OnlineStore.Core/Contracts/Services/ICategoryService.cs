using System;
using System.Collections.Generic;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Contracts.Services
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        Category GetById(Guid id);
        Category Add(Category entity);
        Category Update(Category entity);
        Category Delete(Category entity);
    }
}