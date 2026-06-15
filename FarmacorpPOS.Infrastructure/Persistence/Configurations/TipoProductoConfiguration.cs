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

        builder.HasData(
            new TipoProducto
            {
                IdTipoProducto = 1,
                Descripcion = "Medicamento"
            },
            new TipoProducto
            {
                IdTipoProducto = 2,
                Descripcion = "Cosmético"
            },
            new TipoProducto
            {
                IdTipoProducto = 3,
                Descripcion = "Higiene"
            },
            new TipoProducto
            {
                IdTipoProducto = 4,
                Descripcion = "Suplemento"
            }
        );
    }
}
