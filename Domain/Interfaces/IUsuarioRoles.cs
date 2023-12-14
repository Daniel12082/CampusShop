using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interfaces;
public interface IUsuarioRoles{

    Task<UserRol> GetByIdAsync(int idUsua, int idRol);
    Task<IEnumerable<UserRol>> GetAllAsync();
    IEnumerable<UserRol> Find(Expression<Func<UserRol, bool>> expression);
    Task<(int totalRegistros, IEnumerable<UserRol> registros)> GetAllAsync(int pageIndex, int pageSize, string search);
    void Add(UserRol entity);
    void AddRange(IEnumerable<UserRol> entities);
    void Remove(UserRol entity);
    void RemoveRange(IEnumerable<UserRol> entities);
    void Update(UserRol entity);
      
}