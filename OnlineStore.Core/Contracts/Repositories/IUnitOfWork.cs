namespace OnlineStore.Core.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IItemRepository ItemRepository { get; }
        IOrderRepository OrderRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ISaleRepository SaleRepository { get; }
        IUserRoleRepository UserRoleRepository { get; }

        void Complete();
    }
}