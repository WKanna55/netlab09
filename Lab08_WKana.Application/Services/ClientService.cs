using Lab08_WKana.Application.Dtos.Client;
using Lab08_WKana.Application.Dtos.Order;
using Lab08_WKana.Application.Interfaces;
using Lab08_WKana.Domain.Interfaces;
using Lab08_WKana.Domain.Interfaces.Base;
using Mapster;
using Microsoft.EntityFrameworkCore;

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
    
    
    /*
     * LAB09 - ejemplo 01
     * 
     */
    public async Task<List<ClientOrderDto>> GetCLientWithOrders()
    {
        /*
        // metodo querys en el repositorio
        var query = await _unitOfWork.Clients.GetClientWithOrders();

        //nulo
        //var clientes = query.Adapt<List<ClientOrderDto>>().ToList();


        var clientes = await query.Select(c => new ClientOrderDto()
        {
            ClientName = c.Name,
            Orders = c.Orders.Select(o => new OrderDto
            {
                OrderId = o.Orderid,
                OrderDate = o.Orderdate
            }).ToList()
        }).ToListAsync();
        
        return clientes;
        */
        
        
        // metodo sin querys en el repositorio
        // OJO se puede agregar biblioteca mapster y configurarlo para simplificar el codigo
        var clientes = await _unitOfWork.Clients.GetClientWithOrdersComplete();

        var clientesDto = new List<ClientOrderDto>();
        // Recorrer cada cliente y mapear manualmente
        foreach (var client in clientes)
        {
            // Crear el DTO del cliente
            var clientDto = new ClientOrderDto
            {
                ClientName = client.Name,
                Orders = new List<OrderDto>()
            };

            // Recorrer las órdenes y mapearlas también
            foreach (var order in client.Orders)
            {
                clientDto.Orders.Add(new OrderDto
                {
                    OrderId = order.Orderid,
                    OrderDate = order.Orderdate
                });
            }

            // Agregar el cliente ya mapeado a la lista final
            clientesDto.Add(clientDto);
        }

        return clientesDto;


    }
    
    /*
     * LAB09 - ejercicio 03
     */
    public async Task<List<ClientTotalProductsDto>> GetClientWithTotalProducts()
    {
        var query = _unitOfWork.Clients.GetClientsQuery();
        var clients = await query.Select(c => new ClientTotalProductsDto
        {
            ClientName = c.Name,
            TotalProducts = c.Orders.Sum(o => o.Orderdetails.Sum(d => d.Quantity))
        }).ToListAsync();
        return clients;
    }
    
    
    
}