using OnlineStore.Core.Contracts.Repositories;

namespace OnlineStore.Ado.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IProductRepository ProductRepository => new ProductRepository();

        public ICustomerRepository CustomerRepository => new CustomerRepository();

        public IItemRepository ItemRepository => new ItemRepository();

        public IOrderRepository OrderRepository => new OrderRepository();

        public IRoleRepository RoleRepository => new RoleRepository();

        public IUserRepository UserRepository => new UserRepository();

        public ICategoryRepository CategoryRepository => new CategoryRepository();

        public ISaleRepository SaleRepository => new SaleRepository();

        public IUserRoleRepository UserRoleRepository => new UserRoleRepository();

        public void Complete()
        {

        }
    }
}