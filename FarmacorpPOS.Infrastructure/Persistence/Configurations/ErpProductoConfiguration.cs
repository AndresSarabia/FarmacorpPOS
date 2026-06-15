using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmacorpPOS.Infrastructure.Persistence.Configurations;

public class ErpProductoConfiguration : IEntityTypeConfiguration<ErpProducto>
{
    public void Configure(EntityTypeBuilder<ErpProducto> builder)
    {
        builder.ToTable("ErpProducto");

        builder.HasKey(x => x.IdProducto);

        builder.Property(x => x.Costo)
            .HasPrecision(18, 2);

        builder.Property(x => x.UniqueCodigo)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.UniqueCodigo)
            .IsUnique();

        builder.HasOne(x => x.Producto)
            .WithOne(x => x.ErpProducto)
            .HasForeignKey<ErpProducto>(x => x.IdProducto);
    }
}
