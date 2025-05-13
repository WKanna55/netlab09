using Lab08_WKana.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_WKana.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderdetailController : ControllerBase
{
    private readonly IOrderdetailService _orderdetailService;
    
    public OrderdetailController(IOrderdetailService orderdetailService)
    {
        _orderdetailService = orderdetailService;
    }

    // ejercicio 03: obtener lista de ordenes con sus productos
    [HttpGet("ej03/{id}")]
    public async Task<IActionResult> GetOrderDetailsWithProducts([FromRoute]int id)
    {
        var orderdetails = await _orderdetailService.GetOrderdetailsWithProducts(id);
        return Ok(orderdetails);
    }
    
    // Ejercicio 4: Obtener la Cantidad Total de Productos por Orden
    [HttpGet("ej04/total-quantity/{orderId}")]
    public async Task<ActionResult<int>> GetTotalQuantityByOrderId(int orderId)
    {
        var totalQuantity = await _orderdetailService.GetTotalProductQuantityByOrderIdAsync(orderId);
        return Ok(totalQuantity);
    }
    
    // Ejercicio 10: Endpoint para obtener todos los pedidos con nombre del producto y cantidad
    [HttpGet("ej10/orders-products")]
    public async Task<ActionResult> GetAllOrderDetailsWithProductName()
    {
        var result = await _orderdetailService.GetAllOrderDetailsWithProductNameAsync();
        return Ok(result.Select(r => new {
            OrderId = r.OrderId,
            ProductName = r.ProductName,
            Quantity = r.Quantity
        }));
    }
    
    // Ejercicio 11: Endpoint para obtener productos vendidos a un cliente específico
    [HttpGet("ej11/client/{clientId}/products")]
    public async Task<ActionResult> GetProductsSoldToClient(int clientId)
    {
        var result = await _orderdetailService.GetProductsSoldToClientAsync(clientId);
        
        if (result == null || !result.Any())
        {
            return NotFound($"No products found for client with ID {clientId}.");
        }

        return Ok(result);
    }
    
    
    // Ejercicio 12: Endpoint para obtener clientes que han comprado un producto específico
    [HttpGet("ej12/product/{productId}/clients")]
    public async Task<ActionResult> GetClientsWhoBoughtProduct(int productId)
    {
        var result = await _orderdetailService.GetClientsWhoBoughtProductAsync(productId);

        if (result == null || !result.Any())
        {
            return NotFound($"No clients found who bought the product with ID {productId}.");
        }

        return Ok(result);
    }
    
}