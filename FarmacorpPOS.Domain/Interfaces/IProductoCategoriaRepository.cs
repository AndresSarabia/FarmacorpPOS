using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;

namespace FarmacorpPOS.Domain.Interfaces;

public interface IProductoCategoriaRepository
{
    Task AddAsync(ProductoCategoria productoCategoria);
}
