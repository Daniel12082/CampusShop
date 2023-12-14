using Domain.Entities;
using Domain.Interfaces;
using Persistencia.Data;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;
public class PagoRepository : GenericRepository<Pago>, IPago
{
    private readonly CampusShopContext _Context;
    public PagoRepository(CampusShopContext context) : base(context)
    {
        _Context = context;
    }
    public override async Task<IEnumerable<Pago>> GetAllAsync()
    {
        return await _Context.Set<Pago>()
            .Include(p => p.ClienteCompras)
            .ToListAsync();
    }
}
