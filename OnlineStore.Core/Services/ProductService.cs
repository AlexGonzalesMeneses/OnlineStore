using OnlineStore.Core.Contracts.Repositories;
using OnlineStore.Core.Contracts.Services;
using OnlineStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Product Add(Product entity)
        {
            return unitOfWork.ProductRepository.Add(entity);
        }

        public Product Delete(Product entity)
        {
            return unitOfWork.ProductRepository.Delete(entity);
        }

        public IEnumerable<Product> GetAll()
        {
            return unitOfWork.ProductRepository.GetAll();
        }

        public Product GetById(Guid id)
        {
            return unitOfWork.ProductRepository.GetById(id);
        }

        public IEnumerable<Product> Search(Expression<Func<Product, bool>> predicate)
        {
            var products = unitOfWork.ProductRepository.GetAll();
            
            return products.Where(predicate.Compile());
        }

        public Product Update(Product entity)
        {
            return unitOfWork.ProductRepository.Update(entity);
        }
    }
}
