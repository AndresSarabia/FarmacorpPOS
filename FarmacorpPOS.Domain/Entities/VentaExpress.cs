using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Entities;

public class VentaExpress
{
    public int IdVenta { get; set; }

    public DateTime FechaVenta { get; set; }

    public string Cliente { get; set; } = string.Empty;

    public int IdProducto { get; set; }

    public string UniqueCodigoProducto { get; set; } = string.Empty;

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public decimal Descuento { get; set; }

    public decimal Total { get; set; }

    public ExpProducto Producto { get; set; } = null!;
}
