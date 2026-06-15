using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmacorpPOS.Infrastructure.Persistence.Configurations;

public class VentaExpressConfiguration : IEntityTypeConfiguration<VentaExpress>
{
    public void Configure(EntityTypeBuilder<VentaExpress> builder)
    {
        builder.ToTable("VentaExpress");

        builder.HasKey(x => x.IdVenta);

        builder.Property(x => x.Cliente)
            .HasMaxLength(200);

        builder.Property(x => x.UniqueCodigoProducto)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Precio)
            .HasPrecision(18, 2);

        builder.Property(x => x.Descuento)
            .HasPrecision(18, 2);

        builder.Property(x => x.Total)
            .HasPrecision(18, 2);

        builder.HasOne(x => x.Producto)
            .WithMany(x => x.Ventas)
            .HasForeignKey(x => x.IdProducto);
    }
}
