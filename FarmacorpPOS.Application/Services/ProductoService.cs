using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Application.Interfaces;
using FarmacorpPOS.Application.Utilities;
using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Domain.Strategies;

namespace FarmacorpPOS.Application.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _productoRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPriceStrategy _priceStrategy;

    public ProductoService(
        IProductoRepository productoRepository,
        IUnitOfWork unitOfWork,
        IPriceStrategy priceStrategy)
    {
        _productoRepository = productoRepository;
        _unitOfWork = unitOfWork;
        _priceStrategy = priceStrategy;
    }

    public async Task RegistrarProductoAsync(
        string nombre,
        decimal costo,
        int stock,
        int idTipoProducto)
    {
        var precio =
            _priceStrategy.CalculatePrice(costo);

        var producto = new ExpProducto
        {
            Nombre = nombre,
            Precio = precio,
            Activo = true,
            IdTipoProducto = idTipoProducto
        };

        producto.ErpProducto = new ErpProducto
        {
            Costo = costo,
            Stock = stock,
            UniqueCodigo = UniqueCodeGenerator.Generate(),
            FechaRegistro = DateTime.Now
        };

        await _productoRepository.AddAsync(producto);

        await _unitOfWork.SaveChangesAsync();
    }
}
