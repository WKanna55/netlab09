using Lab08_WKana.Application.Dtos.Client;
using Lab08_WKana.Application.Interfaces;
using Lab08_WKana.Domain.Interfaces;
using Lab08_WKana.Domain.Interfaces.Base;
using Mapster;

namespace Lab08_WKana.Application.Services;

public class ClientService : IClientService
{
    private readonly IUnitOfWork _unitOfWork;

    public ClientService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ClientGetDto>?> GetCLientsByName(string name)
    {
        var clients = await _unitOfWork.Clients.GetClientsByNameStart(name);
        
        return clients.Adapt<List<ClientGetDto>>();
        
    }
    
}