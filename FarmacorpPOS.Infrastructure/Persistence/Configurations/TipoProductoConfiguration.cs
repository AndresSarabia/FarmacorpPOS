using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmacorpPOS.Infrastructure.Persistence.Configurations;

public class TipoProductoConfiguration : IEntityTypeConfiguration<TipoProducto>
{
    public void Configure(EntityTypeBuilder<TipoProducto> builder)
    {
        builder.ToTable("TipoProducto");

        builder.HasKey(x => x.IdTipoProducto);

        builder.Property(x => x.Descripcion)
            .HasMaxLength(100)
            .IsRequired();
    }
}
