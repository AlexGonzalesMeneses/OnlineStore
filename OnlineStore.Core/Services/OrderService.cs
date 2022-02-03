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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Order Add(Order entity)
        {
            return unitOfWork.OrderRepository.Add(entity);
        }

        public Order Delete(Order entity)
        {
            return unitOfWork.OrderRepository.Delete(entity);
        }

        public IEnumerable<Order> GetAll()
        {
            return unitOfWork.OrderRepository.GetAll();
        }

        public Order GetById(Guid id)
        {
            return unitOfWork.OrderRepository.GetById(id);
        }

        public Order Update(Order entity)
        {
            return unitOfWork.OrderRepository.Update(entity);
        }
    }
}
