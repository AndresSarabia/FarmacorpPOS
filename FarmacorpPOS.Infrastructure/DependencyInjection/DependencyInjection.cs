using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Infrastructure.Persistence;
using FarmacorpPOS.Infrastructure.Repositories;
using FarmacorpPOS.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FarmacorpPOS.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        services.AddDbContext<FarmacorpDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IProductoRepository, ProductoRepository>();

        services.AddScoped<ICategoriaRepository, CategoriaRepository>();

        services.AddScoped<IVentaRepository, VentaRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

        return services;
    }
}
