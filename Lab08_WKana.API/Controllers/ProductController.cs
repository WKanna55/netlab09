using Lab08_WKana.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lab08_WKana.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    // ejercicio 02: productos mayores a un valor especifico
    [HttpGet("ej02/min-price/{price}")]
    public async Task<ActionResult> GetProductsByMinPrice(decimal price)
    {
        var products = await _productService.GetProductsByMinPriceAsync(price);

        if (products == null) 
            return NotFound();
        
        return Ok(products);
    }
    
    // Ejercicio 05: Endpoint para obtener el producto más caro
    [HttpGet("ej05/most-expensive")]
    public async Task<ActionResult> GetMostExpensiveProduct()
    {
        var product = await _productService.GetMostExpensiveProductAsync();
        if (product == null)
        {
            return NotFound("No se encontró el producto más caro.");
        }
        return Ok(product);
    }
    
    // Ejercicio 7: Endpoint para obtener el promedio de precio de los productos
    [HttpGet("ej07/average-price")]
    public async Task<ActionResult> GetAverageProductPrice()
    {
        var averagePrice = await _productService.GetAverageProductPriceAsync();
        return Ok(new { AveragePrice = averagePrice });
    }
    
    // Ejercicio 8: Endpoint para productos sin descripción
    [HttpGet("ej08/no-description")]
    public async Task<ActionResult> GetProductsWithoutDescription()
    {
        var products = await _productService.GetProductsWithoutDescriptionAsync();
        return Ok(products);
    }
    
}