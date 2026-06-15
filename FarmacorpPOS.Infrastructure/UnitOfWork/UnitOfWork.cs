using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Persistence;

namespace FarmacorpPOS.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly FarmacorpDbContext _context;

    public UnitOfWork(FarmacorpDbContext context)
    {
        _context = context;
    }

    public async Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
