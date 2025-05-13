using Lab08_WKana.Domain.Entities;
using Lab08_WKana.Domain.Interfaces.Base;

namespace Lab08_WKana.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<List<Product>?> GetProductsByMinPriceAsync(decimal minPrice);
    Task<Product?> GetMostExpensiveProductAsync();
    Task<decimal> GetAverageProductPriceAsync();
    Task<List<Product>> GetProductsWithoutDescriptionAsync();
}