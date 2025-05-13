using System.Collections;
using Lab08_WKana.Domain.Interfaces;
using Lab08_WKana.Domain.Interfaces.Base;
using Lab08_WKana.Infrastructure.Context;

namespace Lab08_WKana.Infrastructure.Repositories.Base;

public class UnitOfWork : IUnitOfWork
{
    private Hashtable? _repositories;
    private readonly ApplicationDbContext _context;
    
    // inyeccion repositorios especificos
    public IClientRepository Clients { get; }
    public IOrderdetailRepository Orderdetails { get; }
    public IOrderRepository Orders { get; }
    public IProductRepository Products { get; }
    
    
    public UnitOfWork(ApplicationDbContext context, IClientRepository clientRepository,
        IOrderdetailRepository orderdetailRepository, IOrderRepository orderRepository,
        IProductRepository productRepository)
    {
        _context = context;
        _repositories = new Hashtable();
        // inyeccion repositorio especificos

        Clients = clientRepository;
        Orderdetails = orderdetailRepository;
        Orders = orderRepository;
        Products = productRepository;

    }

    public Task<int> Complete()
    {
        return _context.SaveChangesAsync();
    }

    /*
     * Funcion para usar un repositorio generico con cualquier entidad
     */
    public IRepository<TEntity> Repository<TEntity>() where TEntity : class
    {
        var type = typeof(TEntity);

        if (_repositories.ContainsKey(type))
        {
            return (IRepository<TEntity>)_repositories[type];
        }

        var repositoryType = typeof(Repository<>);
        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

        if (repositoryInstance != null)
        {
            _repositories.Add(type, repositoryInstance);
            return (IRepository<TEntity>)repositoryInstance;
        }
        
        throw new Exception($"No se pudo crear el repositorio para este tipo {type}");
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}