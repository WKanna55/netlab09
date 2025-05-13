using Lab08_WKana.Application.Dtos.Client;

namespace Lab08_WKana.Application.Interfaces;

public interface IClientService
{
    Task<List<ClientGetDto>?> GetCLientsByName(string name);
}