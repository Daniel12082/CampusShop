﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Data;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(CampusShopContext))]
    partial class CampusShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.CarritoCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdCarritoCompra")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadCadaProductoEnCarrito")
                        .HasColumnType("int")
                        .HasColumnName("CantidadCadaProductoEnCarrito");

                    b.Property<int>("IdClienteFk")
                        .HasColumnType("int")
                        .HasColumnName("IdClienteFk");

                    b.Property<int>("IdProductoFk")
                        .HasColumnType("int")
                        .HasColumnName("IdProductoFk");

                    b.Property<double>("PrecioTotalCarrito")
                        .HasColumnType("double")
                        .HasColumnName("PrecioTotalCarrito");

                    b.Property<string>("ProductoEnCarrito")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("ProductoEnCarrito");

                    b.HasKey("Id");

                    b.HasIndex("IdClienteFk");

                    b.HasIndex("IdProductoFk");

                    b.ToTable("CarritoCompra", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CategoriaProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdCategoriaProducto")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("CategoriaProducto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdCliente")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellidos")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Apellidos");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("Direccion");

                    b.Property<string>("Nombres")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombres");

                    b.Property<double>("NroContacto")
                        .HasColumnType("double")
                        .HasColumnName("NroContacto");

                    b.HasKey("Id");

                    b.ToTable("Cliente", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.ClienteCompra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdClienteCompra")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DireccionCliente")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("DireccionCliente");

                    b.Property<DateTime>("FechaTransaccion")
                        .HasColumnType("DateTime")
                        .HasColumnName("FechaTransaccion");

                    b.Property<int>("IdClienteFk")
                        .HasColumnType("int")
                        .HasColumnName("IdClienteFk");

                    b.Property<int>("IdCompraFk")
                        .HasColumnType("int")
                        .HasColumnName("IdCompraFk");

                    b.Property<int>("IdMetodoPagoFk")
                        .HasColumnType("int")
                        .HasColumnName("IdMetodoPagoFk");

                    b.Property<double>("ValorTotalTransaccion")
                        .HasColumnType("double")
                        .HasColumnName("ValorTotalTransaccion");

                    b.HasKey("Id");

                    b.HasIndex("IdClienteFk");

                    b.HasIndex("IdCompraFk");

                    b.HasIndex("IdMetodoPagoFk");

                    b.ToTable("ClienteCompra", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Compra", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdCompra")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cantidad")
                        .HasColumnType("int")
                        .HasColumnName("Cantidad");

                    b.Property<int>("IdProductoFk")
                        .HasColumnType("int")
                        .HasColumnName("IdProductoFk");

                    b.Property<double>("ValorUnitUSD")
                        .HasColumnType("double")
                        .HasColumnName("ValorUnitUSD");

                    b.HasKey("Id");

                    b.HasIndex("IdProductoFk");

                    b.ToTable("Compra", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.DetalleProducto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdDetalleProducto")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DetallesAdicionalesProducto")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("DetallesAdicionalesProducto");

                    b.Property<int>("IdProductoFk")
                        .HasColumnType("int")
                        .HasColumnName("IdProductoFk");

                    b.HasKey("Id");

                    b.HasIndex("IdProductoFk");

                    b.ToTable("DetalleProducto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdPago")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Pago", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdProducto")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCategoriaFk")
                        .HasColumnType("int")
                        .HasColumnName("IdCategoriaFk");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("Marca");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar")
                        .HasColumnName("Nombre");

                    b.Property<double>("Precio")
                        .HasColumnType("double")
                        .HasColumnName("Precio");

                    b.Property<int>("StockDisponible")
                        .HasColumnType("int")
                        .HasColumnName("StockDisponible");

                    b.Property<string>("UrlImagen")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("UrlImagen");

                    b.HasKey("Id");

                    b.HasIndex("IdCategoriaFk");

                    b.ToTable("Producto", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Revoked")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("RefreshToken", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("IdRol")
                        .HasAnnotation("MySqlValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("NombreRol");

                    b.HasKey("Id");

                    b.ToTable("Rol", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Administrador"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Gerente"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Empleado"
                        },
                        new
                        {
                            Id = 4,
                            Nombre = "Persona"
                        });
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("password");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "RolId");

                    b.HasIndex("RolId");

                    b.ToTable("userRol", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.CarritoCompra", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Clientes")
                        .WithMany("CarritoCompras")
                        .HasForeignKey("IdClienteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Producto", "Productos")
                        .WithMany("CarritoCompras")
                        .HasForeignKey("IdProductoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Domain.Entities.ClienteCompra", b =>
                {
                    b.HasOne("Domain.Entities.Cliente", "Clientes")
                        .WithMany("ClienteCompras")
                        .HasForeignKey("IdClienteFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Compra", "Compras")
                        .WithMany("ClienteCompras")
                        .HasForeignKey("IdCompraFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Pago", "Pagos")
                        .WithMany("ClienteCompras")
                        .HasForeignKey("IdMetodoPagoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Clientes");

                    b.Navigation("Compras");

                    b.Navigation("Pagos");
                });

            modelBuilder.Entity("Domain.Entities.Compra", b =>
                {
                    b.HasOne("Domain.Entities.Producto", "Productos")
                        .WithMany("Compras")
                        .HasForeignKey("IdProductoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Domain.Entities.DetalleProducto", b =>
                {
                    b.HasOne("Domain.Entities.Producto", "Productos")
                        .WithMany("DetalleProductos")
                        .HasForeignKey("IdProductoFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.HasOne("Domain.Entities.CategoriaProducto", "CategoriaProductos")
                        .WithMany("Productos")
                        .HasForeignKey("IdCategoriaFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CategoriaProductos");
                });

            modelBuilder.Entity("Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Domain.Entities.User", "Usuario")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.UserRol", b =>
                {
                    b.HasOne("Domain.Entities.Rol", "Rol")
                        .WithMany("UsuarioRoles")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.User", "Usuario")
                        .WithMany("UsersRols")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.CategoriaProducto", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("Domain.Entities.Cliente", b =>
                {
                    b.Navigation("CarritoCompras");

                    b.Navigation("ClienteCompras");
                });

            modelBuilder.Entity("Domain.Entities.Compra", b =>
                {
                    b.Navigation("ClienteCompras");
                });

            modelBuilder.Entity("Domain.Entities.Pago", b =>
                {
                    b.Navigation("ClienteCompras");
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Navigation("CarritoCompras");

                    b.Navigation("Compras");

                    b.Navigation("DetalleProductos");
                });

            modelBuilder.Entity("Domain.Entities.Rol", b =>
                {
                    b.Navigation("UsuarioRoles");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("UsersRols");
                });
#pragma warning restore 612, 618
        }
    }
}
