using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistencia.Data;

namespace Application.Repository;
public class UsuarioRepository : GenericRepository<User>, IUser
{

    private readonly CampusShopContext _Context;
    public UsuarioRepository(CampusShopContext context) : base(context)
    {
        _Context = context;
    }

    public async Task<User> GetByRefreshTokenAsync(string refreshToken)
    {
        return (await _Context.Set<User>()
                            .Include(u => u.Roles)
                            .Include(u => u.RefreshTokens)
                            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken)))!;
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return (await _Context.Set<User>()
                            .Include(u => u.Roles)
                            .FirstOrDefaultAsync(u => u.Username!.ToLower() == username.ToLower()))!;
    }
    public async Task<User> GetUserByEmailAsync(string email)
    {
        return await _Context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
}
