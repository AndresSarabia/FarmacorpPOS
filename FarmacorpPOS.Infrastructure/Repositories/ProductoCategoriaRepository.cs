using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Persistence;

namespace FarmacorpPOS.Infrastructure.Repositories;

public class ProductoCategoriaRepository
    : IProductoCategoriaRepository
{
    private readonly FarmacorpDbContext _context;

    public ProductoCategoriaRepository(
        FarmacorpDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        ProductoCategoria productoCategoria)
    {
        await _context.ProductosCategorias
            .AddAsync(productoCategoria);
    }
}
