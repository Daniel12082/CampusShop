using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class ProductoRepository : GenericRepository<Producto>, IProducto
{
    private readonly CampusShopContext _Context;
    public ProductoRepository(CampusShopContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Producto>> GetAllAsync()
    {
        return await _Context.Set<Producto>()
            .Include(p => p.CategoriaProductos)
            .Include(p => p.CarritoCompras)
            .Include(p => p.Compras)
            .Include(p => p.DetalleProductos)
            .ToListAsync();
    }
}
