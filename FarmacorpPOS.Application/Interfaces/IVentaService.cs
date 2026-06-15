using System;
using System.Collections.Generic;
using System.Text;
namespace FarmacorpPOS.Application.Interfaces;

public interface IVentaService
{
    Task<decimal> RegistrarVentaAsync(
        int idProducto,
        int cantidad,
        string cliente);
}
