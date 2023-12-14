using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {

        builder.ToTable("Producto");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("IdProducto")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.Nombre)
            .HasColumnName("Nombre")
            .HasColumnType("varchar")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Precio)
            .HasColumnName("Precio")
            .HasColumnType("double")
            .IsRequired();

        builder.Property(p => p.IdCategoriaFk)
            .HasColumnName("IdCategoriaFk")
            .HasColumnType("int")
            .IsRequired();
            
        builder.HasOne(p => p.CategoriaProductos)
            .WithMany(p => p.Productos)
            .HasForeignKey(p => p.IdCategoriaFk);

        builder.Property(p => p.Marca)
            .HasColumnName("Marca")
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.UrlImagen)
            .HasColumnName("UrlImagen")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(p => p.StockDisponible)
            .HasColumnName("StockDisponible")
            .HasColumnType("int")
            .IsRequired();
    }
}
