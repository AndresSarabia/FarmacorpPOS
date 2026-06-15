using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmacorpPOS.Infrastructure.Persistence.Configurations;

public class ExpProductoConfiguration : IEntityTypeConfiguration<ExpProducto>
{
    public void Configure(EntityTypeBuilder<ExpProducto> builder)
    {
        builder.ToTable("ExpProducto");

        builder.HasKey(x => x.IdProducto);

        builder.Property(x => x.Nombre)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.Precio)
            .HasPrecision(18, 2);

        builder.HasOne(x => x.TipoProducto)
            .WithMany(x => x.Productos)
            .HasForeignKey(x => x.IdTipoProducto);
    }
}
