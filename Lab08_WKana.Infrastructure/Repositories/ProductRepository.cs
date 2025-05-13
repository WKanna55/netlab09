using Lab08_WKana.Domain.Entities;
using Lab08_WKana.Domain.Interfaces;
using Lab08_WKana.Infrastructure.Context;
using Lab08_WKana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Lab08_WKana.Infrastructure.Repositories;

public class ProductRepository: Repository<Product>, IProductRepository
{
    private readonly ApplicationDbContext _context;
    
    public ProductRepository(ApplicationDbContext _context) : base(_context)
    {
        this._context = _context;
    }
    
    public async Task<List<Product>?> GetProductsByMinPriceAsync(decimal minPrice)
    {
        var products = await _context.Products
            .Where(p => p.Price > minPrice)
            .ToListAsync();

        return products;
    }
    
    public async Task<Product?> GetMostExpensiveProductAsync()
    {
        return await _context.Products
            .OrderByDescending(p => p.Price)
            .FirstOrDefaultAsync();
    }
    
    // Ejercicio 7: Obtener el promedio de precio de los productos
    public async Task<decimal> GetAverageProductPriceAsync()
    {
        var averagePrice = await _context.Products
            .Select(p => p.Price)
            .AverageAsync();

        return averagePrice;
    }
    
    // Ejercicio 8: Obtener productos sin descripción
    public async Task<List<Product>> GetProductsWithoutDescriptionAsync()
    {
        return await _context.Products
            .Where(p => string.IsNullOrEmpty(p.Description))
            .ToListAsync();
    }
    
}