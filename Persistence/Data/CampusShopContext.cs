using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Data
{
    public class CampusShopContext : DbContext
    {
        public CampusShopContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CarritoCompra> CarritoCompras { get; set; }
        public DbSet<CategoriaProducto> CategoriaProductos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteCompra> ClienteCompras { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleProducto> DetalleProductos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRol> UserRols { get; set; }
        public DbSet<User> Usuarios { get; set; }
        public DbSet<UserRol> UsuarioRoless { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
