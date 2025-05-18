using Lab08_WKana.Domain.Entities;
using Lab08_WKana.Domain.Interfaces;
using Lab08_WKana.Infrastructure.Context;
using Lab08_WKana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Lab08_WKana.Infrastructure.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    private readonly ApplicationDbContext _context;
    
    public OrderRepository(ApplicationDbContext _context) : base(_context)
    {
        this._context = _context;
    }
    
    // Ejercicio 6: Obtener pedidos después de una fecha específica
    public async Task<List<Order>> GetOrdersAfterDateAsync(DateTime date)
    {
        return await _context.Orders
            .Where(o => o.Orderdate > date)
            .ToListAsync();
    }
    
    // Ejercicio 9: Obtener el cliente con más pedidos
    public async Task<(int ClientId, int OrderCount)> GetClientWithMostOrdersAsync()
    {
        var result = await _context.Orders
            .GroupBy(o => o.Clientid)
            .Select(g => new 
            {
                ClientId = g.Key,
                OrderCount = g.Count()
            })
            .OrderByDescending(x => x.OrderCount)
            .FirstOrDefaultAsync();

        if (result == null)
            return (0, 0);

        return (result.ClientId, result.OrderCount);
    }
    
    /*
     * Lab 09 - Ejercicio 02
     */
    public IQueryable<Order> GetOrderWithProducts()
    {
        var query = _context.Orders
            .Include(order => order.Orderdetails)
            .ThenInclude(orderDetail => orderDetail.Product)
            .AsNoTracking();
        return query;
    }
    
}