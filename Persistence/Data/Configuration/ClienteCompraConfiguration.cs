using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;
public class ClienteCompraConfiguration : IEntityTypeConfiguration<ClienteCompra>
{
    public void Configure(EntityTypeBuilder<ClienteCompra> builder)
    {

        builder.ToTable("ClienteCompra");

        builder.Property(p => p.Id)
        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
        .HasColumnName("IdClienteCompra")
        .HasColumnType("int")
        .IsRequired();
        
        builder.Property(p => p.IdClienteFk)
            .HasColumnName("IdClienteFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Clientes)
            .WithMany(p => p.ClienteCompras)
            .HasForeignKey(p => p.IdClienteFk);

        builder.Property(p => p.IdCompraFk)
            .HasColumnName("IdCompraFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Compras)
            .WithMany(p => p.ClienteCompras)
            .HasForeignKey(p => p.IdCompraFk);

        builder.Property(p => p.FechaTransaccion)
            .HasColumnName("FechaTransaccion")
            .HasColumnType("DateTime")
            .IsRequired();

        builder.Property(p => p.ValorTotalTransaccion)
            .HasColumnName("ValorTotalTransaccion")
            .HasColumnType("double")
            .IsRequired();

        builder.Property(p => p.IdMetodoPagoFk)
            .HasColumnName("IdMetodoPagoFk")
            .HasColumnType("int")
            .IsRequired();

        builder.HasOne(p => p.Pagos)
            .WithMany(p => p.ClienteCompras)
            .HasForeignKey(p => p.IdMetodoPagoFk);

        builder.Property(p => p.DireccionCliente)
            .HasColumnName("DireccionCliente")
            .HasColumnType("varchar")
            .HasMaxLength(255)
            .IsRequired();
    }
}
