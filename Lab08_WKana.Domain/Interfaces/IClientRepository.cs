using Lab08_WKana.Domain.Entities;
using Lab08_WKana.Domain.Interfaces.Base;

namespace Lab08_WKana.Domain.Interfaces;

public interface IClientRepository: IRepository<Client>
{
    Task<List<Client>> GetClientsByNameStart(string nameStart);
    Task<IQueryable<Client>> GetClientWithOrders(); // Lab09 - ejercicio 01 variante
    Task<List<Client>> GetClientWithOrdersComplete(); // Lab09 - ejercicio 01 variante
    IQueryable<Client> GetClientsQuery(); // Lab09 - ejercicio 03
}