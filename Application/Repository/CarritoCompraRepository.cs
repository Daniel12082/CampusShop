using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class CarritoCompraRepository : GenericRepository<CarritoCompra>, ICarritoCompra
{
    private readonly CampusShopContext _Context;
    public CarritoCompraRepository(CampusShopContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<CarritoCompra>> GetAllAsync()
    {
        return await _Context.Set<CarritoCompra>()
            .Include(p => p.Clientes)
            .Include(p => p.Productos)
            .ToListAsync();
    }
}
