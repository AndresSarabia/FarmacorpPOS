using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Application.Interfaces;
using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using FarmacorpPOS.Domain.Strategies;

namespace FarmacorpPOS.Application.Services;

public class VentaService : IVentaService
{
    private readonly IProductoRepository _productoRepository;
    private readonly IVentaRepository _ventaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDiscountStrategy _discountStrategy;
    private readonly IStockStrategy _stockStrategy;

    public VentaService(
        IProductoRepository productoRepository,
        IVentaRepository ventaRepository,
        IUnitOfWork unitOfWork,
        IDiscountStrategy discountStrategy,
        IStockStrategy stockStrategy)
    {
        _productoRepository = productoRepository;
        _ventaRepository = ventaRepository;
        _unitOfWork = unitOfWork;
        _discountStrategy = discountStrategy;
        _stockStrategy = stockStrategy;
    }

    public async Task<decimal> RegistrarVentaAsync(
        int idProducto,
        int cantidad,
        string cliente)
    {
        var producto =
            await _productoRepository.GetByIdAsync(idProducto);

        if (producto is null)
            throw new Exception("Producto no encontrado.");

        if (producto.ErpProducto is null)
            throw new Exception("Información ERP inexistente.");

        if (!_stockStrategy.CanSell(
                producto.ErpProducto.Stock,
                cantidad))
        {
            throw new Exception("Stock insuficiente.");
        }

        var subtotal = producto.Precio * cantidad;

        decimal descuento = 0;

        if (producto.Categorias.Count == 1)
        {
            descuento =
                _discountStrategy.CalculateDiscount(subtotal);
        }

        var total = subtotal - descuento;

        var venta = new VentaExpress
        {
            FechaVenta = DateTime.Now,
            Cliente = cliente,
            IdProducto = producto.IdProducto,
            UniqueCodigoProducto = producto.ErpProducto.UniqueCodigo,
            Cantidad = cantidad,
            Precio = producto.Precio,
            Descuento = descuento,
            Total = total
        };

        await _ventaRepository.AddAsync(venta);

        producto.ErpProducto.Stock -= cantidad;

        await _productoRepository.UpdateAsync(producto);

        await _unitOfWork.SaveChangesAsync();

        return total;
    }
}
