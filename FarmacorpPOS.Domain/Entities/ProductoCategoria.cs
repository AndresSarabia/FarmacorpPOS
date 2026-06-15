using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Entities;

public class ProductoCategoria
{
    public int IdDetalle { get; set; }

    public int IdProducto { get; set; }

    public int IdCategoria { get; set; }

    public DateTime FechaCreacion { get; set; }

    public ExpProducto Producto { get; set; } = null!;

    public Categoria Categoria { get; set; } = null!;
}
