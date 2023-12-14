using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class ClienteCompraRepository : GenericRepository<ClienteCompra>, IClienteCompra
{
    private readonly CampusShopContext _Context;
    public ClienteCompraRepository(CampusShopContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<ClienteCompra>> GetAllAsync()
    {
        return await _Context.Set<ClienteCompra>()
            .Include(p => p.Clientes)
            .Include(p => p.Compras)
            .Include(p => p.Pagos)
            .ToListAsync();
    }
}
