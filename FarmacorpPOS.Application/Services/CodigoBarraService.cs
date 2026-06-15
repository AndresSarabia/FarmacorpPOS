using FarmacorpPOS.Application.Interfaces;
using FarmacorpPOS.Application.Utilities;
using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Application.Services;

public class CodigoBarraService
    : ICodigoBarraService
{
    private readonly IProductoRepository _productoRepository;
    private readonly ICodigoBarraRepository _codigoBarraRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CodigoBarraService(
        IProductoRepository productoRepository,
        ICodigoBarraRepository codigoBarraRepository,
        IUnitOfWork unitOfWork)
    {
        _productoRepository = productoRepository;
        _codigoBarraRepository = codigoBarraRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task RegistrarCodigoBarraAsync(
        int idProducto)
    {
        var producto =
            await _productoRepository.GetByIdAsync(
                idProducto);

        if (producto is null)
            throw new Exception(
                "Producto no encontrado.");

        var codigoBarra = new CodigoBarra
        {
            IdProducto = idProducto,
            Activo = true,
            UniqueCodigo =
                UniqueCodeGenerator.Generate()
        };

        await _codigoBarraRepository
            .AddAsync(codigoBarra);

        await _unitOfWork.SaveChangesAsync();
    }
}
