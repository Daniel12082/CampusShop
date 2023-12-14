using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class ClienteRepository : GenericRepository<Cliente>, ICliente
{
    private readonly CampusShopContext _Context;
    public ClienteRepository(CampusShopContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Cliente>> GetAllAsync()
    {
        return await _Context.Set<Cliente>()
            .Include(p => p.ClienteCompras)
            .Include(p => p.CarritoCompras)
            .ToListAsync();
    }
}
