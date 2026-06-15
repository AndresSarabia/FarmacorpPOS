using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Entities;

public class CodigoBarra
{
    public int IdCodigoBarra { get; set; }

    public string UniqueCodigo { get; set; } = string.Empty;

    public bool Activo { get; set; }

    public int IdProducto { get; set; }

    public ExpProducto Producto { get; set; } = null!;
}
