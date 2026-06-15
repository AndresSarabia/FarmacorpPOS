using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;

namespace FarmacorpPOS.Domain.Interfaces;

public interface IProductoRepository
{
    Task<ExpProducto?> GetByIdAsync(int id);

    Task AddAsync(ExpProducto producto);

    Task UpdateAsync(ExpProducto producto);

    Task<List<ExpProducto>> GetAllAsync();
}
