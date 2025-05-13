using Lab08_WKana.Application.Dtos.Order;

namespace Lab08_WKana.Application.Interfaces;

public interface IOrderService
{
    Task<List<OrderGetDto>> GetOrdersAfterDateAsync(DateTime date);
    Task<(int ClientId, int OrderCount)> GetClientWithMostOrdersAsync();
}