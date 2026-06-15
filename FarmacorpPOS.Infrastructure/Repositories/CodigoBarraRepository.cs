using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Persistence;

namespace FarmacorpPOS.Infrastructure.Repositories;

public class CodigoBarraRepository
    : ICodigoBarraRepository
{
    private readonly FarmacorpDbContext _context;

    public CodigoBarraRepository(
        FarmacorpDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(
        CodigoBarra codigoBarra)
    {
        await _context.CodigosBarra
            .AddAsync(codigoBarra);
    }
}
