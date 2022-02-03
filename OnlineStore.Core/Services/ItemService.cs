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
    public class ItemService : IItemService
    {
        private readonly IUnitOfWork unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Item Add(Item entity)
        {
            return unitOfWork.ItemRepository.Add(entity);
        }

        public Item Delete(Item entity)
        {
            return unitOfWork.ItemRepository.Delete(entity);
        }

        public IEnumerable<Item> GetAll()
        {
            return unitOfWork.ItemRepository.GetAll();
        }

        public Item GetById(Guid id)
        {
            return unitOfWork.ItemRepository.GetById(id);
        }

        public Item Update(Item entity)
        {
            return unitOfWork.ItemRepository.Update(entity);
        }
    }
}
