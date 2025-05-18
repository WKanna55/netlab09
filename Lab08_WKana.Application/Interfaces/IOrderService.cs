using Lab08_WKana.Application.Dtos.Order;
using Lab08_WKana.Application.Dtos.Orderdetail;

namespace Lab08_WKana.Application.Interfaces;

public interface IOrderService
{
    Task<List<OrderGetDto>> GetOrdersAfterDateAsync(DateTime date);
    Task<(int ClientId, int OrderCount)> GetClientWithMostOrdersAsync();
    Task<List<OrderDetailsDto>> GetOrderWithDetails(); // LAB09 - ejercicio 02
}