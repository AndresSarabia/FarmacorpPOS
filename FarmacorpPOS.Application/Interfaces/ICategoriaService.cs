using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Application.Interfaces;

public interface ICategoriaService
{
    Task RegistrarCategoriaAsync(
        string descripcion,
        int? idCategoriaPadre);

    Task AsignarCategoriaProductoAsync(
        int idProducto,
        int idCategoria);
}
