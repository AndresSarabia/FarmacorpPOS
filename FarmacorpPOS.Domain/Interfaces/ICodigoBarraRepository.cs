using System;
using System.Collections.Generic;
using System.Text;
using FarmacorpPOS.Domain.Entities;

namespace FarmacorpPOS.Domain.Interfaces;

public interface ICodigoBarraRepository
{
    Task AddAsync(CodigoBarra codigoBarra);
}
