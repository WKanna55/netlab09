using Lab08_WKana.Domain.Entities;
using Lab08_WKana.Domain.Interfaces.Base;

namespace Lab08_WKana.Domain.Interfaces;

public interface IClientRepository: IRepository<Client>
{
    Task<List<Client>> GetClientsByNameStart(string nameStart);
    Task<IQueryable<Client>> GetClientWithOrders();
    Task<List<Client>> GetClientWithOrdersComplete();
}