
using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistencia;
using Persistencia.Data;

namespace Application.Repository;
public class UsuariosRolesRepository : IUsuarioRoles
{
    private readonly CampusShopContext _Context;

    public UsuariosRolesRepository(CampusShopContext context)
    {
        _Context = context;
    }

    //implementacion de los metodos de la Interfaces
    public void Add(UserRol entity)
    {
        _Context.Set<UserRol>().Add(entity);
    }

    public void AddRange(IEnumerable<UserRol> entities)
    {
        _Context.Set<UserRol>().AddRange(entities);
    }

    public IEnumerable<UserRol> Find(Expression<Func<UserRol, bool>> expression)
    {
        return _Context.Set<UserRol>().Where(expression);
    }

    public async Task<IEnumerable<UserRol>> GetAllAsync()
    {
        return await _Context.Set<UserRol>().ToListAsync();
    }

    public async Task<(int totalRegistros, IEnumerable<UserRol> registros)> GetAllAsync(int pageIndex, int pageSize, string search)
    {
        var totalRegistros = await _Context.Set<UserRol>().CountAsync();
        var registros = await _Context.Set<UserRol>()
                                                        .Skip((pageIndex - 1) * pageSize)
                                                        .Take(pageSize)
                                                        .ToListAsync();

        return (totalRegistros, registros);
    }

    public async Task<UserRol> GetByIdAsync(int idUsuario, int idRol)
    {
        return (await _Context.Set<UserRol>().FirstOrDefaultAsync(p => (p.UsuarioId == idUsuario && p.RolId == idRol)))!;
    }

    public void Remove(UserRol entity)
    {
        _Context.Set<UserRol>().Remove(entity);
    }

    public void RemoveRange(IEnumerable<UserRol> entities)
    {
        _Context.Set<UserRol>().RemoveRange(entities);
    }

    public void Update(UserRol entity)
    {
        _Context.Set<UserRol>().Update(entity);
    }
}
