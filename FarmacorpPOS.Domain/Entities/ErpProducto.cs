using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Entities;

public class ErpProducto
{
    public int IdProducto { get; set; }

    public decimal Costo { get; set; }

    public string UniqueCodigo { get; set; } = string.Empty;

    public DateTime FechaRegistro { get; set; }

    public int Stock { get; set; }

    public ExpProducto Producto { get; set; } = null!;
}
