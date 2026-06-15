using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmacorpPOS.Infrastructure.Persistence.Configurations;

public class CodigoBarraConfiguration : IEntityTypeConfiguration<CodigoBarra>
{
    public void Configure(EntityTypeBuilder<CodigoBarra> builder)
    {
        builder.ToTable("CodigoBarra");

        builder.HasKey(x => x.IdCodigoBarra);

        builder.Property(x => x.UniqueCodigo)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.UniqueCodigo)
            .IsUnique();

        builder.HasOne(x => x.Producto)
            .WithMany(x => x.CodigosBarra)
            .HasForeignKey(x => x.IdProducto);
    }
}
