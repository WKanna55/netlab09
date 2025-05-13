using Lab08_WKana.Application.Dtos.Order;
using Lab08_WKana.Application.Interfaces;
using Lab08_WKana.Domain.Interfaces.Base;
using Mapster;

namespace Lab08_WKana.Application.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    // Ejercicio 6: Obtener pedidos después de una fecha específica
    public async Task<List<OrderGetDto>> GetOrdersAfterDateAsync(DateTime date)
    {
        var order = await _unitOfWork.Orders.GetOrdersAfterDateAsync(date);
        return order.Adapt<List<OrderGetDto>>();
    }
    
    // Ejercicio 9: Obtener cliente con más pedidos
    public async Task<(int ClientId, int OrderCount)> GetClientWithMostOrdersAsync()
    {
        return await _unitOfWork.Orders.GetClientWithMostOrdersAsync();
    }
    
}