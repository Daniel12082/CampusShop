using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class CompraRepository : GenericRepository<Compra>, ICompra
{
    private readonly CampusShopContext _Context;
    public CompraRepository(CampusShopContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Compra>> GetAllAsync()
    {
        return await _Context.Set<Compra>()
            .Include(p => p.Productos)
            .Include(p => p.ClienteCompras)
            .ToListAsync();
    }
}
