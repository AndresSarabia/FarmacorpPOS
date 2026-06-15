using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarmacorpPOS.Infrastructure.Persistence.Configurations;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.ToTable("Categoria");

        builder.HasKey(x => x.IdCategoria);

        builder.Property(x => x.Descripcion)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(x => x.CategoriaPadre)
            .WithMany(x => x.CategoriasHijas)
            .HasForeignKey(x => x.IdCategoriaPadre)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
