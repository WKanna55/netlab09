using Lab08_WKana.Application.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_WKana.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    // ejecicio 01: clientes por nombre especifico
    [HttpGet("ej01/{name}")]
    public async Task<IActionResult> GetClientsByName([FromRoute] string name)
    {
        var clients = await _clientService.GetCLientsByName(name);

        if (clients == null) return NotFound();
        
        return Ok(clients);
    }
    
    /*
     * LAB 09 - ejemplo 1
     * 
     */
    [HttpGet("LAB09/ej1/orders")]
    public async Task<IActionResult> GetCLientsWithOrders()
    {

        var clientes = await _clientService.GetCLientWithOrders();

        return Ok(clientes);
    }
    
    /*
     * LAB 09 - ejercicio 03
     *
     */
    [HttpGet("LAB09/ej3/clientWithTotalProducts")]
    public async Task<IActionResult> clientWithTotalProducts()
    {

        var clientes = await _clientService.GetClientWithTotalProducts();

        return Ok(clientes);
    }
    
}