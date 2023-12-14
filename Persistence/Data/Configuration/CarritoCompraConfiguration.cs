using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class CarritoCompraConfiguration : IEntityTypeConfiguration<CarritoCompra>
{
    public void Configure(EntityTypeBuilder<CarritoCompra> builder)
    {

        builder.ToTable("CarritoCompra");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("IdCarritoCompra")
        .HasColumnType("int")
        .IsRequired();

        builder.Property(p => p.IdClienteFk)
            .HasColumnName("IdClienteFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Clientes)
            .WithMany(p => p.CarritoCompras)
            .HasForeignKey(p => p.IdClienteFk);

        builder.Property(p => p.IdProductoFk)
            .HasColumnName("IdProductoFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Productos)
            .WithMany(p => p.CarritoCompras)
            .HasForeignKey(p => p.IdProductoFk);

        builder.Property(p => p.ProductoEnCarrito)
            .HasColumnName("ProductoEnCarrito")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.CantidadCadaProductoEnCarrito)
            .HasColumnName("CantidadCadaProductoEnCarrito")
            .HasColumnType("int")
            .IsRequired();

        builder.Property(p => p.PrecioTotalCarrito)
            .HasColumnName("PrecioTotalCarrito")
            .HasColumnType("double")
            .IsRequired();
    }
}
