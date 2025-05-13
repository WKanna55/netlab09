using Lab08_WKana.Application.Dtos.Product;

namespace Lab08_WKana.Application.Interfaces;

public interface IProductService
{
    Task<List<ProductGetDto>> GetProductsByMinPriceAsync(decimal minPrice);
    Task<ProductGetDto?> GetMostExpensiveProductAsync();
    Task<decimal> GetAverageProductPriceAsync();
    Task<List<ProductGetDto>> GetProductsWithoutDescriptionAsync();
}