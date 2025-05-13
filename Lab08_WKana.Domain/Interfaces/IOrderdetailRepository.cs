using Lab08_WKana.Domain.Entities;
using Lab08_WKana.Domain.Interfaces.Base;

namespace Lab08_WKana.Domain.Interfaces;

public interface IOrderdetailRepository : IRepository<Orderdetail>
{
    Task<IEnumerable<Orderdetail>> GetProductDetailsByOrderIdAsync(int orderId);
    Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId);
    Task<List<(int OrderId, string ProductName, int Quantity)>> GetAllOrderDetailsWithProductNameAsync();
    Task<List<string>> GetProductsSoldToClientAsync(int clientId);
    Task<List<string>> GetClientsWhoBoughtProductAsync(int productId);
}