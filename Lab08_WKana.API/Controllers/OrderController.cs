using Lab08_WKana.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_WKana.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }
    
    // ejercicio 06: Endpoint para obtener pedidos después de una fecha
    [HttpGet("ej06/after-date")]
    public async Task<ActionResult> GetOrdersAfterDate([FromQuery] DateTime date)
    {
        var orders = await _orderService.GetOrdersAfterDateAsync(date);
        return Ok(orders);
    }
    
    // Ejercicio 9: Endpoint para cliente con más pedidos
    [HttpGet("ej09/top-client")]
    public async Task<ActionResult<object>> GetClientWithMostOrders()
    {
        var result = await _orderService.GetClientWithMostOrdersAsync();
        return Ok(new { ClientId = result.ClientId, OrderCount = result.OrderCount });
    }
    
    /*
     * Lab09 - ejercicio 02
     */
    [HttpGet("Lab09/ej2/orderWithDetails")]
    public async Task<ActionResult> GetOrderWithDetails()
    {
        var orderDetails = await _orderService.GetOrderWithDetails();
        return Ok(orderDetails);
    }
}