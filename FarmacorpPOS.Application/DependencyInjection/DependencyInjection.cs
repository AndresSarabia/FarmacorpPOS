using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Application.Interfaces;
using FarmacorpPOS.Application.Services;
using FarmacorpPOS.Domain.Strategies;
using Microsoft.Extensions.DependencyInjection;

namespace FarmacorpPOS.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IProductoService, ProductoService>();

        services.AddScoped<IVentaService, VentaService>();

        services.AddScoped<IPriceStrategy, BasePriceStrategy>();

        services.AddScoped<IDiscountStrategy, BaseDiscountStrategy>();

        services.AddScoped<IStockStrategy, BaseStockStrategy>();

        return services;
    }
}
