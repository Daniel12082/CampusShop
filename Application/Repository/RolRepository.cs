using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;
public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly CampusShopContext _Context;
    public RolRepository(CampusShopContext context) : base(context)
    {
        _Context = context;
    }
}
