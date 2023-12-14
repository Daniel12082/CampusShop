using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class CategoriaProductoRepository : GenericRepository<CategoriaProducto>, ICategoriaProducto
{
    private readonly CampusShopContext _Context;
    public CategoriaProductoRepository(CampusShopContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<CategoriaProducto>> GetAllAsync()
    {
        return await _Context.Set<CategoriaProducto>()
            .Include(p => p.Productos)
            .ToListAsync();
    }
}
