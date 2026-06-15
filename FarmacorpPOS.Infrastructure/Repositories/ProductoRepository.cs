using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FarmacorpPOS.Infrastructure.Repositories;

public class ProductoRepository : IProductoRepository
{
    private readonly FarmacorpDbContext _context;

    public ProductoRepository(FarmacorpDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(ExpProducto producto)
    {
        await _context.Productos.AddAsync(producto);
    }

    public async Task<List<ExpProducto>> GetAllAsync()
    {
        return await _context.Productos
            .Include(x => x.ErpProducto)
            .Include(x => x.TipoProducto)
            .ToListAsync();
    }

    public async Task<ExpProducto?> GetByIdAsync(int id)
    {
        return await _context.Productos
            .Include(x => x.ErpProducto)
            .Include(x => x.TipoProducto)
            .Include(x => x.Categorias)
            .FirstOrDefaultAsync(x => x.IdProducto == id);
    }

    public Task UpdateAsync(ExpProducto producto)
    {
        _context.Productos.Update(producto);

        return Task.CompletedTask;
    }
}
