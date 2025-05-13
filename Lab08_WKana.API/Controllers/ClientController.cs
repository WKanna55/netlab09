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
    
}