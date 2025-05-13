using Lab08_WKana.Application.Dtos.Product;
using Lab08_WKana.Application.Interfaces;
using Lab08_WKana.Domain.Interfaces.Base;
using Mapster;

namespace Lab08_WKana.Application.Services;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<ProductGetDto>> GetProductsByMinPriceAsync(decimal minPrice)
    {
        var products =  await _unitOfWork.Products.GetProductsByMinPriceAsync(minPrice);
        
        return products.Adapt<List<ProductGetDto>>();
    }
    
    // Ejercicio 5: Obtener el producto más caro
    public async Task<ProductGetDto?> GetMostExpensiveProductAsync()
    {
        var product = await _unitOfWork.Products.GetMostExpensiveProductAsync();
        return product.Adapt<ProductGetDto>();
    }
    
    // Ejercicio 7: Obtener el promedio de precio de los productos
    public async Task<decimal> GetAverageProductPriceAsync()
    {
        return await _unitOfWork.Products.GetAverageProductPriceAsync();
    }
    
    // Ejercicio 8: Obtener productos sin descripción
    public async Task<List<ProductGetDto>> GetProductsWithoutDescriptionAsync()
    {
        var products = await _unitOfWork.Products.GetProductsWithoutDescriptionAsync();
        return products.Adapt<List<ProductGetDto>>();
    }
    
}