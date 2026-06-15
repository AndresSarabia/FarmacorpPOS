using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Application.Interfaces;
using FarmacorpPOS.Domain.Entities;
using FarmacorpPOS.Domain.Interfaces;

namespace FarmacorpPOS.Application.Services;

public class CategoriaService : ICategoriaService
{
    private readonly ICategoriaRepository _categoriaRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProductoRepository _productoRepository;
    private readonly IProductoCategoriaRepository _productoCategoriaRepository;

    public CategoriaService(
        ICategoriaRepository categoriaRepository,
        IProductoRepository productoRepository,
        IProductoCategoriaRepository productoCategoriaRepository,
        IUnitOfWork unitOfWork)
    {
        _categoriaRepository = categoriaRepository;
        _productoRepository = productoRepository;
        _productoCategoriaRepository = productoCategoriaRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task RegistrarCategoriaAsync(
        string descripcion,
        int? idCategoriaPadre)
    {
        var categoria = new Categoria
        {
            Descripcion = descripcion,
            Activo = true,
            IdCategoriaPadre = idCategoriaPadre
        };

        await _categoriaRepository.AddAsync(categoria);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AsignarCategoriaProductoAsync(
        int idProducto,
        int idCategoria)
    {
        var producto =
            await _productoRepository.GetByIdAsync(idProducto);

        if (producto is null)
            throw new Exception("Producto no encontrado.");

        var categoria =
            await _categoriaRepository.GetByIdAsync(idCategoria);

        if (categoria is null)
            throw new Exception("Categoría no encontrada.");

        var relacion = new ProductoCategoria
        {
            IdProducto = idProducto,
            IdCategoria = idCategoria,
            FechaCreacion = DateTime.Now
        };

        await _productoCategoriaRepository
            .AddAsync(relacion);

        await _unitOfWork.SaveChangesAsync();
    }
}
