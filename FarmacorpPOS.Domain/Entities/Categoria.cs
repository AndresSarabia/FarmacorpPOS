using FarmacorpPOS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FarmacorpPOS.Domain.Entities;

public class Categoria
{
    public int IdCategoria { get; set; }

    public string Descripcion { get; set; } = string.Empty;

    public bool Activo { get; set; }

    public int? IdCategoriaPadre { get; set; }

    public Categoria? CategoriaPadre { get; set; }

    public ICollection<Categoria> CategoriasHijas { get; set; }
        = new List<Categoria>();

    public ICollection<ProductoCategoria> Productos { get; set; }
        = new List<ProductoCategoria>();
}