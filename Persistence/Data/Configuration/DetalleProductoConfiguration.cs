using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class DetalleProductoConfiguration : IEntityTypeConfiguration<DetalleProducto>
{
    public void Configure(EntityTypeBuilder<DetalleProducto> builder)
    {

        builder.ToTable("DetalleProducto");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("IdDetalleProducto")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.IdProductoFk)
            .HasColumnName("IdProductoFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Productos)
            .WithMany(p => p.DetalleProductos)
            .HasForeignKey(p => p.IdProductoFk);

        builder.Property(p => p.DetallesAdicionalesProducto)
            .HasColumnName("DetallesAdicionalesProducto")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();
    }
}
