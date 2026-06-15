using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmacorpPOS.Infrastructure.Persistence.Configurations;

public class ProductoCategoriaConfiguration : IEntityTypeConfiguration<ProductoCategoria>
{
    public void Configure(EntityTypeBuilder<ProductoCategoria> builder)
    {
        builder.ToTable("ProductoCategoria");

        builder.HasKey(x => x.IdDetalle);

        builder.HasOne(x => x.Producto)
            .WithMany(x => x.Categorias)
            .HasForeignKey(x => x.IdProducto);

        builder.HasOne(x => x.Categoria)
            .WithMany(x => x.Productos)
            .HasForeignKey(x => x.IdCategoria);
    }
}
