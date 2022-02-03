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
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Customer Add(Customer entity)
        {
            return unitOfWork.CustomerRepository.Add(entity);
        }

        public Customer Delete(Customer entity)
        {
            return unitOfWork.CustomerRepository.Delete(entity);
        }

        public IEnumerable<Customer> GetAll()
        {
            return unitOfWork.CustomerRepository.GetAll();
        }

        public Customer GetById(Guid id)
        {
            return unitOfWork.CustomerRepository.GetById(id);
        }

        public Customer Update(Customer entity)
        {
            return unitOfWork.CustomerRepository.Update(entity);
        }
    }
}
