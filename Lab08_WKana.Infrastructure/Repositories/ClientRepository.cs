using Lab08_WKana.Domain.Entities;
using Lab08_WKana.Domain.Interfaces;
using Lab08_WKana.Infrastructure.Context;
using Lab08_WKana.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Lab08_WKana.Infrastructure.Repositories;

public class ClientRepository : Repository<Client>, IClientRepository
{

    private readonly ApplicationDbContext _context;
    
    public ClientRepository(ApplicationDbContext _context) : base(_context)
    {
        this._context = _context;
    }
    
    /*
     * Ejercicio 01: aplicando list y where como lo sugerido
     * Obetnemos un cliente 
     */
    public async Task<List<Client>> GetClientsByNameStart(string nameStart)
    {
        var clients = await _context.Clients
            .Where(c => c.Name.StartsWith(nameStart))
            .ToListAsync();

        return clients;
    }
    
    
    
}