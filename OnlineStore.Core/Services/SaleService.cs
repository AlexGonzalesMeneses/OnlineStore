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
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork unitOfWork;

        public SaleService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Sale Add(Sale entity)
        {
            return unitOfWork.SaleRepository.Add(entity);
        }

        public Sale Delete(Sale entity)
        {
            return unitOfWork.SaleRepository.Delete(entity);
        }

        public IEnumerable<Sale> GetAll()
        {
            return unitOfWork.SaleRepository.GetAll();
        }

        public Sale GetById(Guid id)
        {
            return unitOfWork.SaleRepository.GetById(id);
        }

        public Sale Update(Sale entity)
        {
            return unitOfWork.SaleRepository.Update(entity);
        }
    }
}
