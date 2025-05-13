namespace Lab08_WKana.Domain.Interfaces.Base;

public interface IUnitOfWork : IDisposable
{
    IRepository<TEntity> Repository<TEntity>() where TEntity : class;
    Task<int> Complete();
    
    // inyeccion de repositorios especificos
    IClientRepository Clients { get; }
    IOrderdetailRepository Orderdetails { get; }
    IOrderRepository Orders { get; }
    IProductRepository Products { get; }

}