using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;

namespace FarmacorpPOS.Application.Interfaces;

public interface IProductoService
{
    Task RegistrarProductoAsync(
        string nombre,
        decimal costo,
        int stock,
        int idTipoProducto);
}
