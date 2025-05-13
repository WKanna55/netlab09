using Lab08_WKana.Application.Dtos.Orderdetail;

namespace Lab08_WKana.Application.Interfaces;

public interface IOrderdetailService
{
    Task<IEnumerable<OrderdetailWithProductsDto>> GetOrderdetailsWithProducts(int orderdetailID);
    Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId);
    Task<List<(int OrderId, string ProductName, int Quantity)>> GetAllOrderDetailsWithProductNameAsync();
    Task<List<string>> GetProductsSoldToClientAsync(int clientId);
    Task<List<string>> GetClientsWhoBoughtProductAsync(int productId);
}