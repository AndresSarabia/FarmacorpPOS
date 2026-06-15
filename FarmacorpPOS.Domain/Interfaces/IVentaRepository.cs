using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;

namespace FarmacorpPOS.Domain.Interfaces;

public interface IVentaRepository
{
    Task AddAsync(VentaExpress venta);

    Task<List<VentaExpress>> GetAllAsync();
}
