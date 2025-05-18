using Lab08_WKana.Application.Dtos.Client;

namespace Lab08_WKana.Application.Interfaces;

public interface IClientService
{
    Task<List<ClientGetDto>?> GetCLientsByName(string name);
    Task<List<ClientOrderDto>> GetCLientWithOrders(); // Lab09 - ejercicio 01
    Task<List<ClientTotalProductsDto>> GetClientWithTotalProducts(); // Lab09 - ejercicio 03
}