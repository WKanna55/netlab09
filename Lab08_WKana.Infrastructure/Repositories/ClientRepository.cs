using Lab08_WKana.Domain.Entities;
using Lab08_WKana.Domain.Interfaces;
using Lab08_WKana.Infrastructure.Context;
using Lab08_WKana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Lab08_WKana.Infrastructure.Repositories;

public class ClientRepository : Repository<Client>, IClientRepository
{

    private readonly ApplicationDbContext _context;
    
    public ClientRepository(ApplicationDbContext _context) : base(_context)
    {
        this._context = _context;
    }
    
    /*
     * Ejercicio 01: aplicando list y where como lo sugerido
     * Obetnemos un cliente 
     */
    public async Task<List<Client>> GetClientsByNameStart(string nameStart)
    {
        var clients = await _context.Clients
            .Where(c => c.Name.StartsWith(nameStart))
            .ToListAsync();

        return clients;
    }
    
    /*
     * LAB09 - ejemplo 01
     */
    public Task<IQueryable<Client>> GetClientWithOrders()
    {
        var clientOrders = _context.Clients
            .AsNoTracking();

        return Task.FromResult<IQueryable<Client>>(clientOrders);
    }
    
    /*
     * LAB09 - ejemplo 01, variacion no queryable
     * se puede quitar el Client o Order redundante, pero se tendria que devolver
     * con tuplas u otros datos tipados, tambien genericos pero no es recomendado
     * ya que no se puede acceder sencillamente a sus propiedades 
     */
    public async Task<List<Client>> GetClientWithOrdersComplete()
    {
        var clientOrders = await _context.Clients
            .AsNoTracking()
            .Select(c => new Client
            {
                Name = c.Name,
                Orders = c.Orders.Select(o => new Order
                {
                    Orderid = o.Orderid,
                    Orderdate = o.Orderdate
                }).ToList()
            }).ToListAsync();

        return clientOrders;
    }
    
    
}