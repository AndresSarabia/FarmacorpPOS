using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FarmacorpPOS.Infrastructure.Persistence;

public class FarmacorpDbContextFactory
    : IDesignTimeDbContextFactory<FarmacorpDbContext>
{
    public FarmacorpDbContext CreateDbContext(
        string[] args)
    {
        var optionsBuilder =
            new DbContextOptionsBuilder<FarmacorpDbContext>();

        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\MSSQLLocalDB;Database=FarmacorpPOSDb;Trusted_Connection=True;MultipleActiveResultSets=true");

        return new FarmacorpDbContext(
            optionsBuilder.Options);
    }
}
