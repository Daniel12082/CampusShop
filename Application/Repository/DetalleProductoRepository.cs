using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class DetalleProductoRepository : GenericRepository<DetalleProducto>, IDetalleProducto
{
    private readonly CampusShopContext _Context;
    public DetalleProductoRepository(CampusShopContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<DetalleProducto>> GetAllAsync()
    {
        return await _Context.Set<DetalleProducto>()
            .Include(p => p.Productos)
            .ToListAsync();
    }
}
