using OnlineStore.Core.Contracts.Repositories;
using OnlineStore.Core.Contracts.Services;
using OnlineStore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Category Add(Category entity)
        {
            return unitOfWork.CategoryRepository.Add(entity);
        }

        public Category Delete(Category entity)
        {
            return unitOfWork.CategoryRepository.Delete(entity);
        }

        public IEnumerable<Category> GetAll()
        {
            return unitOfWork.CategoryRepository.GetAll();
        }

        public Category GetById(Guid id)
        {
            return unitOfWork.CategoryRepository.GetById(id);
        }

        public Category Update(Category entity)
        {
            return unitOfWork.CategoryRepository.Update(entity);
        }
    }
}
