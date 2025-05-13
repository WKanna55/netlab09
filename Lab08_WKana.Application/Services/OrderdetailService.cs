using Lab08_WKana.Application.Dtos.Orderdetail;
using Lab08_WKana.Application.Interfaces;
using Lab08_WKana.Domain.Interfaces.Base;
using Mapster;

namespace Lab08_WKana.Application.Services;

public class OrderdetailService : IOrderdetailService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderdetailService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<OrderdetailWithProductsDto>> GetOrderdetailsWithProducts(int orderdetailID)
    {
        var orderdetails = await _unitOfWork.Orderdetails.GetProductDetailsByOrderIdAsync(orderdetailID);

        return orderdetails.Adapt<IEnumerable<OrderdetailWithProductsDto>>();
    }
    
    public async Task<int> GetTotalProductQuantityByOrderIdAsync(int orderId)
    {
        return await _unitOfWork.Orderdetails.GetTotalProductQuantityByOrderIdAsync(orderId);
    }
    
    // Ejercicio 10: Obtener todos los pedidos con nombre de producto y cantidad
    public async Task<List<(int OrderId, string ProductName, int Quantity)>> GetAllOrderDetailsWithProductNameAsync()
    {
        return await _unitOfWork.Orderdetails.GetAllOrderDetailsWithProductNameAsync();
    }
    
    // Ejercicio 11: Obtener todos los productos vendidos a un cliente específico
    public async Task<List<string>> GetProductsSoldToClientAsync(int clientId)
    {
        return await _unitOfWork.Orderdetails.GetProductsSoldToClientAsync(clientId);
    }
    
    // Ejercicio 12: Obtener todos los clientes que han comprado un producto específico
    public async Task<List<string>> GetClientsWhoBoughtProductAsync(int productId)
    {
        return await _unitOfWork.Orderdetails.GetClientsWhoBoughtProductAsync(productId);
    }
    
}