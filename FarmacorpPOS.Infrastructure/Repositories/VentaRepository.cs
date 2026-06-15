using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FarmacorpPOS.Infrastructure.Repositories;

public class VentaRepository : IVentaRepository
{
    private readonly FarmacorpDbContext _context;

    public VentaRepository(FarmacorpDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(VentaExpress venta)
    {
        await _context.Ventas.AddAsync(venta);
    }

    public async Task<List<VentaExpress>> GetAllAsync()
    {
        return await _context.Ventas
            .Include(x => x.Producto)
            .ToListAsync();
    }
}
