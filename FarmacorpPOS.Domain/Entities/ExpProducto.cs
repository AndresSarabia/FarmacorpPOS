using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Entities;

public class ExpProducto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public decimal Precio { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaVencimiento { get; set; }

    public string? Observaciones { get; set; }

    public int IdTipoProducto { get; set; }

    public TipoProducto TipoProducto { get; set; } = null!;

    public ErpProducto? ErpProducto { get; set; }

    public ICollection<ProductoCategoria> Categorias { get; set; }
        = new List<ProductoCategoria>();

    public ICollection<CodigoBarra> CodigosBarra { get; set; }
    = new List<CodigoBarra>();

    public ICollection<VentaExpress> Ventas { get; set; }
    = new List<VentaExpress>();
}
