using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FarmacorpPOS.Infrastructure.Persistence;

public class FarmacorpDbContext : DbContext
{
    public FarmacorpDbContext(
        DbContextOptions<FarmacorpDbContext> options)
        : base(options)
    {
    }

    public DbSet<TipoProducto> TiposProducto => Set<TipoProducto>();

    public DbSet<ExpProducto> Productos => Set<ExpProducto>();

    public DbSet<ErpProducto> ErpProductos => Set<ErpProducto>();

    public DbSet<Categoria> Categorias => Set<Categoria>();

    public DbSet<ProductoCategoria> ProductosCategorias => Set<ProductoCategoria>();

    public DbSet<CodigoBarra> CodigosBarra => Set<CodigoBarra>();

    public DbSet<VentaExpress> Ventas => Set<VentaExpress>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(FarmacorpDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
