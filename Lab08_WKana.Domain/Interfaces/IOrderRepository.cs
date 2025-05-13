using Lab08_WKana.Domain.Entities;
using Lab08_WKana.Domain.Interfaces.Base;

namespace Lab08_WKana.Domain.Interfaces;

public interface IOrderRepository: IRepository<Order>
{
    Task<List<Order>> GetOrdersAfterDateAsync(DateTime date);
    Task<(int ClientId, int OrderCount)> GetClientWithMostOrdersAsync();
}