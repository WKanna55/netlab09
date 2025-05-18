using Lab08_WKana.Domain.Entities;
using Lab08_WKana.Domain.Interfaces;
using Lab08_WKana.Infrastructure.Context;
using Lab08_WKana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Lab08_WKana.Infrastructure.Repositories;

public class OrderdetailRepository : Repository<Orderdetail>, IOrderdetailRepository
{
    private readonly ApplicationDbContext _context;
    
    public OrderdetailRepository(ApplicationDbContext _context) : base(_context)
    {
        this._context = _context;
    }
    
    public async Task<IEnumerable<Orderdetail>> GetProductDetailsByOrderIdAsync(int orderId)
    {
        var result = await _context.Orderdetails
            .Where(od => od.Orderid == orderId)
            .Include(od => od.Product) // Asegúrate que la relación esté bien mapeada
            .ToListAsync();

        return result;
    }
    
    public async Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId)
    {
        return await _context.Orderdetails
            .Where(od => od.Orderid == orderId)
            .Select(od => od.Quantity)
            .SumAsync();
    }
    
    // Ejercicio 10: Obtener todos los pedidos con nombre del producto y cantidad
    public async Task<List<(int OrderId, string ProductName, int Quantity)>> GetAllOrderDetailsWithProductNameAsync()
    {
        var result = await _context.Orderdetails
            .Include(od => od.Product)
            .Select(od => new 
            {
                od.Orderid,
                ProductName = od.Product.Name,
                od.Quantity
            })
            .ToListAsync();

        return result
            .Select(x => (x.Orderid, x.ProductName, x.Quantity))
            .ToList();
    }
    
    // Ejercicio 11: Obtener productos vendidos a un cliente específico
    public async Task<List<string>> GetProductsSoldToClientAsync(int clientId)
    {
        var result = await _context.Orderdetails
            .Include(od => od.Product)
            .Include(od => od.Order)
            .Where(od => od.Order.Clientid == clientId)
            .Select(od => od.Product.Name)
            .Distinct()
            .ToListAsync();

        return result;
    }
    
    // Ejercicio 12: Obtener todos los clientes que han comprado un producto específico
    public async Task<List<string>> GetClientsWhoBoughtProductAsync(int productId)
    {
        var result = await _context.Orderdetails
            .Include(od => od.Order)
            .ThenInclude(o => o.Client)
            .Where(od => od.Productid == productId)
            .Select(od => od.Order.Client.Name)
            .Distinct()
            .ToListAsync();

        return result;
    }
    
    /*
     * LAB 09 - ejemplo 2
     */
    public IQueryable<Order> QueryOrderWithDetailsAndProducts()
    {
        var ordersWithDetails = _context.Orders
            .Include(order => order.Orderdetails)
            .ThenInclude(orderDetail => orderDetail.Product)
            .AsNoTracking();

        return ordersWithDetails;
    }
    
}