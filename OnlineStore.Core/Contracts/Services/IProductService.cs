using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OnlineStore.Core.Models;

namespace OnlineStore.Core.Contracts.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        Product Add(Product entity);
        Product Update(Product entity);
        Product Delete(Product entity);
        IEnumerable<Product> Search(Expression<Func<Product, bool>> predicate);
    }
}